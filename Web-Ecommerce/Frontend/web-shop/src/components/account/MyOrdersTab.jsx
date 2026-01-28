import React, { useState, useEffect } from 'react';
import { Package, Eye, XCircle, ChevronLeft, ChevronRight, MapPin, Phone, User, Star } from 'lucide-react';
import './MyOrdersTab.css';

const MyOrdersTab = () => {
    const [orders, setOrders] = useState([]);
    const [loading, setLoading] = useState(true);

    // STATES CHO PHÂN TRANG
    const [currentPage, setCurrentPage] = useState(1);
    const ordersPerPage = 5; 

    // STATES CHO MODAL
    const [showModal, setShowModal] = useState(false);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [loadingDetail, setLoadingDetail] = useState(false);

    // STATES CHO ĐÁNH GIÁ
    const [showReviewModal, setShowReviewModal] = useState(false);
    const [reviewData, setReviewData] = useState({ orderId: null, rating: 5, comment: '' });
    const [hoverRating, setHoverRating] = useState(0); 

    // 1. LẤY DANH SÁCH ĐƠN HÀNG
    const fetchOrders = async () => {
        const token = localStorage.getItem('token');
        try {
            const res = await fetch('http://localhost:5198/api/Order/mine', {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                const data = await res.json();
                setOrders(data.sort((a, b) => new Date(b.orderDate) - new Date(a.orderDate)));
            }
        } catch (err) {
            console.error("Lỗi lấy đơn hàng", err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchOrders();
    }, []);

    // 2. XỬ LÝ HỦY ĐƠN
    const handleCancelOrder = async (orderId) => {
        if (!window.confirm("Bạn có chắc chắn muốn hủy đơn hàng này không?")) return;
        const token = localStorage.getItem('token');
        try {
            const res = await fetch(`http://localhost:5198/api/Order/${orderId}/cancel`, {
                method: 'PUT', 
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                alert("Hủy đơn hàng thành công!");
                setOrders(orders.map(order => 
                    order.orderId === orderId ? { ...order, status: 'Cancelled' } : order
                ));
            } else {
                const data = await res.json();
                alert(data.message || "Không thể hủy đơn hàng.");
            }
        } catch (error) {
            console.error("Lỗi hủy đơn:", error);
            alert("Lỗi kết nối server.");
        }
    };

    // 3. XỬ LÝ XEM CHI TIẾT
    const handleViewDetail = async (orderId) => {
        setShowModal(true);
        setLoadingDetail(true);
        const token = localStorage.getItem('token');
        try {
            const res = await fetch(`http://localhost:5198/api/Order/${orderId}`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                const data = await res.json();
                setSelectedOrder(data);
            }
        } catch (error) {
            console.error("Lỗi lấy chi tiết:", error);
        } finally {
            setLoadingDetail(false);
        }
    };

    const closeModal = () => {
        setShowModal(false);
        setSelectedOrder(null);
    };

    // 4. XỬ LÝ ĐÁNH GIÁ
    const openReviewModal = (order) => {
        setReviewData({ orderId: order.orderId, rating: 5, comment: '' });
        setShowReviewModal(true);
    };

    const submitReview = async () => {
        if (!reviewData.comment.trim()) {
            alert("Vui lòng viết vài lời nhận xét nhé!");
            return;
        }
        const token = localStorage.getItem('token');
        try {
            const res = await fetch('http://localhost:5198/api/Reviews', {
                method: 'POST',
                headers: { 
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}` 
                },
                body: JSON.stringify({
                    orderId: reviewData.orderId,
                    rating: reviewData.rating,
                    comment: reviewData.comment
                })
            });
            if (res.ok) {
                alert("Cảm ơn bạn đã đánh giá!");
                setShowReviewModal(false);
            } else {
                alert("Gửi đánh giá thất bại.");
            }
        } catch (error) {
            console.error(error);
            alert("Lỗi kết nối.");
        }
    };

    // Helper
    const getStatusColor = (status) => {
        switch(status) {
            case 'Delivered': return '#10b981'; 
            case 'Pending': return '#f59e0b';   
            case 'Cancelled': return '#ef4444'; 
            case 'Shipping': return '#3b82f6';  
            default: return '#6b7280';          
        }
    };

    const getStatusText = (status) => {
        switch(status) {
            case 'Pending': return 'Chờ xác nhận';
            case 'Shipping': return 'Đang giao hàng';
            case 'Delivered': return 'Đã giao';
            case 'Cancelled': return 'Đã hủy';
            default: return status;
        }
    };

    // Pagination
    const indexOfLastOrder = currentPage * ordersPerPage;
    const indexOfFirstOrder = indexOfLastOrder - ordersPerPage;
    const currentOrders = orders.slice(indexOfFirstOrder, indexOfLastOrder);
    const totalPages = Math.ceil(orders.length / ordersPerPage);
    const changePage = (pageNumber) => setCurrentPage(pageNumber);

    if (loading) return <div className="p-4">Đang tải đơn hàng...</div>;

    return (
        <div className="my-orders-container">
            <h2 className="tab-title">Đơn hàng của tôi</h2>
            
            {orders.length === 0 ? (
                <div className="empty-orders">
                    <div className="empty-icon-wrapper"><Package size={48} /></div>
                    <p>Bạn chưa có đơn hàng nào.</p>
                </div>
            ) : (
                <>
                    <div className="order-list">
                        {currentOrders.map((order) => (
                            <div key={order.orderId} className="order-card">
                                <div className="order-header">
                                    <span className="order-id">Đơn hàng #{order.orderId}</span>
                                    <span 
                                        className="status-badge"
                                        style={{
                                            color: getStatusColor(order.status), 
                                            backgroundColor: getStatusColor(order.status) + '20',
                                            border: `1px solid ${getStatusColor(order.status)}40`
                                        }}
                                    >
                                        {getStatusText(order.status)}
                                    </span>
                                </div>

                                <div className="product-info">
                                    <div className="product-thumb">
                                        <Package size={24} color="#6b7280"/>
                                    </div>
                                    <div>
                                        <p className="product-name">{order.firstProductName || "Sản phẩm..."}</p>
                                        <p className="product-count">
                                            {order.productCount > 1 ? `và ${order.productCount - 1} sản phẩm khác` : `Số lượng: 1`}
                                        </p>
                                        {/* ✅ SỬA LỖI Invalid Date: Thêm kiểm tra null */}
                                        <p className="order-date">
                                            {order.orderDate ? new Date(order.orderDate).toLocaleDateString('vi-VN') : ''}
                                        </p>
                                    </div>
                                </div>

                                <div className="order-footer">
                                    <div className="total-section">
                                        <span className="total-label">Tổng tiền: </span>
                                        <span className="total-price">{order.totalAmount?.toLocaleString()}đ</span>
                                    </div>
                                    <div className="action-buttons">
                                        <button className="btn-action btn-view" onClick={() => handleViewDetail(order.orderId)}>
                                            <Eye size={16} /> Chi tiết
                                        </button>

                                        {order.status === 'Pending' && (
                                            <button className="btn-action btn-cancel" onClick={() => handleCancelOrder(order.orderId)}>
                                                <XCircle size={16} /> Hủy đơn
                                            </button>
                                        )}

                                        {order.status === 'Delivered' && (
                                            <button className="btn-action btn-rate" onClick={() => openReviewModal(order)}>
                                                <Star size={16} fill="currentColor" /> Đánh giá
                                            </button>
                                        )}
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>

                    {totalPages > 1 && (
                        <div className="pagination">
                            <button className="page-btn" disabled={currentPage === 1} onClick={() => changePage(currentPage - 1)}>
                                <ChevronLeft size={20} />
                            </button>
                            {[...Array(totalPages)].map((_, index) => (
                                <button
                                    key={index}
                                    className={`page-number ${currentPage === index + 1 ? 'active' : ''}`}
                                    onClick={() => changePage(index + 1)}
                                >
                                    {index + 1}
                                </button>
                            ))}
                            <button className="page-btn" disabled={currentPage === totalPages} onClick={() => changePage(currentPage + 1)}>
                                <ChevronRight size={20} />
                            </button>
                        </div>
                    )}
                </>
            )}

            {/* MODAL CHI TIẾT */}
            {showModal && (
                <div className="modal-overlay" onClick={closeModal}>
                    <div className="modal-content" onClick={e => e.stopPropagation()}>
                        <button className="modal-close-btn" onClick={closeModal}><XCircle size={24}/></button>
                        <h3 className="modal-title">Chi tiết đơn hàng #{selectedOrder?.orderId}</h3>
                        
                        {loadingDetail ? <p>Đang tải chi tiết...</p> : selectedOrder ? (
                            <div className="order-detail-body">
                                <div className="detail-section">
                                    <h4>Thông tin nhận hàng</h4>
                                    <div className="info-row"><User size={16}/> <span>{selectedOrder.receiverName}</span></div>
                                    <div className="info-row"><Phone size={16}/> <span>{selectedOrder.receiverPhone}</span></div>
                                    <div className="info-row"><MapPin size={16}/> <span>{selectedOrder.shippingAddress}</span></div>
                                </div>
                                <div className="detail-section">
                                    <h4>Sản phẩm</h4>
                                    <div className="detail-items-list">
                                        {selectedOrder.items?.map((item, index) => (
                                            <div key={index} className="detail-item">
                                                <div className="item-img-placeholder"><Package size={20}/></div>
                                                <div className="item-info">
                                                    <p className="item-name">{item.productName || item.ProductName || "Sản phẩm"}</p> 
                                                    <p className="item-meta">x{item.quantity || item.Quantity}</p>
                                                </div>
                                                <p className="item-price">{((item.price || item.Price || 0) * (item.quantity || item.Quantity || 1)).toLocaleString()}đ</p>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="detail-summary">
                                    <div className="summary-row total">
                                        <span>Tổng cộng</span>
                                        <span>{selectedOrder.totalAmount?.toLocaleString()}đ</span>
                                    </div>
                                </div>
                            </div>
                        ) : <p>Không tìm thấy thông tin.</p>}
                    </div>
                </div>
            )}

            {/* MODAL ĐÁNH GIÁ (ĐÃ UPDATE CSS STARS-ROW) */}
            {showReviewModal && (
                <div className="modal-overlay" onClick={() => setShowReviewModal(false)}>
                    <div className="modal-content review-modal" onClick={e => e.stopPropagation()}>
                        <button className="modal-close-btn" onClick={() => setShowReviewModal(false)}><XCircle size={24}/></button>
                        <h3 className="modal-title">Đánh giá sản phẩm</h3>
                        
                        <div className="star-rating-container">
                            {/* ✅ Div bao quanh các ngôi sao để CSS stars-row hoạt động */}
                            <div className="stars-row"> 
                                {[1, 2, 3, 4, 5].map((star) => (
                                    <button 
                                        key={star}
                                        type="button"
                                        className="star-btn"
                                        onMouseEnter={() => setHoverRating(star)}
                                        onMouseLeave={() => setHoverRating(0)}
                                        onClick={() => setReviewData({...reviewData, rating: star})}
                                    >
                                        <Star 
                                            size={32} 
                                            color="#facc15" 
                                            fill={(hoverRating || reviewData.rating) >= star ? "#facc15" : "none"} 
                                        />
                                    </button>
                                ))}
                            </div>
                            <p className="rating-text">
                                {reviewData.rating === 5 ? 'Tuyệt vời' : 
                                 reviewData.rating === 4 ? 'Hài lòng' : 
                                 reviewData.rating === 3 ? 'Bình thường' : 
                                 reviewData.rating === 2 ? 'Không hài lòng' : 'Tệ'}
                            </p>
                        </div>

                        <textarea 
                            className="review-textarea"
                            placeholder="Hãy chia sẻ cảm nhận của bạn về sản phẩm nhé..."
                            value={reviewData.comment}
                            onChange={(e) => setReviewData({...reviewData, comment: e.target.value})}
                        ></textarea>

                        <button className="btn-submit-review" onClick={submitReview}>
                            Gửi đánh giá
                        </button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default MyOrdersTab;