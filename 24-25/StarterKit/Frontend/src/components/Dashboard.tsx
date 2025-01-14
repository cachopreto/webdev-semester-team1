import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import "../styles/dashboard.css";

const Dashboard = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState<string>("");

  useEffect(() => {
    const checkSession = async () => {
      try {
        const response = await fetch("http://localhost:5097/api/Admin/isLoggedIn", {
          credentials: 'include'
        });
        const data = await response.json();
        
        if (!data.isLoggedIn) {
          navigate("/login");
        } else {
          setUsername(data.username);
        }
      } catch (error) {
        navigate("/login");
      }
    };

    checkSession();
  }, [navigate]);

  const handleLogout = async () => {
    try {
      // Clear the session cookie by navigating
      navigate("/login");
    } catch (error) {
      console.error("Logout failed:", error);
    }
  };

  return (
    <div className="dashboard-container">
      <div className="dashboard-header">
        <h2>Welcome, {username}!</h2>
        <div style={{ display: 'flex', gap: '10px' }}>
          <button 
            onClick={() => navigate("/")} 
            className="back-button"
            style={{
              padding: '8px 16px',
              backgroundColor: '#6c757d',
              color: 'white',
              border: 'none',
              borderRadius: '4px',
              cursor: 'pointer'
            }}
          >
            Back to Home
          </button>
          <button onClick={handleLogout} className="logout-button">
            Logout
          </button>
        </div>
      </div>
      <div className="dashboard-content">
        <p>This is your admin dashboard. You can manage your content here.</p>
      </div>
    </div>
  );
};

export default Dashboard;
