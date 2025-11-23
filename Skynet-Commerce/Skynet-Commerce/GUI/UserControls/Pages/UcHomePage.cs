using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.BLL.Services; // [ĐÃ SỬA] Bỏ chữ .User đi

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcHomePage : UserControl
    {
        // [QUAN TRỌNG] PHẢI KHAI BÁO BIẾN NÀY Ở ĐÂY ĐỂ KHÔNG BỊ LỖI
        private ProductService _productService;

        // Danh sách Banner
        private List<string> _bannerFiles = new List<string>
        {
            @"Resources\slide1.jpg", @"Resources\slide2.jpg", @"Resources\slide3.jpg"
        };
        private int _currentBannerIndex = 0;

        public UcHomePage()
        {
            InitializeComponent();

            // [QUAN TRỌNG] KHỞI TẠO BIẾN SERVICE
            _productService = new ProductService();

            this.Load += UcHomePage_Load;
            this.pnlScrollContainer.Resize += pnlScrollContainer_Resize;

            // Banner
            LoadBanners();
            tmrBannerSlide.Interval = 3000;
            tmrBannerSlide.Tick += (s, e) => ChangeBanner(1);
            tmrBannerSlide.Start();
            btnNextBanner.Click += (s, e) => { tmrBannerSlide.Stop(); ChangeBanner(1); tmrBannerSlide.Start(); };
            btnPrevBanner.Click += (s, e) => { tmrBannerSlide.Stop(); ChangeBanner(-1); tmrBannerSlide.Start(); };

            // Danh mục
            LoadCategories();

            // Tải dữ liệu thật từ SQL
            LoadSuggestedProducts();
        }

        // --- HÀM TẢI SẢN PHẨM TỪ SQL ---
        private void LoadSuggestedProducts()
        {
            flpRecommendedProducts.Controls.Clear();
            flpRecommendedProducts.WrapContents = true;
            flpRecommendedProducts.Width = 980;
            flpRecommendedProducts.Padding = new Padding(55, 10, 0, 20);

            try
            {
                // Gọi Service lấy 4 sản phẩm mới nhất
                List<ProductDTO> products = _productService.GetSuggestedProducts(4);

                if (products == null || products.Count == 0)
                {
                    Label lbl = new Label { Text = "Chưa có sản phẩm nào.", AutoSize = true, Margin = new Padding(50) };
                    flpRecommendedProducts.Controls.Add(lbl);
                    return;
                }

                foreach (var product in products)
                {
                    // Xử lý ảnh local
                    if (!string.IsNullOrEmpty(product.ImagePath) && !product.ImagePath.StartsWith("http"))
                        product.ImagePath = GetSmartImagePath(product.ImagePath);

                    // Tạo Item
                    UcProductItem item = new UcProductItem(product);

                    // Add vào giao diện
                    flpRecommendedProducts.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        // --- CÁC HÀM HỖ TRỢ (GIỮ NGUYÊN) ---
        private string GetSmartImagePath(string relativePath)
        {
            string[] possibleBaseDirs = new string[] { Application.StartupPath, Directory.GetParent(Application.StartupPath).Parent.FullName, @"C:\BTL123\skynet-commerce\Skynet-Commerce\Skynet-Commerce" };
            foreach (var baseDir in possibleBaseDirs) { try { string fullPath = Path.Combine(baseDir, relativePath); if (File.Exists(fullPath)) return fullPath; } catch { } }
            return "";
        }

        private Image LoadImageFromUrl(string url)
        {
            try { if (string.IsNullOrEmpty(url)) return null; using (WebClient client = new WebClient()) { byte[] imageBytes = client.DownloadData(url); using (MemoryStream ms = new MemoryStream(imageBytes)) { return Image.FromStream(ms); } } } catch { return null; }
        }

        private void UcHomePage_Load(object sender, EventArgs e) { CenterSections(); }
        private void pnlScrollContainer_Resize(object sender, EventArgs e) { CenterSections(); }

        private void CenterSections()
        {
            int contentWidth = 920;
            if (this.pnlScrollContainer.Width > contentWidth) { int x = (this.pnlScrollContainer.Width - contentWidth) / 2; this.flpSections.Left = x; this.flpSections.Width = contentWidth; }
            else { this.flpSections.Left = 0; this.flpSections.Width = this.pnlScrollContainer.Width; }
        }

        private void LoadBanners()
        {
            if (_bannerFiles.Count > 0) { pbBanner.SizeMode = PictureBoxSizeMode.StretchImage; string path = GetSmartImagePath(_bannerFiles[0]); if (!string.IsNullOrEmpty(path)) pbBanner.ImageLocation = path; }
        }

        private void ChangeBanner(int step)
        {
            _currentBannerIndex += step;
            if (_currentBannerIndex >= _bannerFiles.Count) _currentBannerIndex = 0;
            if (_currentBannerIndex < 0) _currentBannerIndex = _bannerFiles.Count - 1;
            string path = GetSmartImagePath(_bannerFiles[_currentBannerIndex]);
            if (!string.IsNullOrEmpty(path)) pbBanner.ImageLocation = path;
        }

        private void LoadCategories()
        {
            flpCategories.Controls.Clear(); flpCategories.WrapContents = false; flpCategories.AutoScroll = true;
            var categories = new[] {
                new { Name = "Thời trang", Color = Color.FromArgb(255, 235, 238), Url = "https://cf.shopee.vn/file/687f3967b7c2fe6a134a2c11894eea4b_tn" },
                new { Name = "Điện tử", Color = Color.FromArgb(227, 242, 253), Url = "https://cf.shopee.vn/file/978b9e4cb61c611aaaf58664fae133c5_tn" },
                new { Name = "Làm đẹp", Color = Color.FromArgb(252, 228, 236), Url = "https://cf.shopee.vn/file/ef1f336ecc6f97b790d5aae9916dcb72_tn" },
                new { Name = "Nhà cửa", Color = Color.FromArgb(255, 243, 224), Url = "https://cf.shopee.vn/file/24b194a695ea59d38476955b64255d18_tn" },
                new { Name = "Thể thao", Color = Color.FromArgb(232, 245, 233), Url = "https://cf.shopee.vn/file/6cb7e633f8b63757463b676bd19a50e4_tn" },
                new { Name = "Đồ ăn", Color = Color.FromArgb(255, 253, 231), Url = "https://cf.shopee.vn/file/b0f78c3136d2d78d49af71dd1c3f38c1_tn" },
                new { Name = "Sách", Color = Color.FromArgb(243, 229, 245), Url = "https://cf.shopee.vn/file/36013311815c55d303b0e6c62d6a8139_tn" },
                new { Name = "Khác", Color = Color.FromArgb(224, 247, 250), Url = "https://cf.shopee.vn/file/76c0c3368207337734cc2473630493d0_tn" }
            };
            foreach (var cat in categories) { Image iconImg = LoadImageFromUrl(cat.Url); UcCategoryItem item = new UcCategoryItem(cat.Name, cat.Color, iconImg); flpCategories.Controls.Add(item); }
        }
    }
}