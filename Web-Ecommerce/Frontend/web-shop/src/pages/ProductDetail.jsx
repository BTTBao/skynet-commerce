import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useCart } from "../context/CartContext";
import Navbar from "../layouts/Navbar";
import "./ProductDetail.css";

function ProductDetail() {
    const { id } = useParams();
    const { addToCart } = useCart();
    
    const [product, setProduct] = useState(null);
    const [loading, setLoading] = useState(true);
    
    // State UI
    const [mainImage, setMainImage] = useState("");
    const [selectedSize, setSelectedSize] = useState("");
    const [selectedColor, setSelectedColor] = useState("");
    const [quantity, setQuantity] = useState(1);

    useEffect(() => {
        const fetchProductDetail = async () => {
            try {
                const response = await fetch(`https://localhost:7215/api/products/${id}`);
                if (!response.ok) throw new Error("Lỗi tải sản phẩm");
                const data = await response.json();
                
                setProduct(data);
                
                // Logic ảnh mặc định
                const primaryImg = data.productImages.find(img => img.isPrimary) || data.productImages[0];
                setMainImage(primaryImg?.imageUrl || "https://via.placeholder.com/500");
                
                // Tự động chọn size/màu đầu tiên
                if(data.productVariants?.length > 0) {
                     setSelectedSize(data.productVariants[0].size);
                     setSelectedColor(data.productVariants[0].color);
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

    if (loading) return <div className="loading-screen">Đang tải chi tiết sản phẩm...</div>;
    if (!product) return <div className="error-screen">Không tìm thấy sản phẩm!</div>;
    
    // Lọc size/color duy nhất
    const uniqueSizes = [...new Set(product.productVariants?.map(v => v.size).filter(Boolean))];
    const uniqueColors = [...new Set(product.productVariants?.map(v => v.color).filter(Boolean))];

    // --- TÍNH TOÁN GIÁ TẠM TÍNH ---
    const unitPrice = Number(product.price) || 0;
    const estimatedTotal = unitPrice * quantity; // Giá x Số lượng

    return (
        <>
            <Navbar />
            <div className="detail-container">
                <div className="detail-wrapper">
                    
                    {/* CỘT TRÁI: THƯ VIỆN ẢNH */}
                    <div className="product-gallery">
                        <div className="main-image-frame">
                            <img src={mainImage} alt={product.name} className="main-img" />
                        </div>
                        {/* Danh sách ảnh nhỏ (Thumbnail) */}
                        <div className="thumbnail-list">
                            {product.productImages?.map((img) => (
                                <img 
                                    key={img.imageId}
                                    src={img.imageUrl} 
                                    alt="thumb"
                                    className={`thumb-img ${mainImage === img.imageUrl ? "active" : ""}`}
                                    onClick={() => setMainImage(img.imageUrl)}
                                />
                            ))}
                        </div>
                    </div>

                    {/* CỘT PHẢI: THÔNG TIN CHI TIẾT */}
                    <div className="product-info">
                        <h1 className="product-name">{product.name}</h1>
                        
                        {/* Thông tin phụ: SKU, Danh mục, Đã bán */}
                        <div className="product-meta">
                            <span>Mã: <strong>{product.productVariants?.[0]?.sku || "N/A"}</strong></span>
                            <span> | </span>
                            <span>Danh mục: <strong>{product.category?.name || "Chưa cập nhật"}</strong></span>
                            <span> | </span>
                            <span>Đã bán: <strong>{product.soldCount || 0}</strong></span>
                        </div>

                        {/* Giá sản phẩm */}
                        <p className="product-price">{unitPrice.toLocaleString()}đ</p>

                        {/* Mô tả ngắn */}
                        <div className="product-description">
                            <h3>Mô tả sản phẩm:</h3>
                            <p>{product.description || "Đang cập nhật mô tả cho sản phẩm này..."}</p>
                        </div>

                        <hr className="divider" />

                        {/* Chọn Size */}
                        {uniqueSizes.length > 0 && (
                            <div className="variant-section">
                                <span className="variant-label">Kích thước:</span>
                                <div className="variant-options">
                                    {uniqueSizes.map(size => (
                                        <button 
                                            key={size}
                                            className={`size-btn ${selectedSize === size ? "selected" : ""}`}
                                            onClick={() => setSelectedSize(size)}
                                        >
                                            {size}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        )}

                        {/* Chọn Màu (Đã bổ sung) */}
                        {uniqueColors.length > 0 && (
                            <div className="variant-section">
                                <span className="variant-label">Màu sắc:</span>
                                <div className="variant-options">
                                    {uniqueColors.map(color => (
                                        <button 
                                            key={color}
                                            className={`color-btn ${selectedColor === color ? "selected" : ""}`}
                                            onClick={() => setSelectedColor(color)}
                                        >
                                            {color}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        )}

                        {/* KHUVỰC MUA HÀNG & TÍNH TIỀN */}
                        <div className="purchase-area">
                            <div className="quantity-wrapper">
                                <span className="variant-label">Số lượng:</span>
                                <div className="quantity-control">
                                    <button onClick={() => setQuantity(Math.max(1, quantity - 1))}>-</button>
                                    <input type="text" value={quantity} readOnly />
                                    <button onClick={() => setQuantity(quantity + 1)}>+</button>
                                </div>
                            </div>

                            {/* Hiển thị tạm tính */}
                            <div className="total-estimate">
                                <span>Tạm tính:</span>
                                <span className="price-value">{estimatedTotal.toLocaleString()}đ</span>
                            </div>

                            <button className="add-to-cart-btn full-width" onClick={handleAddToCart}>
                                <i className="fa fa-shopping-cart"></i> Thêm Vào Giỏ Hàng
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
export default ProductDetail;