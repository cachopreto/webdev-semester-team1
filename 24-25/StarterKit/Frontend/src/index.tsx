// import * as React from "react";
// import { createRoot } from 'react-dom/client';
// import Home from "./pages/Home";

// createRoot(document.getElementById('root')!)
//     .render(<React.StrictMode>
//         <Home />
//     </React.StrictMode>)
import React from 'react';
import ReactDOM from 'react-dom';
import './styles/login.css';
import App from './App';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);
