// src/components/account/AddressTab.jsx
import React, { useState, useEffect } from 'react';
import './AddressTab.css';

const AddressTab = () => {
    // State danh sách địa chỉ đã lưu
    const [addresses, setAddresses] = useState([]);
    const [loading, setLoading] = useState(true);
    
    // State cho Form thêm mới
    const [showForm, setShowForm] = useState(false);
    const [locations, setLocations] = useState({ provinces: [], districts: [], wards: [] });
    const [formData, setFormData] = useState({
        addressName: 'Nhà riêng',
        receiverFullName: '',
        receiverPhone: '',
        province: '', // Lưu Tên (để gửi BE)
        provinceId: '', // Lưu ID (để load Quận)
        district: '',
        districtId: '',
        ward: '',
        addressLine: '',
        isDefault: false
    });

    // 1. Lấy danh sách địa chỉ từ Backend
    const fetchAddresses = async () => {
        const token = localStorage.getItem('token');
        try {
            const res = await fetch('http://localhost:5198/api/User/addresses', {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                const data = await res.json();
                setAddresses(data);
            }
        } catch (err) {
            console.error("Lỗi lấy địa chỉ", err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchAddresses();
    }, []);

    // 2. Load Danh sách Tỉnh/Thành (API Công cộng)
    useEffect(() => {
        if (showForm) {
            // API miễn phí từ esgoo.net
            fetch('https://esgoo.net/api-tinhthanh/1/0.htm')
                .then(res => res.json())
                .then(data => {
                    if (data.error === 0) setLocations(prev => ({ ...prev, provinces: data.data }));
                });
        }
    }, [showForm]);

    // Xử lý khi chọn Tỉnh -> Load Huyện
    const handleProvinceChange = (e) => {
        const provinceId = e.target.value;
        const provinceName = e.target.options[e.target.selectedIndex].text;
        
        setFormData(prev => ({ ...prev, province: provinceName, provinceId, district: '', districtId: '', ward: '' }));
        setLocations(prev => ({ ...prev, districts: [], wards: [] }));

        fetch(`https://esgoo.net/api-tinhthanh/2/${provinceId}.htm`)
            .then(res => res.json())
            .then(data => {
                if (data.error === 0) setLocations(prev => ({ ...prev, districts: data.data }));
            });
    };

    // Xử lý khi chọn Huyện -> Load Xã
    const handleDistrictChange = (e) => {
        const districtId = e.target.value;
        const districtName = e.target.options[e.target.selectedIndex].text;

        setFormData(prev => ({ ...prev, district: districtName, districtId, ward: '' }));
        
        fetch(`https://esgoo.net/api-tinhthanh/3/${districtId}.htm`)
            .then(res => res.json())
            .then(data => {
                if (data.error === 0) setLocations(prev => ({ ...prev, wards: data.data }));
            });
    };

    // Xử lý khi chọn Xã
    const handleWardChange = (e) => {
        const wardName = e.target.options[e.target.selectedIndex].text;
        setFormData(prev => ({ ...prev, ward: wardName }));
    };

    // 3. Gửi Form lên Backend
    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token');
        
        // 👇 THÊM DÒNG NÀY ĐỂ KIỂM TRA
        console.log("Token hiện tại:", token); 

        if (!token) {
            alert("Bạn chưa đăng nhập hoặc phiên đăng nhập hết hạn!");
            return;
        }
        // Validate cơ bản
        if(!formData.province || !formData.district || !formData.ward) {
            alert("Vui lòng chọn đầy đủ Tỉnh/Huyện/Xã");
            return;
        }

        try {
            const res = await fetch('http://localhost:5198/api/User/addresses', {
                method: 'POST',
                headers: { 
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify({
                    AddressName: formData.addressName,
                    ReceiverFullName: formData.receiverFullName,
                    ReceiverPhone: formData.receiverPhone,
                    Province: formData.province,
                    District: formData.district,
                    Ward: formData.ward,
                    AddressLine: formData.addressLine,
                    IsDefault: formData.isDefault
                })
            });

            if (res.ok) {
                alert("Thêm địa chỉ thành công!");
                setShowForm(false);
                fetchAddresses(); // Load lại danh sách
                // Reset form
                setFormData({ addressName: 'Nhà riêng', receiverFullName: '', receiverPhone: '', province: '', provinceId: '', district: '', districtId: '', ward: '', addressLine: '', isDefault: false });
            } else {
                alert("Có lỗi xảy ra khi lưu địa chỉ.");
            }
        } catch (error) {
            console.error(error);
        }
    };

    if (loading) return <div>Đang tải địa chỉ...</div>;

    return (
        <div>
             <div className="address-header">
                <h2 className="tab-title">Địa chỉ giao hàng</h2>
                {!showForm && (
                    <button className="btn-add-address" onClick={() => setShowForm(true)}>+ Thêm địa chỉ</button>
                )}
            </div>

            {/* --- FORM THÊM ĐỊA CHỈ --- */}
            {showForm ? (
                <div className="add-address-form-container">
                    <h3 style={{marginBottom: 16}}>Thêm địa chỉ mới</h3>
                    <form onSubmit={handleSubmit} className="add-address-form">
                        <div className="form-row">
                            <div className="form-group half">
                                <label>Họ tên người nhận</label>
                                <input type="text" required className="form-input" 
                                    value={formData.receiverFullName} 
                                    onChange={e => setFormData({...formData, receiverFullName: e.target.value})} 
                                    placeholder="Nguyễn Văn A" />
                            </div>
                            <div className="form-group half">
                                <label>Số điện thoại</label>
                                <input type="text" required className="form-input" 
                                    value={formData.receiverPhone} 
                                    onChange={e => setFormData({...formData, receiverPhone: e.target.value})} 
                                    placeholder="09xxx..." />
                            </div>
                        </div>

                        <div className="form-row">
                            <div className="form-group third">
                                <label>Tỉnh/Thành phố</label>
                                <select className="form-select" onChange={handleProvinceChange} required value={formData.provinceId}>
                                    <option value="">-- Chọn Tỉnh --</option>
                                    {locations.provinces.map(p => <option key={p.id} value={p.id}>{p.full_name}</option>)}
                                </select>
                            </div>
                            <div className="form-group third">
                                <label>Quận/Huyện</label>
                                <select className="form-select" onChange={handleDistrictChange} required value={formData.districtId} disabled={!formData.provinceId}>
                                    <option value="">-- Chọn Huyện --</option>
                                    {locations.districts.map(d => <option key={d.id} value={d.id}>{d.full_name}</option>)}
                                </select>
                            </div>
                            <div className="form-group third">
                                <label>Phường/Xã</label>
                                <select className="form-select" onChange={handleWardChange} required disabled={!formData.districtId}>
                                    <option value="">-- Chọn Xã --</option>
                                    {locations.wards.map(w => <option key={w.id} value={w.id}>{w.full_name}</option>)}
                                </select>
                            </div>
                        </div>

                        <div className="form-group">
                            <label>Địa chỉ cụ thể (Số nhà, Tên đường)</label>
                            <input type="text" required className="form-input" 
                                value={formData.addressLine} 
                                onChange={e => setFormData({...formData, addressLine: e.target.value})} 
                                placeholder="Số 123 đường ABC..." />
                        </div>

                        <div className="form-row" style={{alignItems: 'center', marginBottom: 20}}>
                             <div className="form-group half">
                                <label>Loại địa chỉ</label>
                                <div style={{display:'flex', gap: 10}}>
                                    <label><input type="radio" name="type" checked={formData.addressName === 'Nhà riêng'} onChange={() => setFormData({...formData, addressName: 'Nhà riêng'})} /> Nhà riêng</label>
                                    <label><input type="radio" name="type" checked={formData.addressName === 'Văn phòng'} onChange={() => setFormData({...formData, addressName: 'Văn phòng'})} /> Văn phòng</label>
                                </div>
                            </div>
                            <div className="form-group half">
                                <label style={{cursor:'pointer', display:'flex', alignItems:'center', gap: 8}}>
                                    <input type="checkbox" checked={formData.isDefault} onChange={e => setFormData({...formData, isDefault: e.target.checked})} />
                                    Đặt làm địa chỉ mặc định
                                </label>
                            </div>
                        </div>

                        <div className="form-actions">
                            <button type="button" className="btn-cancel" onClick={() => setShowForm(false)}>Hủy bỏ</button>
                            <button type="submit" className="btn-save">Lưu địa chỉ</button>
                        </div>
                    </form>
                </div>
            ) : (
                // --- DANH SÁCH ĐỊA CHỈ (Code cũ) ---
                addresses.length === 0 ? (
                    <p className="empty-address-msg">Bạn chưa lưu địa chỉ nào.</p>
                ) : (
                    <div className="address-list">
                        {addresses.map((addr) => (
                            <div key={addr.addressId} className="address-item">
                                <div>
                                    <p className="address-name">
                                        {addr.addressName} 
                                        {addr.isDefault && <span className="default-badge">Mặc định</span>}
                                    </p>
                                    <p className="address-detail">{addr.fullAddress}</p>
                                    <p className="address-detail">{addr.receiverFullName} - {addr.receiverPhone}</p>
                                </div>
                                <div className="address-actions">
                                    <button className="btn-action btn-edit">Sửa</button>
                                    <button className="btn-action btn-delete">Xóa</button>
                                </div>
                            </div>
                        ))}
                    </div>
                )
            )}
        </div>
    );
};

export default AddressTab;