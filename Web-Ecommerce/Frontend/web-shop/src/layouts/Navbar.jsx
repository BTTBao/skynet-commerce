import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import "./Navbar.css";

export default function Navbar() {
    const { cartItems } = useCart();
    const totalItems = cartItems.reduce((total, item) => total + item.quantity, 0);
    const navigate = useNavigate();

    // --- STATES ---
    const [searchTerm, setSearchTerm] = useState("");
    
    // State dữ liệu danh mục từ API
    const [categories, setCategories] = useState([]); 
    
    // State danh mục đang chọn
    const [selectedCategory, setSelectedCategory] = useState("all");

    // State cho Lọc nâng cao
    const [showFilter, setShowFilter] = useState(false); 
    const [priceRange, setPriceRange] = useState({ min: "", max: "" });
    const [sortBy, setSortBy] = useState("newest"); 

    // --- EFFECT: LẤY DỮ LIỆU TỪ API ---
    useEffect(() => {
        const fetchCategories = async () => {
            try {
                // Nhớ đổi port 7000 thành port backend thực tế của bạn
                const response = await fetch('https://localhost:7215/api/Categories');
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
    const handleSearch = (e) => {
        e.preventDefault(); // Ngăn reload trang
        
        const params = new URLSearchParams();
        if (searchTerm) params.append("keyword", searchTerm);
        
        // Logic lọc: Nếu khác 'all' thì đẩy categoryId lên URL
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
                <Link to="/" className="logo">SHOP<span>DEAL</span></Link>

                {/* --- SEARCH BOX CONTAINER --- */}
                <div className="search-container">
                    <form className="search-box" onSubmit={handleSearch}>
                        {/* Đã xóa phần <select> danh mục ở đây cho gọn */}

                        <input 
                            className="search-input" 
                            placeholder="Tìm kiếm sản phẩm..." 
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                            // Bỏ padding-left lớn nếu trước đó CSS có set cho chỗ dropdown
                            style={{ paddingLeft: '15px' }} 
                        />

                        {/* Nút bật tắt Lọc nâng cao */}
                        <button 
                            type="button" 
                            className={`filter-toggle-btn ${showFilter ? "active" : ""}`}
                            onClick={() => setShowFilter(!showFilter)}
                            title="Bộ lọc tìm kiếm"
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
                            
                            {/* 1. Phần chọn Danh Mục (Mới thêm vào đây) */}
                            <div className="filter-group">
                                <label>Danh mục sản phẩm</label>
                                <select 
                                    className="sort-select" // Tái sử dụng class style của select bên dưới
                                    value={selectedCategory}
                                    onChange={(e) => setSelectedCategory(e.target.value)}
                                >
                                    <option value="all">-- Tất cả danh mục --</option>
                                    {categories.map((cat) => (
                                        <option key={cat.categoryId} value={cat.categoryId}>
                                            {cat.categoryName}
                                        </option>
                                    ))}
                                </select>
                            </div>

                            {/* 2. Phần chọn Khoảng giá */}
                            <div className="filter-group">
                                <label>Khoảng giá (VNĐ)</label>
                                <div className="price-inputs">
                                    <input 
                                        type="number" 
                                        placeholder="Tối thiểu" 
                                        value={priceRange.min}
                                        onChange={e => setPriceRange({...priceRange, min: e.target.value})}
                                    />
                                    <span>-</span>
                                    <input 
                                        type="number" 
                                        placeholder="Tối đa" 
                                        value={priceRange.max}
                                        onChange={e => setPriceRange({...priceRange, max: e.target.value})}
                                    />
                                </div>
                            </div>

                            {/* 3. Phần Sắp xếp */}
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
                            
                            {/* Nút Áp dụng */}
                            <div className="filter-actions">
                                <button type="button" onClick={handleSearch} className="apply-filter-btn">
                                    Xem kết quả
                                </button>
                            </div>
                        </div>
                    )}
                </div>

                <div className="nav-links">
                    <Link to="/" className="nav-item">Trang chủ</Link>
                    <Link to="/account" className="nav-item">Tài khoản</Link>
                    <Link to="/cart" className="nav-item cart">
                        <i className="fa-solid fa-cart-shopping"></i> 
                        <span className="cart-count">{totalItems}</span>
                    </Link>
                </div>
            </div>
        </nav>
    );
}