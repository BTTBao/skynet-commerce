using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.UserControls.Components;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        // Cache để lưu các trang đã mở (tránh new lại nhiều lần)
        private Dictionary<string, UserControl> pageCache;

        // Màu sắc menu
        private Color ActiveColor = Color.White;
        private Color InactiveColor = Color.FromArgb(220, 220, 220);

        public FrmMain()
        {
            InitializeComponent();

            // 1. Khởi tạo Cache
            pageCache = new Dictionary<string, UserControl>();

            this.Load += FrmMain_Load;
            SetupMenuEvents();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadPage("Home");
            LoadHeaderIconsAsync();
        }

        private async void LoadHeaderIconsAsync()
        {
            try
            {
                string urlAccount = "https://encrypted-tbn0.gstatic.com/licensed-image?q=tbn:ANd9GcSR2eevKwdaJI3fmx_crf4K-v4Nwp2lBBuX4nOpmIWxDgtrGS5lKCG5VmQfySftR49-jQmuoGXdFQlWpbJWgMSZNeb9vjGbf3a98TdQP40_iWtHyMI";
                string urlCart = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1T7upN8AoHCJ5aBH6QEFO_ryc2FNbm60uKA&s";
                string urlSearch = "https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcQzoLSBkRjyDSEDu8ja6kPTYjysvWpCShlRZOU-LUkgTe_Vj7_wJIGjvP-B6miRuodC8iqOpU6tj4FImP2JerBKe0qtqs4pp6H6SOdiy9UCYQeCQio";

                Image imgAccount = await System.Threading.Tasks.Task.Run(() => LoadImageFromUrl(urlAccount));
                Image imgCart = await System.Threading.Tasks.Task.Run(() => LoadImageFromUrl(urlCart));
                Image imgSearch = await System.Threading.Tasks.Task.Run(() => LoadImageFromUrl(urlSearch));

                if (btnAccount != null && imgAccount != null) btnAccount.Image = imgAccount;
                if (btnCart != null && imgCart != null) btnCart.Image = imgCart;
                if (btnSearch != null && imgSearch != null) btnSearch.Image = imgSearch;
            }
            catch { }
        }

        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] imageBytes = client.DownloadData(url);
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(Image.FromStream(stream));
                    }
                }
            }
            catch { return null; }
        }

        private void SetupMenuEvents()
        {
            lblHome.Click += (sender, e) => LoadPage("Home");
            lblOrders.Click += (sender, e) => LoadPage("Orders");
            btnCart.Click += (sender, e) => LoadPage("Cart");

            // Vào trang Profile
            btnAccount.Click += (sender, e) => LoadPage("Profile");
            lblLogin.Click += (sender, e) => LoadPage("Profile");

            // Tìm kiếm
            btnSearch.Click += (sender, e) => PerformSearch();
            txtSearch.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PerformSearch();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                // Với trang Search, ta luôn muốn mới nhất nên xóa cache cũ đi
                string cacheKey = $"Search_{keyword}";
                if (pageCache.ContainsKey(cacheKey)) pageCache.Remove(cacheKey);

                LoadPage("Search", keyword);
            }
        }

        // =======================================================================
        // HÀM LOADPAGE HOÀN CHỈNH (CÓ REFRESH GIỎ HÀNG)
        // =======================================================================
        public void LoadPage(string pageName, object data = null)
        {
            try
            {
                if (pnlContent == null) return;
                if (pageCache == null) pageCache = new Dictionary<string, UserControl>();

                UserControl targetPage = null;
                string cacheKey = pageName;
                int entityId = 0;

                // --- 1. TẠO CACHE KEY DỰA TRÊN DỮ LIỆU ---
                if (pageName == "ProductDetail" && data is ProductDTO productData)
                {
                    entityId = productData.ProductId;
                    cacheKey = $"ProductDetail_{entityId}";
                }
                else if (pageName == "ShopDetail" && data is int shopId)
                {
                    entityId = shopId;
                    cacheKey = $"ShopDetail_{entityId}";
                }
                else if (pageName == "Search" && data is string keyword)
                {
                    cacheKey = $"Search_{keyword}";
                }

                // --- 2. KIỂM TRA CACHE HOẶC TẠO MỚI ---
                if (pageCache.ContainsKey(cacheKey))
                {
                    // Lấy từ bộ nhớ đệm
                    targetPage = pageCache[cacheKey];

                    // [CỰC KỲ QUAN TRỌNG]
                    // Nếu là trang Giỏ hàng, phải bắt nó tải lại dữ liệu từ SessionManager
                    // Vì giỏ hàng có thể thay đổi ở trang khác
                    if (targetPage is UcCartPage cartPage)
                    {
                        cartPage.LoadCartData();
                    }
                }
                else
                {
                    // Tạo mới nếu chưa có
                    switch (pageName)
                    {
                        case "Home":
                            targetPage = new UcHomePage();
                            break;
                        case "Cart":
                            targetPage = new UcCartPage();
                            break;
                        case "Checkout":
                            targetPage = new UcCheckoutPage();
                            break;
                        case "Profile":
                            targetPage = new UcProfile();
                            break;
                        case "Search":
                            string kw = data as string ?? "";
                            targetPage = new UcSearchResult(kw);
                            break;
                        case "ProductDetail":
                            if (data is ProductDTO pd) targetPage = new UcProductDetail(pd);
                            break;
                        case "ShopDetail":
                            if (entityId != 0)
                            {
                                UcShopDetail shopPage = new UcShopDetail();
                                shopPage.LoadShopData(entityId);
                                targetPage = shopPage;
                            }
                            break;
                        case "Orders":
                            targetPage = new UcHomePage(); // Demo (chưa có UcOrders)
                            break;
                        default:
                            return;
                    }

                    // Lưu vào Cache
                    if (targetPage != null)
                    {
                        targetPage.Dock = DockStyle.Fill;
                        pageCache.Add(cacheKey, targetPage);
                    }
                }

                // --- 3. HIỂN THỊ TRANG ---
                if (targetPage != null)
                {
                    // Thêm vào Panel nếu chưa có
                    if (!pnlContent.Controls.Contains(targetPage))
                    {
                        pnlContent.Controls.Add(targetPage);
                    }

                    // Đưa lên trên cùng
                    targetPage.Visible = true;
                    targetPage.BringToFront();

                    // Cập nhật tiêu đề cửa sổ
                    string title = pageName;
                    if (pageName == "Search") title = $"Tìm kiếm: {data}";
                    else if (pageName == "ProductDetail" && data is ProductDTO pd) title = pd.Name;
                    else if (pageName == "Profile") title = "Hồ sơ của tôi";
                    else if (pageName == "Checkout") title = "Thanh toán";
                    else if (pageName == "Cart") title = "Giỏ hàng";

                    this.Text = $"ShopViet - {title}";
                }

                // --- 4. CẬP NHẬT MENU ---
                UpdateMenuState(pageName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải trang '{pageName}':\n{ex.Message}");
            }
        }

        private void UpdateMenuState(string activePage)
        {
            if (lblHome == null || lblOrders == null) return;

            lblHome.Font = new Font(lblHome.Font, FontStyle.Regular);
            lblOrders.Font = new Font(lblOrders.Font, FontStyle.Regular);
            lblHome.ForeColor = InactiveColor;
            lblOrders.ForeColor = InactiveColor;

            lblLogin.Font = new Font(lblLogin.Font, FontStyle.Regular);
            lblLogin.ForeColor = InactiveColor;

            if (activePage == "Home") { lblHome.Font = new Font(lblHome.Font, FontStyle.Bold); lblHome.ForeColor = ActiveColor; }
            else if (activePage == "Orders") { lblOrders.Font = new Font(lblOrders.Font, FontStyle.Bold); lblOrders.ForeColor = ActiveColor; }
            else if (activePage == "Profile") { lblLogin.Font = new Font(lblLogin.Font, FontStyle.Bold); lblLogin.ForeColor = ActiveColor; }
        }
    }
}