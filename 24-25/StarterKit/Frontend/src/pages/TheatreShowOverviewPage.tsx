import React, { useState } from "react";
import TheatreShowsOverview from "../components/TheatreShowsOverview";
import { Link, useNavigate } from "react-router-dom";
import DeleteTheatreShow from "../components/DeleteTheatreShow";
import "../styles/login.css"; 

const TheatreShowOverviewPage: React.FC = () => {
  const [showId, setShowId] = useState<string>(""); // ID input by the user
  const navigate = useNavigate(); // For navigation

  const handleSearchSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (showId) {
      navigate(`/EditTheatreShowPage/${showId}`); // Navigate to the Edit page
    }
  };

  return (
    <div className="home-container">
      <h1>Theatre Show Overview</h1>
      <TheatreShowsOverview /> {/* Render the table of theatre shows */}

      {/* Form for entering the ID of the show to edit */}
      <form onSubmit={handleSearchSubmit} style={{ marginTop: "20px" }}>
      <h2>Edit Theatre Show</h2> {/* Add this header */}
        <label htmlFor="showId">Enter Theatre Show ID to Edit: </label>
        <input
          type="number"
          id="showId"
          value={showId}
          onChange={(e) => setShowId(e.target.value)}
          placeholder="Enter show ID"
        />
        <button type="submit">Go to Edit Page</button>
      </form>

      {/* Include DeleteTheatreShow component */}
      <DeleteTheatreShow />

      <ul style={{ marginTop: "20px" }}>
        <li>
          <Link to="/Admindashboard">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default TheatreShowOverviewPage;
