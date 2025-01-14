import React from "react";
import { Link } from "react-router-dom";

const AdminDashboard: React.FC = () => {
  return (
    <div>
      <p>Logged in as admin</p>
      <h1>Welcome to the Admin Theatre Show Dashboard</h1>
      <p>Select an option below to manage the system:</p>
      <ul>
        <li>
          <Link to="/TheatreShowOverviewPage">View Theatre Shows and edit or delete</Link>
        </li>
        <li>
          <Link to="/CreateTheatreShowPage">Create New Theatre Show</Link>
        </li>
        <li>
          <Link to="/ShowOverviewPage">zamir code (Search show)</Link>
        </li>
        <li>
          <Link to="/Reservation">Make reservation</Link>
        </li>
        <li>
          <Link to="/FutureShowsPage">Check upcoming shows</Link>
        </li>
        <li>
          <Link to="/ReservationOverviewPage">Check all reservations</Link>
        </li>
      </ul>
    </div>
  );
};

export default AdminDashboard;
