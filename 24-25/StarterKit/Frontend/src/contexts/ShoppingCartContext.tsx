/**
 * Context for managing shopping cart state across the application
 */
import React, { createContext, useContext } from 'react';
import { useShoppingCart } from '../hooks/useShoppingCart';
import { CartItem, ShoppingCart } from '../types/reservation';

// Type definition for shopping cart context values
interface ShoppingCartContextType {
  cart: ShoppingCart;
  addToCart: (item: Omit<CartItem, 'id'>) => void;
  removeFromCart: (itemId: string) => void;
  clearCart: () => void;
  getTotalItems: () => number;
  getTotalPrice: () => number;
}

// Create context with undefined default value
const ShoppingCartContext = createContext<ShoppingCartContextType | undefined>(undefined);

// Provider component that wraps app to provide cart functionality
export const ShoppingCartProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const cartHook = useShoppingCart();

  return (
    <ShoppingCartContext.Provider value={cartHook}>
      {children}
    </ShoppingCartContext.Provider>
  );
};

// Custom hook to access shopping cart context
export const useShoppingCartContext = () => {
  const context = useContext(ShoppingCartContext);
  if (context === undefined) {
    throw new Error('useShoppingCartContext must be used within a ShoppingCartProvider');
  }
  return context;
};
