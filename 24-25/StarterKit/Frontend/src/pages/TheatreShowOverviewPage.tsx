import React from "react";
import TheatreShowsOverview from "../components/TheatreShowsOverview";
import { Link } from "react-router-dom";

const TheatreShowOverviewPage: React.FC = () => {
  return (
    <div>
      <h1>Theatre Show Overview</h1>
      <TheatreShowsOverview />
      <ul>
        <li>
          <Link to="/">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default TheatreShowOverviewPage;
