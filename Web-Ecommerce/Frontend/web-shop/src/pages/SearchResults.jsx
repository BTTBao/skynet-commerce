import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import Navbar from '../layouts/Navbar';
import ProductCard from '../components/ProductCard'; // Giả sử bạn có component này
import './SearchResults.css'; // File CSS tý tạo sau

function SearchResults() {
    const [searchParams] = useSearchParams();
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    // Lấy các giá trị từ URL để hiển thị lại cho người dùng biết họ đang tìm gì
    const keyword = searchParams.get('keyword'); 
    const category = searchParams.get('category');

    useEffect(() => {
        const fetchSearchResults = async () => {
            setLoading(true);
            try {
                // Chuyển searchParams thành query string để gắn vào API
                // Ví dụ: https://localhost:7215/api/products?keyword=iphone&minPrice=100
                const queryString = searchParams.toString();
                
                // GỌI API BACKEND (Giả sử bạn có API lọc)
                const response = await fetch(`https://localhost:7215/api/products?${queryString}`);
                
                if (response.ok) {
                    const data = await response.json();
                    setProducts(data);
                }
            } catch (error) {
                console.error("Lỗi tìm kiếm:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchSearchResults();
    }, [searchParams]); // Khi URL thay đổi thì gọi lại API

    return (
        <>
        <Navbar />
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
                <div className="loading">Đang tìm kiếm...</div>
            ) : (
                <>
                    {products.length > 0 ? (
                        <div className="product-grid">
                            {products.map(product => (
                                    <ProductCard 
                                        key={product.productId} 
                                        product={{
                                            ...product,
                                            id: product.productId,
                                            price: product.price,
                                            img: product.productImages?.[0]?.imageUrl || "..."
                                        }} 
                                    />
                            ))}
                        </div>
                    ) : (
                        <div className="no-results">
                            <i className="fa-regular fa-face-frown"></i>
                            <h3>Không tìm thấy sản phẩm nào</h3>
                            <p>Hãy thử thay đổi từ khóa hoặc bộ lọc giá.</p>
                        </div>
                    )}
                </>
            )}
        </div>
        </>
    );
}

export default SearchResults;