import React from "react";
import CreateTheatreShowForm from "../components/CreateTheatreShowForm";
import { Link } from "react-router-dom";
import "../styles/login.css"; 

const CreateTheatreShowPage: React.FC = () => {
  return (
    <div className="home-container">
      <h1>Create Theatre Show</h1>
      <CreateTheatreShowForm />
      <ul>
        <li>
          <Link to="/Admindashboard">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default CreateTheatreShowPage;
