// src/pages/AdminHome.tsx
import React from "react";
import { Link } from "react-router-dom";

const AdminHome: React.FC = () => {
  return (
    <div>
      <h1>Welcome to the Admin Theatre Management System</h1>
      <p>Select an option below to manage the system:</p>
      <ul>
        <li>
          <Link to="/dashboard">Show Overview</Link>
        </li>
      </ul>
    </div>
  );
};

export default AdminHome;
