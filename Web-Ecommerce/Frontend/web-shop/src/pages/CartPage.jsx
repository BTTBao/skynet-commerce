import React from 'react';
import { useCart } from '../context/CartContext';
import { Link, useNavigate } from 'react-router-dom'; // 1. Thêm useNavigate
import "./CartPage.css"; 
import { useEffect } from 'react';
function CartPage() {
    const { cartItems, removeFromCart, updateQuantity, totalPrice, refreshCartData } = useCart();
    const navigate = useNavigate(); // 2. Khởi tạo hook điều hướng
    useEffect(() => {
        refreshCartData();
    }, []);
    const handleCheckout = () => {
        // Log ra xem thực tế dữ liệu là gì (F12 để xem)
        console.log("Dữ liệu giỏ hàng hiện tại:", cartItems);
        const hiddenItems = cartItems.filter(item => {
            // Lấy status dù backend trả về hoa hay thường
            const currentStatus = item.status || item.Status; 
            return currentStatus === 'Hidden';
        });

        if (hiddenItems.length > 0) {
            const itemNames = hiddenItems.map(i => i.name).join(', ');
            hiddenItems.forEach(item => {
                removeFromCart(item.cartId);
            });
            alert(`Sản phẩm [ ${itemNames} ] đã ngừng kinh doanh nên hệ thống đã xóa khỏi giỏ hàng. Vui lòng kiểm tra lại.`);
        } else {
            navigate('/checkout');
        }
    };

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
                                <tr key={item.cartId}> 
                                    {/* Cột 1: Ảnh & Tên */}
                                    <td className="cart-product-info">
                                        <img src={item.img} alt={item.name} />
                                        <div className="info-text">
                                            <span className="name">{item.name}</span>
                                            
                                            {/* (Tùy chọn) Hiện chữ cảnh báo nhẹ nếu muốn */}
                                            {item.status === 'Hidden' && (
                                                <span style={{color:'red', fontSize:'12px', display:'block'}}>
                                                    (Ngừng kinh doanh)
                                                </span>
                                            )}

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
                        
                        {/* 4. THAY LINK BẰNG BUTTON ĐỂ GỌI HÀM CHECK LOGIC */}
                        <button onClick={handleCheckout} className="btn-checkout">
                            Thanh Toán Ngay
                        </button>
                    </div>
                </div>
            </div>
        </>
    );
}

export default CartPage;