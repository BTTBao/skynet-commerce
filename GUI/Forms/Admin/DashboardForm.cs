using Guna.UI2.WinForms;
using Skynet_Commerce.DAL.Entities;
using Skynet_Ecommerce;
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
            var menuItems = new List<(string Key, string Title, string IconUrl)>
            {
                ("Dashboard", "Tổng quan", "https://cdn-icons-png.flaticon.com/128/12255/12255013.png"),
                ("Users", "Người dùng", "https://cdn-icons-png.flaticon.com/128/33/33308.png"),
                ("Shops", "Cửa hàng", "https://cdn-icons-png.flaticon.com/128/8610/8610577.png"),
                ("Products", "Sản phẩm", "https://cdn-icons-png.flaticon.com/128/10608/10608766.png"),
                ("Orders", "Đơn hàng", "https://cdn-icons-png.flaticon.com/128/10161/10161680.png"),
                ("Categories", "Danh mục", "https://cdn-icons-png.flaticon.com/128/12916/12916359.png"),
                ("Logout", "Đăng xuất", "https://cdn-icons-png.flaticon.com/128/4400/4400629.png")
            };

            int yPos = 80;

            foreach (var item in menuItems)
            {
                Image rawIcon = LoadImageFromUrl(item.IconUrl);

                Guna2Button btn = new Guna2Button
                {
                    Text = item.Title,
                    FillColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),

                    // --- CẤU HÌNH ICON TỪ URL ---
                    ImageSize = new Size(20, 20),
                    ImageAlign = HorizontalAlignment.Left,
                    ImageOffset = new Point(10, 0),
                    TextOffset = new Point(20, 0),

                    TextAlign = HorizontalAlignment.Left,
                    Width = 230,
                    Height = 45,
                    Location = new Point(10, yPos),
                    BorderRadius = 8,
                    ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                    CheckedState = { FillColor = Color.DimGray, ForeColor = Color.White },
                    Tag = item.Key
                };
                btn.BackColor = Color.Transparent;
                btn.Image = RecolorImage(rawIcon, Color.White);
                // [MỚI] Tùy chỉnh riêng cho nút Đăng xuất (Màu đỏ, tách biệt chút)
                if (item.Key == "Logout")
                {
                    btn.Dock = DockStyle.Bottom;
                    btn.Margin = new Padding(10, 0, 30, 10);
                    btn.ForeColor = Color.Red;
                    btn.Image = RecolorImage(rawIcon, Color.Red);
                    btn.CheckedState.FillColor = Color.Red; // Khi chọn sẽ hiện màu đỏ
                    btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton; // Không giữ trạng thái "đang chọn"
                }

                btn.Click += Sidebar_Click;

                if (item.Key == "Dashboard") btn.Checked = true;

                _sidebar.Controls.Add(btn);
                yPos += 50;
            }
        }
        
        // Hàm hỗ trợ tải ảnh từ URL
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                var request = System.Net.WebRequest.Create(url);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                // Nếu link lỗi hoặc mất mạng, trả về null (hoặc icon mặc định nếu muốn)
                return null;
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
        private Image RecolorImage(Image originalImage, Color newColor)
        {
            if (originalImage == null) return null;

            Bitmap bmp = new Bitmap(originalImage);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    // Nếu điểm ảnh không trong suốt (có hình) thì đổi màu
                    if (pixelColor.A > 0)
                    {
                        // Giữ nguyên độ trong suốt (Alpha), đổi màu RGB sang màu mới
                        bmp.SetPixel(x, y, Color.FromArgb(pixelColor.A, newColor));
                    }
                }
            }
            return bmp;
        }
    }
}