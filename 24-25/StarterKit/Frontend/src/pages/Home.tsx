import { Link } from "react-router-dom";
import "../styles/login.css"; 

const Home = () => {
  return (
    <div className="home-container">
      <header>
        <h1>🎬 Welcome to Zoro</h1>
        <p>Your gateway to an exclusive cinema experience.</p>
      </header>

      <div className="home-content">
        <p>Enjoy seamless booking, admin control, and real-time movie updates.</p>
        <Link to="/login" className="btn btn-primary">
          Admin Login
        </Link>
      </div>
    </div>
  );
};

export default Home;
