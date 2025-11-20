using System;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Pages;
using Skynet_Commerce.BLL.Models; // Quan trọng: Đã đổi tên thành ProductDTO

namespace Skynet_Commerce.GUI.UserControls.Components
{
    public partial class UcProductItem : UserControl
    {
        private int _productId;
        private ProductDTO _productData; // <<< THÊM: Trường để lưu trữ toàn bộ dữ liệu sản phẩm

        // -------------------------------------------------------------
        // I. CONSTRUCTORS
        // -------------------------------------------------------------

        // Constructor mặc định (dùng cho Designer)
        public UcProductItem()
        {
            InitializeComponent();
            SetupCardEvents(); // Thiết lập sự kiện click/hover
        }

        /// <summary>
        /// Constructor chính nhận đối tượng ProductDTO
        /// </summary>
        /// <param name="productData">Đối tượng ProductDTO chứa dữ liệu sản phẩm.</param>
        public UcProductItem(ProductDTO productData) : this()
        {
            this._productData = productData; // <<< CẬP NHẬT: Lưu trữ DTO
            LoadProductData(productData);
        }

        // -------------------------------------------------------------
        // II. LOGIC HIỂN THỊ DỮ LIỆU
        // -------------------------------------------------------------

        private void LoadProductData(ProductDTO data)
        {
            this._productId = data.ProductId;

            // Tên sản phẩm
            lblProductName.Text = data.Name;

            // Giá hiện tại
            lblPrice.Text = $"{data.Price:N0}₫";

            // Giá cũ 
            if (data.OldPrice.HasValue && data.DiscountPercent > 0)
            {
                lblOldPrice.Text = $"{data.OldPrice.Value:N0}₫";
                lblOldPrice.Visible = true;
            }
            else
            {
                lblOldPrice.Visible = false;
            }

            // Rating và Sold
            if (data.Rating.HasValue)
            {
                // Hiển thị Rating với biểu tượng ngôi sao
                lblRating.Text = $"★ {data.Rating.Value:N1}"; // Ví dụ: ★ 4.8
                lblSold.Text = $"| Đã bán {data.SoldQuantity:N0}"; // Format số lượng đã bán
            }
            else
            {
                lblRating.Visible = false;
                lblSold.Visible = false;
            }

            // Hình ảnh
            if (data.Image != null)
            {
                pbProductImage.Image = data.Image;
            }
            else if (!string.IsNullOrEmpty(data.ImagePath) && System.IO.File.Exists(data.ImagePath))
            {
                pbProductImage.ImageLocation = data.ImagePath;
            }
        }

        // -------------------------------------------------------------
        // III. XỬ LÝ SỰ KIỆN CLICK (Mở trang chi tiết)
        // -------------------------------------------------------------

        private void SetupCardEvents()
        {
            // Xử lý sự kiện click trên toàn bộ card
            this.Click += UcProductItem_Click;
            pnlCard.Click += UcProductItem_Click;
            // Đảm bảo các controls con cũng kích hoạt sự kiện này
            foreach (Control control in pnlCard.Controls)
            {
                control.Click += UcProductItem_Click;
            }
        }

        private void UcProductItem_Click(object sender, EventArgs e)
        {
            // Logic khi click: Mở trang chi tiết sản phẩm

            // 1. Tìm Form chính (FrmMain)
            FrmMain mainForm = this.FindForm() as FrmMain;

            // 2. Gọi hàm LoadPage bằng DTO
            if (mainForm != null && _productData != null)
            {
                // CẬP NHẬT: Chỉ cần truyền tên trang "ProductDetail" và đối tượng DTO.
                // Logic tạo key caching đã được xử lý trong FrmMain.LoadPage
                mainForm.LoadPage("ProductDetail", _productData);
            }
        }
    }
}