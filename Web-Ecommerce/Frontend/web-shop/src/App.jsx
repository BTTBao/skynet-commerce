import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

// 1. Import các Provider quản lý dữ liệu
import { AuthProvider } from "./context/AuthContext"; 
import { CartProvider } from "./context/CartContext";

// 2. Import các trang (Pages)
import HomePage from "./pages/HomePage";
import ProductDetail from "./pages/ProductDetail"; 
import CartPage from "./pages/CartPage";
import LoginPage from "./pages/LoginPage"; 
import AccountPage from "./pages/AccountPage"; // <--- THÊM DÒNG NÀY

import Navbar from "./layouts/Navbar"; 
import Footer from "./layouts/Footer";

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <CartProvider>
          <Navbar />
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/product/:id" element={<ProductDetail />} />
            <Route path="/cart" element={<CartPage />} />
            <Route path="/login" element={<LoginPage />} />
            
            {/* THÊM ROUTE NÀY */}
            <Route path="/account" element={<AccountPage />} />
          </Routes>
          <Footer />
        </CartProvider>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;