import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { ReservationForm } from '../components/ReservationForm';
import { ShoppingCart } from '../components/ShoppingCart';
import { getTheatreShows } from '../services/TheatreShowService';
import { Link } from "react-router-dom";
import '../styles/reservation.css';

interface Venue {
  venueId: number;
  name: string;
  capacity: number;
}

interface Reservation {
  reservationId: number;
  amountOfTickets: number;
  used: boolean;
  customer?: {
    customerId: number;
    firstName: string;
    lastName: string;
    email: string;
  };
  theatreShowDateId: number;
}

interface ShowData {
  theatreShowId: number;
  title: string;
  description: string;
  price: number;
  venueId: number;
  venue?: Venue;
  theatreShowDates: {
    theatreShowDateId: number;
    dateAndTime: string;
    reservations: Reservation[];
  }[];
}

export const ReservationPage: React.FC = () => {
  const { showDateId } = useParams<{ showDateId: string }>();
  const [showsData, setShowsData] = useState<ShowData[]>([]);  // Now storing an array of shows
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchShowsData = async () => {
      setLoading(true);
      setError(null);

      try {
        const shows = await getTheatreShows();  // Fetch all shows

        if (!shows || shows.length === 0) {
          throw new Error('No theatre shows found');
        }

        // If there's a showDateId, filter based on that
        if (showDateId) {
          const show = shows.find(
            (show: ShowData) =>
              show.theatreShowDates.some(
                (date) => date.theatreShowDateId.toString() === showDateId
              )
          );
          if (!show) {
            throw new Error('Show not found');
          }
          setShowsData([show]);  // Set only the found show
        } else {
          setShowsData(shows);  // If no showDateId, set all shows
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchShowsData();
  }, [showDateId]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}
          <ul>
            <li>
              <Link to="/">Go back to admin dashboard</Link>
            </li>
          </ul>
          </div>;
  }

  if (!showsData.length) {
    return <div>No shows available</div>;
  }

  return (
    <div className="reservation-page">
      {showsData.map((showData) => (
        <div key={showData.theatreShowId} className="show-details">
          <hr style={{ border: '1px solid #ccc', marginBottom: '10px' }} />
          <h1>{showData.title}</h1>
          {/* <p>{showData.description}</p>
          <p>Pricee: ${showData.price}</p>
          <p>Venue: {showData.venue?.name || 'No venue information available'}</p>
          <p>Date and Time: {new Date(showData.theatreShowDates[0]?.dateAndTime).toLocaleString()}</p> */}

          {/* Available Tickets */}
          <p>
            {showData.theatreShowDates[0]?.reservations?.reduce(
              (acc, reservation) => acc + reservation.amountOfTickets,
              0
            )}
          </p>

          <div className="reservation-layout">
            <div className="reservation-form-container">
              <ReservationForm
                showId={showData.theatreShowId}
                showTitle={showData.title}
                showDate={new Date(showData.theatreShowDates[0]?.dateAndTime).toLocaleString()}
                showDateId={showData.theatreShowDates[0]?.theatreShowDateId}
                price={showData.price}
                availableTickets={
                  showData.venue?.capacity ?? 0 -
                  showData.theatreShowDates[0]?.reservations?.reduce(
                    (acc, reservation) => acc + reservation.amountOfTickets,
                    0
                  )
                }
              />
            </div>

            <div className="cart-section">
              <ShoppingCart />
            </div>
            <ul>
        <li>
          <Link to="/">Go back</Link>
        </li>
      </ul>
          </div>
        </div>
      ))}
    </div>
  );
};

export default ReservationPage;
