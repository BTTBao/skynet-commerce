import React from 'react';
import "./ProductCard.css";

function ProductCard({ product }) {
    return (
        <div className="item-card">
            <div className="product-img">
                <img src={product.img} alt={product.name} />
            </div>
            <div className="product-info">
                <h3>{product.name}</h3>
                <p className="price">{product.price}</p>
                <div className="action-buttons">
                    <button className="add-to-cart">Thêm vào giỏ</button>
                </div>
            </div>
        </div>
    );
}

export default ProductCard;