import React, { useEffect, useState } from "react";
import { getTheatreShows } from "../services/TheatreShowService";
import { Link } from "react-router-dom";
import "../styles/login.css"; 

interface TheatreShowDate {
  dateAndTime: string;
}

interface Venue {
  name: string;
  capacity: number;
}

interface TheatreShow {
  theatreShowId: number;
  title: string;
  description: string;
  price: number;
  venue: Venue;
  theatreShowDates: TheatreShowDate[];
}

const FutureShowsPage: React.FC = () => {
  const [futureShows, setFutureShows] = useState<TheatreShow[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(true); // Add loading state

  useEffect(() => {
    const fetchShows = async () => {
      try {
        const data = await getTheatreShows();

        // Filter future shows based on their dates
        const today = new Date();
        const filteredShows = data.filter((show: TheatreShow) =>
          show.theatreShowDates.some(
            (date) => new Date(date.dateAndTime) > today
          )
        );

        setFutureShows(filteredShows);
      } catch (err) {
        setError("Failed to fetch theatre shows");
      } finally {
        setIsLoading(false); // Stop loading after fetch is complete
      }
    };

    fetchShows();
  }, []);

  if (error) {
    return <div>Error: {error}</div>;
  }

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (futureShows.length === 0) {
    return (
      <div>
        <h2>No upcoming theatre shows currently available.</h2>
        <ul>
          <li>
            <Link to="/">Go back</Link>
          </li>
        </ul>
      </div>
    );
  }

  return (
    <div className="home-container">
      <h1>Upcoming Theatre Shows</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Title</th>
            <th>Description</th>
            <th>Price</th>
            <th>Venue</th>
            <th>Capacity</th>
            <th>Dates</th>
          </tr>
        </thead>
        <tbody>
          {futureShows.map((show) => (
            <tr key={show.theatreShowId}>
              <td>{show.theatreShowId}</td>
              <td>{show.title}</td>
              <td>{show.description}</td>
              <td>{show.price}</td>
              <td>{show.venue.name}</td>
              <td>{show.venue.capacity}</td>
              <td>
                {show.theatreShowDates
                  .filter((date) => new Date(date.dateAndTime) > new Date()) // Only future dates
                  .map((date) =>
                    new Date(date.dateAndTime).toLocaleString()
                  )
                  .join(", ")}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <ul style={{ marginTop: "20px" }}>
        <li>
          <Link to="/">Go back</Link>
        </li>
      </ul>
    </div>
  );
};

export default FutureShowsPage;
