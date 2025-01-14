import React, { useEffect, useState } from "react";
import { getReservations } from "../services/TheatreShowService";
import { Link } from "react-router-dom";

interface Customer {
  firstName: string | null;
  lastName: string | null;
  email: string | null;
}

interface Venue {
  name: string | null;
}

interface TheatreShow {
  title: string | null;
  venue: Venue | null;
}

interface TheatreShowDate {
  dateAndTime: string;
  theatreShow: TheatreShow | null; // Allow theatreShow to be null
}

interface Reservation {
  reservationId: number;
  amountOfTickets: number;
  used: boolean;
  customer: Customer | null; // Allow customer to be null
  theatreShowDate: TheatreShowDate | null; // Allow theatreShowDate to be null
}

const ReservationOverview: React.FC = () => {
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(true); // Add loading state

  useEffect(() => {
    const fetchReservations = async () => {
      try {
        const data = await getReservations();
        setReservations(data);
      } catch (err) {
        setError("Failed to fetch reservations");
      } finally {
        setIsLoading(false); // Stop loading after fetch is complete
      }
    };

    fetchReservations();
  }, []);

  if (error) {
    return (
      <div>
        Error: {error}
        <ul>
          <li>
            <Link to="/">Go back to admin dashboard</Link>
          </li>
        </ul>
      </div>
    );
  }

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (reservations.length === 0) {
    return (
      <div>
        <h2>No reservations have been made yet.</h2>
      </div>
    );
  }

  return (
    <div>
      <h1>Reservation Overview</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>Reservation ID</th>
            <th>Customer Name</th>
            <th>Email</th>
            <th>Tickets</th>
            <th>Show Date</th>
            <th>Theatre Show</th>
            <th>Venue</th>
          </tr>
        </thead>
        <tbody>
          {reservations.map((reservation) => (
            <tr key={reservation.reservationId}>
              <td>{reservation.reservationId}</td>
              <td>
                {reservation.customer
                  ? `${reservation.customer.firstName || ""} ${
                      reservation.customer.lastName || ""
                    }`
                  : "Unknown"}
              </td>
              <td>{reservation.customer?.email || "Unknown"}</td>
              <td>{reservation.amountOfTickets}</td>
              <td>
                {reservation.theatreShowDate
                  ? new Date(
                      reservation.theatreShowDate.dateAndTime
                    ).toLocaleString()
                  : "Unknown"}
              </td>
              <td>
                {reservation.theatreShowDate?.theatreShow?.title || "Unknown"}
              </td>
              <td>
                {reservation.theatreShowDate?.theatreShow?.venue?.name ||
                  "Unknown"}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ReservationOverview;
