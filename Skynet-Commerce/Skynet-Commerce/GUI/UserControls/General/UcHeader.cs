using System;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.Forms.User; // [Quan trọng] Thêm dòng này để nhận diện UserSessionDTO

namespace Skynet_Commerce.GUI.UserControls.General
{
    public partial class UcHeader : UserControl
    {
        // Biến lưu trữ thông tin user được truyền sang
        private UserSessionDTO _currentUser;

        // 1. Constructor mặc định (Bắt buộc phải có để Designer không bị lỗi)
        public UcHeader()
        {
            InitializeComponent();
        }

        // 2. Constructor mới: Nhận tham số UserSessionDTO từ FrmMain
        public UcHeader(UserSessionDTO currentUser) : this()
        {
            _currentUser = currentUser; // Lưu dữ liệu vào biến local
            LoadHeaderData();           // Gọi hàm hiển thị dữ liệu
        }

        // Hàm xử lý logic hiển thị (bạn sẽ viết code gán dữ liệu vào Label/Button ở đây)
        private void LoadHeaderData()
        {
            if (_currentUser != null)
            {
                // Ví dụ logic:
                // lblWelcome.Text = "Xin chào, " + _currentUser.FullName;
                // btnKenhNguoiBan.Visible = (_currentUser.Role == "Seller");
                // lblCartCount.Text = _currentUser.CartCount.ToString();
            }
        }

        private void lblAppName_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem FrmMain có đang chạy không
            if (Forms.FrmMain.Instance != null)
            {
                // Chuyển về trang HomePage (luôn tạo mới để đảm bảo fresh data)
                Forms.FrmMain.Instance.LoadUserControl(new Pages.UcHomePage());
            }
        }

        private void cartIcon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem FrmMain có đang chạy không
            if (Forms.FrmMain.Instance != null)
            {
                // 1. Chuyển sang trang Giỏ hàng (UcCartPage)
                Forms.FrmMain.Instance.LoadUserControl(new Pages.UcCartPage());
            }
        }

        private void profileIcon_Click(object sender, EventArgs e)
        {
            Authentication a = new Authentication();
            a.ShowLogin();
            a.Show();
        }
    }
}