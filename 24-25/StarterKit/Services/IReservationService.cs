using StarterKit.Models;


namespace StarterKit.Services
{
    public interface IReservationService
    {
        TheatreShowDate? GetTheatreShowDateById(int theatreShowDateId);
        void CreateReservation(Reservation reservation);
        int GetTotalReservedTicketsForShowDate(int theatreShowDateId);
    }
}
