import React from 'react';
import { Link } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import { Star } from 'lucide-react'; // Import icon Ngôi sao
import "./ProductCard.css";

function ProductCard({ product }) {
    const { addToCart } = useCart();

    // Giả lập rating (Mặc định 5 sao nếu dữ liệu không có)
    const rating = product.rating || 5; 

    const handleAddToCart = (e) => {
        e.preventDefault(); // Ngăn click lan ra ngoài
        addToCart({
            id: product.id,
            name: product.name,
            price: product.price,
            img: product.img
        });
    };

    return (
        <div className="item-card">
            {/* Ảnh sản phẩm */}
            <Link to={`/product/${product.id}`} className="img-container">
                 <img src={product.img} alt={product.name} />
            </Link>

            <div className="product-info">
                <h3>{product.name}</h3>

                {/* --- PHẦN MỚI: HIỂN THỊ SỐ SAO --- */}
                <div className="product-rating">
                    {[1, 2, 3, 4, 5].map((star) => (
                        <Star 
                            key={star} 
                            size={14} 
                            color="#ffc107" // Màu viền vàng
                            fill={star <= rating ? "#ffc107" : "none"} // Tô màu vàng nếu có sao
                            style={{ marginRight: 2 }}
                        />
                    ))}
                    <span className="rating-count">({rating})</span>
                </div>
                {/* ---------------------------------- */}

                <p className="price">{product.price.toLocaleString()}đ</p>
                
                {/* Giữ nguyên 2 nút bấm như cũ */}
                <div className="action-buttons">
                    <Link to={`/product/${product.id}`} className="btn-detail">
                         Xem chi tiết
                    </Link>
                    
                    <button className="add-to-cart" onClick={handleAddToCart}>
                        <i className="fa fa-shopping-cart"></i> Thêm giỏ
                    </button>
                </div>
            </div>
        </div>
    );
}

export default ProductCard;