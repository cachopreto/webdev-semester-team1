import React from "react";
import EditTheatreShowForm from "../components/EditTheatreShowForm";
import { Link, useParams } from "react-router-dom";

const EditTheatreShowPage: React.FC = () => {
  const { id } = useParams<{ id: string }>(); // Extract `id` from URL parameters

  // Validate the ID
  if (!id) {
    return <div>Error: ID is missing</div>; // Handle missing ID case
  }

  const numericId: number = Number(id); // Convert the ID to a number
  if (isNaN(numericId)) {
    return <div>Error: Invalid ID format</div>; // Handle invalid ID case
  }

  return (
    <div>
      <h1>Edit Theatre Show</h1>
      {/* Render the edit form with the valid ID */}
      <EditTheatreShowForm id={numericId} />
      {/* Provide a link to go back to the Theatre Show Overview page */}
      <ul style={{ marginTop: "20px" }}>
        <li>
          <Link to="/TheatreShowOverviewPage">Go back to Theatre Show Overview</Link>
        </li>
      </ul>
    </div>
  );
};

export default EditTheatreShowPage;
