import React, { useState } from 'react';
import { Lock, Shield, ChevronLeft, Eye, EyeOff, Save } from 'lucide-react';
import './SettingsTab.css'; // Tạo file css này ở dưới

export default function SettingsTab() {
    const [activeView, setActiveView] = useState('menu'); // 'menu' | 'password' | 'privacy'

    // --- RENDER: MENU CHÍNH ---
    if (activeView === 'menu') {
        return (
            <div>
                <h2 className="tab-title">Cài đặt tài khoản</h2>
                <div className="settings-list">
                    {/* Item 1: Đổi mật khẩu */}
                    <div className="setting-item" onClick={() => setActiveView('password')}>
                        <div className="setting-info">
                            <div className="setting-icon-box blue">
                                <Lock size={20} />
                            </div>
                            <span>Đổi mật khẩu</span>
                        </div>
                        <span className="arrow">→</span>
                    </div>

                    {/* Item 2: Quyền riêng tư */}
                    <div className="setting-item" onClick={() => setActiveView('privacy')}>
                        <div className="setting-info">
                            <div className="setting-icon-box green">
                                <Shield size={20} />
                            </div>
                            <span>Quyền riêng tư</span>
                        </div>
                        <span className="arrow">→</span>
                    </div>
                </div>
            </div>
        );
    }

    // --- RENDER: FORM ĐỔI MẬT KHẨU ---
    if (activeView === 'password') {
        return <ChangePasswordForm onBack={() => setActiveView('menu')} />;
    }

    // --- RENDER: QUYỀN RIÊNG TƯ ---
    if (activeView === 'privacy') {
        return <PrivacySettings onBack={() => setActiveView('menu')} />;
    }
}

// =========================================================
// COMPONENT CON: FORM ĐỔI MẬT KHẨU
// =========================================================
function ChangePasswordForm({ onBack }) {
    const [formData, setFormData] = useState({ oldPassword: '', newPassword: '', confirmPassword: '' });
    const [showPass, setShowPass] = useState(false);
    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (formData.newPassword !== formData.confirmPassword) {
            alert("Mật khẩu xác nhận không khớp!");
            return;
        }
        if (formData.newPassword.length < 6) {
            alert("Mật khẩu mới phải dài hơn 6 ký tự!");
            return;
        }

        setLoading(true);
        try {
            const token = localStorage.getItem('token');
            const res = await fetch('http://localhost:5198/api/Auth/change-password', {
                method: 'POST',
                headers: { 
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify({
                    oldPassword: formData.oldPassword,
                    newPassword: formData.newPassword
                })
            });

            if (res.ok) {
                alert("Đổi mật khẩu thành công!");
                setFormData({ oldPassword: '', newPassword: '', confirmPassword: '' });
                onBack(); // Quay lại menu
            } else {
                const data = await res.json();
                alert(data.message || "Đổi mật khẩu thất bại (Sai mật khẩu cũ?)");
            }
        } catch (error) {
            console.error(error);
            alert("Lỗi kết nối Server");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="sub-page">
            <button className="btn-back" onClick={onBack}>
                <ChevronLeft size={20} /> Quay lại
            </button>
            <h3 className="sub-title">Đổi mật khẩu</h3>

            <form onSubmit={handleSubmit} className="password-form">
                <div className="form-group">
                    <label>Mật khẩu hiện tại</label>
                    <input 
                        type={showPass ? "text" : "password"} 
                        value={formData.oldPassword}
                        onChange={e => setFormData({...formData, oldPassword: e.target.value})}
                        required
                    />
                </div>
                
                <div className="form-group">
                    <label>Mật khẩu mới</label>
                    <input 
                        type={showPass ? "text" : "password"} 
                        value={formData.newPassword}
                        onChange={e => setFormData({...formData, newPassword: e.target.value})}
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Xác nhận mật khẩu mới</label>
                    <input 
                        type={showPass ? "text" : "password"} 
                        value={formData.confirmPassword}
                        onChange={e => setFormData({...formData, confirmPassword: e.target.value})}
                        required
                    />
                </div>

                <div className="form-options">
                    <label className="checkbox-label">
                        <input type="checkbox" onChange={() => setShowPass(!showPass)} /> 
                        Hiển thị mật khẩu
                    </label>
                </div>

                <button type="submit" className="btn-save" disabled={loading}>
                    {loading ? "Đang xử lý..." : "Lưu thay đổi"}
                </button>
            </form>
        </div>
    );
}

// =========================================================
// COMPONENT CON: QUYỀN RIÊNG TƯ (Demo)
// =========================================================
function PrivacySettings({ onBack }) {
    // Demo state (Sau này có thể call API lấy setting thật)
    const [settings, setSettings] = useState({
        showPhone: false,
        receiveEmail: true,
        publicProfile: true
    });

    const toggle = (key) => {
        setSettings({ ...settings, [key]: !settings[key] });
        // Gọi API lưu setting ở đây nếu cần
    };

    return (
        <div className="sub-page">
            <button className="btn-back" onClick={onBack}>
                <ChevronLeft size={20} /> Quay lại
            </button>
            <h3 className="sub-title">Quyền riêng tư</h3>

            <div className="privacy-list">
                <div className="privacy-item">
                    <div className="privacy-text">
                        <h4>Hiển thị số điện thoại</h4>
                        <p>Cho phép người khác tìm thấy bạn qua SĐT</p>
                    </div>
                    <label className="switch">
                        <input type="checkbox" checked={settings.showPhone} onChange={() => toggle('showPhone')} />
                        <span className="slider round"></span>
                    </label>
                </div>

                <div className="privacy-item">
                    <div className="privacy-text">
                        <h4>Nhận Email thông báo</h4>
                        <p>Nhận tin tức khuyến mãi từ ShopDeal</p>
                    </div>
                    <label className="switch">
                        <input type="checkbox" checked={settings.receiveEmail} onChange={() => toggle('receiveEmail')} />
                        <span className="slider round"></span>
                    </label>
                </div>

                 <div className="privacy-item">
                    <div className="privacy-text">
                        <h4>Hồ sơ công khai</h4>
                        <p>Người khác có thể xem lịch sử đánh giá của bạn</p>
                    </div>
                    <label className="switch">
                        <input type="checkbox" checked={settings.publicProfile} onChange={() => toggle('publicProfile')} />
                        <span className="slider round"></span>
                    </label>
                </div>
            </div>
        </div>
    );
}