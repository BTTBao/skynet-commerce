import React, { useState, useEffect } from 'react';
import { Store, Upload, Clock, Monitor, AlertCircle } from 'lucide-react'; 
import './SellerRegistrationTab.css';

const SellerRegistrationTab = () => {
    // State Form
    const [shopName, setShopName] = useState('');
    const [description, setDescription] = useState('');
    const [citizenID, setCitizenID] = useState('');
    const [citizenImage, setCitizenImage] = useState(null);
    const [previewImage, setPreviewImage] = useState(null);

    // State Status & Reason
    const [currentStatus, setCurrentStatus] = useState('loading'); 
    const [statusMessage, setStatusMessage] = useState('');

    // 1. Check trạng thái khi load trang
    useEffect(() => {
        const checkStatus = async () => {
            const token = localStorage.getItem('token');
            try {
                const res = await fetch('http://localhost:5198/api/User/shop-status', {
                    headers: { 'Authorization': `Bearer ${token}` }
                });
                const data = await res.json();
                if (res.ok) {
                    setCurrentStatus(data.status.toLowerCase());
                    setStatusMessage(data.message);
                }
            } catch (error) {
                console.error(error);
            }
        };
        checkStatus();
    }, []);

    // 2. Xử lý chọn ảnh
    const handleImageChange = (e) => {
        const file = e.target.files[0];
        if (file) {
            setCitizenImage(file);
            setPreviewImage(URL.createObjectURL(file));
        }
    };

    // 3. Submit Form
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        // Validate ảnh thủ công
        if (!citizenImage) {
            alert("Vui lòng tải lên ảnh chụp CCCD!");
            return;
        }

        const token = localStorage.getItem('token');
        const formData = new FormData();
        formData.append('ShopName', shopName);
        formData.append('Description', description);
        formData.append('CitizenID', citizenID);
        formData.append('CitizenImage', citizenImage);

        try {
            const res = await fetch('http://localhost:5198/api/User/register-shop', {
                method: 'POST',
                headers: { 'Authorization': `Bearer ${token}` },
                body: formData
            });

            // Nếu Server lỗi 500 (trả về HTML lỗi), dòng này sẽ gây ra lỗi "Unexpected token 'S'"
            const data = await res.json();
            
            if (res.ok) {
                alert(data.message);
                setCurrentStatus('pending');
                setStatusMessage('');
            } else {
                alert(data.message || 'Lỗi đăng ký');
            }
        } catch (error) {
            console.error("Lỗi submit:", error);
            alert('Lỗi kết nối server (Có thể do lỗi 500 ở Backend)');
        }
    };

    // --- RENDER GIAO DIỆN ---

    if (currentStatus === 'loading') return <div>Đang tải dữ liệu...</div>;

    // A. ĐÃ CÓ SHOP (APPROVED) - Phần bạn nhắc đến đây ạ 👇
    if (currentStatus === 'approved') { // ✅ Đã sửa thành chữ thường
        return (
            <div className="status-container approved">
                <Monitor size={64} color="#2563eb" />
                <h3>Bạn đang là Đối tác bán hàng!</h3>
                <p>Vui lòng sử dụng ứng dụng <b>Skynet Manager (WinForm)</b> trên máy tính để quản lý cửa hàng.</p>
                <div className="download-box"><span>Mở App WinForm ngay.</span></div>
            </div>
        );
    }

    // B. ĐANG CHỜ DUYỆT (PENDING)
    if (currentStatus === 'pending') {
        return (
            <div className="status-container pending">
                <Clock size={64} color="#f59e0b" />
                <h3>Đơn đăng ký đang chờ duyệt</h3>
                <p>Hệ thống đang xem xét hồ sơ của bạn. Bạn không thể chỉnh sửa lúc này.</p>
                <p className="sub-text">Vui lòng quay lại sau.</p>
            </div>
        );
    }
    
    // C. BỊ TỪ CHỐI (REJECTED) HOẶC CHƯA ĐĂNG KÝ (NONE)
    return (
        <div>
            <h2 className="tab-title">
                {currentStatus === 'rejected' ? 'Gửi lại hồ sơ đăng ký' : 'Đăng ký trở thành người bán'}
            </h2>

            {currentStatus === 'rejected' && (
                <div className="status-container rejected" style={{marginBottom: '20px', borderColor: '#ef4444', backgroundColor: '#fef2f2'}}>
                    <AlertCircle size={48} color="#ef4444" />
                    <h3 style={{color: '#b91c1c'}}>Đơn đăng ký bị từ chối</h3>
                    <p style={{color: '#b91c1c'}}><b>Lý do:</b> {statusMessage}</p>
                    <p className="sub-text">Vui lòng kiểm tra và điền lại thông tin chính xác bên dưới.</p>
                </div>
            )}

            <form onSubmit={handleSubmit} className="seller-form">
                <div className="form-group">
                    <label className="form-label">Tên Shop (Không trùng lặp)</label>
                    <input 
                        type="text" required className="form-input" 
                        value={shopName} onChange={e => setShopName(e.target.value)} 
                        placeholder="Ví dụ: TechZone Official" 
                    />
                </div>

                <div className="form-group">
                    <label className="form-label">Mô tả shop</label>
                    <textarea 
                        rows={3} className="form-textarea" 
                        value={description} onChange={e => setDescription(e.target.value)} 
                        placeholder="Giới thiệu về shop..." 
                    />
                </div>

                <div className="form-group">
                    <label className="form-label">Số CCCD (Mỗi người 1 Shop)</label>
                    <input 
                        type="text" required className="form-input" 
                        value={citizenID} onChange={e => setCitizenID(e.target.value)} 
                        placeholder="Nhập 12 số CCCD" maxLength={12}
                    />
                </div>

                <div className="form-group">
                    <label className="form-label">Ảnh chụp CCCD</label>
                    <div className="file-upload-wrapper">
                        <label htmlFor="file-upload" className="file-upload-label">
                            <Upload size={20} />
                            <span>{citizenImage ? citizenImage.name : "Chọn ảnh mới..."}</span>
                        </label>
                        <input 
                            id="file-upload" type="file" accept="image/*" 
                            onChange={handleImageChange}
                            style={{display: 'none'}}
                        />
                    </div>
                    {previewImage && (
                        <div className="image-preview">
                            <img src={previewImage} alt="Preview" />
                        </div>
                    )}
                </div>

                <button type="submit" className="btn-register-shop">
                    <Store size={18} style={{marginRight: 8}}/>
                    {currentStatus === 'rejected' ? 'Gửi lại đơn đăng ký' : 'Gửi hồ sơ đăng ký'}
                </button>
            </form>
        </div>
    );
};

export default SellerRegistrationTab;