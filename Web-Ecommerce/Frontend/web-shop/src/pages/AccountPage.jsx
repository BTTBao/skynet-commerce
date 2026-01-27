// src/pages/AccountPage.jsx
import React, { useState } from 'react';
import { User, Package, MapPin, Bell, Store } from 'lucide-react';
import { useAuth } from '../context/AuthContext';
import './AccountPage.css';

// Import Component con từ thư mục account
import AccountInfo from '../components/account/AccountInfo';
import MyOrdersTab from '../components/account/MyOrdersTab';
import AddressTab from '../components/account/AddressTab';
import SettingsTab from '../components/account/SettingsTab';
import SellerRegistrationTab from '../components/account/SellerRegistrationTab';

export default function AccountPage() {
  const [activeTab, setActiveTab] = useState('profile');
  const { user } = useAuth();

  const renderContent = () => {
    switch (activeTab) {
      case 'profile': return <AccountInfo />;
      case 'orders': return <MyOrdersTab />;
      case 'addresses': return <AddressTab />;
      case 'settings': return <SettingsTab />;
      case 'seller-registration': return <SellerRegistrationTab />;
      default: return <AccountInfo />;
    }
  };

  return (
    <div className="account-page-container">
      <h1 className="account-page-title">Tài khoản của tôi</h1>

      <div className="account-grid">
        {/* --- SIDEBAR --- */}
        <div className="sidebar-col">
          <div className="account-card sidebar-sticky">
            <div className="avatar-section">
              <div className="avatar-circle">
                {user?.name ? user.name.charAt(0).toUpperCase() : 'U'}
              </div>
              <h2 className="user-name">{user?.name || 'Người dùng'}</h2>
              <p className="user-email">{user?.email || 'user@example.com'}</p>
            </div>

            <nav className="nav-menu">
              <TabButton active={activeTab === 'profile'} onClick={() => setActiveTab('profile')} icon={User} label="Thông tin cá nhân" />
              <TabButton active={activeTab === 'orders'} onClick={() => setActiveTab('orders')} icon={Package} label="Đơn hàng của tôi" />
              <TabButton active={activeTab === 'addresses'} onClick={() => setActiveTab('addresses')} icon={MapPin} label="Địa chỉ" />
              <TabButton active={activeTab === 'settings'} onClick={() => setActiveTab('settings')} icon={Bell} label="Cài đặt" />
              
              <div style={{ margin: '10px 0', borderTop: '1px solid #eee' }}></div>
              <TabButton active={activeTab === 'seller-registration'} onClick={() => setActiveTab('seller-registration')} icon={Store} label="Đăng ký bán hàng" />
            </nav>
          </div>
        </div>

        {/* --- MAIN CONTENT --- */}
        <div className="main-col">
          <div className="account-card">
            {renderContent()}
          </div>
        </div>
      </div>
    </div>
  );
}

// Component TabButton (nhỏ nên giữ lại đây)
const TabButton = ({ active, onClick, icon: Icon, label }) => (
  <button onClick={onClick} className={`tab-btn ${active ? 'active' : ''}`}>
    {Icon && <Icon size={20} className={active ? 'icon-blue' : ''} />}
    {label}
  </button>
);