using System;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.General; // Import Header/Footer
using Skynet_Commerce.GUI.UserControls.Pages; // Import HomePage
using Skynet_Commerce.BLL.Models; // Import DTO (để dùng dữ liệu mẫu)

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        private UserSessionDTO _currentUser; // Giữ thông tin người dùng

        public FrmMain()
        {
            InitializeComponent();

            // TẠM THỜI: Tạo dữ liệu người dùng mẫu (Vì chưa có Đăng nhập)
            _currentUser = new UserSessionDTO
            {
                AccountID = 1,
                FullName = "Nguyễn Văn A",
                Role = "Seller", // Đặt là "Seller" để thấy nút Kênh Người Bán
                CartCount = 3
            };

            // Gọi hàm để tải các thành phần cố định (Header/Footer)
            LoadStaticControls();

            // Gọi hàm để tải trang mặc định (HomePage)
            LoadUserControl(new UcHomePage());
        }

        // 1. Tải các controls cố định
        private void LoadStaticControls()
        {
            // Khởi tạo UcHeader (truyền thông tin user vào)
            UcHeader headerControl = new UcHeader(_currentUser);
            pnlHeader.Controls.Add(headerControl);
            headerControl.Dock = DockStyle.Fill; // Tự động lấp đầy pnlHeader

            // Khởi tạo UcFooter
            UcFooter footerControl = new UcFooter();
            pnlFooter.Controls.Add(footerControl);
            footerControl.Dock = DockStyle.Fill; // Tự động lấp đầy pnlFooter
        }

        // 2. Hàm để Tải/Chuyển đổi các trang (Page UCs)
        public void LoadUserControl(UserControl newControl)
        {
            // Xóa control cũ trong pnlContent (nếu có)
            pnlContent.Controls.Clear();

            // Thêm control mới (ví dụ: UcHomePage, UcUserProfile...)
            pnlContent.Controls.Add(newControl);
            newControl.Dock = DockStyle.Fill; // Tự động lấp đầy pnlContent
        }
    }
}