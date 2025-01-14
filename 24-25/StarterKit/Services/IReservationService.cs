using StarterKit.Models;
//giv

namespace StarterKit.Services
{
    public interface IReservationService
    {
        TheatreShowDate? GetTheatreShowDateById(int theatreShowDateId);
        void CreateReservation(Reservation reservation);
        int GetTotalReservedTicketsForShowDate(int theatreShowDateId);
        IEnumerable<Reservation> GetReservations();
    }
}
