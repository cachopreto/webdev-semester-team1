import React, { useState, useEffect } from "react";
import { getTheatreShowById, updateTheatreShow } from "../services/TheatreShowService";

interface EditTheatreShowFormProps {
  id: number; // ID of the theatre show to edit
}

const EditTheatreShowForm: React.FC<EditTheatreShowFormProps> = ({ id }) => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState<number | "">("");
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);

  // Fetch the theatre show details when the component mounts
  useEffect(() => {
    getTheatreShowById(id)
      .then((data) => {
        setTitle(data.title);
        setDescription(data.description);
        setPrice(data.price);
      })
      .catch(() => {
        setError("Failed to fetch theatre show details.");
      });
  }, [id]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
  
    const updatedShow = {
      title: title.trim(),
      description: description.trim(),
      price: Number(price),
    };
  
    updateTheatreShow(id, updatedShow)
      .then(() => {
        setSuccess("Theatre show updated successfully!");
        setError(null);
      })
      .catch((error) => {
        setError("Failed to update theatre show. Please try again.");
        setSuccess(null);
      });
  };
  

  return (
    <div>
      <h2>Edit Theatre Show</h2>
      {error && <div style={{ color: "red" }}>{error}</div>}
      {success && <div style={{ color: "green" }}>{success}</div>}
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="title">Title:</label>
          <input
            id="title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            placeholder="Enter the show title"
            required
          />
        </div>
        <div>
          <label htmlFor="description">Description:</label>
          <input
            id="description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            placeholder="Enter the show description"
            required
          />
        </div>
        <div>
          <label htmlFor="price">Price:</label>
          <input
            id="price"
            type="number"
            value={price}
            onChange={(e) => setPrice(Number(e.target.value))}
            placeholder="Enter the ticket price"
            required
          />
        </div>
        <button type="submit">Update Theatre Show</button>
      </form>
    </div>
  );
};

export default EditTheatreShowForm;
