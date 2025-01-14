import React from "react";
import { Link } from "react-router-dom";
import "../styles/login.css"; // Ensure the styles are shared

const AdminDashboard: React.FC = () => {
  return (
    <div className="home-container">
      <header>
        <h1>Welcome to the Admin Theatre Show Dashboard</h1>
        <p>Logged in as admin</p>
        <p>Select an option below to manage the system:</p>
      </header>

      <div className="home-content">
        <Link to="/TheatreShowOverviewPage" className="btn btn-primary">
          View Theatre Shows and Edit/Delete
        </Link>
        <Link to="/CreateTheatreShowPage" className="btn btn-primary">
          Create New Theatre Show
        </Link>
        <Link to="/ReservationOverviewPage" className="btn btn-primary">
          Check All Reservations
        </Link>
        <Link to="/" className="btn btn-primary">
          Back to Home
        </Link>
      </div>
    </div>
  );
};

export default AdminDashboard;
