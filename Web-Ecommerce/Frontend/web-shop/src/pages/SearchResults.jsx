import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import Navbar from '../layouts/Navbar'; // Nếu cần Navbar
import ProductCard from '../components/ProductCard';
import './SearchResults.css';

function SearchResults() {
    const [searchParams] = useSearchParams();
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    // --- 1. THÊM STATE PHÂN TRANG ---
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 10; // Yêu cầu 10 sản phẩm 1 trang

    const keyword = searchParams.get('keyword'); 
    const category = searchParams.get('category');

    useEffect(() => {
        const fetchSearchResults = async () => {
            setLoading(true);
            try {
                const queryString = searchParams.toString();
                
                // Gọi API lấy kết quả tìm kiếm
                const response = await fetch(`http://localhost:5198/api/products?${queryString}`);
                
                if (response.ok) {
                    const data = await response.json();

                    // ==============================================================
                    // BƯỚC LỌC QUAN TRỌNG: ẨN SẢN PHẨM HIDDEN
                    // ==============================================================
                    const visibleProducts = data.filter(item => {
                        // Lấy giá trị status (kiểm tra cả chữ hoa/thường cho chắc)
                        const status = item.status || item.Status;
                        
                        // Chỉ giữ lại sản phẩm có Status KHÁC 'Hidden'
                        return status !== 'Hidden';
                    });

                    setProducts(visibleProducts); // Lưu danh sách đã lọc
                    
                    // Reset về trang 1 khi tìm kiếm mới
                    setCurrentPage(1); 
                } else {
                    setProducts([]);
                }
            } catch (error) {
                console.error("Lỗi tìm kiếm:", error);
                setProducts([]);
            } finally {
                setLoading(false);
            }
        };

        fetchSearchResults();
    }, [searchParams]);

    // --- 3. LOGIC TÍNH TOÁN PHÂN TRANG ---
    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentProducts = products.slice(indexOfFirstItem, indexOfLastItem);
    const totalPages = Math.ceil(products.length / itemsPerPage);

    const paginate = (pageNumber) => {
        setCurrentPage(pageNumber);
        window.scrollTo(0, 0); // Cuộn lên đầu trang khi chuyển trang
    };

    return (
        <div className="search-page-wrapper">
             {/* <Navbar />  <-- Bỏ comment nếu bạn muốn hiện Navbar */}
            
            <div className="search-page-container">
                <div className="search-header">
                    <h2>Kết quả tìm kiếm</h2>
                    <p>
                        {keyword && <>Từ khóa: <strong>"{keyword}"</strong></>}
                        {category && category !== 'all' && <> | Danh mục: <strong>{category}</strong></>}
                    </p>
                    <span className="result-count">Tìm thấy {products.length} sản phẩm</span>
                </div>

                {loading ? (
                    <div className="loading-container">
                        <div className="spinner"></div>
                        <p>Đang tìm kiếm sản phẩm...</p>
                    </div>
                ) : (
                    <>
                        {products.length > 0 ? (
                            <>
                                {/* --- HIỂN THỊ DANH SÁCH ĐÃ CẮT (currentProducts) --- */}
                                <div className="product-grid">
                                    {currentProducts.map(product => (
                                        <ProductCard 
                                            key={product.productId} 
                                            product={{
                                                ...product,
                                                id: product.productId,
                                                price: product.price,
                                                img: product.productImages?.[0]?.imageUrl || "https://via.placeholder.com/300"
                                            }} 
                                        />
                                    ))}
                                </div>

                                {/* --- 4. UI PHÂN TRANG (Chỉ hiện khi > 10 sản phẩm) --- */}
                                {products.length > itemsPerPage && (
                                    <div className="pagination-container">
                                        <button 
                                            onClick={() => paginate(currentPage - 1)} 
                                            disabled={currentPage === 1}
                                            className="page-btn"
                                        >
                                            &laquo;
                                        </button>

                                        {Array.from({ length: totalPages }, (_, index) => (
                                            <button
                                                key={index + 1}
                                                onClick={() => paginate(index + 1)}
                                                className={`page-btn ${currentPage === index + 1 ? 'active' : ''}`}
                                            >
                                                {index + 1}
                                            </button>
                                        ))}

                                        <button 
                                            onClick={() => paginate(currentPage + 1)} 
                                            disabled={currentPage === totalPages}
                                            className="page-btn"
                                        >
                                            &raquo;
                                        </button>
                                    </div>
                                )}
                            </>
                        ) : (
                            <div className="no-results">
                                <i className="fa-regular fa-face-frown"></i>
                                <h3>Không tìm thấy sản phẩm nào</h3>
                                <p>Hãy thử thay đổi từ khóa hoặc bộ lọc.</p>
                            </div>
                        )}
                    </>
                )}
            </div>
        </div>
    );
}

export default SearchResults;