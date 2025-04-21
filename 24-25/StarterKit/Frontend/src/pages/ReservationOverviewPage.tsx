import React from "react";
import { useNavigate } from "react-router-dom";
import ReservationOverview from "../components/ReservationOverview";
import { Link } from "react-router-dom";
import '../styles/reservation.css';

const ReservationPage: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div className="home-container">
      <ReservationOverview />
      <ul>
        <li>
          <Link to="/AdminDashboard">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default ReservationPage;
