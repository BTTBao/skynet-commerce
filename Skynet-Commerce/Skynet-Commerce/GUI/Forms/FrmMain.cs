using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms.User;
using Skynet_Commerce.GUI.UserControls.Components;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.GUI.UserControls.Pages.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

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
            this.pnlContent.Resize += PnlContent_Resize;

            SetupMenuEvents();
        }

        private void PnlContent_Resize(object sender, EventArgs e)
        {
            if (pnlContent.Controls.Count > 0)
            {
                var currentCtrl = pnlContent.Controls[0];
                if (currentCtrl is UcLogin || currentCtrl is UcRegister)
                {
                    CenterControl(currentCtrl);
                }
            }
        }

        private void CenterControl(Control ctrl)
        {
            ctrl.Location = new Point(
                (pnlContent.Width - ctrl.Width) / 2,
                (pnlContent.Height - ctrl.Height) / 2
            );
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UpdateLoginState();
            LoadPage("Home");
            LoadHeaderIconsAsync();
        }

        public void UpdateLoginState()
        {
            if (AppSession.Instance.IsLoggedIn)
            {
                string displayName = AppSession.Instance.FullName;
                if (string.IsNullOrEmpty(displayName)) displayName = "Tài khoản";
                if (lblLogin != null) lblLogin.Text = displayName;
            }
            else
            {
                if (lblLogin != null) lblLogin.Text = "Đăng nhập";
            }
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

            // Các nút liên quan đến Profile
            btnAccount.Click += (sender, e) => LoadPage("Profile");
            lblLogin.Click += (sender, e) => LoadPage("Profile");

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

        // --- HÀM NÀY ĐÃ ĐƯỢC CẬP NHẬT ---
        public void LoadPage(string pageName, object data = null)
        {
            try
            {
                if (pnlContent == null) return;
                if (pageCache == null) pageCache = new Dictionary<string, UserControl>();

                UserControl targetPage = null;
                string cacheKey = pageName;
                int entityId = 0;

                // [MỚI] 1. Xử lý logic RIÊNG cho Profile:
                // Nếu gọi Profile -> Luôn xóa Cache để ép chương trình kiểm tra lại Session
                if (pageName == "Profile")
                {
                    // Xóa cache cũ để fetch lại dữ liệu mới nhất
                    if (pageCache.ContainsKey("Profile")) pageCache.Remove("Profile");

                    // Kiểm tra đăng nhập ngay tại đây để điều hướng đúng
                    if (!AppSession.Instance.IsLoggedIn)
                    {
                        // Chưa đăng nhập -> Chuyển hướng sang Login
                        pageName = "Login";
                        data = "Profile"; // Truyền tham số để login xong quay lại Profile
                        cacheKey = "Login"; // Đổi key cache
                    }
                }

                // 2. Xử lý Key Cache đặc biệt cho các trang chi tiết
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

                // 3. Tìm trong Cache hoặc Tạo mới
                if (pageCache.ContainsKey(cacheKey))
                {
                    targetPage = pageCache[cacheKey];

                    // Refresh dữ liệu cho Giỏ hàng (vì giỏ hàng thay đổi liên tục)
                    if (targetPage is UcCartPage cartPage) cartPage.LoadCartData();
                }
                else
                {
                    switch (pageName)
                    {
                        // --- CÁC TRANG CHÍNH ---
                        case "Home":
                            targetPage = new UcHomePage();
                            break;
                        case "Cart":
                            targetPage = new UcCartPage();
                            break;
                        case "Checkout":
                            targetPage = new UcCheckoutPage();
                            break;

                        // --- TRANG PROFILE (Đã được xử lý logic ở bước 1) ---
                        case "Profile":
                            // Tại đây chắc chắn đã đăng nhập (vì nếu chưa thì pageName đã đổi thành Login)
                            // Tạo mới UcProfile -> Nó sẽ chạy constructor -> chạy OnLoad -> Fetch DB
                            targetPage = new UcProfile(this);
                            break;

                        // --- AUTHENTICATION ---
                        case "Login":
                            string nextLinkLogin = data as string;
                            targetPage = new UcLogin(this, nextLinkLogin);
                            break;
                        case "Register":
                            string nextLinkReg = data as string;
                            targetPage = new UcRegister(this, nextLinkReg);
                            break;

                        // --- CHI TIẾT ---
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

                        // --- CÁC TRANG USER CON ---
                        case "Orders":
                            targetPage = new UcOrderHistory(this);
                            break;
                        case "ChangePassword":
                            targetPage = new UcChangePassword(this);
                            break;
                        case "Address":
                            targetPage = new UcUserAddress(this);
                            break;
                        case "EditProfile":
                            targetPage = new UcEditProfile(this);
                            break;
                        case "ShopRegister":
                            targetPage = new UcShopRegister(this);
                            break;

                        default:
                            return;
                    }

                    // Lưu Cache (Trừ Login/Register để tránh lỗi trạng thái)
                    // Lưu ý: Profile vẫn có thể lưu cache cho phiên làm việc đó, 
                    // nhưng ở bước 1 ta đã chủ động remove nếu người dùng bấm lại vào menu Profile.
                    if (targetPage != null && pageName != "Login" && pageName != "Register")
                    {
                        targetPage.Dock = DockStyle.Fill;
                        pageCache.Add(cacheKey, targetPage);
                    }
                }

                // 4. Hiển thị trang
                if (targetPage != null)
                {
                    foreach (Control c in pnlContent.Controls) c.Visible = false;

                    if (!pnlContent.Controls.Contains(targetPage))
                    {
                        pnlContent.Controls.Add(targetPage);
                    }

                    targetPage.Visible = true;
                    targetPage.BringToFront();

                    // Căn giữa Login/Register
                    if (pageName == "Login" || pageName == "Register")
                    {
                        targetPage.Dock = DockStyle.None;
                        targetPage.Anchor = AnchorStyles.None;
                        CenterControl(targetPage);
                    }
                    else
                    {
                        targetPage.Dock = DockStyle.Fill;
                    }

                    // Cập nhật tiêu đề Form
                    string title = pageName;
                    if (pageName == "Search") title = $"Tìm kiếm: {data}";
                    else if (pageName == "ProductDetail" && data is ProductDTO pd) title = pd.Name;
                    else if (pageName == "Profile") title = "Hồ sơ của tôi";
                    else if (pageName == "Checkout") title = "Thanh toán";

                    this.Text = $"ShopViet - {title}";
                }

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