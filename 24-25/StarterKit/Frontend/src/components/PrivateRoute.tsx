import { Navigate, Outlet } from "react-router-dom";
import { useState, useEffect } from "react";

const PrivateRoute = () => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean | null>(null);

  useEffect(() => {
    const checkAuth = async () => {
      try {
        const response = await fetch("http://localhost:5097/api/Admin/isLoggedIn", {
          credentials: 'include'
        });
        const data = await response.json();
        setIsAuthenticated(data.isLoggedIn);
      } catch (error) {
        setIsAuthenticated(false);
      }
    };

    checkAuth();
  }, []);

  // Show loading while checking authentication
  if (isAuthenticated === null) {
    return <div>Loading...</div>;
  }

  return isAuthenticated ? <Outlet /> : <Navigate to="/login" />;
};

export default PrivateRoute;
