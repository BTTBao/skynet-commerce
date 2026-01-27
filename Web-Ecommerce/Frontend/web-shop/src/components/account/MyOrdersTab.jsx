import React, { useState, useEffect } from 'react';
import { Package } from 'lucide-react';
import './MyOrdersTab.css'; // <--- Import CSS vừa tạo

const MyOrdersTab = () => {
    const [orders, setOrders] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchOrders = async () => {
            const token = localStorage.getItem('token');
            try {
                // Nhớ đổi port thành 5198 nếu bạn đang dùng http
                const res = await fetch('http://localhost:5198/api/Order/mine', {
                    headers: { 'Authorization': `Bearer ${token}` }
                });
                if (res.ok) {
                    const data = await res.json();
                    setOrders(data);
                }
            } catch (err) {
                console.error("Lỗi lấy đơn hàng", err);
            } finally {
                setLoading(false);
            }
        };
        fetchOrders();
    }, []);

    const getStatusColor = (status) => {
        switch(status) {
            case 'Completed': return '#10b981'; // Xanh lá
            case 'Pending': return '#f59e0b';   // Vàng
            case 'Cancelled': return '#ef4444'; // Đỏ
            default: return '#3b82f6';          // Xanh dương
        }
    };

    if (loading) return <div className="p-4">Đang tải đơn hàng...</div>;

    return (
        <div>
            <h2 className="tab-title">Đơn hàng của tôi</h2>
            
            {orders.length === 0 ? (
                <div className="empty-orders">
                    <div className="empty-icon-wrapper">
                        <Package size={48} />
                    </div>
                    <p>Bạn chưa có đơn hàng nào.</p>
                </div>
            ) : (
                <div className="order-list">
                    {orders.map((order) => (
                        <div key={order.orderId} className="order-card">
                            {/* Header: Shop & Status */}
                            <div className="order-header">
                                <span className="shop-name">{order.shopName}</span>
                                <span 
                                    className="status-badge"
                                    style={{
                                        color: getStatusColor(order.status), 
                                        backgroundColor: getStatusColor(order.status) + '20' // Thêm độ trong suốt
                                    }}
                                >
                                    {order.status}
                                </span>
                            </div>

                            {/* Body: Product Info */}
                            <div className="product-info">
                                <div className="product-thumb">
                                    <Package size={24} color="#9ca3af"/>
                                </div>
                                <div>
                                    <p className="product-name">{order.firstProductName}</p>
                                    <p className="product-count">
                                        và {order.productCount - 1} sản phẩm khác
                                    </p>
                                </div>
                            </div>

                            {/* Footer: Price & Action */}
                            <div className="order-footer">
                                <div>
                                    <span className="total-label">Tổng tiền: </span>
                                    <span className="total-price">
                                        {order.totalAmount?.toLocaleString()}đ
                                    </span>
                                </div>
                                <button className="btn-view-detail">
                                    Xem chi tiết
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default MyOrdersTab;