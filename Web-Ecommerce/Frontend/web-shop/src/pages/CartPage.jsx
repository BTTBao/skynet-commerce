import React from 'react';
import { useCart } from '../context/CartContext';
import { Link } from 'react-router-dom';
import Navbar from '../layouts/Navbar';
import "./CartPage.css"; 

function CartPage() {
    const { cartItems, removeFromCart, updateQuantity, totalPrice } = useCart();

    if (cartItems.length === 0) {
        return (
            <>
                <div className="empty-cart">
                    <h2>Giỏ hàng của bạn đang trống!</h2>
                    <Link to="/" className="btn-shop-now">Mua sắm ngay</Link>
                </div>
            </>
        );
    }

    return (
        <>
            <div className="cart-container">
                <h2 className="cart-title">Giỏ Hàng Của Bạn</h2>
                
                <div className="cart-content">
                    <table className="cart-table">
                        <thead>
                            <tr>
                                <th>Sản phẩm</th>
                                <th>Đơn giá</th>
                                <th>Số lượng</th>
                                <th>Thành tiền</th>
                                <th>Thao tác</th>
                            </tr>
                        </thead>
                        <tbody>
                            {cartItems.map((item) => (
                                /* 1. SỬA KEY: Dùng cartId để React phân biệt các dòng */
                                <tr key={item.cartId}> 
                                    
                                    {/* Cột 1: Ảnh & Tên */}
                                    <td className="cart-product-info">
                                        <img src={item.img} alt={item.name} />
                                        <div className="info-text">
                                            <span className="name">{item.name}</span>
                                            {(item.selectedSize || item.selectedColor) && (
                                                <small style={{color: '#777'}}>
                                                    {item.selectedSize} / {item.selectedColor}
                                                </small>
                                            )}
                                        </div>
                                    </td>

                                    {/* Cột 2: Giá */}
                                    <td>{Number(item.price).toLocaleString()}đ</td>

                                    {/* Cột 3: Tăng giảm số lượng */}
                                    <td>
                                        <div className="qty-control">
                                            {/* 2. SỬA UPDATE: Truyền cartId */}
                                            <button onClick={() => updateQuantity(item.cartId, -1)}>-</button>
                                            <span>{item.quantity}</span>
                                            <button onClick={() => updateQuantity(item.cartId, 1)}>+</button>
                                        </div>
                                    </td>

                                    {/* Cột 4: Thành tiền */}
                                    <td className="col-total">
                                        {(Number(item.price) * item.quantity).toLocaleString()}đ
                                    </td>

                                    {/* Cột 5: NÚT XÓA */}
                                    <td>
                                        <button 
                                            className="btn-delete" 
                                            /* 3. SỬA REMOVE: Truyền cartId */
                                            onClick={() => removeFromCart(item.cartId)}
                                            title="Xóa sản phẩm này"
                                        >
                                            <i className="fa fa-trash"></i> Xóa
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>

                    <div className="cart-summary">
                        <h3>Tổng cộng: <span className="final-price">{totalPrice.toLocaleString()}đ</span></h3>
                        <button className="btn-checkout">Thanh Toán</button>
                    </div>
                </div>
            </div>
        </>
    );
}

export default CartPage;