// src/components/InputField.jsx
import React from 'react';
import './InputField.css'; // <--- Import file CSS

const InputField = ({ 
  label, 
  icon: Icon, 
  type = "text", 
  value, 
  onChange, 
  placeholder, 
  required = true, 
  rightIcon 
}) => {
  return (
    <div className="input-group">
      {label && <label className="input-label">{label}</label>}
      
      <div className="input-wrapper">
        
        {/* Icon bên trái */}
        {Icon && (
          <div className="input-icon-left">
            <Icon size={20} />
          </div>
        )}

        <input
          type={type}
          required={required}
          value={value}
          onChange={onChange}
          placeholder={placeholder}
          // Logic class: Thêm class CSS tương ứng nếu có icon
          className={`input-control ${Icon ? 'has-left-icon' : ''} ${rightIcon ? 'has-right-icon' : ''}`}
        />
        
        {/* Icon bên phải (ví dụ nút hiện mật khẩu) */}
        {rightIcon && (
          <div className="input-icon-right">
            {rightIcon}
          </div>
        )}
      </div>
    </div>
  );
};

export default InputField;