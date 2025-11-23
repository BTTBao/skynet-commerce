using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms;      // [CẦN THÊM] Để gọi FrmMain
using Skynet_Commerce.BLL.Models;     // [CẦN THÊM] Để tạo ProductDTO

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcShopDetail : UserControl
    {
        private Color PrimaryColor = Color.FromArgb(238, 77, 45);
        private Color TextGray = Color.FromArgb(100, 100, 100);

        public UcShopDetail()
        {
            InitializeComponent();
            SetupDynamicUI();
        }

        private void SetupDynamicUI()
        {
            picBanner.ImageLocation = "https://cf.shopee.vn/file/c0b0c96077867d8110459700d432c921_tn";
            picAvatar.ImageLocation = "https://i.imgur.com/HalqU6S.png";
            picAvatar.BringToFront();

            InitFilterButtons();
            InitStatItems();
        }

        private void InitFilterButtons()
        {
            string[] filters = { "Tất cả sản phẩm", "Mới nhất", "Bán chạy", "Giá thấp", "Giá cao" };
            int x = 15;
            for (int i = 0; i < filters.Length; i++)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = filters[i];
                btn.Size = new Size(120, 34);
                btn.Location = new Point(x, 3);
                btn.BorderRadius = 2;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btn.Cursor = Cursors.Hand;

                if (i == 0) { btn.FillColor = PrimaryColor; btn.ForeColor = Color.White; }
                else { btn.FillColor = Color.White; btn.ForeColor = Color.Black; btn.BorderThickness = 1; btn.BorderColor = Color.WhiteSmoke; }

                if (this.Controls.Find("pnlFilterInner", true).Length > 0)
                    ((Panel)this.Controls.Find("pnlFilterInner", true)[0]).Controls.Add(btn);

                x += 130;
            }
        }

        private void InitStatItems()
        {
            int startX = 650;
            CreateStatLabel("Sản phẩm", "156", startX, 180);
            CreateStatLabel("Tỷ lệ phản hồi", "98%", startX + 150, 180);
            CreateStatLabel("Thời gian phản hồi", "2 giờ", startX + 300, 180);
            CreateStatLabel("Tham gia", "01/2023", startX + 450, 180);
        }

        private void CreateStatLabel(string title, string value, int x, int y)
        {
            Label lblVal = new Label();
            lblVal.Text = value;
            lblVal.ForeColor = PrimaryColor;
            lblVal.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblVal.Location = new Point(x, y);
            lblVal.AutoSize = true;

            if (this.Controls.Find("pnlHeaderContainer", true).Length > 0)
            {
                var pnlHeader = this.Controls.Find("pnlHeaderContainer", true)[0];
                pnlHeader.Controls.Add(lblVal);
                lblVal.BringToFront();

                Label lblTitle = new Label();
                lblTitle.Text = title;
                lblTitle.ForeColor = TextGray;
                lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblTitle.Location = new Point(x, y + 25);
                lblTitle.AutoSize = true;
                pnlHeader.Controls.Add(lblTitle);
                lblTitle.BringToFront();
            }
        }

        public void LoadShopData(int shopId)
        {
            if (this.Controls.Find("flowProducts", true).Length > 0)
            {
                var flow = (FlowLayoutPanel)this.Controls.Find("flowProducts", true)[0];
                flow.Controls.Clear();

                // [CẬP NHẬT] Thêm ID giả lập (1, 2, 3...) vào tham số đầu tiên
                AddProductCard(flow, 101, "Áo khoác denim thời trang", "450.000đ", "https://cf.shopee.vn/file/5c48983458307d95651950f3b8a27d6c", "1.2k");
                AddProductCard(flow, 102, "Áo thun nam basic", "149.000đ", "https://cf.shopee.vn/file/90200d5c57375f99767f156e0d913994", "2.4k");
                AddProductCard(flow, 103, "Quần jean nữ skinny", "390.000đ", "https://cf.shopee.vn/file/sg-11134201-22100-0j1g4k3h3liv64", "890");
                AddProductCard(flow, 104, "Giày thể thao Nike", "1.200.000đ", "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e6da41fa-1be4-4ce5-b89c-22be4f1f02d6/air-force-1-07-shoes-WrLlWX.png", "456");

                for (int i = 0; i < 6; i++)
                    AddProductCard(flow, 200 + i, $"Sản phẩm mẫu {i + 1}", "99.000đ", "", "100");
            }
        }

        // [QUAN TRỌNG] Hàm này đã được cập nhật logic Click
        private void AddProductCard(FlowLayoutPanel flow, int productId, string name, string priceStr, string imgUrl, string sold)
        {
            int cardWidth = 210;

            Guna2Panel card = new Guna2Panel();
            card.Size = new Size(cardWidth, 310);
            card.BackColor = Color.White;
            card.Margin = new Padding(10, 0, 10, 20);
            card.BorderRadius = 4;
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Shadow = new Padding(2);
            card.ShadowDecoration.Depth = 5;
            card.ShadowDecoration.Color = Color.LightGray;
            card.Cursor = Cursors.Hand;

            // --- 1. Tạo các Controls ---
            Guna2PictureBox pic = new Guna2PictureBox();
            pic.Dock = DockStyle.Top;
            pic.Height = 190;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BorderRadius = 4;
            if (!string.IsNullOrEmpty(imgUrl)) pic.ImageLocation = imgUrl;
            else pic.FillColor = Color.WhiteSmoke;

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblName.Location = new Point(8, 200);
            lblName.Size = new Size(cardWidth - 16, 40);
            lblName.AutoEllipsis = true;

            Label lblPrice = new Label();
            lblPrice.Text = priceStr;
            lblPrice.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPrice.ForeColor = PrimaryColor;
            lblPrice.Location = new Point(8, 245);
            lblPrice.AutoSize = true;

            Label lblSold = new Label();
            lblSold.Text = "⭐ 4.8 | Đã bán " + sold;
            lblSold.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblSold.ForeColor = Color.Gray;
            lblSold.Location = new Point(10, 275);
            lblSold.AutoSize = true;

            // --- 2. Xử lý Sự kiện Click ---
            // Định nghĩa hành động khi click
            EventHandler onCardClick = (sender, e) =>
            {
                // Parse giá tiền từ chuỗi (ví dụ "450.000đ" -> 450000)
                decimal priceVal = 0;
                string cleanPrice = priceStr.Replace(".", "").Replace("đ", "").Replace(",", "").Trim();
                decimal.TryParse(cleanPrice, out priceVal);

                // Tạo DTO để truyền sang trang chi tiết
                ProductDTO productDTO = new ProductDTO
                {
                    ProductId = productId,
                    Name = name,
                    Price = priceVal,
                    Rating = 4.8,
                    SoldQuantity = 100, // Demo
                    ImagePath = imgUrl,
                    // Nếu muốn test ảnh thumbnail thì gán luôn vào đây
                    ThumbnailPaths = new System.Collections.Generic.List<string> { imgUrl, imgUrl }
                };

                // Tìm Form Main và chuyển trang
                FrmMain mainForm = this.FindForm() as FrmMain;
                if (mainForm != null)
                {
                    mainForm.LoadPage("ProductDetail", productDTO);
                }
            };

            // Gán sự kiện click cho TẤT CẢ các thành phần (để click vào đâu cũng ăn)
            card.Click += onCardClick;
            pic.Click += onCardClick;
            lblName.Click += onCardClick;
            lblPrice.Click += onCardClick;

            // --- 3. Add vào Panel ---
            card.Controls.Add(lblSold);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblName);
            card.Controls.Add(pic);
            flow.Controls.Add(card);
        }
    }
}