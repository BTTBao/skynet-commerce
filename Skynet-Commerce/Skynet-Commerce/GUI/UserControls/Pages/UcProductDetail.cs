using System;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models; // Dùng để tham chiếu đến các DTO/Model nếu có
using System.Linq;
namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProductDetail : UserControl
    {
        private int _productId;
        private FlowLayoutPanel flpMainLayout; // Layout 2 cột chính

        // Dữ liệu mẫu (Lấy từ code React)
        private readonly dynamic _productData = new
        {
            id = 1,
            name = "Áo khoác denim thời trang cao cấp",
            description = "Áo khoác denim chất lượng cao, thiết kế trẻ trung, năng động. Chất liệu denim cao cấp, bền đẹp, không phai màu. Phù hợp cho cả nam và nữ.",
            images = new[] {
                @"img\download.png",
                @"img\download.png",
                @"img\download.png",
                @"img\download.png",
            },
            price = 450000m,
            originalPrice = 650000m,
            rating = 4.8,
            reviewCount = 234,
            sold = 1234,
            shop = new
            {
                name = "Fashion Store",
                logo = "https://images.unsplash.com/photo-1441986300917-64674bd600d8?w=100&h=100&fit=crop",
                followers = 12500,
                products = 156,
            },
            variants = new
            {
                sizes = new[] { "S", "M", "L", "XL", "XXL" },
                colors = new[] {
                    new { name = "Xanh đen", hex = "#1a3a52" },
                    new { name = "Xanh nhạt", hex = "#7b9fb8" },
                    new { name = "Đen", hex = "#000000" },
                },
            },
            stock = 150,
        };

        public UcProductDetail(int productId)
        {
            InitializeComponent();
            _productId = productId;
            LoadMainLayout(); // Khởi tạo bố cục lớn
            LoadProductData(); // Tải dữ liệu và vẽ UI
        }

        // 1. Khởi tạo FlowLayoutPanel chính để chứa các Panel con
        private void LoadMainLayout()
        {
            flpMainLayout = new FlowLayoutPanel();
            flpMainLayout.AutoScroll = true;
            flpMainLayout.FlowDirection = FlowDirection.TopDown;
            flpMainLayout.AutoSize = true;
            flpMainLayout.Margin = new Padding(30, 20, 30, 20); // Padding ngoài
            flpMainLayout.Width = 1140; // Chiều rộng cố định cho trang

            pnlContent.Controls.Add(flpMainLayout);
            pnlContent.Dock = DockStyle.Fill;
        }

        // 2. Tải và vẽ dữ liệu
        private void LoadProductData()
        {
            // Panel chứa 2 cột chính (Hình ảnh và Thông tin)
            Panel pnlTopSection = new Panel();
            pnlTopSection.Size = new Size(1140, 500); // Kích thước cố định cho 2 cột trên cùng

            // --- CỘT TRÁI: HÌNH ẢNH (Image Section) ---
            Panel pnlImage = CreateImageSection(500, 500);
            pnlImage.Location = new Point(0, 0);

            // --- CỘT PHẢI: THÔNG TIN (Product Info) ---
            Panel pnlInfo = CreateInfoSection(600, 500);
            pnlInfo.Location = new Point(540, 0); // Đặt cách 40px (540 - 500)

            pnlTopSection.Controls.Add(pnlImage);
            pnlTopSection.Controls.Add(pnlInfo);
            flpMainLayout.Controls.Add(pnlTopSection);

            // --- Dòng dưới: SHOP INFO ---
            Panel pnlShop = CreateShopSection(1140, 100);
            flpMainLayout.Controls.Add(pnlShop);

            // --- Dòng dưới: MÔ TẢ SẢN PHẨM ---
            Panel pnlDescription = CreateDescriptionSection(1140, 300);
            flpMainLayout.Controls.Add(pnlDescription);
        }

        // 3. Hàm tạo Cột Hình ảnh
        private Panel CreateImageSection(int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // Hình ảnh chính
            PictureBox pbMain = new PictureBox();

            // FIX 1: Giảm chiều cao ảnh chính (500 - 90 = 410px) để chừa chỗ cho thumbnail
            int mainImageHeight = width - 90;
            pbMain.Size = new Size(width - 20, mainImageHeight);

            pbMain.Location = new Point(10, 10);
            pbMain.SizeMode = PictureBoxSizeMode.Zoom;

            // FIX 2: Load ảnh đầu tiên bằng đường dẫn tuyệt đối
            string initialPath = System.IO.Path.Combine(Application.StartupPath, _productData.images[0]);
            if (System.IO.File.Exists(initialPath))
                pbMain.ImageLocation = initialPath;
            else
                pbMain.BackColor = Color.LightGray;

            pbMain.Name = "pbMainImage";
            pnl.Controls.Add(pbMain);

            // --- Thêm khu vực Thumbnail ở dưới ---
            FlowLayoutPanel flpThumbnails = CreateThumbnailGallery(width - 20);

            // FIX 3: Đặt thumbnail ngay dưới ảnh chính + 10px margin
            flpThumbnails.Location = new Point(10, mainImageHeight + 20);
            pnl.Controls.Add(flpThumbnails);

            return pnl;
        }
        // Hàm tạo thư viện ảnh Thumbnail (FIX: Dùng Path.Combine cho ảnh local)
        private FlowLayoutPanel CreateThumbnailGallery(int width)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Size = new Size(width, 80);
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.WrapContents = false;
            flp.Margin = new Padding(0);

            int index = 0;
            foreach (var imageUrl in _productData.images)
            {
                PictureBox pbThumbnail = new PictureBox();
                pbThumbnail.Size = new Size(70, 70);
                pbThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
                pbThumbnail.BorderStyle = BorderStyle.FixedSingle;
                pbThumbnail.Cursor = Cursors.Hand;
                pbThumbnail.Margin = new Padding(0, 0, 5, 0);

                // FIX: Load ảnh thumbnail bằng đường dẫn tuyệt đối
                string fullPath = System.IO.Path.Combine(Application.StartupPath, imageUrl);
                if (System.IO.File.Exists(fullPath))
                    pbThumbnail.ImageLocation = fullPath;
                else
                    pbThumbnail.BackColor = Color.LightCoral;

                pbThumbnail.Tag = index;
                pbThumbnail.Click += (s, e) => HandleThumbnailClick((int)pbThumbnail.Tag);

                flp.Controls.Add(pbThumbnail);
                index++;
            }
            return flp;
        }

        // Hàm xử lý sự kiện khi click vào thumbnail (FIX: Cập nhật đường dẫn tuyệt đối)
        private void HandleThumbnailClick(int index)
        {
            // Tìm pnlContent (được đặt trong Designer)
            // Cần đảm bảo pnlContent đã được khai báo
            Control mainContentPanel = this.Controls.Find("pnlContent", true).FirstOrDefault();

            if (mainContentPanel != null)
            {
                // Tìm PictureBox chính
                Control mainControl = mainContentPanel.Controls.Find("pbMainImage", true).FirstOrDefault();

                if (mainControl is PictureBox pbMain)
                {
                    if (index >= 0 && index < _productData.images.Length)
                    {
                        // FIX: Dùng đường dẫn tuyệt đối khi cập nhật ImageLocation
                        string newImagePath = System.IO.Path.Combine(Application.StartupPath, _productData.images[index]);
                        if (System.IO.File.Exists(newImagePath))
                        {
                            pbMain.ImageLocation = newImagePath;
                        }
                    }
                }
            }
        }


        // 4. Hàm tạo Cột Thông tin & Variants
        private Panel CreateInfoSection(int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            int currentY = 10; // Biến theo dõi vị trí Y

            // --- 1. TÊN SẢN PHẨM ---
            Label lblName = new Label();
            lblName.Text = _productData.name;
            lblName.Font = new Font("Arial", 16, FontStyle.Bold);
            lblName.Location = new Point(10, currentY);
            lblName.Size = new Size(width - 20, 40);
            pnl.Controls.Add(lblName);
            currentY += 40;

            // --- 2. KHU VỰC ĐÁNH GIÁ (Stars, Reviews, Sold) ---
            Label lblStats = new Label();
            lblStats.Text = $"⭐️ {_productData.rating} ({_productData.reviewCount} Đánh giá) | {_productData.sold} Đã bán";
            lblStats.Location = new Point(10, currentY);
            lblStats.AutoSize = true;
            pnl.Controls.Add(lblStats);
            currentY += 40;

            // --- 3. KHU VỰC GIÁ (bg-gray-50) ---
            Panel pnlPrice = new Panel();
            pnlPrice.Size = new Size(width - 20, 70);
            pnlPrice.Location = new Point(10, currentY);
            pnlPrice.BackColor = Color.FromArgb(240, 240, 240);

            Label lblPrice = new Label();
            lblPrice.Text = _productData.price.ToString("N0") + "đ";
            lblPrice.Font = new Font("Arial", 20, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(255, 87, 34);
            lblPrice.Location = new Point(10, 10);
            lblPrice.AutoSize = true;
            pnlPrice.Controls.Add(lblPrice);

            pnl.Controls.Add(pnlPrice);
            currentY += 80; // Tăng thêm 80px cho khu vực giá

            // --- 4. VARIANTS: Kích thước ---
            Label lblSize = new Label();
            lblSize.Text = "Kích thước";
            lblSize.Location = new Point(10, currentY);
            lblSize.AutoSize = true;
            pnl.Controls.Add(lblSize);
            currentY += 25;

            // FlowLayoutPanel cho các nút Kích thước
            FlowLayoutPanel flpSizes = CreateVariantButtons(_productData.variants.sizes, isSize: true);
            flpSizes.Location = new Point(10, currentY);
            flpSizes.Size = new Size(width - 20, 40);
            pnl.Controls.Add(flpSizes);
            currentY += 50;

            // --- 5. VARIANTS: Màu sắc ---
            Label lblColor = new Label();
            lblColor.Text = "Màu sắc";
            lblColor.Location = new Point(10, currentY);
            lblColor.AutoSize = true;
            pnl.Controls.Add(lblColor);
            currentY += 25;

            // FlowLayoutPanel cho các nút Màu sắc
            FlowLayoutPanel flpColors = CreateVariantButtons(_productData.variants.colors, isSize: false);
            flpColors.Location = new Point(10, currentY);
            flpColors.Size = new Size(width - 20, 40);
            pnl.Controls.Add(flpColors);
            currentY += 50;

            // --- 6. QUANTITY: Số lượng ---
            Label lblQuantity = new Label();
            lblQuantity.Text = "Số lượng";
            lblQuantity.Location = new Point(10, currentY);
            lblQuantity.AutoSize = true;
            pnl.Controls.Add(lblQuantity);
            currentY += 25;

            // Khởi tạo ô nhập số lượng (TextBox, Minus, Plus buttons)
            Panel pnlQuantity = CreateQuantityControl(_productData.stock);
            pnlQuantity.Location = new Point(10, currentY);
            pnl.Controls.Add(pnlQuantity);
            currentY += 50;

            // --- 7. ACTIONS: Thêm giỏ hàng / Mua ngay ---
            Panel pnlActions = CreateActionButtons(width - 20);
            pnlActions.Location = new Point(10, currentY);
            pnl.Controls.Add(pnlActions);

            return pnl;
        }

        // 5. Hàm tạo Khu vực Shop Info
        private Panel CreateShopSection(int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.Margin = new Padding(0, 20, 0, 20);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            int avatarSize = 60; // Kích thước avatar (60x60)
            int margin = 20; // Margin 20px

            // --- 1. SHOP LOGO (Avatar) ---
            PictureBox pbLogo = new PictureBox();
            pbLogo.Size = new Size(avatarSize, avatarSize);
            pbLogo.Location = new Point(margin, (height - avatarSize) / 2); // Căn giữa theo chiều dọc
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;

            // Load ảnh từ URL mẫu (Sử dụng URL trong _productData)
            pbLogo.ImageLocation = _productData.shop.logo;

            // Tùy chọn: Nếu muốn avatar hình tròn, cần xử lý trong sự kiện Paint (Nâng cao)
            pnl.Controls.Add(pbLogo);

            // --- 2. THÔNG TIN SHOP (Tên, Followers) ---

            // Tên Shop
            Label lblShopName = new Label();
            lblShopName.Text = _productData.shop.name;
            lblShopName.Font = new Font("Arial", 12, FontStyle.Bold);
            lblShopName.Location = new Point(margin + avatarSize + 15, margin);
            lblShopName.AutoSize = true;

            // Thống kê (Followers | Products)
            Label lblStats = new Label();
            lblStats.Text = $"{_productData.shop.followers.ToString("N0")} người theo dõi | {_productData.shop.products} sản phẩm";
            lblStats.Location = new Point(margin + avatarSize + 15, margin + 25);
            lblStats.ForeColor = Color.Gray;
            lblStats.Font = new Font("Arial", 9);
            lblStats.AutoSize = true;

            pnl.Controls.Add(lblShopName);
            pnl.Controls.Add(lblStats);

            // --- 3. NÚT HÀNH ĐỘNG (Far Right) ---
            int btnWidth = 100;
            int btnHeight = 35;
            int paddingRight = 20; // Padding bên phải

            // Nút Theo dõi (Orange outline)
            Button btnFollow = new Button();
            btnFollow.Text = "Theo dõi";
            btnFollow.Size = new Size(btnWidth, btnHeight);
            btnFollow.Location = new Point(width - paddingRight - btnWidth, (height - btnHeight) / 2); // Căn giữa dọc
            btnFollow.FlatStyle = FlatStyle.Flat;
            btnFollow.FlatAppearance.BorderColor = Color.FromArgb(255, 87, 34);
            btnFollow.ForeColor = Color.FromArgb(255, 87, 34);
            btnFollow.BackColor = Color.White;
            pnl.Controls.Add(btnFollow);

            // Nút Xem Shop (Grey outline)
            Button btnViewShop = new Button();
            btnViewShop.Text = "Xem Shop";
            btnViewShop.Size = new Size(btnWidth, btnHeight);
            btnViewShop.Location = new Point(width - paddingRight - (btnWidth * 2) - 10, (height - btnHeight) / 2); // Căn giữa dọc
            btnViewShop.FlatStyle = FlatStyle.Flat;
            btnViewShop.FlatAppearance.BorderColor = Color.LightGray;
            btnViewShop.BackColor = Color.White;
            pnl.Controls.Add(btnViewShop);

            return pnl;
        }

        // 6. Hàm tạo Khu vực Mô tả sản phẩm
        private Panel CreateDescriptionSection(int width, int height)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, height);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = "Mô tả sản phẩm";
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            lblTitle.AutoSize = true;
            pnl.Controls.Add(lblTitle);

            RichTextBox rtbDesc = new RichTextBox();
            rtbDesc.Text = _productData.description;
            rtbDesc.Location = new Point(10, 40);
            rtbDesc.Size = new Size(width - 20, height - 50);
            rtbDesc.ReadOnly = true;
            pnl.Controls.Add(rtbDesc);

            return pnl;
        }
        // Biến lưu trữ trạng thái lựa chọn (Cần thiết cho logic AddToCart)
        private string _selectedSize = "";
        private string _selectedColor = "";
        private int _quantity = 1;

        // 1. Hàm tạo các nút bấm Variants (Kích thước hoặc Màu sắc)
        private FlowLayoutPanel CreateVariantButtons(dynamic variants, bool isSize)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.AutoSize = true;
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.WrapContents = false;

            foreach (var variant in variants)
            {
                Button btn = new Button();
                btn.Size = new Size(80, 30);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.BackColor = Color.White;

                btn.Tag = isSize ? (string)variant : (string)variant.name;
                btn.Text = isSize ? (string)variant : (string)variant.name;
                btn.Margin = new Padding(0, 0, 5, 0);

                btn.Click += (s, e) =>
                {
                    // Reset màu của tất cả các nút cùng nhóm
                    foreach (Control c in flp.Controls)
                    {
                        if (c is Button b)
                        {
                            b.FlatAppearance.BorderColor = Color.Gray;
                            b.BackColor = Color.White;
                        }
                    }

                    // Đặt màu cho nút được chọn
                    btn.FlatAppearance.BorderColor = Color.FromArgb(255, 87, 34);
                    btn.BackColor = Color.FromArgb(255, 240, 230);

                    // Lưu trạng thái
                    if (isSize)
                        _selectedSize = (string)btn.Tag;
                    else
                        _selectedColor = (string)btn.Tag;
                };

                flp.Controls.Add(btn);
            }
            return flp;
        }


        // 2. Hàm tạo ô nhập Số lượng (Quantity)
        private Panel CreateQuantityControl(int maxStock)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(300, 30);

            TextBox txtQuantity = new TextBox();
            txtQuantity.Text = _quantity.ToString();
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.Size = new Size(50, 30);
            txtQuantity.Location = new Point(30, 0);
            txtQuantity.ReadOnly = true;

            // Nút Minus (-)
            Button btnMinus = new Button();
            btnMinus.Text = "–";
            btnMinus.Size = new Size(30, 30);
            btnMinus.Location = new Point(0, 0);
            btnMinus.Click += (s, e) =>
            {
                if (_quantity > 1)
                {
                    _quantity--;
                    txtQuantity.Text = _quantity.ToString();
                }
            };

            // Nút Plus (+)
            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Size = new Size(30, 30);
            btnPlus.Location = new Point(80, 0);
            btnPlus.Click += (s, e) =>
            {
                if (_quantity < maxStock)
                {
                    _quantity++;
                    txtQuantity.Text = _quantity.ToString();
                }
            };

            Label lblStock = new Label();
            lblStock.Text = $"{maxStock} sản phẩm có sẵn";
            lblStock.Location = new Point(120, 5);
            lblStock.AutoSize = true;

            pnl.Controls.Add(btnMinus);
            pnl.Controls.Add(txtQuantity);
            pnl.Controls.Add(btnPlus);
            pnl.Controls.Add(lblStock);

            return pnl;
        }


        // 3. Hàm tạo Nút Hành động (Actions: AddToCart / BuyNow)
        private Panel CreateActionButtons(int width)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(width, 40);

            // Nút Thêm vào giỏ hàng
            Button btnAddToCart = new Button();
            btnAddToCart.Text = "🛒 Thêm vào giỏ";
            btnAddToCart.Size = new Size((width / 2) - 5, 40);
            btnAddToCart.Location = new Point(0, 0);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.FlatAppearance.BorderColor = Color.FromArgb(255, 87, 34);
            btnAddToCart.ForeColor = Color.FromArgb(255, 87, 34);
            btnAddToCart.Click += (s, e) => HandleAddToCart();

            // Nút Mua ngay
            Button btnBuyNow = new Button();
            btnBuyNow.Text = "Mua ngay";
            btnBuyNow.Size = new Size((width / 2) - 5, 40);
            btnBuyNow.Location = new Point(width / 2 + 5, 0);
            btnBuyNow.BackColor = Color.FromArgb(255, 87, 34);
            btnBuyNow.ForeColor = Color.White;
            btnBuyNow.FlatStyle = FlatStyle.Flat;
            btnBuyNow.Click += (s, e) => HandleBuyNow();

            pnl.Controls.Add(btnAddToCart);
            pnl.Controls.Add(btnBuyNow);

            return pnl;
        }

        // 4. LOGIC XỬ LÝ CLICK CUỐI CÙNG
        private void HandleAddToCart()
        {
            if (string.IsNullOrEmpty(_selectedSize) || string.IsNullOrEmpty(_selectedColor))
            {
                MessageBox.Show("Vui lòng chọn Kích thước và Màu sắc trước khi thêm vào giỏ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Thực hiện logic thêm vào giỏ hàng (DAL/BLL) ở đây

            MessageBox.Show($"Đã thêm {_quantity} sản phẩm '{_productData.name}' (Size: {_selectedSize}, Color: {_selectedColor}) vào giỏ hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HandleBuyNow()
        {
            HandleAddToCart();
            // TODO: Chuyển sang trang giỏ hàng (Cart Page)
            // Ví dụ: FrmMain.Instance.LoadUserControl(new UcCartPage());
        }
    }
}