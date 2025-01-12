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
          <Link to="/TheatreShowOverviewPage">View Theatre Shows</Link>
        </li>
        <li>
          <Link to="/CreateTheatreShowPage">Create New Theatre Show</Link>
        </li>
      </ul>
    </div>
  );
};

export default AdminDashboard;
