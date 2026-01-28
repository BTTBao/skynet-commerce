using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skynet_Commerce.DAL.Entities;
namespace Skynet_Commerce.DAL.Entities
{
    public class AppSession
    {
        private static AppSession _instance;

        public static AppSession Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSession();
                return _instance;
            }
        }

        // Các thông tin lưu trữ phiên đăng nhập
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // [THÊM MỚI] Tên hiển thị của người dùng
        public string FullName { get; set; }

        // Kiểm tra trạng thái đăng nhập
        public bool IsLoggedIn => AccountID > 0;

        private AppSession() { }

        // [THÊM MỚI] Hàm xóa session (Dùng khi Đăng xuất)
        public void Clear()
        {
            AccountID = 0;
            Email = null;
            Role = null;
            FullName = null;
        }
    }
}