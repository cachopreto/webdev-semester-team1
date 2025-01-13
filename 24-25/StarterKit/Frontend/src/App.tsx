import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AdminDashboard from "./pages/AdminDashboard";
import TheatreShowOverviewPage from "./pages/TheatreShowOverviewPage";
import CreateTheatreShowPage from "./pages/CreateTheatreShowPage"; // Import the page

const App: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<AdminDashboard />} />
        <Route path="/TheatreShowOverviewPage" element={<TheatreShowOverviewPage />} />
        <Route path="/CreateTheatreShowPage" element={<CreateTheatreShowPage />} />
      </Routes>
    </Router>
  );
};

export default App;
