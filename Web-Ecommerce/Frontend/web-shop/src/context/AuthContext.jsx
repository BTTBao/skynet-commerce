// src/context/AuthContext.jsx
import React, { createContext, useContext, useState } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  // 1. Lấy thông tin user từ LocalStorage nếu có
  const [user, setUser] = useState(() => {
    const savedUser = localStorage.getItem('user');
    return savedUser ? JSON.parse(savedUser) : null;
  });

  // 2. Hàm Đăng nhập (SỬA LẠI ĐOẠN NÀY)
  const login = (userData) => {
    setUser(userData);
    
    // Lưu thông tin user (để hiển thị tên, avatar)
    localStorage.setItem('user', JSON.stringify(userData));
    
    // 👇 QUAN TRỌNG: Lưu riêng Token để các file khác dễ lấy gọi API
    if (userData.token) {
        localStorage.setItem('token', userData.token);
    }
  };

  // 3. Hàm Đăng xuất (SỬA LẠI ĐOẠN NÀY)
  const logout = () => {
    setUser(null);
    
    // Xóa sạch cả User lẫn Token
    localStorage.removeItem('user');
    localStorage.removeItem('token'); // <--- Thêm dòng này
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// eslint-disable-next-line react-refresh/only-export-components
export const useAuth = () => useContext(AuthContext);