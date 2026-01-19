import Navbar from "../layouts/Navbar";
import "./HomePage.css";
function HomePage()
{
    return (
        <div>
            <Navbar/>
            <div className="container">
                <div className="wrapper">
                    <div className="list-item">
                        <div className="item">1</div>
                        <div className="item">2</div>
                        <div className="item">1</div>
                        <div className="item">2</div>
                    </div>
                </div>
            </div>

        </div>
    )
}

export default HomePage;