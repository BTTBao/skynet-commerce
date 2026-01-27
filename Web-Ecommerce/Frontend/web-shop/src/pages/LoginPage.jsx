// src/pages/LoginPage.jsx
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Mail, Lock, User, Phone, Eye, EyeOff } from 'lucide-react';
import { useAuth } from '../context/AuthContext'; 

// ❌ BỎ import Navbar, Footer đi
import InputField from '../components/InputField';
import SocialLogin from '../components/SocialLogin';
import './LoginPage.css'; 

export default function LoginPage() {
  // ... (Giữ nguyên phần logic state, handle submit...)
  const navigate = useNavigate();
  const { login } = useAuth();
  const [mode, setMode] = useState('login');
  // ... (code logic giữ nguyên) ...
  const [showPassword, setShowPassword] = useState(false);
  const [formData, setFormData] = useState({ name: '', email: '', phone: '', password: '', confirmPassword: '' });
  const handleChange = (e, field) => setFormData({ ...formData, [field]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
        let url = '';
        let bodyData = {};

        // 1. Xác định API
        if (mode === 'login') {
            // ❌ XÓA DÒNG NÀY ĐI: localStorage.setItem('token', data.token);
            // Vì lúc này chưa có biến data!
            
            url = 'https://localhost:7215/api/Auth/login'; 
            bodyData = {
                email: formData.email,
                password: formData.password
            };
        } else {
            // ... Logic đăng ký giữ nguyên
             if (formData.password !== formData.confirmPassword) {
                alert("Mật khẩu xác nhận không khớp!");
                return;
            }
            url = 'https://localhost:7215/api/Auth/register';
            bodyData = {
                fullName: formData.name,
                email: formData.email,
                phone: formData.phone,
                password: formData.password
            };
        }

        // 2. Gọi API (Giữ nguyên)
        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(bodyData)
        });

        const data = await response.json(); // <--- Lúc này mới có biến 'data'

        // 3. Xử lý lỗi (Giữ nguyên)
        if (!response.ok) {
            alert(data.message || 'Có lỗi xảy ra!');
            return;
        }

        // 4. THÀNH CÔNG (SỬA Ở ĐÂY)
        if (mode === 'login') {
            
            // 👇 CHUYỂN DÒNG LƯU TOKEN XUỐNG ĐÂY 👇
            localStorage.setItem('token', data.token); 
            // 👆 Lúc này data.token mới có giá trị thực
            
            // Cập nhật Context
            login({
                token: data.token,
                name: data.user.name,
                email: data.user.email,
                role: data.user.role
            });

            alert("Đăng nhập thành công!");
            navigate('/');
        } else {
            alert("Đăng ký thành công! Vui lòng đăng nhập.");
            setMode('login');
            setFormData({ ...formData, password: '', confirmPassword: '' });
        }

    } catch (error) {
        console.error("Lỗi kết nối:", error);
        alert("Không thể kết nối đến Server Backend!");
    }
  };

  return (
    // Sửa className từ "login-page" thành "login-content" để tránh conflict CSS full màn hình
    <div className="login-main"> 
      <div className="login-container">
        
        {/* Header Form */}
        <div className="login-header">
          <h1 className="login-title">Chào Mừng Trở Lại</h1>
          <p className="login-subtitle">
            {mode === 'login' ? 'Đăng nhập vào tài khoản của bạn' : 'Tạo tài khoản mới cùng Skynet'}
          </p>
        </div>

        {/* Card Form */}
        <div className="login-card">
          <div className="tab-group">
            <button onClick={() => setMode('login')} className={`tab-btn ${mode === 'login' ? 'active' : ''}`}>
              Đăng nhập
            </button>
            <button onClick={() => setMode('register')} className={`tab-btn ${mode === 'register' ? 'active' : ''}`}>
              Đăng ký
            </button>
          </div>

          <form onSubmit={handleSubmit}>
            {mode === 'register' && (
              <>
                <InputField label="Họ và tên" icon={User} value={formData.name} onChange={(e) => handleChange(e, 'name')} placeholder="Nguyễn Văn A" />
                <InputField label="Số điện thoại" icon={Phone} type="tel" value={formData.phone} onChange={(e) => handleChange(e, 'phone')} placeholder="0901234567" />
              </>
            )}

            <InputField label="Email" icon={Mail} type="email" value={formData.email} onChange={(e) => handleChange(e, 'email')} placeholder="email@example.com" />
            
            <InputField 
              label="Mật khẩu" icon={Lock} 
              type={showPassword ? 'text' : 'password'}
              value={formData.password} onChange={(e) => handleChange(e, 'password')} placeholder="••••••••"
              rightIcon={
                <button type="button" onClick={() => setShowPassword(!showPassword)} style={{background: 'none', border: 'none', cursor: 'pointer', color: '#9ca3af'}}>
                  {showPassword ? <EyeOff size={20} /> : <Eye size={20} />}
                </button>
              }
            />

            {mode === 'register' && (
              <InputField label="Xác nhận mật khẩu" icon={Lock} type={showPassword ? 'text' : 'password'} value={formData.confirmPassword} onChange={(e) => handleChange(e, 'confirmPassword')} placeholder="••••••••" />
            )}

            {mode === 'login' && (
              <div className="form-options">
                <label style={{display: 'flex', alignItems: 'center', gap: '5px', color: '#4b5563'}}>
                  <input type="checkbox" /> Ghi nhớ
                </label>
                <a href="#" className="forgot-password">Quên mật khẩu?</a>
              </div>
            )}

            <button type="submit" className="submit-btn">
              {mode === 'login' ? 'Đăng nhập' : 'Đăng ký'}
            </button>
          </form>

          <SocialLogin />
        </div>
      </div>
    </div>
  );
}