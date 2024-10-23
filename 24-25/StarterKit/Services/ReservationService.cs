using StarterKit.Models;
using Microsoft.EntityFrameworkCore;

namespace StarterKit.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DatabaseContext _context;  // Using DatabaseContext for database access

        public ReservationService(DatabaseContext context)
        {
            _context = context;  // Inject the DatabaseContext through the constructor
        }

        // Fetches TheatreShowDate by ID
        public TheatreShowDate? GetTheatreShowDateById(int theatreShowDateId)
        {
            return _context.TheatreShowDate
                           .Include(tsd => tsd.TheatreShow)   // Include the related TheatreShow
                           .ThenInclude(ts => ts.Venue)       // Include the related Venue
                           .FirstOrDefault(t => t.TheatreShowDateId == theatreShowDateId);
        }

        // Saves the reservation to the database
        public void CreateReservation(Reservation reservation)
        {
            _context.Reservation.Add(reservation);  // Add reservation to the database
            _context.SaveChanges();  // Commit the changes
        }

        // Gets total reserved tickets for a specific show date
        public int GetTotalReservedTicketsForShowDate(int theatreShowDateId)
        {
            return _context.Reservation
                           .Where(r => r.TheatreShowDate != null && r.TheatreShowDate.TheatreShowDateId == theatreShowDateId)
                           .Sum(r => r.AmountOfTickets);
        }
    }
}
