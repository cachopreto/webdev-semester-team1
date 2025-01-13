import React, { useState } from 'react';
import { useShoppingCartContext } from '../contexts/ShoppingCartContext';
import { createReservation } from '../services/TheatreShowService';  // Import the service
import '../styles/reservation.css';

export const ShoppingCart: React.FC = () => {
  const { cart, removeFromCart, clearCart, getTotalItems, getTotalPrice } = useShoppingCartContext();
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  /**
   * Processes checkout by sending reservation requests for each cart item
   * Clears cart on success, displays error on failure
   */
  const handleCheckout = async () => {
    setIsLoading(true);
    setError(null);

    try {
      // Send reservation requests for each cart item using the reservation service
      const results = await Promise.all(
        cart.items.map(item =>
          createReservation({
            firstName: item.firstName,
            lastName: item.lastName,
            email: item.email,
            theatreShowDateId: item.theatreShowDateId,
            amountOfTickets: item.amountOfTickets,
          }).catch(err => {
            // Handle individual reservation failures
            throw new Error(`Failed to reserve ${item.showTitle}: ${err.message}`);
          })
        )
      );

      // Clear cart and notify user on success
      clearCart();
      alert('All reservations completed successfully!');
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to process reservations');
    } finally {
      setIsLoading(false);
    }
  };

  if (cart.items.length === 0) {
    return <div className="cart-container">Your cart is empty</div>;
  }

  return (
    <div className="cart-container">
      <h2>Shopping Cart</h2>

      {error && (
        <div style={{ color: '#dc3545', marginBottom: '1rem' }}>
          {error}
        </div>
      )}

      {cart.items.map(item => (
        <div key={item.id} className="cart-item">
          <div className="cart-item-info">
            <div className="cart-item-title">{item.showTitle}</div>
            <div className="cart-item-details">
              Date: {item.showDate}<br />
              Tickets: {item.amountOfTickets}<br />
              Price: €{(item.price || 0) * item.amountOfTickets}
            </div>
          </div>
          <button
            className="remove-button"
            onClick={() => removeFromCart(item.id)}
            disabled={isLoading}
          >
            Remove
          </button>
        </div>
      ))}

      <div className="cart-total">
        <div>Total Items: {getTotalItems()}</div>
        <div>Total Price: €{getTotalPrice()}</div>
      </div>

      <div className="cart-actions">
        <button
          className="checkout-button"
          onClick={handleCheckout}
          disabled={isLoading}
        >
          {isLoading ? 'Processing...' : 'Checkout'}
        </button>
      </div>
    </div>
  );
};
