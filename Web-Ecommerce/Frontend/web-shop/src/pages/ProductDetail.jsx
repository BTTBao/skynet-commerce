import { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import { useCart } from "../context/CartContext";
import Navbar from "../layouts/Navbar";
import "./ProductDetail.css";

function ProductDetail() {
    const { id } = useParams();
    const { addToCart } = useCart();
    
    const [product, setProduct] = useState(null);
    const [shop, setShop] = useState(null);
    const [loading, setLoading] = useState(true);
    
    // State UI
    const [mainImage, setMainImage] = useState("");
    const [selectedSize, setSelectedSize] = useState("");
    const [selectedColor, setSelectedColor] = useState("");
    const [quantity, setQuantity] = useState(1);

    useEffect(() => {
        const fetchProductDetail = async () => {
            try {
                // 1. Gọi API lấy Product
                const response = await fetch(`https://localhost:7215/api/products/${id}`);
                if (!response.ok) throw new Error("Lỗi tải sản phẩm");
                const productData = await response.json();
                
                setProduct(productData);

                // Setup ảnh chính
                const primaryImg = productData.productImages?.find(img => img.isPrimary) || productData.productImages?.[0];
                setMainImage(primaryImg?.imageUrl || "https://via.placeholder.com/500");
                
                // Setup variant mặc định (Chọn cái đầu tiên nếu có)
                if(productData.productVariants?.length > 0) {
                     setSelectedSize(productData.productVariants[0].size);
                     setSelectedColor(productData.productVariants[0].color);
                }

                // 2. Xử lý lấy thông tin Shop
                if (productData.shop) {
                    setShop(productData.shop);
                } 
                else if (productData.shopId) {
                    const shopRes = await fetch(`https://localhost:7215/api/shops/${productData.shopId}`);
                    if (shopRes.ok) {
                        const shopData = await shopRes.json();
                        setShop(shopData);
                    }
                }

            } catch (error) {
                console.error(error);
            } finally {
                setLoading(false);
            }
        };
        fetchProductDetail();
    }, [id]);

    const handleAddToCart = () => {
        if (!product) return;
        
        const hasVariants = product.productVariants && product.productVariants.length > 0;
        if (hasVariants && (!selectedSize || !selectedColor)) {
            alert("Vui lòng chọn Size và Màu sắc!");
            return;
        }

        addToCart(
            {
                id: product.productId,
                name: product.name,
                price: product.price, 
                img: mainImage
            }, 
            quantity, 
            { size: selectedSize, color: selectedColor }
        );
    };

    if (loading) return <div className="loading-screen">Đang tải...</div>;
    if (!product) return <div className="error-screen">Không tìm thấy sản phẩm!</div>;

    // Lọc danh sách Size và Color duy nhất từ Variants
    const uniqueSizes = [...new Set(product.productVariants?.map(v => v.size).filter(Boolean))];
    const uniqueColors = [...new Set(product.productVariants?.map(v => v.color).filter(Boolean))];
    const unitPrice = Number(product.price) || 0;

    return (
        <>
            <div className="detail-container">
                <div className="detail-wrapper">
                    
                    {/* CỘT TRÁI: ẢNH */}
                    <div className="product-gallery">
                        <div className="main-image-frame">
                            <img src={mainImage} alt={product.name} className="main-img" />
                        </div>
                        <div className="thumbnail-list">
                            {product.productImages?.map((img) => (
                                <img 
                                    key={img.imageId || Math.random()}
                                    src={img.imageUrl} 
                                    alt="thumb"
                                    className={`thumb-img ${mainImage === img.imageUrl ? "active" : ""}`}
                                    onClick={() => setMainImage(img.imageUrl)}
                                />
                            ))}
                        </div>
                    </div>

                    {/* CỘT PHẢI: THÔNG TIN */}
                    <div className="product-info">
                        <h1 className="product-name">{product.name}</h1>
                        
                        <div className="product-meta">
                            <span>Đã bán: <strong>{product.soldCount || 0}</strong></span>
                            <span> | </span>
                            <span>Tình trạng: <strong>{product.stockQuantity > 0 ? "Còn hàng" : "Hết hàng"}</strong></span>
                        </div>

                        <p className="product-price">{unitPrice.toLocaleString()}đ</p>

                        <div className="product-description">
                             <p>{product.description}</p>
                        </div>
                        
                        <hr className="divider" />
                        
                        {/* --- BẮT ĐẦU PHẦN VARIANT (SIZE/COLOR) ĐƯỢC THÊM LẠI --- */}
                        
                        {/* 1. Chọn Size */}
                        {uniqueSizes.length > 0 && (
                            <div className="variant-group">
                                <span className="variant-label">Kích thước:</span>
                                <div className="variant-options">
                                    {uniqueSizes.map((size) => (
                                        <button 
                                            key={size} 
                                            className={`variant-btn ${selectedSize === size ? "active" : ""}`}
                                            onClick={() => setSelectedSize(size)}
                                        >
                                            {size}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        )}

                        {/* 2. Chọn Màu */}
                        {uniqueColors.length > 0 && (
                            <div className="variant-group">
                                <span className="variant-label">Màu sắc:</span>
                                <div className="variant-options">
                                    {uniqueColors.map((color) => (
                                        <button 
                                            key={color} 
                                            className={`variant-btn ${selectedColor === color ? "active" : ""}`}
                                            onClick={() => setSelectedColor(color)}
                                        >
                                            {color}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        )}
                        {/* --- KẾT THÚC PHẦN VARIANT --- */}

                        <div className="purchase-area">
                            <div className="quantity-wrapper">
                                <span className="variant-label">Số lượng:</span>
                                <div className="quantity-control">
                                    <button onClick={() => setQuantity(Math.max(1, quantity - 1))}>-</button>
                                    <input type="text" value={quantity} readOnly />
                                    <button onClick={() => setQuantity(quantity + 1)}>+</button>
                                </div>
                            </div>
                            <button className="add-to-cart-btn full-width" onClick={handleAddToCart}>
                                <i className="fa fa-shopping-cart"></i> Thêm Vào Giỏ Hàng
                            </button>
                        </div>

                        {/* --- PHẦN SHOP INFO --- */}
                        {shop && (
                            <div className="shop-info-card">
                                <div className="shop-header-left">
                                    <img 
                                        src={shop.avatarUrl || "https://via.placeholder.com/150"} 
                                        alt={shop.shopName} 
                                        className="shop-avatar" 
                                    />
                                    {shop.ratingAverage >= 4.5 && <span className="official-badge">Mall</span>}
                                </div>
                                
                                <div className="shop-details-right">
                                    <h4 className="shop-name">{shop.shopName}</h4>
                                    
                                    <div className="shop-stats">
                                        <span><i className="fa fa-star" style={{color:'#ffce3d'}}></i> {shop.ratingAverage ? shop.ratingAverage.toFixed(1) : "N/A"}</span>
                                        <span className="divider-vertical">|</span>
                                        <span style={{color: shop.isActive ? 'green' : 'gray'}}>
                                            {shop.isActive ? "Đang hoạt động" : "Nghỉ bán"}
                                        </span>
                                    </div>
                                    
                                    <div className="shop-actions">
                                        <button className="btn-chat"><i className="fa-regular fa-message"></i> Chat</button>
                                        <Link to={`/shop-profile/${shop.shopId}`} className="btn-view-shop">
                                            <i className="fa-solid fa-store"></i> Xem Shop
                                        </Link>
                                    </div>
                                </div>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </>
    );
}
export default ProductDetail;