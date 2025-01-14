import React from 'react';
import ShowsOverview from '../components/ShowsOverview';
import { Link } from "react-router-dom";

const ShowsOverviewPage = () => {
  return (
    <div>
      <h1>Shows Overview</h1>
      <ShowsOverview />
      <ul>
        <li>
          <Link to="/">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default ShowsOverviewPage;

