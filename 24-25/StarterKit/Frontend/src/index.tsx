// import * as React from "react";
// import { createRoot } from 'react-dom/client';

// import { BrowserRouter, Routes, Route } from 'react-router-dom';
// import Home from "./pages/Home";
// import { ReservationPage } from "./pages/Reservation";
// import { ShoppingCartProvider } from "./contexts/ShoppingCartContext";

// createRoot(document.getElementById('root')!)
//     .render(
//         <React.StrictMode>
//             <ShoppingCartProvider>
//                 <BrowserRouter>
//                 <Routes>
//                     <Route path="/" element={<Home />} />
//                     <Route path="/reservation/:showDateId" element={<ReservationPage />} />
//                 </Routes>
//                 </BrowserRouter>
//             </ShoppingCartProvider>
//         </React.StrictMode>
//     );

// import * as React from "react";
// import { createRoot } from 'react-dom/client';
// import App from "./App";  // Import App component

// createRoot(document.getElementById('root')!).render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>
// );


import React from 'react';
import { createRoot } from 'react-dom/client';
import './styles/login.css';
import App from './App';

const container = document.getElementById('root');
if (!container) throw new Error('Failed to find the root element');
const root = createRoot(container);

root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
