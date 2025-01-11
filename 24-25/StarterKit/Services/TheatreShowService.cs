using Microsoft.EntityFrameworkCore;
using StarterKit.Models;

namespace StarterKit.Services;

public class TheatreShowService
{
    private readonly DatabaseContext _context;

    public TheatreShowService(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<TheatreShow> GetAllTheatreShows()
    {
        return _context.TheatreShow.ToList();
    }

    public TheatreShow GetTheatreShowById(int id)
    {
        return _context.TheatreShow.FirstOrDefault(i => i.TheatreShowId == id);
    }

    public void PostTheatreShow(TheatreShow theatreShow)
    {
        //IsAdminLoggedIn()
        if (theatreShow.Venue != null && theatreShow.Venue.VenueId > 0)
        {
            var existingVenue = _context.Venue.FirstOrDefault(v => v.VenueId == theatreShow.Venue.VenueId);

            if (existingVenue != null)
            {
                var theatreShowData = new TheatreShow
                {
                    Title = theatreShow.Title,
                    Description = theatreShow.Description,
                    Venue = existingVenue,
                    theatreShowDates = theatreShow.theatreShowDates
                };
                _context.TheatreShow.Add(theatreShowData);
                _context.SaveChanges();
            }
        }
        else
        {
            _context.TheatreShow.Add(theatreShow);
            _context.SaveChanges();
        }

    }

    public void DeleteTheatreShow(int id)
    {
        //IsAdminLoggedIn()
        var theatreShow = _context.TheatreShow.FirstOrDefault(i => i.TheatreShowId == id);
        if (theatreShow != null)
        {
            _context.TheatreShow.Remove(theatreShow);
            _context.SaveChanges();
        }
    }

    public void UpdateTheatreShow(int id, TheatreShow updatedTheatreShow)
    {
        //IsAdminLoggedIn()
        var theatreShow = _context.TheatreShow.FirstOrDefault(i => i.TheatreShowId == id);
        if (theatreShow != null)
        {
            //TheatreShowId = theatreShow.TheatreShowId,
            theatreShow.Title = updatedTheatreShow.Title;
            theatreShow.Description = updatedTheatreShow.Description;
            //Price = theatreShow.Price,
            theatreShow.Venue = updatedTheatreShow.Venue;
            theatreShow.theatreShowDates = updatedTheatreShow.theatreShowDates;

            _context.TheatreShow.Update(theatreShow);
            _context.SaveChanges();
        }
    }

    public void PostVenue(Venue venue)
    {
        //IsAdminLoggedIn()
        _context.Venue.Add(venue);
        _context.SaveChanges();
    }

    public void DeleteVenue(int id)
    {
        //IsAdminLoggedIn()
        var venue = _context.Venue.FirstOrDefault(v => v.VenueId == id);
        if (venue != null)
        {
            _context.Venue.Remove(venue);
            _context.SaveChanges();
        }
    }

    public void PostTheatreShowDate(TheatreShowDate theatreShowDate)
    {
        //IsAdminLoggedIn()
        _context.TheatreShowDate.Add(theatreShowDate);
        _context.SaveChanges();
    }

    public void DeleteDate(int id)
    {
        //IsAdminLoggedIn()
        var theatreDate = _context.TheatreShowDate.FirstOrDefault(i => i.TheatreShowDateId == id);
        if (theatreDate != null)
        {
            _context.TheatreShowDate.Remove(theatreDate);
            _context.SaveChanges();
        }
    }
}
