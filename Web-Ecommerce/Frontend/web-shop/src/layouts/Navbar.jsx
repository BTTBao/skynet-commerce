import React from 'react';
import { Link } from 'react-router-dom'; // 1. Import Link
import { useCart } from '../context/CartContext'; // 2. Import Context
import "./Navbar.css";

export default function Navbar() {
    const { cartItems } = useCart(); // Lấy dữ liệu giỏ hàng

    // 3. Tính tổng số lượng sản phẩm (Ví dụ: mua 2 áo + 3 quần = 5)
    const totalItems = cartItems.reduce((total, item) => total + item.quantity, 0);

    return (
        <nav className="navbar">
            <div className="nav-wrapper">
                {/* Click Logo về trang chủ */}
                <Link to="/" className="logo">
                    SHOP<span>DEAL</span>
                </Link>

                <div className="search-box">
                    <input className="search-input" placeholder="Tìm sản phẩm, thương hiệu..." />
                    <button className="search-btn">
                        <i className="fa-solid fa-magnifying-glass"></i> Tìm
                    </button>
                </div>

                <div className="nav-links">
                    {/* Click chữ Trang chủ cũng về trang chủ */}
                    <Link to="/" className="nav-item">Trang chủ</Link>
                    
                    <div className="nav-item">Tài khoản</div>
                    
                    {/* Click Giỏ hàng sang trang Cart */}
                    <Link to="/cart" className="nav-item cart">
                        <i className="fa-solid fa-cart-shopping"></i> Giỏ hàng 
                        <span className="cart-count">({totalItems})</span>
                    </Link>
                </div>
            </div>
        </nav>
    );
}