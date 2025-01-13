import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import { fetchShows, fetchVenues } from '../services/showService';

const ShowsOverview = () => {
  const [shows, setShows] = useState([]);
  const [venues, setVenues] = useState([]);
  const [filters, setFilters] = useState({
    search: '',
    venue: '',
    month: '',
    orderBy: '',
  });

  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    const loadVenues = async () => {
      const venuesData = await fetchVenues();
      setVenues(venuesData);
    };

    const loadShows = async () => {
      const showsData = await fetchShows(filters);
      setShows(showsData);
    };

    loadVenues();
    loadShows();
  }, [filters]);

  useEffect(() => {
    const params = Object.fromEntries([...searchParams]);
    setFilters((prev) => ({ ...prev, ...params }));
  }, [searchParams]);

  const handleFilterChange = (e) => {
    const { name, value } = e.target;
    setFilters((prev) => ({ ...prev, [name]: value }));
    setSearchParams((prev) => ({ ...Object.fromEntries([...prev]), [name]: value }));
  };

  return (
    <div>
      <div>
        <input
          type="text"
          name="search"
          value={filters.search}
          onChange={handleFilterChange}
          placeholder="Search by title or description"
        />

        <select name="venue" value={filters.venue} onChange={handleFilterChange}>
          <option value="">All Venues</option>
          {venues.map((venue) => (
            <option key={venue.id} value={venue.name}>
              {venue.name}
            </option>
          ))}
        </select>

        <input
          type="month"
          name="month"
          value={filters.month}
          onChange={handleFilterChange}
        />

        <select name="orderBy" value={filters.orderBy} onChange={handleFilterChange}>
          <option value="">Default Order</option>
          <option value="title-asc">Title A-Z</option>
          <option value="title-desc">Title Z-A</option>
          <option value="price-asc">Price Low to High</option>
          <option value="price-desc">Price High to Low</option>
          <option value="date-asc">Date Ascending</option>
          <option value="date-desc">Date Descending</option>
        </select>
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

