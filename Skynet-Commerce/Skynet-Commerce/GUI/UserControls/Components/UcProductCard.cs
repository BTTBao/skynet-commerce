using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models; // Dùng chung DTO nếu có
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcProductCard : UserControl
    {
        // Sự kiện khi click vào sản phẩm để xem chi tiết
        public event EventHandler CardClicked;
        public int ProductId { get; set; }

        // Các controls
        private Guna2PictureBox pbImage;
        private Label lblName;
        private Label lblPrice;
        private Label lblStats; // Đánh giá + Đã bán
        private Label lblShopLocation; // Tên shop hoặc địa điểm

        public UcProductCard()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Size = new Size(190, 280); // Kích thước chuẩn giống Shopee
            this.BackColor = Color.White;
            this.Margin = new Padding(5);
            this.Cursor = Cursors.Hand;

            // Hiệu ứng Hover
            this.MouseEnter += (s, e) => this.BorderStyle = BorderStyle.FixedSingle;
            this.MouseLeave += (s, e) => this.BorderStyle = BorderStyle.None;
            this.Click += (s, e) => CardClicked?.Invoke(this, e);

            // 1. Ảnh sản phẩm
            pbImage = new Guna2PictureBox
            {
                Size = new Size(190, 190),
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderRadius = 2,
                BackColor = Color.WhiteSmoke
            };
            pbImage.Click += (s, e) => CardClicked?.Invoke(this, e); // Click ảnh cũng kích hoạt

            // 2. Tên sản phẩm
            lblName = new Label
            {
                Location = new Point(8, 200),
                Size = new Size(174, 40), // Đủ cho 2 dòng
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                Text = "Tên sản phẩm...",
                AutoEllipsis = true, // Tự động ... nếu dài
            };
            lblName.Click += (s, e) => CardClicked?.Invoke(this, e);

            // 3. Giá
            lblPrice = new Label
            {
                Location = new Point(8, 240),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 87, 34), // Màu cam
                Text = "0đ"
            };

            // 4. Stats (Đánh giá & Đã bán)
            lblStats = new Label
            {
                Location = new Point(8, 260),
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                Text = "★ 5.0 | Đã bán 0"
            };

            this.Controls.Add(lblStats);
            this.Controls.Add(lblPrice);
            this.Controls.Add(lblName);
            this.Controls.Add(pbImage);
        }

        // Hàm nạp dữ liệu
        public void LoadData(int id, string name, decimal price, double rating, int sold, string imgUrl)
        {
            this.ProductId = id;
            lblName.Text = name;
            lblPrice.Text = $"{price:N0}đ";
            lblStats.Text = $"★ {rating:N1} | Đã bán {sold}";

            // Load ảnh (Online hoặc Offline)
            if (!string.IsNullOrEmpty(imgUrl) && imgUrl.StartsWith("http"))
                pbImage.ImageLocation = imgUrl;
            else if (System.IO.File.Exists(imgUrl))
                pbImage.ImageLocation = imgUrl;
        }
    }
}