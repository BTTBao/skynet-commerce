import React, { useState, useEffect } from 'react';
import { Package, Eye, XCircle, ChevronLeft, ChevronRight, MapPin, Phone, User, Star, Store, Calendar, Truck } from 'lucide-react';
import './MyOrdersTab.css';

const MyOrdersTab = () => {
    const [orderGroups, setOrderGroups] = useState([]);
    const [loading, setLoading] = useState(true);

    // STATES CHO PHÂN TRANG
    const [currentPage, setCurrentPage] = useState(1);
    const groupsPerPage = 5; 

    // STATES CHO MODAL
    const [showModal, setShowModal] = useState(false);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [loadingDetail, setLoadingDetail] = useState(false);

    // STATES CHO ĐÁNH GIÁ
    const [showReviewModal, setShowReviewModal] = useState(false);
    const [reviewData, setReviewData] = useState({ orderId: null, rating: 5, comment: '' });
    const [hoverRating, setHoverRating] = useState(0); 

    // 1. LẤY DANH SÁCH ĐƠN HÀNG (API GetMyOrders trả về OrderGroup)
    const fetchOrders = async () => {
        const token = localStorage.getItem('token');
        try {
            const res = await fetch('http://localhost:5198/api/Order/mine', {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                const data = await res.json();
                // Data trả về là danh sách Group, sắp xếp mới nhất lên đầu
                setOrderGroups(data);
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

    // 2. XỬ LÝ HỦY ĐƠN CON (SubOrder)
    const handleCancelOrder = async (orderId) => {
        if (!window.confirm("Bạn có chắc chắn muốn hủy đơn hàng của Shop này không?")) return;
        const token = localStorage.getItem('token');
        try {
            const res = await fetch(`http://localhost:5198/api/Order/${orderId}/cancel`, {
                method: 'PUT', 
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                alert("Hủy đơn hàng thành công!");
                fetchOrders(); // Load lại toàn bộ danh sách để cập nhật trạng thái
            } else {
                const data = await res.json();
                alert(data.message || "Không thể hủy đơn hàng.");
            }
        } catch (error) {
            console.error("Lỗi hủy đơn:", error);
            alert("Lỗi kết nối server.");
        }
    };

    // 3. XỬ LÝ XEM CHI TIẾT (SubOrder)
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
    const openReviewModal = (orderId) => {
        setReviewData({ orderId: orderId, rating: 5, comment: '' });
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
                body: JSON.stringify(reviewData)
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

    // Helper Status
    const getStatusText = (status) => {
        switch(status) {
            case 'Pending': return 'Chờ xác nhận';
            case 'Shipping': return 'Đang giao';
            case 'Delivered': return 'Đã giao';
            case 'Cancelled': return 'Đã hủy';
            default: return status;
        }
    };

    const getStatusClass = (status) => {
        return `status-tag status-${status.toLowerCase()}`;
    };

    // Pagination (Phân trang theo Group)
    const indexOfLastGroup = currentPage * groupsPerPage;
    const indexOfFirstGroup = indexOfLastGroup - groupsPerPage;
    const currentGroups = orderGroups.slice(indexOfFirstGroup, indexOfLastGroup);
    const totalPages = Math.ceil(orderGroups.length / groupsPerPage);
    const changePage = (pageNumber) => setCurrentPage(pageNumber);

    if (loading) return <div className="p-4">Đang tải lịch sử đơn hàng...</div>;

    return (
        <div className="my-orders-container">
            <h2 className="tab-title">Lịch sử đơn hàng</h2>
            
            {orderGroups.length === 0 ? (
                <div className="empty-orders">
                    <div className="empty-icon-wrapper"><Package size={48} /></div>
                    <p>Bạn chưa có đơn hàng nào.</p>
                </div>
            ) : (
                <div className="order-group-list">
                    {/* --- LOOP QUA TỪNG LẦN ĐẶT HÀNG (GROUP) --- */}
                    {currentGroups.map((group) => (
                        <div key={group.orderGroupId} className="order-group-card">
                            
                            {/* Header của Group: Ngày & Tổng tiền lần đó */}
                            <div className="group-header">
                                <div className="group-meta">
                                    <span className="group-id">Mã giao dịch: #{group.orderGroupId}</span>
                                    <span className="group-date">
                                        <Calendar size={14} style={{marginRight:4, marginBottom:2}}/>
                                        {new Date(group.createdAt).toLocaleString('vi-VN')}
                                    </span>
                                </div>
                                <div className="group-total-label">
                                    Tổng thanh toán: <span className="highlight-price">{group.totalGroupAmount?.toLocaleString()}đ</span>
                                </div>
                            </div>

                            {/* Body của Group: Liệt kê các đơn con (SubOrders) */}
                            <div className="group-body">
                                {group.subOrders.map((order) => (
                                    <div key={order.orderId} className="sub-order-item">
                                        
                                        {/* Tên Shop & Trạng thái đơn con */}
                                        <div className="sub-order-header">
                                            <div className="shop-info">
                                                <Store size={18} color="#ee4d2d"/>
                                                <span className="shop-name">{order.shopName}</span>
                                            </div>
                                            <div className="order-status-wrapper">
                                                {order.status === 'Shipping' && <Truck size={16} className="mr-1"/>}
                                                <span className={getStatusClass(order.status)}>
                                                    {getStatusText(order.status)}
                                                </span>
                                            </div>
                                        </div>

                                        {/* Thông tin sản phẩm đại diện */}
                                        <div className="sub-order-content" onClick={() => handleViewDetail(order.orderId)}>
                                            <div className="product-preview">
                                                <div className="img-box">
                                                    <Package size={24} color="#888"/>
                                                </div>
                                                <div className="product-text">
                                                    <p className="main-product-name">{order.firstProductName}</p>
                                                    <p className="product-variant-hint">
                                                        {order.items && order.items[0]?.variant}
                                                    </p>
                                                    {order.productCount > 1 && (
                                                        <span className="more-products-tag">
                                                            + {order.productCount - 1} sản phẩm khác
                                                        </span>
                                                    )}
                                                </div>
                                            </div>
                                            <div className="sub-order-price">
                                                {order.totalOrderAmount?.toLocaleString()}đ
                                            </div>
                                        </div>

                                        {/* Nút hành động cho đơn con */}
                                        <div className="sub-order-actions">
                                            <button className="btn-secondary" onClick={() => handleViewDetail(order.orderId)}>
                                                Xem chi tiết
                                            </button>

                                            {order.status === 'Pending' && (
                                                <button className="btn-danger" onClick={() => handleCancelOrder(order.orderId)}>
                                                    Hủy đơn
                                                </button>
                                            )}

                                            {order.status === 'Delivered' && (
                                                <button className="btn-primary" onClick={() => openReviewModal(order.orderId)}>
                                                    Đánh giá
                                                </button>
                                            )}
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    ))}

                    {/* Phân trang */}
                    {totalPages > 1 && (
                        <div className="pagination">
                            <button className="page-btn" disabled={currentPage === 1} onClick={() => changePage(currentPage - 1)}>
                                <ChevronLeft size={20} />
                            </button>
                            <span className="page-info">{currentPage} / {totalPages}</span>
                            <button className="page-btn" disabled={currentPage === totalPages} onClick={() => changePage(currentPage + 1)}>
                                <ChevronRight size={20} />
                            </button>
                        </div>
                    )}
                </div>
            )}

            {/* MODAL CHI TIẾT (Giữ nguyên logic hiển thị) */}
            {showModal && (
                <div className="modal-overlay" onClick={closeModal}>
                    <div className="modal-content" onClick={e => e.stopPropagation()}>
                        <button className="modal-close-btn" onClick={closeModal}><XCircle size={24}/></button>
                        <h3 className="modal-title">Chi tiết đơn hàng #{selectedOrder?.orderId}</h3>
                        
                        {loadingDetail ? <p className="text-center p-4">Đang tải...</p> : selectedOrder ? (
                            <div className="order-detail-body">
                                <div className="detail-status-bar">
                                    Trạng thái: <span className={getStatusClass(selectedOrder.status)}>{getStatusText(selectedOrder.status)}</span>
                                </div>

                                <div className="detail-group">
                                    <h4>Địa chỉ nhận hàng</h4>
                                    <div className="info-row"><User size={16}/> <span>{selectedOrder.receiverName}</span></div>
                                    <div className="info-row"><Phone size={16}/> <span>{selectedOrder.receiverPhone}</span></div>
                                    <div className="info-row"><MapPin size={16}/> <span>{selectedOrder.shippingAddress}</span></div>
                                </div>

                                <div className="detail-group">
                                    <h4>Sản phẩm</h4>
                                    <div className="detail-items-list">
                                        {selectedOrder.items?.map((item, index) => (
                                            <div key={index} className="detail-item">
                                                <div className="item-img-placeholder"><Package size={20}/></div>
                                                <div className="item-info">
                                                    {/* Hiển thị tên đầy đủ từ Backend mới */}
                                                    <p className="item-name">{item.fullProductName || item.productName}</p> 
                                                    <p className="item-meta">x{item.quantity}</p>
                                                </div>
                                                <p className="item-price">{(item.price * item.quantity).toLocaleString()}đ</p>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="detail-total">
                                    <span>Thành tiền:</span>
                                    <span className="big-price">{selectedOrder.totalAmount?.toLocaleString()}đ</span>
                                </div>
                            </div>
                        ) : <p>Không có dữ liệu.</p>}
                    </div>
                </div>
            )}

            {/* MODAL ĐÁNH GIÁ (Giữ nguyên) */}
            {showReviewModal && (
                <div className="modal-overlay" onClick={() => setShowReviewModal(false)}>
                    <div className="modal-content review-modal" onClick={e => e.stopPropagation()}>
                        {/* ... (Code modal đánh giá giữ nguyên như cũ) ... */}
                        <button className="modal-close-btn" onClick={() => setShowReviewModal(false)}><XCircle size={24}/></button>
                        <h3 className="modal-title">Đánh giá sản phẩm</h3>
                        <div className="star-rating-container">
                            <div className="stars-row"> 
                                {[1, 2, 3, 4, 5].map((star) => (
                                    <button key={star} type="button" className="star-btn"
                                        onMouseEnter={() => setHoverRating(star)}
                                        onMouseLeave={() => setHoverRating(0)}
                                        onClick={() => setReviewData({...reviewData, rating: star})}
                                    >
                                        <Star size={32} color="#facc15" fill={(hoverRating || reviewData.rating) >= star ? "#facc15" : "none"} />
                                    </button>
                                ))}
                            </div>
                        </div>
                        <textarea className="review-textarea" placeholder="Nhập đánh giá..."
                            value={reviewData.comment} onChange={(e) => setReviewData({...reviewData, comment: e.target.value})}
                        ></textarea>
                        <button className="btn-submit-review" onClick={submitReview}>Gửi đánh giá</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default MyOrdersTab;