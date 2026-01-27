// src/components/account/SettingsTab.jsx
import React from 'react';
import { Lock, Shield } from 'lucide-react';

const SettingsTab = () => (
    <div>
        <h2 className="tab-title">Cài đặt</h2>
        <div className="settings-list" style={{display:'flex', flexDirection:'column', gap:16}}>
            <div className="setting-item" style={{display:'flex', justifyContent:'space-between', padding:16, border:'1px solid #e5e7eb', borderRadius:8}}>
                <div style={{display:'flex', alignItems:'center', gap:12}}>
                    <Lock size={20} color="#2563eb" />
                    <span>Đổi mật khẩu</span>
                </div>
                <span style={{color:'#9ca3af'}}>→</span>
            </div>
             <div className="setting-item" style={{display:'flex', justifyContent:'space-between', padding:16, border:'1px solid #e5e7eb', borderRadius:8}}>
                <div style={{display:'flex', alignItems:'center', gap:12}}>
                    <Shield size={20} color="#2563eb" />
                    <span>Quyền riêng tư</span>
                </div>
                <span style={{color:'#9ca3af'}}>→</span>
            </div>
        </div>
    </div>
);


export default SettingsTab;