import { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import { useCart } from "../context/CartContext";
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
                const response = await fetch(`http://localhost:5198/api/products/${id}`);
                if (!response.ok) throw new Error("Lỗi tải sản phẩm");
                const productData = await response.json();
                
                setProduct(productData);

                // Setup ảnh chính
                const primaryImg = productData.productImages?.find(img => img.isPrimary) || productData.productImages?.[0];
                setMainImage(primaryImg?.imageUrl || "https://via.placeholder.com/500");
                
                // Setup variant mặc định
                if(productData.productVariants?.length > 0) {
                     setSelectedSize(productData.productVariants[0].size);
                     setSelectedColor(productData.productVariants[0].color);
                }

                if (productData.shop) {
                    setShop(productData.shop);
                } 
                else if (productData.shopId) {
                    const shopRes = await fetch(`http://localhost:5198/api/shops/${productData.shopId}`);
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

        // Logic check tồn kho khi thêm vào giỏ
        if (currentStock <= 0) {
            alert("Sản phẩm tạm thời hết hàng!");
            return;
        }
        if (quantity > currentStock) {
            alert(`Chỉ còn lại ${currentStock} sản phẩm!`);
            return;
        }

        addToCart(
            {
                id: product.productId,
                name: product.name,
                price: currentPrice, // Dùng giá hiện tại (có thể là giá variant)
                img: mainImage
            }, 
            quantity, 
            { size: selectedSize, color: selectedColor }
        );
    };

    if (loading) return <div className="loading-screen">Đang tải...</div>;
    if (!product) return <div className="error-screen">Không tìm thấy sản phẩm!</div>;

    // --- LOGIC MỚI: TÍNH TOÁN STOCK VÀ PRICE ---
    
    // 1. Tìm variant đang được chọn (Match cả Size và Color)
    const selectedVariant = product.productVariants?.find(
        v => v.size === selectedSize && v.color === selectedColor
    );

    // 2. Xác định hiển thị Stock
    let currentStock = product.stockQuantity || 0; // Mặc định là tổng stock
    let stockLabel = "Tổng kho"; // Nhãn hiển thị cho rõ nghĩa (tuỳ chọn)

    // Nếu sản phẩm CÓ variants
    if (product.productVariants && product.productVariants.length > 0) {
        if (selectedVariant) {
            // Trường hợp tìm thấy Variant cụ thể
            currentStock = selectedVariant.stockQuantity || 0;
            stockLabel = "Kho (Phân loại)";
        } else if (selectedSize && selectedColor) {
            // Đã chọn Size+Color nhưng không tìm thấy trong list (Combo không tồn tại)
            currentStock = 0;
        }
        // Nếu chưa chọn đủ Size/Color, giữ nguyên currentStock là product.stockQuantity
    }

    // 3. Xác định hiển thị Giá (Nếu Variant có giá riêng)
    let currentPrice = product.price || 0;
    if (selectedVariant && selectedVariant.price) {
        currentPrice = selectedVariant.price;
    }

    // Lọc danh sách Size và Color duy nhất để render nút bấm
    const uniqueSizes = [...new Set(product.productVariants?.map(v => v.size).filter(Boolean))];
    const uniqueColors = [...new Set(product.productVariants?.map(v => v.color).filter(Boolean))];

    return (
        <>
            <div className="detail-container">
                <div className="detail-wrapper">
                    
                    {/* CỘT TRÁI: ẢNH (Giữ nguyên) */}
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
                            
                            {/* --- CHỖ NÀY ĐÃ SỬA: Hiển thị Stock động --- */}
                            <span>
                                Tình trạng: 
                                <span style={{ color: currentStock > 0 ? 'green' : 'red', marginLeft: '5px' }}>
                                    {currentStock > 0 ? `Còn hàng (${currentStock})` : "Hết hàng"}
                                </span>
                            </span>
                        </div>

                        {/* Hiển thị giá động (theo variant nếu có) */}
                        <p className="product-price">{Number(currentPrice).toLocaleString()}đ</p>

                        <div className="product-description">
                             <p>{product.description}</p>
                        </div>
                        
                        <hr className="divider" />
                        
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

                        <div className="purchase-area">
                            <div className="quantity-wrapper">
                                <span className="variant-label">Số lượng:</span>
                                <div className="quantity-control">
                                    <button onClick={() => setQuantity(Math.max(1, quantity - 1))}>-</button>
                                    <input type="text" value={quantity} readOnly />
                                    {/* Giới hạn không cho tăng quá số lượng tồn kho hiện tại */}
                                    <button onClick={() => setQuantity(Math.min(currentStock, quantity + 1))}>+</button>
                                </div>
                                {/* Hiển thị text nhỏ tồn kho bên cạnh nút số lượng (giống Shopee) */}
                                <span className="stock-info-small" style={{fontSize: '12px', color: '#757575', marginLeft: '10px'}}>
                                    {currentStock} sản phẩm có sẵn
                                </span>
                            </div>

                            <button 
                                className={`add-to-cart-btn full-width ${currentStock <= 0 ? 'disabled' : ''}`} 
                                onClick={handleAddToCart}
                                disabled={currentStock <= 0}
                            >
                                <i className="fa fa-shopping-cart"></i> 
                                {currentStock > 0 ? "Thêm Vào Giỏ Hàng" : "Hết Hàng"}
                            </button>
                        </div>

                        {/* --- PHẦN SHOP INFO (GIỮ NGUYÊN) --- */}
                        {shop && (
                             <div className="shop-info-card">
                                {/* ... code shop cũ giữ nguyên ... */}
                                <div className="shop-header-left">
                                    <img src={shop.avatarUrl || "https://via.placeholder.com/150"} alt={shop.shopName} className="shop-avatar" />
                                </div>
                                <div className="shop-details-right">
                                     <h4 className="shop-name">{shop.shopName}</h4>
                                     <div className="shop-actions">
                                        <Link to={`/shop-profile/${shop.shopId}`} className="btn-view-shop">Xem Shop</Link>
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