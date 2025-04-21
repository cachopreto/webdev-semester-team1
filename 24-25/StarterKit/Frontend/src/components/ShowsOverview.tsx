import { useState } from "react";
import '../styles/styles.css';

// Define the interface for TheatreShow
interface TheatreShow {
  theatreShowId: number;
  title: string;
  description: string;
  price: number;
  venue: {
    name: string;
  };
  theatreShowDates: Array<{
    dateAndTime: string;
  }>;
}

// Define the filters interface
interface Filters {
  titleOrDescription?: string;
  location?: string;
  startDate?: string;
  endDate?: string;
  sortBy?: string;
  ascending?: boolean;
}

// Import the fetchShows service function
import { fetchShows } from "../services/TheatreShowService"; // Replace with the correct path

const ShowsList = () => {
  const [shows, setShows] = useState<TheatreShow[]>([]);
  const [filters, setFilters] = useState<Filters>({
    titleOrDescription: "",
    location: "",
    startDate: "",
    endDate: "",
    sortBy: "title",
    ascending: true,
  });

  // Handle the search and fetching of shows based on filters
  const handleSearch = async () => {
    try {
      const fetchedShows = await fetchShows(filters); // Use fetchShows with filters
      setShows(fetchedShows); // Set fetched shows in state
    } catch (error) {
      console.error("Failed to fetch shows:", error);
    }
  };

  return (
    <div className="search-container">
      <h2>Search Shows</h2>
      
      {/* Search by title/description */}
      <div>
        <label htmlFor="titleOrDescription">Search by title or description:</label>
        <input
          id="titleOrDescription"
          type="text"
          placeholder="Enter title or description"
          value={filters.titleOrDescription}
          onChange={(e) => setFilters({ ...filters, titleOrDescription: e.target.value })}
        />
      </div>

      {/* Filter by venue */}
      <div>
        <label htmlFor="location">Search by venue:</label>
        <input
          id="location"
          type="text"
          placeholder="Enter venue name"
          value={filters.location}
          onChange={(e) => setFilters({ ...filters, location: e.target.value })}
        />
      </div>

      {/* Date range filter */}
      <div>
        <label htmlFor="startDate">Start Date:</label>
        <input
          id="startDate"
          type="date"
          value={filters.startDate}
          onChange={(e) => setFilters({ ...filters, startDate: e.target.value })}
        />
      </div>
      <div>
        <label htmlFor="endDate">End Date:</label>
        <input
          id="endDate"
          type="date"
          value={filters.endDate}
          onChange={(e) => setFilters({ ...filters, endDate: e.target.value })}
        />
      </div>

      {/* Sort by dropdown */}
      <div>
        <label htmlFor="sortBy">Sort by:</label>
        <select
          id="sortBy"
          value={filters.sortBy}
          onChange={(e) => setFilters({ ...filters, sortBy: e.target.value })}
        >
          <option value="title">Title</option>
          <option value="price">Price</option>
          <option value="date">Date</option>
        </select>
      </div>

      {/* Ascending/Descending */}
      <div>
        <label htmlFor="ascending">Ascending</label>
        <input
          id="ascending"
          type="checkbox"
          checked={filters.ascending}
          onChange={(e) => setFilters({ ...filters, ascending: e.target.checked })}
        />
      </div>

      <button onClick={handleSearch}>Search</button>

      {/* Displaying the search results */}
      <div className="shows-container">
        {shows.length > 0 ? (
          shows.map((show) => (
            <div className="show-card" key={show.theatreShowId}>
              <h3>{show.title}</h3>
              <p>{show.description}</p>
              <p><strong>Venue:</strong> {show.venue?.name}</p>
              <p><strong>Price:</strong> ${show.price}</p>
              {show.theatreShowDates && show.theatreShowDates.length > 0 && (
                <p><strong>First Show Date:</strong> {new Date(show.theatreShowDates[0].dateAndTime).toLocaleString()}</p>
              )}
            </div>
          ))
        ) : (
          <p>No shows found</p>
        )}
      </div>
    </div>
  );
};

export default ShowsList;
