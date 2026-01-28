import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import { useAuth } from '../context/AuthContext';
// Import icon từ lucide-react (thay thế cho thẻ <i class="fa...">)
import { User, LogOut, ShoppingCart, Search, SlidersHorizontal } from 'lucide-react'; 
import "./Navbar.css";

export default function Navbar() {
    // --- HOOKS ---
    const { cartItems } = useCart();
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    // Tính tổng số lượng giỏ hàng
    const totalItems = cartItems.reduce((total, item) => total + item.quantity, 0);

    // --- STATES CHO TÌM KIẾM & LỌC ---
    const [searchTerm, setSearchTerm] = useState("");
    const [categories, setCategories] = useState([]); 
    const [selectedCategory, setSelectedCategory] = useState("all");
    const [showFilter, setShowFilter] = useState(false); 
    const [priceRange, setPriceRange] = useState({ min: "", max: "" });
    const [sortBy, setSortBy] = useState("newest"); 

    // --- EFFECT: LẤY DANH MỤC TỪ API ---
    useEffect(() => {
        const fetchCategories = async () => {
            try {
                // LƯU Ý: Kiểm tra lại port Backend của bạn (5198, 7215, hay 7000)
                const response = await fetch('http://localhost:5198/api/Categories');
                if (response.ok) {
                    const data = await response.json();
                    setCategories(data);
                }
            } catch (error) {
                console.error("Lỗi kết nối API:", error);
            }
        };
        fetchCategories();
    }, []);

    // --- HANDLERS ---
    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    const handleSearch = (e) => {
        e.preventDefault();
        
        const params = new URLSearchParams();
        if (searchTerm) params.append("keyword", searchTerm);
        
        if (selectedCategory !== "all") {
            params.append("categoryId", selectedCategory); 
        }
        
        if (priceRange.min) params.append("minPrice", priceRange.min);
        if (priceRange.max) params.append("maxPrice", priceRange.max);
        params.append("sort", sortBy);

        setShowFilter(false); // Đóng bảng lọc sau khi tìm
        navigate(`/search?${params.toString()}`); 
    };

    return (
        <nav className="navbar">
            <div className="nav-wrapper">
                {/* 1. LOGO */}
                <Link to="/" className="logo">
                    SHOP<span>DEAL</span>
                </Link>

                {/* 2. SEARCH BOX & FILTER */}
                <div className="search-container">
                    <form className="search-box" onSubmit={handleSearch}>
                        <input 
                            className="search-input" 
                            placeholder="Tìm kiếm sản phẩm..." 
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                        />

                        {/* Nút bật tắt Lọc nâng cao */}
                        <button 
                            type="button" 
                            className={`filter-toggle-btn ${showFilter ? "active" : ""}`}
                            onClick={() => setShowFilter(!showFilter)}
                            title="Bộ lọc tìm kiếm"
                        >
                            <span className="filter-text">Lọc</span> 
                            <SlidersHorizontal size={18} />
                        </button>

                        {/* Nút Submit tìm kiếm */}
                        <button type="submit" className="search-btn">
                            <Search size={20} />
                        </button>
                    </form>

                    {/* --- BẢNG LỌC NÂNG CAO (Dropdown) --- */}
                    {showFilter && (
                        <div className="advanced-filter-panel">
                            {/* Chọn Danh Mục */}
                            <div className="filter-group">
                                <label>Danh mục</label>
                                <select 
                                    className="form-select"
                                    value={selectedCategory}
                                    onChange={(e) => setSelectedCategory(e.target.value)}
                                >
                                    <option value="all">-- Tất cả --</option>
                                    {categories.map((cat) => (
                                        <option key={cat.categoryId} value={cat.categoryId}>
                                            {cat.categoryName}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            {/* Chọn Khoảng giá */}
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

                            {/* Chọn Sắp xếp */}
                            <div className="filter-group">
                                <label>Sắp xếp</label>
                                <select 
                                    className="form-select"
                                    value={sortBy} 
                                    onChange={(e) => setSortBy(e.target.value)}
                                >
                                    <option value="newest">Mới nhất</option>
                                    <option value="price_asc">Giá: Thấp đến Cao</option>
                                    <option value="price_desc">Giá: Cao đến Thấp</option>
                                    <option value="best_sell">Bán chạy nhất</option>
                                </select>
                            </div>
                            
                            {/* Actions */}
                            <div className="filter-actions">
                                <button type="button" onClick={handleSearch} className="apply-filter-btn">
                                    Áp dụng
                                </button>
                            </div>
                        </div>
                    )}
                </div>

                {/* 3. MENU LINKS & AUTH */}
                <div className="nav-links">
                    <Link to="/" className="nav-item">Trang chủ</Link>
                    
                    {/* --- LOGIC HIỂN THỊ USER --- */}
                    {user ? (
                        <div className="user-menu">
                            <Link to="/account" className="user-link">
                                <User size={18} />
                                <span className="user-name-text">{user.name}</span>
                            </Link>
                            <button onClick={handleLogout} className="logout-btn" title="Đăng xuất">
                                <LogOut size={18} />
                            </button>
                        </div>
                    ) : (
                        <Link to="/login" className="nav-item">
                            <User size={18} style={{ marginRight: '5px' }}/>
                            Tài khoản
                        </Link>
                    )}
                    
                    {/* --- GIỎ HÀNG --- */}
                    <Link to="/cart" className="nav-item cart-item">
                        <ShoppingCart size={20} style={{ marginRight: '5px' }} />
                        Giỏ hàng 
                        {totalItems > 0 && <span className="cart-count">{totalItems}</span>}
                    </Link>
                </div>
            </div>
        </nav>
    );
}