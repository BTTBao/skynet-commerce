using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.Components; // Import namespace chứa thẻ Danh mục

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcHomePage : UserControl
    {
        // 1. Danh sách đường dẫn ảnh Banner (Bạn có thể thay bằng link ảnh thật của bạn)
        private List<string> _bannerUrls = new List<string>
        {
            @"img\slide1.jpg", // Ảnh 1
            @"img\slide2.jpg", // Ảnh 2
            @"img\slide3.jpg"  // Ảnh 3
        };

        private int _currentBannerIndex = 0; // Đang hiện ảnh số mấy

        public UcHomePage()
        {
            InitializeComponent();

            // --- CẤU HÌNH BANNER ---
            LoadBanners();

            // Gắn sự kiện cho Timer và Nút bấm (Code logic thay vì kéo thả)
            tmrBannerSlide.Interval = 3000; // 3 giây đổi 1 lần
            tmrBannerSlide.Tick += TmrBannerSlide_Tick;
            tmrBannerSlide.Start();

            btnNextBanner.Click += (s, e) => ChangeBanner(1);  // Next: +1
            btnPrevBanner.Click += (s, e) => ChangeBanner(-1); // Prev: -1

            // --- CẤU HÌNH CÁC PHẦN KHÁC ---
            LoadCategories(); // Tải danh mục
            LoadSuggestedProducts(); // Tải sản phẩm gợi ý
        }

        // Hàm khởi tạo Banner ban đầu
        private void LoadBanners()
        {
            if (_bannerUrls.Count > 0)
            {
                pbBanner.ImageLocation = _bannerUrls[0]; // Load ảnh đầu tiên từ URL
                pbBanner.SizeMode = PictureBoxSizeMode.StretchImage; // Co dãn ảnh cho vừa khung
            }
        }

        // Sự kiện Timer tự động chạy sau mỗi 3 giây
        private void TmrBannerSlide_Tick(object sender, EventArgs e)
        {
            ChangeBanner(1); // Tự động chuyển sang ảnh tiếp theo
        }

        // Hàm xử lý chuyển ảnh (dùng chung cho cả Timer và Nút bấm)
        private void ChangeBanner(int step)
        {
            // Tính toán chỉ số ảnh mới
            _currentBannerIndex += step;

            // Nếu vượt quá ảnh cuối -> Quay về ảnh đầu
            if (_currentBannerIndex >= _bannerUrls.Count)
                _currentBannerIndex = 0;

            // Nếu lùi quá ảnh đầu -> Nhảy về ảnh cuối
            if (_currentBannerIndex < 0)
                _currentBannerIndex = _bannerUrls.Count - 1;

            // Cập nhật ảnh lên PictureBox
            pbBanner.ImageLocation = _bannerUrls[_currentBannerIndex];
        }

        // ---------------------------------------------------------
        // PHẦN CODE DANH MỤC (Giữ nguyên từ bước trước)
        // ---------------------------------------------------------
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
                // Nếu chưa tạo file UcCategoryItem thì comment dòng dưới lại để tránh lỗi
                UcCategoryItem item = new UcCategoryItem(cat.Name, cat.Color);
                flpCategories.Controls.Add(item);
            }
        }

        private void LoadSuggestedProducts()
        {
            // Code giả lập sản phẩm (để trống hoặc thêm code hiển thị sản phẩm ở đây)
        }
    }
}