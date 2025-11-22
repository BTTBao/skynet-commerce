using Skynet_Commerce.GUI.UserControls.Components; // Import để dùng UcProductItem và UcCategoryItem
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; // Thêm thư viện này để dùng Path.Combine
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models;
namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcHomePage : UserControl
    {
        // Danh sách ảnh banner (Local)
        private List<string> _bannerUrls = new List<string>
        {
            @"img\slide1.jpg",
            @"img\slide2.jpg",
            @"img\slide3.jpg"
        };
        private int _currentBannerIndex = 0;

        public UcHomePage()
        {
            InitializeComponent();

            // Căn giữa nội dung chính khi UserControl được tải (Khắc phục lỗi lệch trái)
            this.Load += UcHomePage_Load;
            this.pnlScrollContainer.Resize += pnlScrollContainer_Resize;

            // 1. Khởi chạy Banner
            LoadBanners();
            tmrBannerSlide.Interval = 3000;
            tmrBannerSlide.Tick += (s, e) => ChangeBanner(1);
            tmrBannerSlide.Start();
            btnNextBanner.Click += (s, e) => ChangeBanner(1);
            btnPrevBanner.Click += (s, e) => ChangeBanner(-1);

            // 2. Tải Danh Mục
            LoadCategories();

            // 3. Tải Sản Phẩm Gợi Ý
            LoadSuggestedProducts();

            // 4. Tải Flash Sale (Thêm hàm mới)
           
        }

        // --- LOGIC CĂN GIỮA NỘI DUNG ---
        private void UcHomePage_Load(object sender, EventArgs e)
        {
            CenterSections();
        }

        private void pnlScrollContainer_Resize(object sender, EventArgs e)
        {
            CenterSections();
        }

        /// <summary>
        /// Căn giữa FlowLayoutPanel chứa các Section theo chiều ngang.
        /// </summary>
        private void CenterSections()
        {
            // Kiểm tra và đặt lại kích thước của FlowLayoutPanel để nó không tạo cuộn ngang
            // Giả định chiều rộng của các section con (pnlBanner, pnlCategoryGrid,...) là 920px
            int contentWidth = 920;

            if (this.pnlScrollContainer.Width > contentWidth)
            {
                // Tính toán vị trí X để căn giữa
                int x = (this.pnlScrollContainer.Width - contentWidth) / 2;
                this.flpSections.Left = x;
                this.flpSections.Width = contentWidth;
            }
            else
            {
                // Nếu cửa sổ quá nhỏ, căn về mép trái và chiếm hết chiều rộng
                this.flpSections.Left = 0;
                this.flpSections.Width = this.pnlScrollContainer.Width;
            }
        }

        // --- HÀM TẠO SẢN PHẨM GỢI Ý (ĐÃ KÍCH HOẠT) ---
        private void LoadSuggestedProducts()
        {
            flpRecommendedProducts.Controls.Clear();
            flpRecommendedProducts.WrapContents = true;

            // Đặt chiều rộng cho FlowLayoutPanel để nó có thể chứa 5 thẻ sản phẩm (5 x 180px + margin)
            // 5 * (180 + 10 margin) = 950px
            flpRecommendedProducts.Width = 980;

            // Đặt Padding để căn chỉnh (Đẩy sang trái 55px)
            flpRecommendedProducts.Padding = new Padding(55, 10, 0, 20);

            // --- Dữ liệu giả lập ---
            var products = new List<ProductDTO>
    {
        new ProductDTO { ProductId = 1, Name = "Áo khoác denim thời trang", Price = 450000, OldPrice = 550000, Rating = 4.8, SoldQuantity = 1234, ImagePath = @"img\slide1.jpg" },
        new ProductDTO { ProductId = 2, Name = "Điện thoại thông minh", Price = 8500000, OldPrice = 0, Rating = 4.9, SoldQuantity = 567, ImagePath = @"img\product1.jpg" },
        new ProductDTO { ProductId = 3, Name = "Bàn làm việc gỗ cao cấp", Price = 2500000, OldPrice = 3000000, Rating = 4.7, SoldQuantity = 234, ImagePath = @"img\product1.jpg" },
        new ProductDTO { ProductId = 4, Name = "Bộ mỹ phẩm dưỡng da", Price = 890000, OldPrice = 990000, Rating = 4.6, SoldQuantity = 890, ImagePath = @"img\product1.jpg" },
        
    };

            // --- Vòng lặp tạo sản phẩm ---
            foreach (var product in products)
            {
                UcProductItem item = new UcProductItem(product); // Sử dụng constructor nhận DTO
                flpRecommendedProducts.Controls.Add(item);
            }
        }

        /// <summary>
        /// Hàm Tải Sản phẩm Flash Sale (Tương tự LoadSuggestedProducts)
        /// </summary>
        

        // --- HÀM XỬ LÝ BANNER (GIỮ NGUYÊN) ---
        private void LoadBanners()
        {
            if (_bannerUrls.Count > 0)
            {
                string fullPath = Path.Combine(Application.StartupPath, _bannerUrls[0]);
                if (File.Exists(fullPath))
                {
                    pbBanner.ImageLocation = fullPath;
                    pbBanner.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void ChangeBanner(int step)
        {
            _currentBannerIndex += step;
            if (_currentBannerIndex >= _bannerUrls.Count) _currentBannerIndex = 0;
            if (_currentBannerIndex < 0) _currentBannerIndex = _bannerUrls.Count - 1;

            string fullPath = Path.Combine(Application.StartupPath, _bannerUrls[_currentBannerIndex]);
            if (File.Exists(fullPath)) pbBanner.ImageLocation = fullPath;
        }

        // --- HÀM XỬ LÝ DANH MỤC (ĐÃ SỬA LỖI CONSTRUCTOR) ---
        private void LoadCategories()
        {
            flpCategories.Controls.Clear();
            flpCategories.WrapContents = false;
            flpCategories.AutoScroll = true;

            var categories = new[]
            {
                new { Name = "Thời trang", Color = Color.FromArgb(255, 235, 238) },
                new { Name = "Điện tử", Color = Color.FromArgb(227, 242, 253) },
                new { Name = "Nhà cửa", Color = Color.FromArgb(255, 243, 224) },
                new { Name = "Làm đẹp", Color = Color.FromArgb(252, 228, 236) },
                new { Name = "Thể thao", Color = Color.FromArgb(232, 245, 233) },
                new { Name = "Đồ ăn", Color = Color.FromArgb(255, 253, 231) },
                new { Name = "Sách", Color = Color.FromArgb(243, 229, 245) },
                new { Name = "Khác", Color = Color.FromArgb(224, 247, 250) }
            };

            foreach (var cat in categories)
            {
                // >>> ĐÃ SỬA LỖI: CẦN TRUYỀN THAM SỐ THỨ 3 LÀ IMAGE (NULL MẶC ĐỊNH HOẶC ICON) <<<
                // Giả định bạn đã tạo constructor UcCategoryItem(string name, Color bgColor, Image icon)
                UcCategoryItem item = new UcCategoryItem(cat.Name, cat.Color, null);
                flpCategories.Controls.Add(item);
            }
        }
        
    }
}