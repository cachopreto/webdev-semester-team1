import React from "react";
import { useNavigate } from "react-router-dom";
import ReservationOverview from "../components/ReservationOverview";
import { Link } from "react-router-dom";

const ReservationPage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div>
      <h1>Reservation Overview</h1>
      <ReservationOverview />
      <ul>
        <li>
          <Link to="/">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default ReservationPage;
