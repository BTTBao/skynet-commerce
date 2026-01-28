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
        addressId: 0, // <--- QUAN TRỌNG: Thêm trường này để lưu ID
        fullName: '',
        phone: '',
        address: '',
        note: '',
        paymentMethod: 'cod'
    });

    // =========================================================
    // LOGIC: TỰ ĐỘNG LẤY THÔNG TIN & CHUYỂN HƯỚNG NẾU RỖNG
    // =========================================================
    useEffect(() => {
        if (isCheckedRef.current) return;
        isCheckedRef.current = true;

        const token = localStorage.getItem('token');
        if (!token) {
            alert("Bạn cần đăng nhập để thanh toán!");
            navigate('/login', { state: { from: location }, replace: true });
            return;
        }

        const fetchUserData = async () => {
            try {
                const headers = {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                };

                const addrRes = await fetch('http://localhost:5198/api/User/addresses', { headers });

                if (addrRes.ok) {
                    const addresses = await addrRes.json();
                    
                    if (addresses && addresses.length > 0) {
                        // CÓ ĐỊA CHỈ -> Lấy mặc định điền vào Form
                        const defaultAddr = addresses.find(a => a.isDefault) || addresses[0];
                        
                        setFormData(prev => ({
                            ...prev,
                            addressId: defaultAddr.addressId, // <--- LƯU ID VÀO STATE
                            fullName: defaultAddr.receiverFullName || '',
                            phone: defaultAddr.receiverPhone || '',
                            address: defaultAddr.fullAddress || ''
                        }));
                    } else {
                        // KHÔNG CÓ ĐỊA CHỈ -> CHUYỂN HƯỚNG NGAY
                        alert("Bạn chưa có địa chỉ nhận hàng. Vui lòng thêm địa chỉ mới!");
                        navigate('/account', {
                            state: { activeTab: 'addresses', from: '/checkout' },
                            replace: true
                        });
                    }
                }
            } catch (error) {
                console.error("Lỗi lấy thông tin:", error);
            }
        };

        fetchUserData();
    }, [navigate, location]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Kiểm tra ID thay vì kiểm tra string address
        if (!formData.addressId || formData.addressId <= 0) {
            alert("Vui lòng chọn hoặc thêm địa chỉ giao hàng!");
            return;
        }

        const token = localStorage.getItem('token');
        
        // Payload mới: Gọn gàng hơn, chỉ cần AddressId và Items
        const payload = {
            addressId: formData.addressId, // <--- BẮT BUỘC PHẢI CÓ
            note: formData.note,
            paymentMethod: formData.paymentMethod,
            items: cartItems.map(item => ({
                productId: item.id || item.productId,
                quantity: item.quantity,
                color: item.selectedColor || null,
                size: item.selectedSize || null
            }))
        };

        // Biến cờ để đánh dấu trạng thái thành công
        let isSuccess = false;

        try {
            const response = await fetch('http://localhost:5198/api/Order/create', {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(payload)
            });

            const result = await response.json();

            if (response.ok) {
                isSuccess = true; 
                
                alert("Đặt hàng thành công! Mã đơn: " + result.orderGroupId);
                
                clearCart(); 
                
                navigate('/account', { 
                    state: { activeTab: 'orders' },
                    replace: true 
                });
                
                return; 
            } else {
                let errorMessage = result.message || "Có lỗi xảy ra";
                if (result.errors) {
                    errorMessage = Object.values(result.errors)[0][0];
                }
                alert("Lỗi: " + errorMessage);
            }

        } catch (error) {
            if (isSuccess) return;
            console.error("Lỗi network:", error);
            alert("Không thể kết nối server hoặc có lỗi xảy ra.");
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

                {/* FORM NHẬP LIỆU */}
                <div className="checkout-form-section">
                    <h3>Thông tin giao hàng</h3>
                    <form id="checkoutForm" onSubmit={handleSubmit}>
                        
                        <div className="form-group">
                            <label>Họ và tên người nhận</label>
                            <input
                                type="text" name="fullName"
                                value={formData.fullName} 
                                // ReadOnly để user biết là lấy từ sổ địa chỉ, không sửa trực tiếp ở đây
                                readOnly 
                                style={{backgroundColor: '#f9f9f9', cursor: 'not-allowed'}}
                            />
                        </div>
                        <div className="form-group">
                            <label>Số điện thoại</label>
                            <input
                                type="text" name="phone"
                                value={formData.phone} 
                                readOnly
                                style={{backgroundColor: '#f9f9f9', cursor: 'not-allowed'}}
                            />
                        </div>

                        {/* ĐỊA CHỈ */}
                        <div className="form-group">
                            <div style={{display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '5px'}}>
                                <label style={{marginBottom: 0}}>Địa chỉ nhận hàng</label>
                                <Link 
                                    to="/account" 
                                    state={{ activeTab: 'addresses', from: '/checkout' }}
                                    style={{fontSize: '0.9rem', color: '#007bff', textDecoration: 'none'}}
                                >
                                    Thay đổi / Thêm mới
                                </Link>
                            </div>
                            <textarea
                                name="address"
                                value={formData.address}
                                rows="3"
                                disabled={true} 
                                style={{ backgroundColor: '#f9f9f9', cursor: 'not-allowed', color: '#555' }}
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
                                        checked={formData.paymentMethod === 'cod'} onChange={handleChange} />
                                    COD (Thanh toán khi nhận hàng)
                                </label>
                                <label>
                                    <input type="radio" name="paymentMethod" value="banking" disabled
                                        checked={formData.paymentMethod === 'banking'} onChange={handleChange} />
                                    Chuyển khoản ngân hàng (Đang bảo trì)
                                </label>
                            </div>
                        </div>
                    </form>
                </div>

                {/* TÓM TẮT ĐƠN HÀNG (Giữ nguyên) */}
                <div className="checkout-summary-section">
                    <h3>Đơn hàng của bạn</h3>
                    <div className="summary-items">
                        {cartItems.map((item) => (
                            <div key={item.cartId || item.id} className="summary-item">
                                <div className="summary-item-left">
                                    <span className="sum-name">{item.name}</span>
                                    <span className="sum-qty">x {item.quantity}</span>
                                    {(item.selectedSize || item.selectedColor) && (
                                        <small className="sum-variant">
                                            {item.selectedSize ? `Size: ${item.selectedSize} ` : ''}
                                            {item.selectedColor ? `- Màu: ${item.selectedColor}` : ''}
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