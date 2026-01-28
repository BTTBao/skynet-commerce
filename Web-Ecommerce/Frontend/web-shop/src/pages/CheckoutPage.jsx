import React, { useState, useEffect, useRef } from 'react';
import { useCart } from '../context/CartContext';
import { Link, useNavigate, useLocation } from 'react-router-dom';
import './CheckoutPage.css';

function CheckoutPage() {
    const { cartItems, totalPrice, clearCart } = useCart();
    const navigate = useNavigate();
    const location = useLocation();
    const isCheckedRef = useRef(false);

    // State form nhập liệu
    const [formData, setFormData] = useState({
        fullName: '',
        phone: '',
        address: '',
        note: '',
        paymentMethod: 'cod'
    });

    // Check login
    useEffect(() => {
        if (isCheckedRef.current) return;
        isCheckedRef.current = true;
        
        const token = localStorage.getItem('token');
        if (!token) {
            alert("Bạn cần đăng nhập để thanh toán!");
            navigate('/login', { state: { from: location }, replace: true });
        }
    }, [navigate, location]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!formData.fullName || !formData.phone || !formData.address) {
            alert("Vui lòng điền đầy đủ thông tin giao hàng!");
            return;
        }

        const token = localStorage.getItem('token');

        // =========================================================
        // PAYLOAD ĐÃ ĐƯỢC CHỈNH SỬA ĐỂ KHỚP VỚI BACKEND
        // =========================================================
        const payload = {
            receiverName: formData.fullName, 
            
            receiverPhone: formData.phone,
            addressLine: formData.address,
            note: formData.note,
            paymentMethod: formData.paymentMethod,
            items: cartItems.map(item => ({
                productId: item.id,
                price: item.price,
                quantity: item.quantity,
                color: item.selectedColor || null,
                size: item.selectedSize || null
            }))
        };
        console.log("Dữ liệu gửi đi:", payload);
        try {
            const response = await fetch('https://localhost:7215/api/Order/create', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(payload)
            });

            const result = await response.json();

            if (response.ok) {
                // --- THÀNH CÔNG ---
                alert("Đặt hàng thành công! Mã đơn: " + result.orderGroupId);
                
                // Bọc clearCart và navigate trong try-catch riêng 
                // để nếu nó lỗi thì cũng không báo "Lỗi kết nối server"
                try {
                    clearCart(); 
                    navigate('/profile');
                } catch (err) {
                    console.error("Lỗi dọn giỏ hàng (không ảnh hưởng đơn hàng):", err);
                    // Vẫn chuyển trang kể cả khi clearCart lỗi
                    window.location.href = '/profile'; 
                }
                return; // <--- QUAN TRỌNG: Dừng hàm tại đây
            } 
            
            // --- LỖI TỪ BACKEND (400, 500...) ---
            let errorMessage = result.message || result.title || "Có lỗi xảy ra";
            if (result.errors) {
                const firstErrorKey = Object.keys(result.errors)[0];
                errorMessage = result.errors[firstErrorKey][0];
            }
            alert("Lỗi đặt hàng: " + errorMessage);

        } catch (error) {
            // --- LỖI MẠNG / KHÔNG GỌI ĐƯỢC API ---
            console.error("Lỗi network:", error);
            alert("Không thể kết nối đến server (hoặc server đang tắt).");
        }
    };

    if (cartItems.length === 0) {
        return (
            <div className="empty-checkout">
                <h2>Giỏ hàng trống</h2>
                <Link to="/">Quay lại mua sắm</Link>
            </div>
        );
    }

    return (
        <div className="checkout-container">
            <h2 className="checkout-title">Thanh Toán</h2>
            <div className="checkout-layout">
                
                {/* FORM NHẬP TAY */}
                <div className="checkout-form-section">
                    <h3>Thông tin giao hàng</h3>
                    <form id="checkoutForm" onSubmit={handleSubmit}>
                        <div className="form-group">
                            <label>Họ và tên người nhận</label>
                            <input 
                                type="text" name="fullName" 
                                value={formData.fullName} onChange={handleChange} 
                                placeholder="Nguyễn Văn A" required 
                            />
                        </div>
                        <div className="form-group">
                            <label>Số điện thoại</label>
                            <input 
                                type="text" name="phone" 
                                value={formData.phone} onChange={handleChange} 
                                placeholder="09xxxxxxxx" required 
                            />
                        </div>
                        <div className="form-group">
                            <label>Địa chỉ nhận hàng</label>
                            <textarea 
                                name="address" 
                                value={formData.address} onChange={handleChange} 
                                placeholder="Số nhà, đường, phường, quận..." required 
                                rows="3"
                            />
                        </div>
                        <div className="form-group">
                            <label>Ghi chú (Tùy chọn)</label>
                            <textarea 
                                name="note" 
                                value={formData.note} onChange={handleChange} 
                                placeholder="Ghi chú thêm..." 
                            />
                        </div>

                        <div className="payment-method-section">
                            <h3>Phương thức thanh toán</h3>
                            <div className="radio-group">
                                <label>
                                    <input type="radio" name="paymentMethod" value="cod" 
                                        checked={formData.paymentMethod === 'cod'} onChange={handleChange}/> 
                                    COD (Thanh toán khi nhận hàng)
                                </label>
                                <label>
                                    <input type="radio" name="paymentMethod" value="banking" 
                                        checked={formData.paymentMethod === 'banking'} onChange={handleChange}/> 
                                    Chuyển khoản ngân hàng
                                </label>
                            </div>
                        </div>
                    </form>
                </div>

                {/* TÓM TẮT ĐƠN HÀNG */}
                <div className="checkout-summary-section">
                    <h3>Đơn hàng của bạn</h3>
                    <div className="summary-items">
                        {cartItems.map((item) => (
                            <div key={item.cartId || item.productId} className="summary-item">
                                <div className="summary-item-left">
                                    <span className="sum-name">{item.name}</span>
                                    <span className="sum-qty">x {item.quantity}</span>
                                    {(item.selectedSize || item.selectedColor) && (
                                        <small className="sum-variant">
                                            {item.selectedSize ? `Size: ${item.selectedSize}` : ''} 
                                            {item.selectedColor ? ` - Màu: ${item.selectedColor}` : ''}
                                        </small>
                                    )}
                                </div>
                                <div className="summary-item-right">
                                    {(Number(item.price) * item.quantity).toLocaleString()}đ
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="summary-divider"></div>
                    <div className="summary-total">
                        <span>Tổng cộng:</span>
                        <span className="total-price">{totalPrice.toLocaleString()}đ</span>
                    </div>
                    <button type="submit" form="checkoutForm" className="btn-place-order">
                        ĐẶT HÀNG NGAY
                    </button>
                </div>
            </div>
        </div>
    );
}

export default CheckoutPage;