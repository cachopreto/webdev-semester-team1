import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import { fetchShows, fetchVenues } from '../services/TheatreShowService';

// Define types for shows and venues
interface Show {
  id: number;
  title: string;
  description: string;
  date: string;
  price: number;
}

interface Venue {
  id: number;
  name: string;
}

const ShowsOverview = () => {
  const [shows, setShows] = useState<Show[]>([]); // Explicitly type as Show[]
  const [venues, setVenues] = useState<Venue[]>([]); // Explicitly type as Venue[]
  const [filters, setFilters] = useState({
    search: '',
    venue: '',
    month: '',
    orderBy: '',
  });

  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    const loadVenues = async () => {
      const venuesData: Venue[] = await fetchVenues(); // Add type assertion
      setVenues(venuesData);
    };

    const loadShows = async () => {
      const showsData: Show[] = await fetchShows(filters); // Add type assertion
      setShows(showsData);
    };

    loadVenues();
    loadShows();
  }, [filters]);

  useEffect(() => {
    const params = Object.fromEntries([...searchParams]);
    setFilters((prev) => ({ ...prev, ...params }));
  }, [searchParams]);

  const handleFilterChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFilters((prev) => ({ ...prev, [name]: value }));
    setSearchParams((prev) => ({ ...Object.fromEntries([...prev]), [name]: value }));
  };

  return (
    <div>
      <div>
        <div>
          <label htmlFor="search">Search by title or description</label>
          <input
            type="text"
            id="search"
            name="search"
            value={filters.search}
            onChange={handleFilterChange}
            placeholder="Search..."
          />
        </div>

        <div>
          <label htmlFor="venue">Select a Venue</label>
          <select
            id="venue"
            name="venue"
            value={filters.venue}
            onChange={handleFilterChange}
            aria-label="Select a venue"
          >
            <option value="">All Venues</option>
            {venues.map((venue) => (
              <option key={venue.id} value={venue.name}>
                {venue.name}
              </option>
            ))}
          </select>
        </div>

        <div>
          <label htmlFor="month">Select a Month</label>
          <input
            type="text"
            id="month"
            name="month"
            value={filters.month}
            onChange={handleFilterChange}
            placeholder="YYYY-MM"
            pattern="\d{4}-\d{2}"
            title="Enter month in YYYY-MM format"
          />
        </div>

        <div>
          <label htmlFor="orderBy">Order By</label>
          <select
            id="orderBy"
            name="orderBy"
            value={filters.orderBy}
            onChange={handleFilterChange}
            aria-label="Order by options"
          >
            <option value="">Default Order</option>
            <option value="title-asc">Title A-Z</option>
            <option value="title-desc">Title Z-A</option>
            <option value="price-asc">Price Low to High</option>
            <option value="price-desc">Price High to Low</option>
            <option value="date-asc">Date Ascending</option>
            <option value="date-desc">Date Descending</option>
          </select>
        </div>
      </div>

      <ul>
        {shows.map((show) => (
          <li key={show.id}>
            <h2>{show.title}</h2>
            <p>{show.description}</p>
            <p>{show.date}</p>
            <p>{show.price}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ShowsOverview;
