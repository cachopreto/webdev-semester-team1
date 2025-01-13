import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { ReservationForm } from '../components/ReservationForm';
import { ShoppingCart } from '../components/ShoppingCart';
import '../styles/reservation.css';

interface ShowData {
  theatreShowDateId: number;
  showId: number;
  title: string;
  dateAndTime: string;
  price: number;
  venue: {
    capacity: number;
  };
}

export const ReservationPage: React.FC = () => {
  const { showDateId } = useParams<{ showDateId: string }>();
  const [showData, setShowData] = useState<ShowData | null>(null);
  const [availableTickets, setAvailableTickets] = useState<number>(0);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchShowData = async () => {
      try {
        // Fetch show date details
        const showDateResponse = await fetch(`/api/v1/reservations/showdate/${showDateId}`);
        if (!showDateResponse.ok) {
          throw new Error('Failed to fetch show data');
        }
        const showDateData = await showDateResponse.json();

        // Fetch reserved tickets count
        const reservedResponse = await fetch(`/api/v1/reservations/count/${showDateId}`);
        if (!reservedResponse.ok) {
          throw new Error('Failed to fetch reserved tickets count');
        }
        const { reservedTickets } = await reservedResponse.json();

        setShowData(showDateData);
        setAvailableTickets(showDateData.venue.capacity - reservedTickets);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    if (showDateId) {
      fetchShowData();
    }
  }, [showDateId]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error || !showData) {
    return <div>Error: {error || 'Show not found'}</div>;
  }

  return (
    <div className="reservation-page">
      <h1>{showData.title}</h1>
      
      <div className="reservation-layout">
        <div className="reservation-form-container">
          <ReservationForm
            showId={showData.showId}
            showTitle={showData.title}
            showDate={new Date(showData.dateAndTime).toLocaleString()}
            showDateId={showData.theatreShowDateId}
            price={showData.price}
            availableTickets={availableTickets}
          />
        </div>

        <div className="cart-section">
          <ShoppingCart />
        </div>
      </div>
    </div>
  );
};

export default ReservationPage;
