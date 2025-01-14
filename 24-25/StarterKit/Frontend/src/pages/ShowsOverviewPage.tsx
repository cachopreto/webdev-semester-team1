// src/pages/ShowsOverviewPage.tsx

import React from 'react';
import ShowsOverview from '../components/ShowsOverview';
import "../styles/login.css"; 
import { Link } from "react-router-dom";


const ShowsOverviewPage = () => {
  return (
    <div className="home-container">
      <h1>Shows Overview</h1>
      <ShowsOverview />
      <ul style={{ marginTop: "20px" }}>
        <li>
          <Link to="/">Go back</Link>
        </li>
      </ul>
    </div>
  );
};

export default ShowsOverviewPage;
