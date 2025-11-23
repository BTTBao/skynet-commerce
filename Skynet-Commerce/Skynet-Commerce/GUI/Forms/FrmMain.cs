using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.General;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.Forms.User; // Sử dụng ProductDTO

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        // Dictionary để lưu trữ các UserControl đã được khởi tạo
        private Dictionary<string, UserControl> pageCache;
        // Đã xóa bỏ khai báo thừa 'private ProductDTO _productData;'

        // Màu sắc để highlight link menu
        private Color ActiveColor = Color.White;
        private Color InactiveColor = Color.FromArgb(220, 220, 220); // Màu xám nhạt

        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;

            // Khởi tạo Dictionary và gán sự kiện cho Menu
            pageCache = new Dictionary<string, UserControl>();
            SetupMenuEvents();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Tải trang chủ mặc định khi Form Load
            LoadPage("Home");
        }

        /// <summary>
        /// Gán các sự kiện click cho các Label menu.
        /// </summary>
        private void SetupMenuEvents()
        {
            lblHome.Click += (sender, e) => LoadPage("Home");
            lblOrders.Click += (sender, e) => LoadPage("Orders");
            btnCart.Click += (sender, e) => LoadPage("Cart"); // Thêm sự kiện cho nút Giỏ hàng
        }

        /// <summary>
        /// Tải UserControl tương ứng vào pnlContent.
        /// </summary>
        /// <param name="pageName">Tên trang cần tải (Home, Orders, Cart...)</param>
        public void LoadPage(string pageName, ProductDTO productData = null)
        {
            UserControl targetPage = null;

            // Tên trang chi tiết sẽ là PageName_ProductID để phân biệt (Dùng cho caching)
            string cacheKey = pageName;
            if (productData != null)
            {
                cacheKey = $"Detail_{productData.ProductId}";
            }

            // 1. Kiểm tra trong Cache
            if (pageCache.ContainsKey(cacheKey))
            {
                targetPage = pageCache[cacheKey];
            }
            else
            {
                // 2. Khởi tạo trang mới
                switch (pageName)
                {
                    case "Home":
                        targetPage = new UcHomePage();
                        break;
                    case "Cart":
                        targetPage = new UcCartPage();
                        break;
                    case "ProductDetail":
                        if (productData != null)
                        {
                            targetPage = new UcProductDetail(productData); // Sử dụng constructor nhận DTO
                        }
                        else
                        {
                            targetPage = new UcHomePage(); // Trường hợp lỗi DTO, chuyển về Home
                        }
                        break;
                    case "Orders":
                        // Giả định bạn có UcOrderPage
                        // targetPage = new UcOrderPage();
                        targetPage = new UcHomePage(); // Dùng tạm
                        break;
                    default:
                        return;
                }

                // Cài đặt thuộc tính cơ bản và lưu vào cache
                if (targetPage != null)
                {
                    targetPage.Dock = DockStyle.Fill;
                    pageCache.Add(cacheKey, targetPage); // Lưu vào cache với key mới
                    pnlContent.Controls.Add(targetPage);
                }
            }

            // 3. Hiển thị trang
            if (targetPage != null)
            {
                // Ẩn tất cả các controls cũ
                foreach (UserControl uc in pnlContent.Controls)
                {
                    uc.Visible = false;
                }

                // Hiển thị targetPage
                targetPage.Visible = true;
                targetPage.BringToFront();

                // Cập nhật tiêu đề Form
                this.Text = $"ShopViet - {(productData != null ? productData.Name : pageName)}";
            }

            // 4. Cập nhật trạng thái Active của Menu (Chỉ Home/Orders)
            UpdateMenuState(pageName);
        }

        private void UpdateMenuState(string activePage)
        {
            // Đặt lại font style và màu sắc cho tất cả các Label menu
            lblHome.Font = new Font(lblHome.Font, FontStyle.Regular);
            lblOrders.Font = new Font(lblOrders.Font, FontStyle.Regular);
            lblHome.ForeColor = InactiveColor;
            lblOrders.ForeColor = InactiveColor;

            Label activeLabel = null;
            if (activePage == "Home")
            {
                activeLabel = lblHome;
            }
            else if (activePage == "Orders")
            {
                activeLabel = lblOrders;
            }

            // Highlight Label đang active
            if (activeLabel != null)
            {
                activeLabel.Font = new Font(activeLabel.Font, FontStyle.Bold);
                activeLabel.ForeColor = ActiveColor;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Authentication a = new Authentication();
            a.ShowLogin();
        }
    }
}