using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.Components; // Import để dùng UcProductItem và UcCategoryItem

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

            // 1. Khởi chạy Banner
            LoadBanners();
            tmrBannerSlide.Interval = 3000;
            tmrBannerSlide.Tick += (s, e) => ChangeBanner(1);
            tmrBannerSlide.Start();
            btnNextBanner.Click += (s, e) => ChangeBanner(1);
            btnPrevBanner.Click += (s, e) => ChangeBanner(-1);

            // 2. Tải Danh Mục
            LoadCategories();

            // 3. Tải Sản Phẩm Gợi Ý (QUAN TRỌNG: Đây là hàm làm đầy phần đang trống)
            LoadSuggestedProducts();
        }

        // --- HÀM TẠO SẢN PHẨM GỢI Ý ---
        private void LoadSuggestedProducts()
        {
            flpRecommendedProducts.Controls.Clear();
            flpRecommendedProducts.WrapContents = true;

            // 1. Đặt chiều rộng cố định (đảm bảo đủ chỗ cho 5 sản phẩm/hàng)
            // 1 thẻ ~ 200px (gồm margin) x 5 thẻ = 1000px. 
            // Để rộng 1150px là an toàn.
            flpRecommendedProducts.Width = 1150;

            // 2. [QUAN TRỌNG] Thêm Padding để căn chỉnh
            // Padding(Trái, Trên, Phải, Dưới)
            // Đẩy sang trái 55px để nhìn cân đối hơn với tiêu đề
            flpRecommendedProducts.Padding = new Padding(55, 10, 0, 20);

            // --- Phần vòng lặp tạo sản phẩm (Giữ nguyên code cũ) ---
            for (int i = 1; i <= 5; i++)
            {
                string name = $"Sản phẩm demo mẫu số {i} phong cách React";
                decimal price = 150000 + (i * 25000);
                double rating = 4.0 + (i % 10) * 0.1;
                int sold = 50 * i;
                string imgPath = @"img\download.png";

                // SỬA: Thêm tham số cuối cùng là ProductID (i)
                UcProductItem item = new UcProductItem(
                    name,
                    price,
                    rating,
                    sold,
                    imgPath,
                    i // Biến i là ProductID giả lập
                );

                flpRecommendedProducts.Controls.Add(item);
            }
        }

        // --- HÀM XỬ LÝ BANNER (Giữ nguyên) ---
        private void LoadBanners()
        {
            if (_bannerUrls.Count > 0)
            {
                string fullPath = System.IO.Path.Combine(Application.StartupPath, _bannerUrls[0]);
                if (System.IO.File.Exists(fullPath))
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

            string fullPath = System.IO.Path.Combine(Application.StartupPath, _bannerUrls[_currentBannerIndex]);
            if (System.IO.File.Exists(fullPath)) pbBanner.ImageLocation = fullPath;
        }

        // --- HÀM XỬ LÝ DANH MỤC (Giữ nguyên) ---
        private void LoadCategories()
        {
            flpCategories.Controls.Clear();
            flpCategories.WrapContents = false;
            flpCategories.AutoScroll = true;

            var categories = new[]
            {
                new { Name = "Thời trang", Color = Color.FromArgb(255, 235, 238) },
                new { Name = "Điện tử",    Color = Color.FromArgb(227, 242, 253) },
                new { Name = "Nhà cửa",    Color = Color.FromArgb(255, 243, 224) },
                new { Name = "Làm đẹp",    Color = Color.FromArgb(252, 228, 236) },
                new { Name = "Thể thao",   Color = Color.FromArgb(232, 245, 233) },
                new { Name = "Đồ ăn",      Color = Color.FromArgb(255, 253, 231) },
                new { Name = "Sách",       Color = Color.FromArgb(243, 229, 245) },
                new { Name = "Khác",       Color = Color.FromArgb(224, 247, 250) }
            };

            foreach (var cat in categories)
            {
                // Nếu chưa có UcCategoryItem thì comment dòng này lại
                UcCategoryItem item = new UcCategoryItem(cat.Name, cat.Color);
                flpCategories.Controls.Add(item);
            }
        }
    }
}   

