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
import Home from "./pages/Home";
import Login from "./components/Login";
import Dashboard from "./components/Dashboard";

const App: React.FC = () => {
  return (
    <ShoppingCartProvider> {/* Wrap the Routes with the ShoppingCartProvider */}
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/TheatreShowOverviewPage" element={<TheatreShowOverviewPage />} />
          <Route path="/CreateTheatreShowPage" element={<CreateTheatreShowPage />} />
          <Route path="/EditTheatreShowPage/:id" element={<EditTheatreShowPage />} />
          <Route path="/ShowOverviewPage" element={<ShowOverview />} />
          <Route path="/Reservation" element={<Reservation />} />
          <Route path="/FutureShowsPage" element={<FutureShowsPage />} />
          <Route path="/ReservationOverviewPage" element={<ReservationOverviewPage />} />
          <Route path="/AdminDashboard" element={<AdminDashboard />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Dashboard" element={<Dashboard />} />
        </Routes>
      </Router>
    </ShoppingCartProvider>
  );
};

export default App;


// import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
// import Home from "./pages/Home";
// import Login from "./components/Login";
// import Dashboard from "./components/Dashboard";
// import PrivateRoute from "./components/PrivateRoute";

// function App() {
//   return (
//     <Router>
//       <Routes>
//         <Route path="/" element={<Home />} />
//         <Route path="/login" element={<Login />} />
//         <Route element={<PrivateRoute />}>
//           <Route path="/dashboard" element={<Dashboard />} />
//         </Route>
//       </Routes>
//     </Router>
//   );
// }

// export default App;