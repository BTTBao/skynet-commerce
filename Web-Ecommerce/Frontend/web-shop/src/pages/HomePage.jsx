import Navbar from "../layouts/Navbar";
import "./HomePage.css";
import ProductCard from "../components/ProductCard";

function HomePage() {

    const products = [
        { id: 1, name: "Áo Thun Oversize", price: "250.000đ", img: "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?q=80&w=500&auto=format&fit=crop" },
        { id: 2, name: "Giày Sneaker White", price: "1.200.000đ", img: "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=500&auto=format&fit=crop" },
        { id: 3, name: "Balo Thời Trang", price: "450.000đ", img: "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?q=80&w=500&auto=format&fit=crop" },
        { id: 4, name: "Đồng Hồ Smartwatch", price: "2.500.000đ", img: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?q=80&w=500&auto=format&fit=crop" },
        { id: 5, name: "Tai Nghe Không Dây", price: "890.000đ", img: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?q=80&w=500&auto=format&fit=crop" },
        { id: 6, name: "Kính Râm Phi Công", price: "350.000đ", img: "https://images.unsplash.com/photo-1572635196237-14b3f281503f?q=80&w=500&auto=format&fit=crop" },
        { id: 7, name: "Túi Xách Da Nam", price: "1.100.000đ", img: "https://images.unsplash.com/photo-1548036328-c9fa89d128fa?q=80&w=500&auto=format&fit=crop" },
    ];

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
                    <div className="list-item">
                        {products.map(item => (
                            <ProductCard key={item.id} product={item} />
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HomePage;