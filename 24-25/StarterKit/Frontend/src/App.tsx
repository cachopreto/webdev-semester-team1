import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { ShoppingCartProvider } from './contexts/ShoppingCartContext'; // Path to your ShoppingCartContext file
import AdminDashboard from "./pages/AdminDashboard";
import TheatreShowOverviewPage from "./pages/TheatreShowOverviewPage";
import CreateTheatreShowPage from "./pages/CreateTheatreShowPage";
import EditTheatreShowPage from "./pages/EditTheatreShowPage";
import ShowOverview from "./pages/ShowsOverviewPage";
import Reservation from "./pages/Reservation";
import FutureShowsPage from "./pages/FutureShowsPage";
import ReservationOverviewPage from "./pages/ReservationOverviewPage";

const App: React.FC = () => {
  return (
    <ShoppingCartProvider> {/* Wrap the Routes with the ShoppingCartProvider */}
      <Router>
        <Routes>
          <Route path="/" element={<AdminDashboard />} />
          <Route path="/TheatreShowOverviewPage" element={<TheatreShowOverviewPage />} />
          <Route path="/CreateTheatreShowPage" element={<CreateTheatreShowPage />} />
          <Route path="/EditTheatreShowPage/:id" element={<EditTheatreShowPage />} />
          <Route path="/ShowOverviewPage" element={<ShowOverview />} />
          <Route path="/Reservation" element={<Reservation />} />
          <Route path="/FutureShowsPage" element={<FutureShowsPage />} />
          <Route path="/ReservationOverviewPage" element={<ReservationOverviewPage />} />
        </Routes>
      </Router>
    </ShoppingCartProvider>
  );
};

export default App;
