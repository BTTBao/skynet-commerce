import { useState, useEffect } from "react";
import Navbar from "../layouts/Navbar";
import "./HomePage.css";
import ProductCard from "../components/ProductCard";

function HomePage() {
    // 1. State chứa TOÀN BỘ sản phẩm từ DB
    const [allProducts, setAllProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    // 2. State quản lý trang hiện tại
    const [currentPage, setCurrentPage] = useState(1);
    const pageSize = 8; // Số lượng hiển thị mỗi trang

    // 3. Gọi API 1 lần duy nhất khi vào web
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                // Đảm bảo Port đúng là 7215
                const response = await fetch("https://localhost:7215/api/products");
                if (!response.ok) throw new Error("Lỗi tải dữ liệu");
                
                const data = await response.json();
                setAllProducts(data); // Lưu hết vào đây
            } catch (error) {
                console.error("Lỗi:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchProducts();
    }, []);

    // --- LOGIC PHÂN TRANG (Cắt mảng) ---
    // Vị trí bắt đầu và kết thúc của trang hiện tại
    const indexOfLastItem = currentPage * pageSize;
    const indexOfFirstItem = indexOfLastItem - pageSize;
    
    // Cắt lấy danh sách sản phẩm cho trang hiện tại
    const currentProducts = allProducts.slice(indexOfFirstItem, indexOfLastItem);

    // Tính tổng số trang
    const totalPages = Math.ceil(allProducts.length / pageSize);

    // Hàm đổi trang
    const handlePageChange = (pageNumber) => {
        setCurrentPage(pageNumber);
        window.scrollTo({ top: 500, behavior: 'smooth' });
    };

    return (
        <div className="homepage">
            <Navbar />
            <header className="hero">
                <div className="hero-content">
                    <h1>Săn Sale Cực Khủng</h1>
                    <p>Giảm giá lên đến 50% cho tất cả mặt hàng</p>
                    <button className="btn-shop">Mua Ngay</button>
                </div>
            </header>

            <div className="container">
                <div className="wrapper">
                    <h2 className="section-title">Sản Phẩm Mới Nhất</h2>
                    
                    {loading ? (
                        <p>Đang tải dữ liệu...</p>
                    ) : (
                        <>
                            {/* Hiển thị danh sách ĐÃ ĐƯỢC CẮT (currentProducts) */}
                            <div className="list-item">
                                {currentProducts.map(item => (
                                    <ProductCard 
                                        key={item.productId} 
                                        product={{
                                            ...item,
                                            id: item.productId,
                                            price: item.price,
                                            img: item.productImages?.[0]?.imageUrl || "..."
                                        }} 
                                    />
                                ))}
                            </div>

                            {/* UI Phân trang (Chỉ hiện khi có > 1 trang) */}
                            {totalPages > 1 && (
                                <div className="pagination">
                                    <button 
                                        className="page-btn"
                                        disabled={currentPage === 1}
                                        onClick={() => handlePageChange(currentPage - 1)}
                                    >
                                        &laquo;
                                    </button>

                                    {/* Tạo nút số trang */}
                                    {[...Array(totalPages)].map((_, index) => (
                                        <button
                                            key={index + 1}
                                            className={`page-btn ${currentPage === index + 1 ? 'active' : ''}`}
                                            onClick={() => handlePageChange(index + 1)}
                                        >
                                            {index + 1}
                                        </button>
                                    ))}

                                    <button 
                                        className="page-btn"
                                        disabled={currentPage === totalPages}
                                        onClick={() => handlePageChange(currentPage + 1)}
                                    >
                                        &raquo;
                                    </button>
                                </div>
                            )}
                        </>
                    )}
                </div>
            </div>
        </div>
    );
}

export default HomePage;