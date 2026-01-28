import React from 'react';
import { Link } from 'react-router-dom';
import { useCart } from '../context/CartContext'; // 1. Import hook
import "./ProductCard.css";

function ProductCard({ product }) {
    const { addToCart } = useCart(); // 2. Lấy hàm thêm

    // Hàm xử lý khi click
    const handleAddToCart = () => {
        addToCart({
            id: product.id,
            name: product.name,
            price: product.price, // Lưu ý: Đảm bảo price là số (VD: 100000), không phải chuỗi "100.000đ"
            img: product.img
        });
    };

    return (
        <div className="item-card">
            {/* ... Phần ảnh giữ nguyên ... */}
            <Link to={`/product/${product.id}`} className="img-container">
                 <img src={product.img} alt={product.name} />
            </Link>

            <div className="product-info">
                <h3>{product.name}</h3>
                <p className="price">{product.price.toLocaleString()}đ</p>
                
                <div className="action-buttons">
                    <Link to={`/product/${product.id}`} className="btn-detail">
                         Xem chi tiết
                    </Link>
                    
                    {/* 3. Gắn sự kiện onClick */}
                    <button className="add-to-cart" onClick={handleAddToCart}>
                        <i className="fa fa-shopping-cart"></i> Thêm giỏ
                    </button>
                </div>
            </div>
        </div>
    );
}
export default ProductCard;