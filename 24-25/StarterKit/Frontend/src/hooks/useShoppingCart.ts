/**
 * Custom hook for managing the shopping cart state and persistence
 */
import { useState, useEffect } from 'react';
import { CartItem, ShoppingCart } from '../types/reservation';

// Key used for storing cart data in localStorage
const CART_STORAGE_KEY = 'theatre_cart';

export const useShoppingCart = () => {
  const [cart, setCart] = useState<ShoppingCart>({ items: [] });

  // Load cart from localStorage on mount
  useEffect(() => {
    const savedCart = localStorage.getItem(CART_STORAGE_KEY);
    if (savedCart) {
      try {
        setCart(JSON.parse(savedCart));
      } catch (e) {
        console.error('Failed to parse cart from localStorage:', e);
      }
    }
  }, []);

  // Save cart to localStorage whenever it changes
  useEffect(() => {
    localStorage.setItem(CART_STORAGE_KEY, JSON.stringify(cart));
  }, [cart]);

  // Adds a new item to cart with generated ID
  const addToCart = (item: Omit<CartItem, 'id'>) => {
    setCart(prevCart => ({
      items: [
        ...prevCart.items,
        {
          ...item,
          id: Math.random().toString(36).substring(2, 9) // Generate simple unique ID
        }
      ]
    }));
  };

  // Removes item from cart by ID
  const removeFromCart = (itemId: string) => {
    setCart(prevCart => ({
      items: prevCart.items.filter(item => item.id !== itemId)
    }));
  };

  // Empties the entire cart
  const clearCart = () => {
    setCart({ items: [] });
  };

  // Calculates total number of tickets in cart
  const getTotalItems = () => {
    return cart.items.reduce((total, item) => total + item.AmountOfTickets, 0);
  };

  // Calculates total price of all items in cart
  const getTotalPrice = () => {
    return cart.items.reduce((total, item) => total + (item.price || 0) * item.AmountOfTickets, 0);
  };

  return {
    cart,
    addToCart,
    removeFromCart,
    clearCart,
    getTotalItems,
    getTotalPrice
  };
};
