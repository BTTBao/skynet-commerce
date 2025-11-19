using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class DashboardForm : Form
    {
        // LƯU Ý: Không khai báo _sidebar, _header, _mainPanel ở đây nữa vì đã có trong Designer

        public DashboardForm()
        {
            InitializeComponent(); // Khởi tạo các control từ Designer

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
            string[] menus = { "Dashboard", "Users", "Shops", "Products", "Orders", "Categories" };
            int yPos = 80;

            foreach (var item in menus)
            {
                Guna2Button btn = new Guna2Button
                {
                    Text = item,
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
                    Tag = item // QUAN TRỌNG: Lưu tên menu vào Tag để bắt sự kiện
                };

                // Gán sự kiện Click
                btn.Click += Sidebar_Click;

                if (item == "Dashboard") btn.Checked = true;

                // _sidebar đã được tạo trong Designer, chỉ cần Add vào
                _sidebar.Controls.Add(btn);
                yPos += 50;
            }
        }

        private void Sidebar_Click(object sender, EventArgs e)
        {
            // Ép kiểu an toàn để tránh lỗi NullReference
            Guna2Button btn = sender as Guna2Button;
            if (btn == null) return;

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