import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom"; // Bỏ useLocation, chỉ cần useParams
import Navbar from "../layouts/Navbar";
import ProductCard from "../components/ProductCard";
import "./SellerShopPage.css"; 

function SellerShopPage() {
    const { shopId } = useParams(); // Lấy ID từ URL (VD: shopId = 1)
    
    const [shop, setShop] = useState(null);
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [activeTab, setActiveTab] = useState('products');

    // Hàm an toàn để lấy dữ liệu (Do backend có thể trả về hoa/thường)
    const getVal = (obj, keyLower, keyUpper) => {
        if (!obj) return null;
        return obj[keyLower] !== undefined ? obj[keyLower] : obj[keyUpper];
    };

    const formatDate = (dateString) => {
        if (!dateString) return "Mới tham gia";
        return new Date(dateString).toLocaleDateString('vi-VN');
    };

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                // Chạy song song 2 API để tiết kiệm thời gian
                const [shopRes, prodRes] = await Promise.all([
                    fetch(`https://localhost:7215/api/shops/${shopId}`),
                    fetch(`https://localhost:7215/api/products`)
                ]);

                // 1. Xử lý dữ liệu Shop
                if (shopRes.ok) {
                    const shopData = await shopRes.json();
                    setShop(shopData);
                } else {
                    console.error("Không tìm thấy shop");
                    setShop(null);
                }

                // 2. Xử lý dữ liệu Sản phẩm
                if (prodRes.ok) {
                    const prodData = await prodRes.json();
                    const currentShopId = parseInt(shopId);
                    
                    // Lọc sản phẩm thuộc shop này
                    const shopProducts = prodData.filter(p => 
                        (p.shopId === currentShopId) || 
                        (p.ShopId === currentShopId) || 
                        (p.shop?.shopId === currentShopId)
                    );
                    setProducts(shopProducts);
                }

            } catch (error) {
                console.error("Lỗi kết nối API:", error);
            } finally {
                setLoading(false);
            }
        };

        if (shopId) {
            fetchData();
        }
    }, [shopId]); // Khi URL thay đổi ID -> Gọi lại API ngay

    if (loading) return <div className="loading-container">Đang tải dữ liệu Shop...</div>;
    
    // Nếu load xong mà vẫn không có shop (do ID sai hoặc API lỗi)
    if (!shop) return (
        <>
            <Navbar />
            <div className="error-container" style={{padding: '50px', textAlign: 'center'}}>
                <h2>Không tìm thấy Shop có ID: {shopId}</h2>
                <p>Vui lòng kiểm tra lại đường dẫn.</p>
            </div>
        </>
    );

    // Chuẩn bị dữ liệu hiển thị (Dùng getVal để tránh lỗi null)
    const displayShop = {
        name: getVal(shop, 'shopName', 'ShopName'),
        avatar: getVal(shop, 'avatarUrl', 'AvatarUrl'),
        cover: getVal(shop, 'coverImageUrl', 'CoverImageUrl'),
        desc: getVal(shop, 'description', 'Description'),
        rating: getVal(shop, 'ratingAverage', 'RatingAverage'),
        followers: getVal(shop, 'followers', 'Followers') || 0, // Entity chưa có thì để 0
        joinDate: getVal(shop, 'createdAt', 'CreatedAt'),
        isActive: getVal(shop, 'isActive', 'IsActive')
    };

    return (
        <>
            <div className="seller-shop-container">
                
                {/* --- HEADER --- */}
                <div className="shop-header-section">
                    <div 
                        className="shop-cover-bg" 
                        style={{ backgroundImage: `url(${displayShop.cover || 'https://via.placeholder.com/1200x300'})` }}
                    ></div>

                    <div className="shop-info-wrapper">
                        <div className="shop-profile-card">
                            <div className="shop-avatar-box">
                                <img src={displayShop.avatar || "https://via.placeholder.com/150"} alt={displayShop.name} />
                                {displayShop.isActive && <span className="status-badge">Online</span>}
                            </div>
                            
                            <div className="shop-details-main">
                                <h1 className="shop-name-title">{displayShop.name}</h1>
                                <div className="shop-actions-row">
                                    <button className="btn-action follow">+ Theo Dõi</button>
                                    <button className="btn-action chat"><i className="fa-regular fa-message"></i> Chat Ngay</button>
                                </div>
                            </div>
                        </div>

                        <div className="shop-stats-grid">
                            <div className="stat-item">
                                <i className="fa fa-box-open"></i>
                                <span>Sản phẩm: <strong>{products.length}</strong></span>
                            </div>
                            <div className="stat-item">
                                <i className="fa fa-star"></i>
                                <span>Đánh giá: <strong>{displayShop.rating ? Number(displayShop.rating).toFixed(1) : 0}/5.0</strong></span>
                            </div>
                            <div className="stat-item">
                                <i className="fa fa-user-plus"></i>
                                <span>Người theo dõi: <strong>{displayShop.followers}</strong></span>
                            </div>
                             <div className="stat-item">
                                <i className="fa fa-clock"></i>
                                <span>Tham gia: <strong>{formatDate(displayShop.joinDate)}</strong></span>
                            </div>
                        </div>
                    </div>
                </div>

                {/* --- TABS --- */}
                <div className="shop-nav-tabs">
                    <button 
                        className={`tab-item ${activeTab === 'products' ? 'active' : ''}`}
                        onClick={() => setActiveTab('products')}
                    >
                        Tất cả sản phẩm
                    </button>
                    <button 
                        className={`tab-item ${activeTab === 'about' ? 'active' : ''}`}
                        onClick={() => setActiveTab('about')}
                    >
                        Hồ sơ Shop
                    </button>
                </div>

                {/* --- BODY --- */}
                <div className="shop-body-content">
                    
                    {/* TAB: PRODUCTS */}
                    {activeTab === 'products' && (
                        <>
                            <div className="shop-filter-bar">
                                <span>Sắp xếp theo:</span>
                                <button className="filter-opt active">Phổ biến</button>
                                <button className="filter-opt">Mới nhất</button>
                                <select className="price-sort">
                                    <option>Giá: Thấp đến Cao</option>
                                    <option>Giá: Cao đến Thấp</option>
                                </select>
                            </div>

                            <div className="product-grid">
                                {products.map((item) => (
                                    <ProductCard 
                                        key={item.productId || item.ProductId} 
                                        product={{
                                            ...item,
                                            id: getVal(item, 'productId', 'ProductId'), 
                                            name: getVal(item, 'name', 'Name'),
                                            price: getVal(item, 'price', 'Price'),
                                            img: (item.productImages?.[0]?.imageUrl) || (item.ProductImages?.[0]?.ImageUrl) || "https://via.placeholder.com/300", 
                                            ratingAverage: getVal(item, 'ratingAverage', 'RatingAverage'),
                                            soldCount: getVal(item, 'soldCount', 'SoldCount')
                                        }} 
                                    />
                                ))}
                            </div>
                            {products.length === 0 && <div className="empty-state">Shop này chưa đăng bán sản phẩm nào.</div>}
                        </>
                    )}

                    {/* TAB: ABOUT */}
                    {activeTab === 'about' && (
                        <div className="shop-about-section">
                            <h3>Giới thiệu về {displayShop.name}</h3>
                            <div className="about-content">
                                {displayShop.desc ? (
                                    displayShop.desc.split('\n').map((line, index) => (
                                        <p key={index}>{line}</p>
                                    ))
                                ) : (
                                    <p style={{color: '#888'}}>Shop chưa cập nhật mô tả.</p>
                                )}
                            </div>
                        </div>
                    )}
                </div>
            </div>
        </>
    );
}

export default SellerShopPage;