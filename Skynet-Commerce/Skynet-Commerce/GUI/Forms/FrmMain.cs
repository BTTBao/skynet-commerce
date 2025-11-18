using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.General;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.BLL.Models;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        // QUAN TRỌNG: Thêm thuộc tính tĩnh để truy cập Form chính từ mọi nơi
        public static FrmMain Instance { get; private set; }

        // Stack lưu trữ lịch sử chuyển trang (Giống lịch sử trình duyệt)
        private Stack<UserControl> _history = new Stack<UserControl>();

        private UserSessionDTO _currentUser;

        public FrmMain()
        {
            InitializeComponent();
            Instance = this; // Gán tham chiếu của instance hiện tại vào thuộc tính tĩnh

            // TẠM THỜI: Tạo dữ liệu người dùng mẫu
            _currentUser = new UserSessionDTO
            {
                AccountID = 1,
                FullName = "Nguyễn Văn A",
                Role = "Seller",
                CartCount = 3
            };

            LoadStaticControls();

            // Tải trang mặc định (HomePage)
            LoadUserControl(new UcHomePage());
        }

        // 1. Tải các controls cố định
        private void LoadStaticControls()
        {
            // Khởi tạo UcHeader (truyền thông tin user vào)
            UcHeader headerControl = new UcHeader(_currentUser);
            pnlHeader.Controls.Add(headerControl);
            headerControl.Dock = DockStyle.Fill;

            // Khởi tạo UcFooter
            UcFooter footerControl = new UcFooter();
            pnlFooter.Controls.Add(footerControl);
            footerControl.Dock = DockStyle.Fill;
        }

        // 2. Hàm để Tải/Chuyển đổi các trang (Page UCs)
        public void LoadUserControl(UserControl newControl)
        {
            // Lưu trang cũ vào lịch sử trước khi chuyển
            if (pnlContent.Controls.Count > 0)
            {
                _history.Push((UserControl)pnlContent.Controls[0]);
            }

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(newControl);
            newControl.Dock = DockStyle.Fill;
        }

        // 3. Hàm Quay lại trang trước
        public void GoBack()
        {
            if (_history.Count > 0)
            {
                UserControl previousControl = _history.Pop();
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(previousControl);
                previousControl.Dock = DockStyle.Fill;
            }
        }
    }
}