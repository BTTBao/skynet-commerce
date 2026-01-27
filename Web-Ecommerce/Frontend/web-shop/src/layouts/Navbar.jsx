import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import "./Navbar.css";

export default function Navbar() {
    const { cartItems } = useCart();
    const totalItems = cartItems.reduce((total, item) => total + item.quantity, 0);
    const navigate = useNavigate();

    // --- STATES ---
    const [searchTerm, setSearchTerm] = useState("");
    const [category, setCategory] = useState("all");
    
    // State cho Lọc nâng cao
    const [showFilter, setShowFilter] = useState(false); 
    const [priceRange, setPriceRange] = useState({ min: "", max: "" });
    const [sortBy, setSortBy] = useState("newest"); 

    // --- HANDLERS ---
    const handleSearch = (e) => {
        e.preventDefault();
        
        const params = new URLSearchParams();
        if (searchTerm) params.append("keyword", searchTerm);
        if (category !== "all") params.append("category", category);
        if (priceRange.min) params.append("minPrice", priceRange.min);
        if (priceRange.max) params.append("maxPrice", priceRange.max);
        params.append("sort", sortBy);

        setShowFilter(false); 
        navigate(`/search?${params.toString()}`); 
    };

    return (
        <nav className="navbar">
            <div className="nav-wrapper">
                <Link to="/" className="logo">SHOP<span>DEAL</span></Link>

                {/* --- SEARCH BOX CONTAINER --- */}
                <div className="search-container">
                    <form className="search-box" onSubmit={handleSearch}>
                        <select 
                            className="search-select"
                            value={category}
                            onChange={(e) => setCategory(e.target.value)}
                        >
                            <option value="all">Tất cả</option>
                            <option value="electronics">Điện tử</option>
                            <option value="fashion">Thời trang</option>
                        </select>
                        
                        <div className="divider">|</div>

                        <input 
                            className="search-input" 
                            placeholder="Tìm kiếm..." 
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                        />

                        {/* Nút Lọc nâng cao (Đã thêm chữ để dễ bấm) */}
                        <button 
                            type="button" 
                            className={`filter-toggle-btn ${showFilter ? "active" : ""}`}
                            onClick={() => setShowFilter(!showFilter)}
                            title="Lọc nâng cao"
                        >
                            <span>Lọc</span> <i className="fa-solid fa-sliders"></i>
                        </button>

                        <button type="submit" className="search-btn">
                            <i className="fa-solid fa-magnifying-glass"></i>
                        </button>
                    </form>

                    {/* --- BẢNG LỌC NÂNG CAO --- */}
                    {showFilter && (
                        <div className="advanced-filter-panel">
                            <div className="filter-group">
                                <label>Khoảng giá (VNĐ)</label>
                                <div className="price-inputs">
                                    <input 
                                        type="number" 
                                        placeholder="Min" 
                                        value={priceRange.min}
                                        onChange={e => setPriceRange({...priceRange, min: e.target.value})}
                                    />
                                    <span>-</span>
                                    <input 
                                        type="number" 
                                        placeholder="Max" 
                                        value={priceRange.max}
                                        onChange={e => setPriceRange({...priceRange, max: e.target.value})}
                                    />
                                </div>
                            </div>

                            <div className="filter-group">
                                <label>Sắp xếp theo</label>
                                <select 
                                    value={sortBy} 
                                    onChange={(e) => setSortBy(e.target.value)}
                                    className="sort-select"
                                >
                                    <option value="newest">Mới nhất</option>
                                    <option value="price_asc">Giá: Thấp đến Cao</option>
                                    <option value="price_desc">Giá: Cao đến Thấp</option>
                                    <option value="best_sell">Bán chạy nhất</option>
                                </select>
                            </div>
                            
                            <button onClick={handleSearch} className="apply-filter-btn">
                                Áp dụng
                            </button>
                        </div>
                    )}
                </div>

                <div className="nav-links">
                    <Link to="/" className="nav-item">Trang chủ</Link>
                    <Link to="/" className="nav-item">Tài khoản</Link>
                    <Link to="/cart" className="nav-item cart">
                        <i className="fa-solid fa-cart-shopping"></i> 
                        <span className="cart-count">{totalItems}</span>
                    </Link>
                </div>
            </div>
        </nav>
    );
}