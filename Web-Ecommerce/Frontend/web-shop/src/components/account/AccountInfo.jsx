import React, { useEffect, useState } from 'react';
import { useAuth } from '../../context/AuthContext';
import { Save } from 'lucide-react'; 
import './AccountInfo.css';

const AccountInfo = () => {
  const { user } = useAuth();
  
  const [profile, setProfile] = useState({
    fullName: '',
    phone: '',
    email: '',
    dateOfBirth: '',
    gender: 'other'
  });
  
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);

  // 1. Fetch dữ liệu
  useEffect(() => {
    const fetchProfile = async () => {
      const token = localStorage.getItem('token');
      if (!token) return;

      try {
        const response = await fetch('http://localhost:5198/api/Auth/me', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
          }
        });

        if (response.ok) {
          const data = await response.json();
          setProfile({
            fullName: data.fullName || '',
            phone: data.phone || '',
            email: data.email || '',
            // Cắt chuỗi lấy yyyy-MM-dd để map vào input date
            dateOfBirth: data.dateOfBirth ? data.dateOfBirth.split('T')[0] : '',
            gender: data.gender || 'other'
          });
        }
      } catch (error) {
        console.error("Lỗi kết nối:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchProfile();
  }, [user]);

  const handleChange = (e) => {
    setProfile({ ...profile, [e.target.name]: e.target.value });
  };

  // 2. HÀM RÀNG BUỘC DỮ LIỆU (VALIDATION) - ĐÃ NÂNG CẤP
  const validateForm = () => {
    // Kiểm tra tên
    if (!profile.fullName.trim()) {
        alert("Vui lòng nhập Họ và tên.");
        return false;
    }
    
    // Kiểm tra số điện thoại
    const phoneRegex = /(84|0[3|5|7|8|9])+([0-9]{8})\b/;
    if (!phoneRegex.test(profile.phone)) {
        alert("Số điện thoại không hợp lệ (Phải có 10 số và đúng định dạng VN).");
        return false;
    }

    // --- SỬA LẠI KHÚC NGÀY SINH ---
    if (profile.dateOfBirth) {
        const selectedDate = new Date(profile.dateOfBirth);
        const today = new Date();
        const minDate = new Date('1900-01-01');

        // 1. Không được chọn ngày trong tương lai
        if (selectedDate > today) {
            alert("Ngày sinh không được lớn hơn ngày hiện tại.");
            return false;
        }

        // 2. Không được chọn năm quá cũ (trước 1900)
        if (selectedDate < minDate) {
            alert("Năm sinh không hợp lệ (Vui lòng chọn năm sau 1900).");
            return false;
        }

        // 3. (Tùy chọn) Kiểm tra độ tuổi tối thiểu (Ví dụ phải trên 6 tuổi)
        // Tính tuổi
        let age = today.getFullYear() - selectedDate.getFullYear();
        const m = today.getMonth() - selectedDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < selectedDate.getDate())) {
            age--;
        }

        if (age < 10) {
            alert("Độ tuổi không hợp lệ (Bạn phải trên 6 tuổi).");
            return false;
        }
    }
    // -----------------------------

    return true;
  };

  // 3. HÀM LƯU THÔNG TIN
  const handleSave = async () => {
    if (!validateForm()) return;

    setSaving(true);
    const token = localStorage.getItem('token');

    try {
        const response = await fetch('http://localhost:5198/api/Auth/update-profile', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({
                fullName: profile.fullName,
                phone: profile.phone,
                dateOfBirth: profile.dateOfBirth,
                gender: profile.gender
            })
        });

        const data = await response.json();

        if (response.ok) {
            alert("✅ " + data.message);
        } else {
            alert("❌ " + (data.message || "Cập nhật thất bại"));
        }
    } catch (error) {
        console.error("Lỗi:", error);
        alert("Lỗi kết nối đến Server");
    } finally {
        setSaving(false);
    }
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
              placeholder="Nhập họ tên của bạn"
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
              placeholder="0912..."
            />
          </div>
        </div>

        <div className="form-group">
          <label className="form-label">Email</label>
          <input
            type="email"
            value={profile.email}
            disabled 
            className="form-control disabled-input" 
            style={{backgroundColor: '#f3f4f6', cursor: 'not-allowed'}}
          />
          <small style={{color: '#6b7280', marginTop: '4px', display: 'block'}}>
            * Email không thể thay đổi
          </small>
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
              // Giới hạn max date trên giao diện là ngày hôm nay
              max={new Date().toISOString().split("T")[0]}
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
              <option value="Male">Nam</option>
              <option value="Female">Nữ</option>
              <option value="Other">Khác</option>
            </select>
          </div>
        </div>

        <div style={{marginTop: '20px'}}>
            <button 
                type="button" 
                className="save-btn" 
                onClick={handleSave}
                disabled={saving}
                style={{
                    display: 'flex', 
                    alignItems: 'center', 
                    justifyContent: 'center', 
                    gap: '8px',
                    opacity: saving ? 0.7 : 1
                }}
            >
                <Save size={18} />
                {saving ? "Đang lưu..." : "Lưu thay đổi"}
            </button>
        </div>
      </form>
    </div>
  );
};

export default AccountInfo;