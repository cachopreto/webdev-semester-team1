using Microsoft.EntityFrameworkCore;
using StarterKit.Models;

namespace StarterKit.Services;

public class TheatreShowService : ITheatreShowService
{
    private readonly DatabaseContext _context;

    public TheatreShowService(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<TheatreShow> GetAllTheatreShows(
    string? titleOrDescription = null,
    string? location = null,
    DateTime? startDate = null,
    DateTime? endDate = null,
    string? sortBy = null,
    bool ascending = true)
    {
        // Get all theatre shows with related data
        var allShows = _context.TheatreShow
            .Include(ts => ts.Venue)
            .Include(ts => ts.theatreShowDates)
            .Where(ts => ts.Venue != null && ts.theatreShowDates != null && ts.theatreShowDates.Any()) // Ensure valid data
            .ToList();

        // Filter by title or description
        if (!string.IsNullOrEmpty(titleOrDescription))
        {
            allShows = allShows.Where(ts => 
                (ts.Title != null && ts.Title.Contains(titleOrDescription)) || 
                (ts.Description != null && ts.Description.Contains(titleOrDescription)))
                .ToList();
        }

        // Filter by location (venue name)
        if (!string.IsNullOrEmpty(location))
        {
            allShows = allShows.Where(ts => ts.Venue != null && ts.Venue.Name != null && ts.Venue.Name.Contains(location))
                .ToList();
        }

        // Filter by start date
        if (startDate.HasValue)
        {
            allShows = allShows.Where(ts => ts.theatreShowDates.Any(d => d.DateAndTime >= startDate.Value))
                .ToList();
        }

        // Filter by end date
        if (endDate.HasValue)
        {
            allShows = allShows.Where(ts => ts.theatreShowDates.Any(d => d.DateAndTime <= endDate.Value))
                .ToList();
        }

        // Sort the results
        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy.ToLower() == "title")
            {
                allShows = ascending 
                    ? allShows.OrderBy(ts => ts.Title).ToList() 
                    : allShows.OrderByDescending(ts => ts.Title).ToList();
            }
            else if (sortBy.ToLower() == "price")
            {
                allShows = ascending 
                    ? allShows.OrderBy(ts => ts.Price).ToList() 
                    : allShows.OrderByDescending(ts => ts.Price).ToList();
            }
            else if (sortBy.ToLower() == "date")
            {
                allShows = ascending
                    ? allShows.OrderBy(ts => ts.theatreShowDates.Min(d => d.DateAndTime)).ToList()
                    : allShows.OrderByDescending(ts => ts.theatreShowDates.Max(d => d.DateAndTime)).ToList();
            }
        }

        return allShows;
    }


    public TheatreShow GetTheatreShowById(int id)
    {
        return _context.TheatreShow
                .Include(ts => ts.Venue)
                .Include(ts => ts.theatreShowDates)
                .FirstOrDefault(ts => ts.TheatreShowId == id);
    }

    public void PostTheatreShow(TheatreShow theatreShow)
    {
        //IsAdminLoggedIn()
        // if (theatreShow.Venue != null && theatreShow.Venue.VenueId > 0)
        // {
        //     var existingVenue = _context.Venue.FirstOrDefault(v => v.VenueId == theatreShow.Venue.VenueId);

        //     if (existingVenue != null)
        //     {
        //         var theatreShowData = new TheatreShow
        //         {
        //             Title = theatreShow.Title,
        //             Description = theatreShow.Description,
        //             Venue = existingVenue,
        //             theatreShowDates = theatreShow.theatreShowDates
        //         };
        //         _context.TheatreShow.Add(theatreShowData);
        //         _context.SaveChanges();
        //     }
        // }
        _context.TheatreShow.Add(theatreShow);
        _context.SaveChanges();
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

    public void UpdateTheatreShow(int id, UpdateTheatreShow updatedTheatreShow)
    {
        //IsAdminLoggedIn()
        var theatreShow = _context.TheatreShow.FirstOrDefault(i => i.TheatreShowId == id);
        if (theatreShow != null)
        {
            theatreShow.Title = updatedTheatreShow.Title;
            theatreShow.Description = updatedTheatreShow.Description;
            theatreShow.Price = updatedTheatreShow.Price;

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
