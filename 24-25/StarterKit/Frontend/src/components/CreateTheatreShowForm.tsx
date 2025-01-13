import React, { useState } from "react";
import { createTheatreShow } from "../services/TheatreShowService";

const CreateTheatreShowForm: React.FC = () => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState<number | "">("");
  const [venueName, setVenueName] = useState("");
  const [venueCapacity, setVenueCapacity] = useState<number | "">("");
  const [dates, setDates] = useState<string[]>([]);
  const [dateInput, setDateInput] = useState("");

  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    // Construct the payload
    const newTheatreShow = {
      title,
      description,
      price: Number(price),
      venue: { name: venueName, capacity: Number(venueCapacity) },
      theatreShowDates: dates.map((date) => ({ dateAndTime: date })),
    };

    // Send the POST request
    createTheatreShow(newTheatreShow)
      .then(() => {
        setSuccess("Theatre show created successfully!");
        setError(null);
        // Clear the form
        setTitle("");
        setDescription("");
        setPrice("");
        setVenueName("");
        setVenueCapacity("");
        setDates([]);
      })
      .catch(() => {
        setError("Failed to create theatre show. Please try again.");
        setSuccess(null);
      });
  };

  const handleAddDate = () => {
    if (dateInput.trim()) {
      setDates([...dates, dateInput]);
      setDateInput("");
    }
  };

  return (
    <div>
      <h2>Create a New Theatre Show</h2>
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
        <div>
          <label htmlFor="venueName">Venue Name:</label>
          <input
            id="venueName"
            value={venueName}
            onChange={(e) => setVenueName(e.target.value)}
            placeholder="Enter the venue name"
            required
          />
        </div>
        <div>
          <label htmlFor="venueCapacity">Venue Capacity:</label>
          <input
            id="venueCapacity"
            type="number"
            value={venueCapacity}
            onChange={(e) => setVenueCapacity(Number(e.target.value))}
            placeholder="Enter the venue capacity"
            required
          />
        </div>
        <div>
          <label htmlFor="dateInput">Add Show Dates:</label>
          <input
            id="dateInput"
            type="datetime-local"
            value={dateInput}
            onChange={(e) => setDateInput(e.target.value)}
            placeholder="Select date and time"
          />
          <button type="button" onClick={handleAddDate}>
            Add Date
          </button>
        </div>
        <div>
          <h4>Show Dates:</h4>
          <ul>
            {dates.map((date, index) => (
              <li key={index}>{new Date(date).toLocaleString()}</li>
            ))}
          </ul>
        </div>
        <button type="submit">Create Theatre Show</button>
      </form>
    </div>
  );
};

export default CreateTheatreShowForm;
