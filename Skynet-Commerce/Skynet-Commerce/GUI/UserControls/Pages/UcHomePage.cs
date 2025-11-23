using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net; // [MỚI] Cần để tải ảnh icon từ web
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcHomePage : UserControl
    {
        // Danh sách ảnh Banner
        private List<string> _bannerFiles = new List<string>
        {
            @"Resources\slide1.jpg",
            @"Resources\slide2.jpg",
            @"Resources\slide3.jpg"
        };
        private int _currentBannerIndex = 0;

        public UcHomePage()
        {
            InitializeComponent();

            this.Load += UcHomePage_Load;
            this.pnlScrollContainer.Resize += pnlScrollContainer_Resize;

            // 1. Chạy Banner
            LoadBanners();
            tmrBannerSlide.Interval = 3000;
            tmrBannerSlide.Tick += (s, e) => ChangeBanner(1);
            tmrBannerSlide.Start();

            btnNextBanner.Click += (s, e) => { tmrBannerSlide.Stop(); ChangeBanner(1); tmrBannerSlide.Start(); };
            btnPrevBanner.Click += (s, e) => { tmrBannerSlide.Stop(); ChangeBanner(-1); tmrBannerSlide.Start(); };

            // 2. Tải dữ liệu
            LoadCategories();         // <--- Đã cập nhật icon Web
            LoadSuggestedProducts();
        }

        // --- LOGIC TÌM ẢNH THÔNG MINH (CHO BANNER & SẢN PHẨM LOCAL) ---
        private string GetSmartImagePath(string relativePath)
        {
            string[] possibleBaseDirs = new string[]
            {
                Application.StartupPath,
                Directory.GetParent(Application.StartupPath).Parent.FullName,
                @"C:\BTL123\skynet-commerce\Skynet-Commerce\Skynet-Commerce"
            };

            foreach (var baseDir in possibleBaseDirs)
            {
                try
                {
                    string fullPath = Path.Combine(baseDir, relativePath);
                    if (File.Exists(fullPath)) return fullPath;
                }
                catch { }
            }
            return "";
        }

        // --- [MỚI] HÀM TẢI ẢNH TỪ WEB CHO CATEGORY ---
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return null;

                using (WebClient client = new WebClient())
                {
                    byte[] imageBytes = client.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null; // Trả về null nếu lỗi mạng hoặc link hỏng
            }
        }

        // --- XỬ LÝ GIAO DIỆN ---
        private void UcHomePage_Load(object sender, EventArgs e) { CenterSections(); }
        private void pnlScrollContainer_Resize(object sender, EventArgs e) { CenterSections(); }

        private void CenterSections()
        {
            int contentWidth = 920;
            if (this.pnlScrollContainer.Width > contentWidth)
            {
                int x = (this.pnlScrollContainer.Width - contentWidth) / 2;
                this.flpSections.Left = x;
                this.flpSections.Width = contentWidth;
            }
            else
            {
                this.flpSections.Left = 0;
                this.flpSections.Width = this.pnlScrollContainer.Width;
            }
        }

        private void LoadBanners()
        {
            if (_bannerFiles.Count > 0)
            {
                pbBanner.SizeMode = PictureBoxSizeMode.StretchImage;
                string path = GetSmartImagePath(_bannerFiles[0]);
                if (!string.IsNullOrEmpty(path)) pbBanner.ImageLocation = path;
            }
        }

        private void ChangeBanner(int step)
        {
            _currentBannerIndex += step;
            if (_currentBannerIndex >= _bannerFiles.Count) _currentBannerIndex = 0;
            if (_currentBannerIndex < 0) _currentBannerIndex = _bannerFiles.Count - 1;

            string path = GetSmartImagePath(_bannerFiles[_currentBannerIndex]);
            if (!string.IsNullOrEmpty(path)) pbBanner.ImageLocation = path;
        }

        private void LoadSuggestedProducts()
        {
            flpRecommendedProducts.Controls.Clear();
            flpRecommendedProducts.WrapContents = true;
            flpRecommendedProducts.Width = 980;
            flpRecommendedProducts.Padding = new Padding(55, 10, 0, 20);

            string imgPro1 = GetSmartImagePath(@"Resources\product1.jpg");

            var products = new List<ProductDTO>
            {
                new ProductDTO { ProductId = 1, Name = "Áo khoác denim thời trang", Price = 450000, OldPrice = 550000, Rating = 4.8, SoldQuantity = 1234, ImagePath = imgPro1 },
                new ProductDTO { ProductId = 2, Name = "Điện thoại thông minh", Price = 8500000, OldPrice = 0, Rating = 4.9, SoldQuantity = 567, ImagePath = "" },
                new ProductDTO { ProductId = 3, Name = "Bàn làm việc gỗ cao cấp", Price = 2500000, OldPrice = 3000000, Rating = 4.7, SoldQuantity = 234, ImagePath = "" },
                new ProductDTO { ProductId = 4, Name = "Bộ mỹ phẩm dưỡng da", Price = 890000, OldPrice = 990000, Rating = 4.6, SoldQuantity = 890, ImagePath = "" },
            };

            foreach (var product in products)
            {
                UcProductItem item = new UcProductItem(product);
                flpRecommendedProducts.Controls.Add(item);
            }
        }

        // --- [CẬP NHẬT] LOAD CATEGORIES VỚI LINK ẢNH WEB ---
        private void LoadCategories()
        {
            flpCategories.Controls.Clear();
            flpCategories.WrapContents = false;
            flpCategories.AutoScroll = true;

            // Danh sách bao gồm Tên, Màu nền và Link Icon Online
            var categories = new[]
            {
                new { Name = "Thời trang", Color = Color.FromArgb(255, 235, 238), Url = "https://cf.shopee.vn/file/687f3967b7c2fe6a134a2c11894eea4b_tn" },
                new { Name = "Điện tử",   Color = Color.FromArgb(227, 242, 253), Url = "https://cf.shopee.vn/file/978b9e4cb61c611aaaf58664fae133c5_tn" },
                new { Name = "Làm đẹp",   Color = Color.FromArgb(252, 228, 236), Url = "https://cf.shopee.vn/file/ef1f336ecc6f97b790d5aae9916dcb72_tn" }, // <--- Icon Mỹ phẩm/Làm đẹp
                new { Name = "Nhà cửa",   Color = Color.FromArgb(255, 243, 224), Url = "https://cf.shopee.vn/file/24b194a695ea59d38476955b64255d18_tn" },
                new { Name = "Thể thao",  Color = Color.FromArgb(232, 245, 233), Url = "https://cf.shopee.vn/file/6cb7e633f8b63757463b676bd19a50e4_tn" },
                new { Name = "Đồ ăn",     Color = Color.FromArgb(255, 253, 231), Url = "https://cf.shopee.vn/file/b0f78c3136d2d78d49af71dd1c3f38c1_tn" },
                new { Name = "Sách",      Color = Color.FromArgb(243, 229, 245), Url = "https://cf.shopee.vn/file/36013311815c55d303b0e6c62d6a8139_tn" },
                new { Name = "Khác",      Color = Color.FromArgb(224, 247, 250), Url = "https://cf.shopee.vn/file/76c0c3368207337734cc2473630493d0_tn" }
            };

            foreach (var cat in categories)
            {
                // Tải ảnh từ URL
                Image iconImg = LoadImageFromUrl(cat.Url);

                // Tạo Item với ảnh vừa tải
                UcCategoryItem item = new UcCategoryItem(cat.Name, cat.Color, iconImg);
                flpCategories.Controls.Add(item);
            }
        }
    }
}