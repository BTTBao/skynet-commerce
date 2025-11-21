using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class DashboardForm : Form
    {
        // LƯU Ý: Không khai báo _sidebar, _header, _mainPanel ở đây nữa vì đã có trong Designer

        public DashboardForm()
        {
            InitializeComponent(); // Khởi tạo các control từ Designer
            guna2PictureBox1.LoadAsync("https://cdn-icons-png.flaticon.com/128/1533/1533565.png");
            CreateSidebarItems();

            // Mặc định load trang Overview
            LoadPage(new DashboardOverviewForm());
        }

        // Hàm chuyển trang (Lồng Form con vào _mainPanel)
        private void LoadPage(Form childForm)
        {
            // Xóa nội dung cũ
            _mainPanel.Controls.Clear();

            // Cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm vào panel
            _mainPanel.Controls.Add(childForm);
            _mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void CreateSidebarItems()
        {
            // Dictionary: <Key (Tiếng Anh - Tag), Value (Tiếng Việt - Text)>
            Dictionary<string, string> menuMap = new Dictionary<string, string>()
            {
                { "Dashboard", "Tổng quan" },
                { "Users", "Người dùng" },
                { "Shops", "Cửa hàng" },
                { "Products", "Sản phẩm" },
                { "Orders", "Đơn hàng" },
                { "Categories", "Danh mục" }
            };

            int yPos = 80;

            // Duyệt qua từng phần tử trong Dictionary
            foreach (var menu in menuMap)
            {
                Guna2Button btn = new Guna2Button
                {
                    Text = menu.Value, // HIỂN THỊ: Tiếng Việt (ví dụ: "Tổng quan")
                    FillColor = Color.White,
                    ForeColor = Color.DimGray,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    TextAlign = HorizontalAlignment.Left,
                    Width = 230,
                    Height = 45,
                    Location = new Point(10, yPos),
                    BorderRadius = 8,
                    ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                    CheckedState = { FillColor = Color.FromArgb(79, 70, 229), ForeColor = Color.White },
                    TextOffset = new Point(10, 0),

                    Tag = menu.Key // LOGIC: Tiếng Anh (ví dụ: "Dashboard")
                };

                // Gán sự kiện Click
                btn.Click += Sidebar_Click;

                // Kiểm tra theo Key tiếng Anh để set mặc định
                if (menu.Key == "Dashboard") btn.Checked = true;

                _sidebar.Controls.Add(btn);
                yPos += 50;
            }
        }
        private void Sidebar_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn == null) return;

            // Lấy Tag (là tiếng Anh) để xử lý switch case
            string menuName = btn.Tag?.ToString() ?? "";

            switch (menuName)
            {
                case "Dashboard":
                    LoadPage(new DashboardOverviewForm());
                    break;

                case "Users":
                    LoadPage(new UsersForm());
                    break;

                case "Shops":
                    LoadPage(new ShopsForm());
                    break;

                case "Products":
                    LoadPage(new ProductsForm());
                    break;

                case "Orders":
                    LoadPage(new OrdersForm());
                    break;

                case "Categories":
                    LoadPage(new CategoriesForm());
                    break;

                default:
                    MessageBox.Show("Tính năng đang phát triển!");
                    break;
            }
        }
    }
}