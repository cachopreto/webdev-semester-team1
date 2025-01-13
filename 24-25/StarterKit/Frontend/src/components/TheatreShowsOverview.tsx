import React, { useEffect, useState } from "react";
import { getTheatreShows } from "../services/TheatreShowService";

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

const TheatreShowsOverview: React.FC = () => {
  const [shows, setShows] = useState<TheatreShow[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchShows = async () => {
      try {
        const data = await getTheatreShows();
        setShows(data);
      } catch (err) {
        setError("Failed to fetch theatre shows");
      }
    };

    fetchShows();
  }, []);

  if (error) {
    return <div>Error: {error}</div>;
  }

  if (shows.length === 0) {
    return <div>Loading...</div>;
  }

  return (
    <table border={1}>
      <thead>
        <tr>
          <th>Title</th>
          <th>Description</th>
          <th>Price</th>
          <th>Venue</th>
          <th>Capacity</th>
          <th>Dates</th>
        </tr>
      </thead>
      <tbody>
        {shows.map((show) => (
          <tr key={show.theatreShowId}>
            <td>{show.title}</td>
            <td>{show.description}</td>
            <td>{show.price}</td>
            <td>{show.venue.name}</td>
            <td>{show.venue.capacity}</td>
            <td>
              {show.theatreShowDates
                .map((date) => new Date(date.dateAndTime).toLocaleString())
                .join(", ")}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TheatreShowsOverview;
