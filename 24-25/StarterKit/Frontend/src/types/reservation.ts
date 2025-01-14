export interface ReservationRequest {
  firstName: string;
  lastName: string;
  email: string;
  TheatreShowDateId: number;
  AmountOfTickets: number;
}

export interface CartItem extends ReservationRequest {
  id: string; // Unique ID for cart management
  showTitle?: string; // Optional show title for display
  showDate?: string; // Optional date for display
  price?: number; // Optional price for display
}

export interface ShoppingCart {
  items: CartItem[];
}
