using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities; // Sử dụng ProductDTO
using Skynet_Commerce.GUI.Forms.User;
//using Skynet_Commerce.GUI.UserControls.General;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.GUI.UserControls.Pages.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Skynet_Commerce.GUI.UserControls.Components;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        private Dictionary<string, UserControl> pageCache;
        private Color ActiveColor = Color.White;
        private Color InactiveColor = Color.FromArgb(220, 220, 220);

        public FrmMain()
        {
            InitializeComponent();
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

            // Sự kiện bấm vào icon Account hoặc chữ Tài khoản -> Vào trang Profile

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
                string cacheKey = $"Search_{keyword}";
                if (pageCache.ContainsKey(cacheKey)) pageCache.Remove(cacheKey);
                LoadPage("Search", keyword);
            }
        }

        // --- HÀM LOADPAGE ĐÃ ĐƯỢC MERGE HOÀN CHỈNH ---
        public void LoadPage(string pageName, object data = null)
        {
            try
            {
                if (pnlContent == null) return;
                if (pageCache == null) pageCache = new Dictionary<string, UserControl>();

                UserControl targetPage = null;
                string cacheKey = pageName;
                int entityId = 0;

                // 1. Xử lý Key Cache để phân biệt các trang chi tiết
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

                // 2. Kiểm tra Cache
                if (pageCache.ContainsKey(cacheKey))
                {
                    targetPage = pageCache[cacheKey];
                }
                else
                {
                    // 3. Khởi tạo trang mới nếu chưa có
                    switch (pageName)
                    {
                        case "Home":
                            targetPage = new UcHomePage();
                            break;
                        case "Cart":
                            targetPage = new UcCartPage();
                            break;
                        
                        // --- Các trang User/Account (Mới thêm từ pthuan) ---
                        case "Profile":
                            targetPage = new UcProfile(this);
                            break;
                        case "Address":
                            targetPage = new UcUserAddress(this);
                            break;
                        case "ShopRegister":
                            targetPage = new UcShopRegister(this);
                            break;
                        case "EditProfile":
                            targetPage = new UcEditProfile(this);
                            break;
                        case "ChangePassword":
                            targetPage = new UcChangePassword(this);
                            break;
                        case "Order":
                        case "Orders":
                            targetPage = new UcOrderHistory(this);
                            break;

                        // --- Các trang Chi tiết & Tìm kiếm ---
                        case "Search":
                            string kw = data as string ?? "";
                            targetPage = new UcSearchResult(kw);
                            break;
                        case "ProductDetail":
                            if (data is ProductDTO pd) targetPage = new UcProductDetail(pd);
                            else targetPage = new UcHomePage(); // Fallback nếu lỗi data
                            break;
                        case "ShopDetail":
                            if (entityId != 0)
                            {
                                UcShopDetail shopPage = new UcShopDetail();
                                shopPage.LoadShopData(entityId);
                                targetPage = shopPage;
                            }
                            break;
                        
                        default:
                            return;
                    }

                    // Lưu vào Cache
                    if (targetPage != null)
                    {
                        // Tắt AutoSize để tránh lỗi hiển thị
                        targetPage.AutoSize = false; 
                        pageCache[cacheKey] = targetPage;
                        
                        // Thêm vào Panel nếu chưa có (để sẵn sàng hiển thị)
                        if (!pnlContent.Controls.Contains(targetPage))
                        {
                            pnlContent.Controls.Add(targetPage);
                        }
                    }
                }

                // 4. Hiển thị trang
                if (targetPage != null)
                {
                    // Ẩn tất cả các trang khác đi
                    foreach (Control c in pnlContent.Controls)
                    {
                        c.Visible = false;
                    }

                    // Hiển thị trang mục tiêu
                    targetPage.Dock = DockStyle.Fill;
                    targetPage.Visible = true;
                    targetPage.BringToFront();

                    // Cập nhật tiêu đề Form
                    string title = pageName;
                    if (pageName == "Search") title = $"Tìm kiếm: {data}";
                    else if (pageName == "ProductDetail" && data is ProductDTO pd) title = pd.Name;
                    else if (pageName == "Profile") title = "Hồ sơ của tôi";
                    
                    this.Text = $"ShopViet - {title}";
                }

                // 5. Cập nhật trạng thái Menu
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

            // Highlight Label Tài Khoản nếu đang ở trang Profile
            lblLogin.Font = new Font(lblLogin.Font, FontStyle.Regular);
            lblLogin.ForeColor = InactiveColor;

            if (activePage == "Home") { lblHome.Font = new Font(lblHome.Font, FontStyle.Bold); lblHome.ForeColor = ActiveColor; }
            else if (activePage == "Orders" || activePage == "Order") { lblOrders.Font = new Font(lblOrders.Font, FontStyle.Bold); lblOrders.ForeColor = ActiveColor; }
            else if (activePage == "Profile") { lblLogin.Font = new Font(lblLogin.Font, FontStyle.Bold); lblLogin.ForeColor = ActiveColor; }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (AppSession.Instance.IsLoggedIn)
            {
                LoadPage("Profile");
            }
            else
            {
                Authentication a = new Authentication();
                a.ShowLogin();
                // this.Hide(); // Tùy chọn: Ẩn form chính khi hiện form login
            }
        }
    }
}