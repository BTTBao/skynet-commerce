import React, { useState } from 'react';
import { Store } from 'lucide-react';
import './SellerRegistrationTab.css'; // <--- Import file CSS

const SellerRegistrationTab = () => {
    const [formData, setFormData] = useState({ shopName: '', description: '' });
    const [status, setStatus] = useState(null);
    const [message, setMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token');
        try {
            // Nhớ kiểm tra đúng port backend (5198 hoặc 7215)
            const res = await fetch('http://localhost:5198/api/User/register-shop', {
                method: 'POST',
                headers: { 
                    'Content-Type': 'application/json', 
                    'Authorization': `Bearer ${token}` 
                },
                body: JSON.stringify(formData)
            });
            const data = await res.json();
            if (res.ok) {
                setStatus('success');
                setMessage(data.message);
            } else {
                setStatus('error');
                setMessage(data.message || 'Có lỗi xảy ra');
            }
        } catch (error) {
            console.error(error);
            setStatus('error');
            setMessage('Lỗi kết nối đến server');
        }
    };

    return (
        <div>
            <h2 className="tab-title">Đăng ký bán hàng</h2>
            
            {status === 'success' ? (
                <div className="seller-success-container">
                    <Store size={48} className="seller-success-icon" />
                    <h3 className="seller-success-title">{message}</h3>
                    <p className="seller-success-desc">Hệ thống sẽ xem xét và thông báo cho bạn sớm nhất.</p>
                </div>
            ) : (
                <form onSubmit={handleSubmit} className="seller-form">
                    {status === 'error' && <div className="error-msg">{message}</div>}
                    
                    <div className="form-group">
                        <label className="form-label">Tên Shop của bạn</label>
                        <input 
                            type="text" 
                            required 
                            className="form-input" 
                            value={formData.shopName} 
                            onChange={e => setFormData({...formData, shopName: e.target.value})} 
                            placeholder="Ví dụ: Cửa hàng Skynet" 
                        />
                    </div>

                    <div className="form-group">
                        <label className="form-label">Mô tả ngắn</label>
                        <textarea 
                            rows={4} 
                            className="form-textarea" 
                            value={formData.description} 
                            onChange={e => setFormData({...formData, description: e.target.value})} 
                            placeholder="Shop chuyên bán đồ điện tử, laptop..." 
                        />
                    </div>

                    <button type="submit" className="btn-register-shop">
                        Gửi đơn đăng ký
                    </button>
                </form>
            )}
        </div>
    );
};

export default SellerRegistrationTab;