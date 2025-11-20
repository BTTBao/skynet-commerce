using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCartPage : UserControl
    {
        private List<ProductDTO> CurrentCartItems;

        // ----------------------------------------------------------------------
        // I. KHỞI TẠO
        // ----------------------------------------------------------------------

        private List<ProductDTO> GetInitialSampleItems(bool isEmpty)
        {
            if (isEmpty) return new List<ProductDTO>();

            return new List<ProductDTO>
            {
                new ProductDTO { ProductId = 1, Name = "Áo khoác denim thời trang", Price = 450000, InitialQuantity = 1, ImagePath = @"img\product1.jpg" },
                new ProductDTO { ProductId = 2, Name = "Điện thoại thông minh (Màu đen)", Price = 8500000, InitialQuantity = 2, ImagePath = @"img\product1.jpg" }, // Đổi ảnh nếu cần
                new ProductDTO { ProductId = 3, Name = "Giày thể thao nam A8", Price = 1200000, InitialQuantity = 1, ImagePath = @"img\product1.jpg" }
            };
        }

        public UcCartPage()
        {
            InitializeComponent();
            SetupEventHandlers();
            this.Load += UcCartPage_Load;

            // Thay đổi false thành true để test giao diện giỏ hàng trống
            CurrentCartItems = GetInitialSampleItems(false);
        }

        private void UcCartPage_Load(object sender, EventArgs e)
        {
            LoadCartItems(CurrentCartItems);
            UpdateCartSummary();
        }

        private void SetupEventHandlers()
        {
            btnContinueShopping.Click += BtnContinueShopping_Click;
            // Nếu nút này nằm trong pnlSummary (giao diện mới), hãy đảm bảo tên biến đúng
            if (this.btnContinueShoppingSummary != null)
                this.btnContinueShoppingSummary.Click += BtnContinueShopping_Click;

            this.btnCheckout.Click += BtnCheckout_Click;
        }

        // ----------------------------------------------------------------------
        // II. LOGIC TẢI DATA
        // ----------------------------------------------------------------------

        private void LoadCartItems(List<ProductDTO> cartData)
        {
            flpCartItems.Controls.Clear();

            if (cartData == null || !cartData.Any())
            {
                CurrentCartItems = new List<ProductDTO>();
                ToggleCartView();
                return;
            }

            foreach (var itemData in cartData)
            {
                // Sử dụng Constructor đầy đủ (bao gồm ImagePath)
                UcCartItem item = new UcCartItem(
                    itemData.ProductId,
                    itemData.Name,
                    itemData.Price,
                    itemData.InitialQuantity,
                    itemData.Image,
                    itemData.ImagePath
                );

                // Thiết lập layout cho item trong FlowLayoutPanel
                item.Width = flpCartItems.Width - 25; // Trừ thanh cuộn
                item.Height = 110; // Chiều cao cố định (khớp với thiết kế UcCartItem)
                item.Margin = new Padding(0, 0, 0, 10);
                // Không dùng Dock=Top nếu đã set Width cụ thể để tránh lỗi layout khi resize
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                // Gán sự kiện
                item.ItemDataChanged += item_ItemDataChanged;
                item.ItemRemoved += item_ItemRemoved;

                flpCartItems.Controls.Add(item);
            }

            ToggleCartView();
        }

        // ----------------------------------------------------------------------
        // III. XỬ LÝ SỰ KIỆN TỪ ITEM
        // ----------------------------------------------------------------------

        private void item_ItemDataChanged(object sender, EventArgs e)
        {
            UpdateCartSummary();
        }

        private void item_ItemRemoved(object sender, EventArgs e)
        {
            UcCartItem item = sender as UcCartItem;
            if (item != null)
            {
                flpCartItems.Controls.Remove(item);
                item.Dispose();
                UpdateCartSummary();
            }
        }

        // ----------------------------------------------------------------------
        // IV. TÍNH TOÁN VÀ HIỂN THỊ
        // ----------------------------------------------------------------------

        private void UpdateCartSummary()
        {
            var cartItems = flpCartItems.Controls.OfType<UcCartItem>();

            // Tính tổng tiền (Chỉ tính các item được chọn - nếu đã cài đặt CheckBox)
            // Nếu chưa có CheckBox logic, tính tổng tất cả
            decimal subtotal = cartItems.Where(i => i.IsSelected).Sum(item => item.TotalPrice);

            decimal shippingFee = (subtotal > 0) ? 30000 : 0; // Phí ship mẫu
            decimal totalAmount = subtotal + shippingFee;

            lblSubtotal.Text = $"Tạm tính: {subtotal:N0}₫";
            lblShippingFee.Text = $"Phí vận chuyển: {shippingFee:N0}₫";
            lblTotalAmount.Text = $"{totalAmount:N0}₫"; // Không cần chữ "Tổng tiền:" vì label tiêu đề đã có hoặc thiết kế yêu cầu

            ToggleCartView();
        }

        private void ToggleCartView()
        {
            bool isEmpty = flpCartItems.Controls.Count == 0;

            // 1. Hiển thị/Ẩn màn hình Giỏ hàng trống
            if (pnlEmptyCart != null) pnlEmptyCart.Visible = isEmpty;

            // 2. Hiển thị/Ẩn giao diện danh sách (Giao diện chia 2 cột mới)
            if (pnlLeftContainer != null) pnlLeftContainer.Visible = !isEmpty;
            if (pnlSummary != null) pnlSummary.Visible = !isEmpty;

            if (isEmpty && pnlEmptyCart != null)
            {
                pnlEmptyCart.BringToFront();
            }
        }

        // ----------------------------------------------------------------------
        // V. NAVIGATE
        // ----------------------------------------------------------------------

        private void BtnContinueShopping_Click(object sender, EventArgs e)
        {
            FrmMain mainForm = this.FindForm() as FrmMain;
            if (mainForm != null)
            {
                mainForm.LoadPage("Home");
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (flpCartItems.Controls.Count > 0)
            {
                MessageBox.Show("Đã chuyển đến trang Thanh toán.", "Thông báo");
            }
        }
    }
}