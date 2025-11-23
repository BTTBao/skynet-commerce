using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms;      // Để gọi FrmMain
using Skynet_Commerce.BLL.Models;     // Để dùng ShopDTO, ProductDTO
using Skynet_Commerce.BLL.Services;   // Để gọi UserShopService

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcShopDetail : UserControl
    {
        // [QUAN TRỌNG] Dùng UserShopService (Service dành cho người dùng)
        private UserShopService _shopService;

        // Màu sắc giao diện
        private Color PrimaryColor = Color.FromArgb(238, 77, 45);
        private Color TextGray = Color.FromArgb(100, 100, 100);

        public UcShopDetail()
        {
            InitializeComponent();

            // Khởi tạo Service
            _shopService = new UserShopService();

            // Vẽ các thành phần tĩnh (Nút bộ lọc...)
            SetupStaticUI();
        }

        private void SetupStaticUI()
        {
            // Khởi tạo các nút lọc (Mới nhất, Bán chạy...)
            InitFilterButtons();
        }

        // =================================================================================
        // 1. HÀM LOAD DỮ LIỆU CHÍNH (ĐƯỢC GỌI TỪ FRMMAIN)
        // =================================================================================
        public void LoadShopData(int shopId)
        {
            try
            {
                // Gọi Service lấy dữ liệu Shop + Sản phẩm
                ShopDTO shop = _shopService.GetShopDetail(shopId);

                if (shop == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin Shop này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- A. CẬP NHẬT THÔNG TIN SHOP (HEADER) ---

                // 1. Ảnh đại diện & Ảnh bìa
                if (!string.IsNullOrEmpty(shop.AvatarUrl))
                    picAvatar.ImageLocation = shop.AvatarUrl;

                if (!string.IsNullOrEmpty(shop.CoverImageUrl))
                    picBanner.ImageLocation = shop.CoverImageUrl;

                picAvatar.BringToFront(); // Đảm bảo Avatar nằm trên Banner

                // 2. Tên Shop (Nếu bạn có label tên shop thì gán ở đây)
                // lblShopName.Text = shop.ShopName;

                // 3. Cập nhật thống kê (Số sản phẩm, Đánh giá, Ngày tham gia)
                UpdateStatItems(shop);


                // --- B. CẬP NHẬT DANH SÁCH SẢN PHẨM ---

                // Tìm FlowLayoutPanel trong giao diện (do Designer tạo ra)
                var flow = this.Controls.Find("flowProducts", true).Length > 0
                           ? (FlowLayoutPanel)this.Controls.Find("flowProducts", true)[0]
                           : null;

                if (flow != null)
                {
                    flow.Controls.Clear(); // Xóa dữ liệu cũ

                    // Duyệt qua danh sách sản phẩm thật
                    foreach (var p in shop.Products)
                    {
                        // Gọi hàm vẽ thẻ sản phẩm
                        AddProductCard(flow, p);
                    }

                    // Nếu shop chưa có sản phẩm nào
                    if (shop.Products.Count == 0)
                    {
                        Label lblEmpty = new Label
                        {
                            Text = "Shop này chưa đăng bán sản phẩm nào.",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            Margin = new Padding(20)
                        };
                        flow.Controls.Add(lblEmpty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Shop: " + ex.Message);
            }
        }

        // =================================================================================
        // 2. CÁC HÀM HỖ TRỢ GIAO DIỆN (UI HELPERS)
        // =================================================================================

        // Cập nhật các chỉ số thống kê trên Header
        private void UpdateStatItems(ShopDTO shop)
        {
            // Tìm Panel chứa thống kê
            var pnlHeader = this.Controls.Find("pnlHeaderContainer", true).Length > 0
                            ? (Panel)this.Controls.Find("pnlHeaderContainer", true)[0]
                            : null;

            if (pnlHeader != null)
            {
                // Xóa các label thống kê cũ để vẽ lại
                for (int i = pnlHeader.Controls.Count - 1; i >= 0; i--)
                {
                    if (pnlHeader.Controls[i] is Label) pnlHeader.Controls.RemoveAt(i);
                }

                // Vẽ lại thông tin mới
                int startX = 650;
                CreateStatLabel(pnlHeader, "Sản phẩm", shop.ProductCount.ToString(), startX, 180);
                CreateStatLabel(pnlHeader, "Đánh giá", $"{shop.Rating:N1}", startX + 150, 180);
                CreateStatLabel(pnlHeader, "Tham gia", shop.JoinDate, startX + 300, 180);
            }
        }

        // Hàm vẽ 1 thẻ sản phẩm vào danh sách
        private void AddProductCard(FlowLayoutPanel flow, ProductDTO product)
        {
            int cardWidth = 210;

            // 1. Tạo Panel Card
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

            // 2. Ảnh sản phẩm
            Guna2PictureBox pic = new Guna2PictureBox();
            pic.Dock = DockStyle.Top;
            pic.Height = 190;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BorderRadius = 4;

            // Xử lý ảnh online/offline
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                if (product.ImagePath.StartsWith("http")) pic.ImageLocation = product.ImagePath;
                else if (System.IO.File.Exists(product.ImagePath)) pic.ImageLocation = product.ImagePath;
                else pic.FillColor = Color.WhiteSmoke;
            }
            else pic.FillColor = Color.WhiteSmoke;

            // 3. Tên sản phẩm
            Label lblName = new Label();
            lblName.Text = product.Name;
            lblName.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblName.Location = new Point(8, 200);
            lblName.Size = new Size(cardWidth - 16, 40);
            lblName.AutoEllipsis = true;

            // 4. Giá tiền
            Label lblPrice = new Label();
            lblPrice.Text = $"{product.Price:N0}₫";
            lblPrice.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPrice.ForeColor = PrimaryColor;
            lblPrice.Location = new Point(8, 245);
            lblPrice.AutoSize = true;

            // 5. Đã bán
            Label lblSold = new Label();
            lblSold.Text = $"⭐ {product.Rating:N1} | Đã bán {product.SoldQuantity.GetValueOrDefault(0)}";
            lblSold.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblSold.ForeColor = Color.Gray;
            lblSold.Location = new Point(10, 275);
            lblSold.AutoSize = true;

            // --- SỰ KIỆN CLICK: CHUYỂN TRANG ---
            EventHandler onCardClick = (sender, e) =>
            {
                FrmMain mainForm = this.FindForm() as FrmMain;
                if (mainForm != null)
                {
                    // Chuyển sang trang ProductDetail với dữ liệu thật
                    mainForm.LoadPage("ProductDetail", product);
                }
            };

            // Gán sự kiện cho tất cả thành phần
            card.Click += onCardClick;
            pic.Click += onCardClick;
            lblName.Click += onCardClick;
            lblPrice.Click += onCardClick;

            // Thêm vào Card -> Thêm vào Flow
            card.Controls.Add(lblSold);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblName);
            card.Controls.Add(pic);
            flow.Controls.Add(card);
        }

        // Hàm vẽ các nút bộ lọc (UI tĩnh)
        private void InitFilterButtons()
        {
            string[] filters = { "Tất cả sản phẩm", "Mới nhất", "Bán chạy", "Giá thấp", "Giá cao" };
            int x = 15;

            // Tìm panel chứa nút filter
            var pnlFilterInner = this.Controls.Find("pnlFilterInner", true).Length > 0
                                 ? (Panel)this.Controls.Find("pnlFilterInner", true)[0]
                                 : null;

            if (pnlFilterInner != null)
            {
                pnlFilterInner.Controls.Clear(); // Xóa cũ nếu có

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

                    pnlFilterInner.Controls.Add(btn);
                    x += 130;
                }
            }
        }

        // Hàm vẽ Label thống kê
        private void CreateStatLabel(Control parent, string title, string value, int x, int y)
        {
            Label lblVal = new Label();
            lblVal.Text = value;
            lblVal.ForeColor = PrimaryColor;
            lblVal.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblVal.Location = new Point(x, y);
            lblVal.AutoSize = true;
            parent.Controls.Add(lblVal);
            lblVal.BringToFront();

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = TextGray;
            lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTitle.Location = new Point(x, y + 25);
            lblTitle.AutoSize = true;
            parent.Controls.Add(lblTitle);
            lblTitle.BringToFront();
        }
    }
}