import React from "react";
import CreateTheatreShowForm from "../components/CreateTheatreShowForm";
import { Link } from "react-router-dom";

const CreateTheatreShowPage: React.FC = () => {
  return (
    <div>
      <h1>Create Theatre Show</h1>
      <CreateTheatreShowForm />
      <ul>
        <li>
          <Link to="/">Go back to admin dashboard</Link>
        </li>
      </ul>
    </div>
  );
};

export default CreateTheatreShowPage;
