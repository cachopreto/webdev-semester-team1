// Form component for theatre ticket reservations
import React, { useState } from 'react';
import { useShoppingCartContext } from '../contexts/ShoppingCartContext';
import { CartItem } from '../types/reservation';
import '../styles/reservation.css';

// Props for show details and ticket info
interface ReservationFormProps {
  showId: number;
  showTitle: string;
  showDate: string;
  showDateId: number;
  price: number;
  availableTickets: number;
}

export const ReservationForm: React.FC<ReservationFormProps> = ({
  showId,
  showTitle,
  showDate,
  showDateId,
  price,
  availableTickets,
}) => {
  const { addToCart } = useShoppingCartContext();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    amountOfTickets: 1,
  });
  const [error, setError] = useState<string | null>(null);

  // Updates form data and validates ticket quantity
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === 'amountOfTickets') {
      const tickets = parseInt(value);
      if (tickets > availableTickets) {
        setError(`Only ${availableTickets} tickets available`);
      } else {
        setError(null);
      }
    }
    setFormData(prev => ({
      ...prev,
      [name]: name === 'amountOfTickets' ? parseInt(value) || 0 : value
    }));
  };

  // Processes form submission and adds to cart
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (formData.amountOfTickets <= 0) {
      setError('Please select at least 1 ticket');
      return;
    }

    if (formData.amountOfTickets > availableTickets) {
      setError(`Only ${availableTickets} tickets available`);
      return;
    }

    const cartItem: Omit<CartItem, 'id'> = {
      firstName: formData.firstName,
      lastName: formData.lastName,
      email: formData.email,
      theatreShowDateId: showDateId,
      amountOfTickets: formData.amountOfTickets,
      showTitle,
      showDate,
      price,
    };

    addToCart(cartItem);

    // Reset form
    setFormData({
      firstName: '',
      lastName: '',
      email: '',
      amountOfTickets: 1,
    });
    setError(null);
  };

  return (
    <form onSubmit={handleSubmit} className="reservation-form">
      <h3>Reserve Tickets for {showTitle}</h3>
      <p>Show Date: {showDate}</p>
      <p>Price per ticket: €{price}</p>
      <p>Available tickets: {availableTickets}</p>

      {error && (
        <div style={{ color: '#dc3545', marginBottom: '1rem' }}>
          {error}
        </div>
      )}

      <div className="form-group">
        <label htmlFor="firstName">First Name:</label>
        <input
          type="text"
          id="firstName"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <label htmlFor="lastName">Last Name:</label>
        <input
          type="text"
          id="lastName"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <label htmlFor="email">Email:</label>
        <input
          type="email"
          id="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <label htmlFor="amountOfTickets">Number of Tickets:</label>
        <input
          type="number"
          id="amountOfTickets"
          name="amountOfTickets"
          min="1"
          max={availableTickets}
          value={formData.amountOfTickets}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <button type="submit" className="submit-button">
          Add to Cart
        </button>
      </div>
    </form>
  );
};
