import React, { useState } from "react";
import { deleteTheatreShow } from "../services/TheatreShowService";
import { useNavigate } from "react-router-dom";

const DeleteTheatreShow: React.FC = () => {
  const [deleteId, setDeleteId] = useState<number | null>(null); // ID for deletion
  const [isDeletePopupOpen, setDeletePopupOpen] = useState(false); // Pop-up state
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);
  const navigate = useNavigate(); // Hook to navigate

  const confirmDelete = () => {
    if (deleteId !== null) {
      deleteTheatreShow(deleteId)
        .then((message) => {
          setSuccess(message); // Backend success message
          setError(null);
          setDeleteId(null); // Clear delete ID
          setDeletePopupOpen(false); // Close the pop-up
          navigate(0); // Refresh the page by navigating to the same route
        })
        .catch(() => {
          setError("Failed to delete the theatre show. Please try again.");
          setSuccess(null);
          setDeletePopupOpen(false); // Close the pop-up
        });
    }
  };

  return (
    <div style={{ marginTop: "20px" }}>
      <h2>Delete Theatre Show</h2>
      <label htmlFor="deleteId">Enter Theatre Show ID: </label>
      <input
        type="number"
        id="deleteId"
        value={deleteId || ""}
        onChange={(e) => setDeleteId(Number(e.target.value))}
        placeholder="Enter show ID"
      />
      <button
        type="button"
        onClick={() => setDeletePopupOpen(true)}
        disabled={!deleteId}
        style={{ marginLeft: "10px" }}
      >
        Delete Theatre Show
      </button>

      {/* Delete Confirmation Pop-Up */}
      {isDeletePopupOpen && (
        <div
          style={{
            position: "fixed",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
            backgroundColor: "white",
            padding: "20px",
            border: "1px solid black",
            zIndex: 1000,
          }}
        >
          <p>Are you sure you want to delete Theatre Show ID: {deleteId}?</p>
          <button
            onClick={confirmDelete}
            style={{ marginRight: "10px", color: "white", backgroundColor: "red" }}
          >
            Confirm
          </button>
          <button onClick={() => setDeletePopupOpen(false)}>Cancel</button>
        </div>
      )}

      {/* Overlay for the pop-up */}
      {isDeletePopupOpen && (
        <div
          onClick={() => setDeletePopupOpen(false)}
          style={{
            position: "fixed",
            top: 0,
            left: 0,
            width: "100%",
            height: "100%",
            backgroundColor: "rgba(0, 0, 0, 0.5)",
            zIndex: 999,
          }}
        ></div>
      )}

      {/* Display error or success messages */}
      {error && <div style={{ color: "red", marginTop: "10px" }}>{error}</div>}
      {success && <div style={{ color: "green", marginTop: "10px" }}>{success}</div>}
    </div>
  );
};

export default DeleteTheatreShow;
