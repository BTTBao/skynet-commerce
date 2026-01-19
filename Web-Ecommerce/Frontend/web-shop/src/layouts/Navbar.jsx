import "./Navbar.css";

export default function Navbar() {
    return (
        <nav className="navbar">
            <div className="nav-wrapper">
                <div className="logo">SHOP<span>DEAL</span></div>

                <div className="search-box">
                    <input className="search-input" placeholder="Tìm sản phẩm, thương hiệu..." />
                    <button className="search-btn">
                        <i className="fa-solid fa-magnifying-glass"></i> Tìm
                    </button>
                </div>
                <div className="nav-links">
                    <div className="nav-item">Trang chủ</div>
                    <div className="nav-item">Tài khoản</div>
                    <div className="nav-item cart">
                        Giỏ hàng <span>(0)</span>
                    </div>
                </div>
            </div>
        </nav>
    );
}