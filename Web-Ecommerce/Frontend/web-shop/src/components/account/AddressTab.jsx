import React, { useState, useEffect } from 'react';
import './AddressTab.css';

const AddressTab = () => {
    const [addresses, setAddresses] = useState([]);
    const [loading, setLoading] = useState(true);
    
    // State quản lý form
    const [showForm, setShowForm] = useState(false);
    const [editingId, setEditingId] = useState(null); // ID của địa chỉ đang sửa (null nếu là thêm mới)
    
    const [locations, setLocations] = useState({ provinces: [], districts: [], wards: [] });
    const [formData, setFormData] = useState({
        addressName: 'Nhà riêng',
        receiverFullName: '',
        receiverPhone: '',
        province: '', provinceId: '',
        district: '', districtId: '',
        ward: '',
        addressLine: '',
        isDefault: false
    });

    // 1. Lấy danh sách & Sắp xếp Mặc định lên đầu
    const fetchAddresses = async () => {
        const token = localStorage.getItem('token');
        try {
            const res = await fetch('http://localhost:5198/api/User/addresses', {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                let data = await res.json();
                
                // --- LOGIC SẮP XẾP: Mặc định lên đầu ---
                data.sort((a, b) => (b.isDefault === true) - (a.isDefault === true));
                
                setAddresses(data);
            }
        } catch (err) {
            console.error("Lỗi lấy địa chỉ", err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => { fetchAddresses(); }, []);

    // 2. Load Tỉnh/Thành (Giữ nguyên logic của bạn)
    useEffect(() => {
        if (showForm) {
            fetch('https://esgoo.net/api-tinhthanh/1/0.htm')
                .then(res => res.json())
                .then(data => { if (data.error === 0) setLocations(prev => ({ ...prev, provinces: data.data })); });
        }
    }, [showForm]);

    // ... (Giữ nguyên các hàm handleProvinceChange, handleDistrictChange, handleWardChange)
    const handleProvinceChange = (e) => {
        const provinceId = e.target.value;
        const provinceName = e.target.options[e.target.selectedIndex].text;
        setFormData(prev => ({ ...prev, province: provinceName, provinceId, district: '', districtId: '', ward: '' }));
        fetch(`https://esgoo.net/api-tinhthanh/2/${provinceId}.htm`).then(res => res.json()).then(data => { if (data.error === 0) setLocations(prev => ({ ...prev, districts: data.data })); });
    };
    const handleDistrictChange = (e) => {
        const districtId = e.target.value;
        const districtName = e.target.options[e.target.selectedIndex].text;
        setFormData(prev => ({ ...prev, district: districtName, districtId, ward: '' }));
        fetch(`https://esgoo.net/api-tinhthanh/3/${districtId}.htm`).then(res => res.json()).then(data => { if (data.error === 0) setLocations(prev => ({ ...prev, wards: data.data })); });
    };
    const handleWardChange = (e) => {
        const wardName = e.target.options[e.target.selectedIndex].text;
        setFormData(prev => ({ ...prev, ward: wardName }));
    };

    // --- CHỨC NĂNG MỚI: ĐẶT MẶC ĐỊNH ---
    const handleSetDefault = async (id) => {
        const token = localStorage.getItem('token');
        try {
            const res = await fetch(`http://localhost:5198/api/User/addresses/${id}/set-default`, {
                method: 'PUT',
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                alert("Đã thay đổi địa chỉ mặc định!");
                fetchAddresses(); // Load lại để sắp xếp lại
            }
        } catch (error) {
            console.error(error);
        }
    };

    // --- CHỨC NĂNG MỚI: XÓA ---
    const handleDelete = async (id) => {
        if (!window.confirm("Bạn có chắc chắn muốn xóa địa chỉ này?")) return;
        const token = localStorage.getItem('token');
        try {
            const res = await fetch(`http://localhost:5198/api/User/addresses/${id}`, {
                method: 'DELETE',
                headers: { 'Authorization': `Bearer ${token}` }
            });
            
            if (res.ok) {
                alert("Đã xóa thành công!");
                fetchAddresses();
            } else {
                const data = await res.json();
                alert(data.message || "Không thể xóa");
            }
        } catch (error) {
            console.error(error);
        }
    };

    // --- CHỨC NĂNG MỚI: CHUẨN BỊ SỬA (Populate Form) ---
    const handleEdit = (addr) => {
        setEditingId(addr.addressId); // Set ID đang sửa
        // Điền dữ liệu cũ vào form
        // Lưu ý: Vì DB bạn lưu Tên Tỉnh (String) chứ ko lưu ID, nên khi sửa người dùng phải chọn lại địa điểm
        // Hoặc bạn chỉ cho sửa Tên/SĐT/Số nhà. Ở đây mình cho load lại form cơ bản.
        setFormData({
            addressName: addr.addressName,
            receiverFullName: addr.receiverFullName,
            receiverPhone: addr.receiverPhone,
            addressLine: addr.addressLine.split(',')[0], // Tạm lấy phần đầu
            province: '', provinceId: '', // Reset địa điểm để chọn lại cho chính xác
            district: '', districtId: '',
            ward: '',
            isDefault: addr.isDefault
        });
        setShowForm(true);
    };

    // 3. XỬ LÝ SUBMIT (THÊM MỚI HOẶC CẬP NHẬT)
    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('token');
        
        if (!formData.province || !formData.district || !formData.ward) {
            alert("Vui lòng chọn đầy đủ Tỉnh/Huyện/Xã");
            return;
        }

        // Xác định URL và Method dựa trên editingId
        const url = editingId 
            ? `http://localhost:5198/api/User/addresses/${editingId}` // API Sửa
            : 'http://localhost:5198/api/User/addresses';             // API Thêm mới
        
        const method = editingId ? 'PUT' : 'POST';

        try {
            const res = await fetch(url, {
                method: method,
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
                alert(editingId ? "Cập nhật thành công!" : "Thêm mới thành công!");
                setShowForm(false);
                setEditingId(null); // Reset trạng thái sửa
                fetchAddresses();
                // Reset form
                setFormData({ addressName: 'Nhà riêng', receiverFullName: '', receiverPhone: '', province: '', provinceId: '', district: '', districtId: '', ward: '', addressLine: '', isDefault: false });
            } else {
                alert("Có lỗi xảy ra.");
            }
        } catch (error) {
            console.error(error);
        }
    };

    const handleCancelForm = () => {
        setShowForm(false);
        setEditingId(null);
        setFormData({ addressName: 'Nhà riêng', receiverFullName: '', receiverPhone: '', province: '', provinceId: '', district: '', districtId: '', ward: '', addressLine: '', isDefault: false });
    };

    if (loading) return <div>Đang tải địa chỉ...</div>;

    return (
        <div>
             <div className="address-header">
                <h2 className="tab-title">Địa chỉ giao hàng</h2>
                {!showForm && (
                    <button className="btn-add-address" onClick={() => {
                        setEditingId(null); // Đảm bảo là chế độ thêm mới
                        setShowForm(true);
                    }}>+ Thêm địa chỉ</button>
                )}
            </div>

            {/* --- FORM (Dùng chung cho Thêm & Sửa) --- */}
            {showForm ? (
                <div className="add-address-form-container">
                    <h3 style={{marginBottom: 16}}>{editingId ? "Cập nhật địa chỉ" : "Thêm địa chỉ mới"}</h3>
                    <form onSubmit={handleSubmit} className="add-address-form">
                        {/* ... (Giữ nguyên các input Form cũ của bạn) ... */}
                        <div className="form-row">
                            <div className="form-group half">
                                <label>Họ tên người nhận</label>
                                <input type="text" required className="form-input" value={formData.receiverFullName} onChange={e => setFormData({...formData, receiverFullName: e.target.value})} />
                            </div>
                            <div className="form-group half">
                                <label>Số điện thoại</label>
                                <input type="text" required className="form-input" value={formData.receiverPhone} onChange={e => setFormData({...formData, receiverPhone: e.target.value})} />
                            </div>
                        </div>

                        {/* Dropdown Địa lý */}
                        <div className="form-row">
                            <div className="form-group third">
                                <label>Tỉnh/Thành phố</label>
                                <select className="form-select" onChange={handleProvinceChange} required value={formData.provinceId}>
                                    <option value="">{formData.province || "-- Chọn Tỉnh --"}</option>
                                    {locations.provinces.map(p => <option key={p.id} value={p.id}>{p.full_name}</option>)}
                                </select>
                            </div>
                            <div className="form-group third">
                                <label>Quận/Huyện</label>
                                <select className="form-select" onChange={handleDistrictChange} required value={formData.districtId} disabled={!formData.provinceId}>
                                    <option value="">{formData.district || "-- Chọn Huyện --"}</option>
                                    {locations.districts.map(d => <option key={d.id} value={d.id}>{d.full_name}</option>)}
                                </select>
                            </div>
                            <div className="form-group third">
                                <label>Phường/Xã</label>
                                <select className="form-select" onChange={handleWardChange} required disabled={!formData.districtId}>
                                    <option value="">{formData.ward || "-- Chọn Xã --"}</option>
                                    {locations.wards.map(w => <option key={w.id} value={w.id}>{w.full_name}</option>)}
                                </select>
                            </div>
                        </div>

                        <div className="form-group">
                            <label>Địa chỉ cụ thể</label>
                            <input type="text" required className="form-input" value={formData.addressLine} onChange={e => setFormData({...formData, addressLine: e.target.value})} />
                        </div>

                        <div className="form-row" style={{ marginBottom: 20 }}>
                            {/* Cột Trái: Loại địa chỉ */}
                            <div className="form-group half">
                                <label>Loại địa chỉ</label>
                                <div className="radio-group">
                                    <label className="custom-control-label">
                                        <input 
                                            type="radio" 
                                            name="type" 
                                            checked={formData.addressName === 'Nhà riêng'} 
                                            onChange={() => setFormData({...formData, addressName: 'Nhà riêng'})} 
                                        /> 
                                        Nhà riêng
                                    </label>
                                    <label className="custom-control-label">
                                        <input 
                                            type="radio" 
                                            name="type" 
                                            checked={formData.addressName === 'Văn phòng'} 
                                            onChange={() => setFormData({...formData, addressName: 'Văn phòng'})} 
                                        /> 
                                        Văn phòng
                                    </label>
                                </div>
                            </div>

                            {/* Cột Phải: Checkbox mặc định */}
                            <div className="form-group half">
                                {/* 👇 Mẹo: Label tàng hình này giúp đẩy Checkbox xuống ngang hàng với Radio bên trái */}
                                <label className="spacer-label">Tùy chọn</label> 
                                
                                <div className="radio-group"> {/* Dùng chung class height với bên kia để căn giữa */}
                                    <label className="custom-control-label">
                                        <input 
                                            type="checkbox" 
                                            checked={formData.isDefault} 
                                            onChange={e => setFormData({...formData, isDefault: e.target.checked})} 
                                        />
                                        Đặt làm địa chỉ mặc định
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div className="form-actions">
                            <button type="button" className="btn-cancel" onClick={handleCancelForm}>Hủy bỏ</button>
                            <button type="submit" className="btn-save">{editingId ? "Cập nhật" : "Lưu địa chỉ"}</button>
                        </div>
                    </form>
                </div>
            ) : (
                // --- DANH SÁCH ĐỊA CHỈ ---
                addresses.length === 0 ? (
                    <p className="empty-address-msg">Bạn chưa lưu địa chỉ nào.</p>
                ) : (
                    <div className="address-list">
                        {addresses.map((addr) => (
                            <div key={addr.addressId} className={`address-item ${addr.isDefault ? 'default-item' : ''}`}>
                                <div>
                                    <p className="address-name">
                                        {addr.addressName} 
                                        {addr.isDefault && <span className="default-badge">Mặc định</span>}
                                    </p>
                                    <p className="address-detail">{addr.fullAddress}</p>
                                    <p className="address-detail">{addr.receiverFullName} - {addr.receiverPhone}</p>
                                    
                                    {/* Nút đặt mặc định nhanh */}
                                    {!addr.isDefault && (
                                        <button 
                                            className="btn-set-default" 
                                            onClick={() => handleSetDefault(addr.addressId)}
                                            style={{marginTop: 8, fontSize: '0.85rem', color: '#2563eb', background: 'none', border: 'none', cursor: 'pointer', padding: 0, textDecoration: 'underline'}}
                                        >
                                            Thiết lập mặc định
                                        </button>
                                    )}
                                </div>
                                <div className="address-actions">
                                    <button className="btn-action btn-edit" onClick={() => handleEdit(addr)}>Sửa</button>
                                    {/* Không cho xóa địa chỉ mặc định */}
                                    {!addr.isDefault && (
                                        <button className="btn-action btn-delete" onClick={() => handleDelete(addr.addressId)}>Xóa</button>
                                    )}
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