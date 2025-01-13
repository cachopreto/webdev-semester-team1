using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using StarterKit.Models;
using StarterKit.Services;

namespace StarterKit.Controllers;

// Define the route for the Reservation API
[Route("api/v1/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService; // Service for reservation-related operations
    private readonly ILogger<ReservationController> _logger; // Logger for logging actions and errors
    private readonly DatabaseContext _context; // Database context to interact with the database

    // Constructor that initializes the dependencies
    public ReservationController(
        IReservationService reservationService, 
        ILogger<ReservationController> logger,
        DatabaseContext context)
    {
        _reservationService = reservationService;
        _logger = logger;
        _context = context;
    }

    // Endpoint to get the show date details by ID
    [HttpGet("showdate/{id}")]
    public IActionResult GetShowDate(int id)
    {
        // Fetch show date by ID using the service
        var showDate = _reservationService.GetTheatreShowDateById(id);
        if (showDate == null)
        {
            return NotFound("Show date not found."); // If no show date is found, return 404
        }

        // Return the show date details along with related information like title, price, and venue capacity
        return Ok(new {
            theatreShowDateId = showDate.TheatreShowDateId,
            showId = showDate.TheatreShow!.TheatreShowId,
            title = showDate.TheatreShow.Title,
            dateAndTime = showDate.DateAndTime,
            price = showDate.TheatreShow.Price,
            venue = new {
                capacity = showDate.TheatreShow.Venue!.Capacity
            }
        });
    }

    // Endpoint to get the total number of reserved tickets for a specific show date
    [HttpGet("count/{showDateId}")]
    public IActionResult GetReservedTicketsCount(int showDateId)
    {
        // Get the total count of reserved tickets for the given show date ID
        var count = _reservationService.GetTotalReservedTicketsForShowDate(showDateId);
        return Ok(new { reservedTickets = count }); // Return the count in a response
    }

    // Endpoint to fetch all available shows with their details
    [HttpGet("shows")]
    public IActionResult GetAllShows()
    {
        try
        {
            // Log the request for fetching all shows
            _logger.LogInformation("Fetching all shows from database");

            // Get the count of all shows in the database
            var showCount = _context.TheatreShow.Count();
            _logger.LogInformation($"Found {showCount} shows");

            // Fetch all shows along with their related dates and venue details
            var shows = _context.TheatreShow
                .Include(s => s.theatreShowDates) // Include related show dates
                .Include(s => s.Venue) // Include related venue
                .Select(s => new
                {
                    showId = s.TheatreShowId,
                    title = s.Title,
                    description = s.Description,
                    price = s.Price,
                    venue = new
                    {
                        name = s.Venue!.Name,
                        capacity = s.Venue.Capacity
                    },
                    dates = s.theatreShowDates!.Select(d => new
                    {
                        id = d.TheatreShowDateId,
                        dateAndTime = d.DateAndTime
                    })
                })
                .ToList(); // Execute the query and retrieve the data

            // Return the shows data as a response
            return Ok(shows);
        }
        catch (Exception ex)
        {
            // If there's an error, log it and return a 500 internal server error
            _logger.LogError(ex, "Error fetching shows from database");
            return StatusCode(500, "An error occurred while fetching shows");
        }
    }

    // Endpoint to create a new reservation
    [HttpPost]
    public IActionResult CreateReservation([FromBody] ReservationRequest reservationRequest)
    {
        // Log the received reservation request
        _logger.LogInformation("Received reservation request: {@ReservationRequest}", reservationRequest);

        // Validate the reservation request
        if (reservationRequest == null || !ModelState.IsValid)
        {
            _logger.LogWarning("Invalid reservation request: {ModelState}", ModelState);
            return BadRequest("Invalid request."); // Return bad request if the request is invalid
        }

        // Fetch the show date associated with the reservation request
        var showDate = _reservationService.GetTheatreShowDateById(reservationRequest.TheatreShowDateId);
        if (showDate == null)
        {
            _logger.LogWarning("Show date not found for ID: {TheatreShowDateId}", reservationRequest.TheatreShowDateId);
            return NotFound("Show date not found."); // Return 404 if the show date is not found
        }

        // Check if the show date is in the future
        if (showDate.DateAndTime <= DateTime.Now)
        {
            _logger.LogWarning("Attempt to reserve tickets for a past show: {ShowDate}", showDate.DateAndTime);
            return BadRequest("You cannot reserve tickets for a past show."); // Return bad request if the show date is in the past
        }

        // Get the total number of reserved tickets for the show date
        int totalReservedTickets = _reservationService.GetTotalReservedTicketsForShowDate(reservationRequest.TheatreShowDateId);
        _logger.LogInformation("Total reserved tickets for show date ID {TheatreShowDateId}: {TotalReservedTickets}", reservationRequest.TheatreShowDateId, totalReservedTickets);

        // Calculate the available tickets based on the venue's capacity and already reserved tickets
        int availableTickets = (showDate.TheatreShow?.Venue?.Capacity ?? 0) - totalReservedTickets;
        _logger.LogInformation("Available tickets for show date ID {TheatreShowDateId}: {AvailableTickets}", reservationRequest.TheatreShowDateId, availableTickets);

        // Check if enough tickets are available for the reservation
        if (availableTickets < reservationRequest.AmountOfTickets)
        {
            _logger.LogWarning("Not enough tickets available. Requested: {RequestedTickets}, Available: {AvailableTickets}", reservationRequest.AmountOfTickets, availableTickets);
            return BadRequest($"Not enough tickets available. Only {availableTickets} left."); // Return bad request if there are not enough tickets
        }

        // Calculate the total price for the reservation based on the number of tickets requested
        double totalPrice = reservationRequest.AmountOfTickets * showDate.TheatreShow!.Price;
        _logger.LogInformation("Total price calculated: {TotalPrice}", totalPrice);

        try
        {
            // Create a new Reservation object with the details from the request
            var reservation = new Reservation
            {
                AmountOfTickets = reservationRequest.AmountOfTickets,
                Customer = new Customer
                {
                    FirstName = reservationRequest.FirstName,
                    LastName = reservationRequest.LastName,
                    Email = reservationRequest.Email
                },
                TheatreShowDateId = showDate.TheatreShowDateId,
                Used = false // Mark reservation as not used
            };

            // Save the reservation using the reservation service
            _reservationService.CreateReservation(reservation);
            _logger.LogInformation("Reservation created successfully for {FirstName} {LastName}.", reservationRequest.FirstName, reservationRequest.LastName);

            // Return success response with a message and total price
            return Ok(new
            {
                Message = "Reservation successful!",
                TotalPrice = totalPrice
            });
        }
        catch (Exception ex)
        {
            // If an error occurs during reservation creation, log it and return a 500 error
            _logger.LogError(ex, "Error creating reservation");
            return StatusCode(500, "An error occurred while creating the reservation");
        }
    }
}

// DTO for handling incoming reservation requests
public class ReservationRequest
{
    public required string FirstName { get; set; } 
    public required string LastName { get; set; } 
    public required string Email { get; set; } 
    public int TheatreShowDateId { get; set; } 
    public int AmountOfTickets { get; set; } 
}
