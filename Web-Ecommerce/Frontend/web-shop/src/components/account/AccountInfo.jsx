// src/components/account/AccountInfo.jsx
import React, { useEffect, useState } from 'react';
import { useAuth } from '../../context/AuthContext'; // 1. Lấy Token từ Context
import './AccountInfo.css';

const AccountInfo = () => {
  const { user } = useAuth(); // Lấy thông tin user cơ bản từ Context (nếu cần token)
  
  // 2. State lưu dữ liệu form
  const [profile, setProfile] = useState({
    fullName: '',
    phone: '',
    email: '',
    dateOfBirth: '',
    gender: 'other'
  });
  
  const [loading, setLoading] = useState(true);

  // 3. Gọi API khi trang vừa tải
  useEffect(() => {
    const fetchProfile = async () => {
      // Lấy token từ localStorage (hoặc từ user.token nếu context có lưu)
      const token = localStorage.getItem('token') || (user && user.token);

      if (!token) return;

      try {
        // Gọi xuống Backend (cổng 7215 hoặc cổng của bạn)
        const response = await fetch('http://localhost:5198/api/Auth/me', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}` // <--- Gửi Token kèm theo
          }
        });

        if (response.ok) {
          const data = await response.json();
          // Map dữ liệu từ API vào State
          setProfile({
            fullName: data.fullName || '',
            phone: data.phone || '',
            email: data.email || '',
            // Format ngày sinh về dạng yyyy-MM-dd cho input type="date"
            dateOfBirth: data.dateOfBirth ? data.dateOfBirth.split('T')[0] : '',
            gender: data.gender || 'other'
          });
        } else {
            console.error("Lỗi lấy thông tin user");
        }
      } catch (error) {
        console.error("Lỗi kết nối:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchProfile();
  }, [user]);

  // Hàm xử lý khi gõ phím
  const handleChange = (e) => {
    setProfile({ ...profile, [e.target.name]: e.target.value });
  };

  if (loading) return <div className="p-4">Đang tải thông tin...</div>;

  return (
    <div>
      <h2 className="account-info-title">Thông tin cá nhân</h2>
      
      <form className="account-form">
        <div className="form-grid">
          <div className="form-group">
            <label className="form-label">Họ và tên</label>
            <input
              type="text"
              name="fullName"
              value={profile.fullName}
              onChange={handleChange}
              className="form-control"
            />
          </div>
          <div className="form-group">
            <label className="form-label">Số điện thoại</label>
            <input
              type="tel"
              name="phone"
              value={profile.phone}
              onChange={handleChange}
              className="form-control"
            />
          </div>
        </div>

        <div className="form-group">
          <label className="form-label">Email</label>
          <input
            type="email"
            value={profile.email}
            disabled
            className="form-control"
          />
        </div>

        <div className="form-grid">
          <div className="form-group">
            <label className="form-label">Ngày sinh</label>
            <input
              type="date"
              name="dateOfBirth"
              value={profile.dateOfBirth}
              onChange={handleChange}
              className="form-control"
            />
          </div>
          <div className="form-group">
            <label className="form-label">Giới tính</label>
            <select 
                name="gender" 
                value={profile.gender} 
                onChange={handleChange}
                className="form-control"
            >
              <option value="male">Nam</option>
              <option value="female">Nữ</option>
              <option value="other">Khác</option>
            </select>
          </div>
        </div>

        <div>
            <button type="button" className="save-btn">
            Lưu thay đổi
            </button>
        </div>
      </form>
    </div>
  );
};

export default AccountInfo;