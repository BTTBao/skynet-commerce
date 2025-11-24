using Guna.UI2.WinForms;
using Skynet_Commerce.DAL.Entities; // Cần dòng này để gọi AppSession
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            guna2PictureBox1.LoadAsync("https://cdn-icons-png.flaticon.com/128/1533/1533565.png");
            CreateSidebarItems();

            LoadPage(new DashboardOverviewForm());
        }

        private void LoadPage(Form childForm)
        {
            _mainPanel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(childForm);
            _mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void CreateSidebarItems()
        {
            // Thêm "Logout" vào cuối danh sách
            Dictionary<string, string> menuMap = new Dictionary<string, string>()
            {
                { "Dashboard", "Tổng quan" },
                { "Users", "Người dùng" },
                { "Shops", "Cửa hàng" },
                { "Products", "Sản phẩm" },
                { "Orders", "Đơn hàng" },
                { "Categories", "Danh mục" },
                { "Logout", "Đăng xuất" } // [MỚI] Thêm nút này
            };

            int yPos = 80;

            foreach (var menu in menuMap)
            {
                Guna2Button btn = new Guna2Button
                {
                    Text = menu.Value,
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
                    Tag = menu.Key
                };

                // [MỚI] Tùy chỉnh riêng cho nút Đăng xuất (Màu đỏ, tách biệt chút)
                if (menu.Key == "Logout")
                {
                    yPos += 20; // Cách ra một chút cho đẹp
                    btn.Location = new Point(10, yPos);
                    btn.ForeColor = Color.Red;
                    btn.CheckedState.FillColor = Color.Red; // Khi chọn sẽ hiện màu đỏ
                    btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton; // Không giữ trạng thái "đang chọn"
                }

                btn.Click += Sidebar_Click;

                if (menu.Key == "Dashboard") btn.Checked = true;

                _sidebar.Controls.Add(btn);
                yPos += 50;
            }
        }

        private void Sidebar_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn == null) return;

            string menuName = btn.Tag?.ToString() ?? "";

            switch (menuName)
            {
                case "Dashboard": LoadPage(new DashboardOverviewForm()); break;
                case "Users": LoadPage(new UsersForm()); break;
                case "Shops": LoadPage(new ShopsForm()); break;
                case "Products": LoadPage(new ProductsForm()); break;
                case "Orders": LoadPage(new OrdersForm()); break;
                case "Categories": LoadPage(new CategoriesForm()); break;

                // [MỚI] Xử lý Đăng xuất
                case "Logout":
                    if (MessageBox.Show("Bạn có chắc muốn đăng xuất khỏi trang Quản trị?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // 1. Xóa Session
                        AppSession.Instance.Clear();

                        // 2. Mở lại FrmMain (Giao diện khách hàng)
                        FrmMain main = new FrmMain();
                        main.Show();

                        // 3. Ẩn Form Dashboard hiện tại đi
                        // Lưu ý: Dùng Hide() thay vì Close() để tránh kích hoạt sự kiện Application.Exit() nếu bạn đã cài đặt ở form Login trước đó.
                        this.Hide();
                    }
                    break;

                default:
                    MessageBox.Show("Tính năng đang phát triển!");
                    break;
            }
        }
    }
}