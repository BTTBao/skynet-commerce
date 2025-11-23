using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.BLL.Models; // Sử dụng ProductDTO
using Skynet_Commerce.GUI.UserControls.Components; // Cần cho các controls khác

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FrmMain : Form
    {
        // Dictionary để lưu trữ các UserControl đã được khởi tạo
        private Dictionary<string, UserControl> pageCache;
        // Giả định pnlContent đã được khai báo trong Designer
        // private Panel pnlContent; 

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
        /// <param name="pageName">Tên trang cần tải (Home, Orders, Cart, ShopDetail, ProductDetail...)</param>
        /// <param name="data">Dữ liệu đi kèm (ProductDTO hoặc ShopID)</param>
        public void LoadPage(string pageName, object data = null)
        {
            UserControl targetPage = null;

            // Tên trang chi tiết sẽ là PageName_ID để phân biệt (Dùng cho caching)
            string cacheKey = pageName;
            int entityId = 0; // Dùng để xác định ProductID hoặc ShopID

            // Xử lý key cache và ID từ dữ liệu đầu vào
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
            else if (pageName == "ShopDetail" && data is ProductDTO shopProduct)
            {
                // Giả định ProductDTO có thuộc tính ShopId
                // entityId = shopProduct.ShopId; 
                entityId = 1; // Dùng ShopID giả lập
                cacheKey = $"ShopDetail_{entityId}";
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
                        if (data is ProductDTO pd)
                        {
                            targetPage = new UcProductDetail(pd); // Sử dụng constructor nhận DTO
                        }
                        break;
                    case "ShopDetail":
                        // Cần có Shop ID để tải dữ liệu
                        if (entityId != 0)
                        {
                            UcShopDetail shopPage = new UcShopDetail();
                            shopPage.LoadShopData(entityId); // Gọi hàm tải dữ liệu shop
                            targetPage = shopPage;
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
                    pageCache.Add(cacheKey, targetPage);

                    // Thêm vào Controls lần đầu
                    // *Chú ý: Nếu pnlContent là FlowLayoutPanel hoặc TableLayoutPanel, 
                    // cách quản lý Controls sẽ khác một chút.*
                    pnlContent.Controls.Add(targetPage);
                }
            }

            // 3. Hiển thị trang
            if (targetPage != null)
            {
                // Ẩn tất cả các controls cũ
                foreach (Control uc in pnlContent.Controls)
                {
                    uc.Visible = false;
                }

                // Hiển thị targetPage
                targetPage.Visible = true;
                targetPage.BringToFront();

                // 4. Cập nhật tiêu đề Form
                string title = pageName;
                if (pageName == "ProductDetail" && data is ProductDTO pdTitle)
                    title = pdTitle.Name;
                else if (pageName == "ShopDetail")
                    title = $"Shop ID {entityId}"; // Cần cập nhật Title sau khi UcShopDetail.LoadShopData chạy

                this.Text = $"ShopViet - {title}";
            }

            // 5. Cập nhật trạng thái Active của Menu (Chỉ Home/Orders)
            UpdateMenuState(pageName);
        }

        // ... Hàm UpdateMenuState giữ nguyên ...
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
    }
}