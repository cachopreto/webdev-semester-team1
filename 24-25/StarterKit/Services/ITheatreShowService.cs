using System.Collections.Generic;
using System;
using StarterKit.Models;

namespace StarterKit.Services
{
    public interface ITheatreShowService
    {
        IEnumerable<TheatreShow> GetAllTheatreShows(
            string? titleOrDescription = null,
            string? location = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string? sortBy = null,
            bool ascending = true);

        TheatreShow GetTheatreShowById(int id);

        void PostTheatreShow(TheatreShow theatreShow);

        void DeleteTheatreShow(int id);

        void UpdateTheatreShow(int id, UpdateTheatreShow updatedTheatreShow);

        void PostVenue(Venue venue);

        void DeleteVenue(int id);

        void PostTheatreShowDate(TheatreShowDate theatreShowDate);

        void DeleteDate(int id);
    }
}
