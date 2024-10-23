using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarterKit.Models;
using StarterKit.Services;

//comment
namespace StarterKit.Controllers;

    [Route("api/v1/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationRequest reservationRequest)
        {
            // Log the received reservation request
            _logger.LogInformation("Received reservation request: {@ReservationRequest}", reservationRequest);

            // Check if the request is valid
            if (reservationRequest == null || !ModelState.IsValid)
            {
                _logger.LogWarning("Invalid reservation request: {ModelState}", ModelState);
                return BadRequest("Invalid request.");
            }

            // Fetch the show date
            var showDate = _reservationService.GetTheatreShowDateById(reservationRequest.TheatreShowDateId);
            if (showDate == null)
            {
                _logger.LogWarning("Show date not found for ID: {TheatreShowDateId}", reservationRequest.TheatreShowDateId);
                return NotFound("Show date not found.");
            }

            // Check if the show date is in the future
            if (showDate.DateAndTime <= DateTime.Now)
            {
                _logger.LogWarning("Attempt to reserve tickets for a past show: {ShowDate}", showDate.DateAndTime);
                return BadRequest("You cannot reserve tickets for a past show.");
            }

            // Get total reserved tickets for the show date
            int totalReservedTickets = _reservationService.GetTotalReservedTicketsForShowDate(reservationRequest.TheatreShowDateId);
            _logger.LogInformation("Total reserved tickets for show date ID {TheatreShowDateId}: {TotalReservedTickets}", reservationRequest.TheatreShowDateId, totalReservedTickets);

            // Calculate available tickets
            int availableTickets = (showDate.TheatreShow?.Venue?.Capacity ?? 0) - totalReservedTickets;
            _logger.LogInformation("Available tickets for show date ID {TheatreShowDateId}: {AvailableTickets}", reservationRequest.TheatreShowDateId, availableTickets);

            // Check if enough tickets are available
            if (availableTickets < reservationRequest.AmountOfTickets)
            {
                _logger.LogWarning("Not enough tickets available. Requested: {RequestedTickets}, Available: {AvailableTickets}", reservationRequest.AmountOfTickets, availableTickets);
                return BadRequest($"Not enough tickets available. Only {availableTickets} left.");
            }

            // Calculate total price
            double totalPrice = reservationRequest.AmountOfTickets * showDate.TheatreShow!.Price;
            _logger.LogInformation("Total price calculated: {TotalPrice}", totalPrice);

            // Create a new reservation object
            var reservation = new Reservation
            {
                AmountOfTickets = reservationRequest.AmountOfTickets,
                Customer = new Customer
                {
                    FirstName = reservationRequest.FirstName,
                    LastName = reservationRequest.LastName,
                    Email = reservationRequest.Email
                },
                TheatreShowDate = showDate,
                Used = false
            };

            // Save the reservation
            _reservationService.CreateReservation(reservation);
            _logger.LogInformation("Reservation created successfully for {FirstName} {LastName}.", reservationRequest.FirstName, reservationRequest.LastName);

            return Ok(new
            {
                Message = "Reservation successful!",
                TotalPrice = totalPrice
            });
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

