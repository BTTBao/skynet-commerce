import "./Navbar.css";
export default function Navbar() {
    return (
        <div className="navbar">
            <div className="list-menu">
                <div className="logo">Logo đây</div>
                <div className="search-box">
                    <input className="search" placeholder="Search..." />
                    <button className="search-btn">Tìm</button>
                </div>
                <div className="home">trang chủ</div>
                <div className="account">tài khoản</div>
            </div>
        </div>
    )
}