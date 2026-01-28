// src/layouts/Footer.jsx
import React from 'react';
import './Footer.css'; // <--- Nhớ import file CSS này

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-container">
        {/* Phần lưới cột */}
        <div className="footer-grid">
          {/* Cột 1: Logo & Slogan */}
          <div className="footer-column brand-column">
            <h3 className="brand-name">SKYNET</h3>
            <p className="brand-desc">
              Nền tảng thương mại điện tử hiện đại, nhanh chóng, tiện lợi
            </p>
          </div>

          {/* Cột 2: Hỗ trợ */}
          <div className="footer-column">
            <h4 className="footer-heading">Hỗ Trợ</h4>
            <ul className="footer-list">
              <li>Câu Hỏi Thường Gặp</li>
              <li>Chính Sách Đổi Trả</li>
              <li>Phương Thức Thanh Toán</li>
            </ul>
          </div>

          {/* Cột 3: Về chúng tôi */}
          <div className="footer-column">
            <h4 className="footer-heading">Về Chúng Tôi</h4>
            <ul className="footer-list">
              <li>Giới Thiệu</li>
              <li>Tuyển Dụng</li>
              <li>Liên Hệ</li>
            </ul>
          </div>

          {/* Cột 4: Kết nối (Mạng xã hội) */}
          <div className="footer-column">
            <h4 className="footer-heading">Kết Nối</h4>
            <div className="social-links">
              {['F', 'I', 'T', 'Y'].map((social) => (
                <div key={social} className="social-icon">
                  {social}
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* Phần bản quyền dưới cùng */}
        <div className="footer-bottom">
          © 2026 Skynet Commerce. All rights reserved.
        </div>
      </div>
    </footer>
  );
};

export default Footer;