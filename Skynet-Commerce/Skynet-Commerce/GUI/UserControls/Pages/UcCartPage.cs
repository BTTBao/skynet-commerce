using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.BLL.Helpers; // [QUAN TRỌNG] Để gọi SessionManager

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCartPage : UserControl
    {
        // Cấu hình hiển thị tiền tệ Việt Nam
        private CultureInfo VNCulture = new CultureInfo("vi-VN");
        private Color PrimaryColor = Color.FromArgb(238, 77, 45); // Màu cam Shopee

        public UcCartPage()
        {
            InitializeComponent();

            // --- 1. SỰ KIỆN NÚT "MUA NGAY" (KHI GIỎ TRỐNG) ---
            btnShopNow.Click += (s, e) =>
            {
                GoToPage("Home");
            };

            // --- 2. SỰ KIỆN NÚT "MUA HÀNG" (THANH TOÁN) ---
            btnCheckout.Click += (s, e) =>
            {
                // A. Kiểm tra giỏ hàng trống
                if (flpCartItems.Controls.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng của bạn đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // B. [QUAN TRỌNG] Kiểm tra Đăng nhập
                if (SessionManager.CurrentUser == null)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn cần đăng nhập để tiếp tục thanh toán.\nChuyển đến trang đăng nhập ngay?",
                        "Yêu cầu đăng nhập",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Chuyển sang trang Login và dặn nó: "Login xong thì quay lại Checkout nhé"
                        GoToPage("Login", "Checkout");
                    }
                    return; // Dừng lại, không vào Checkout
                }

                // C. Đã đăng nhập + Có hàng -> Vào Checkout
                GoToPage("Checkout");
            };

            // --- 3. TỰ ĐỘNG TẢI LẠI KHI TRANG HIỆN LÊN ---
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible) LoadCartData();
            };

            // Load lần đầu
            LoadCartData();
        }

        // Hàm hỗ trợ chuyển trang an toàn
        private void GoToPage(string pageName, object data = null)
        {
            FrmMain main = this.FindForm() as FrmMain;
            if (main != null)
            {
                main.LoadPage(pageName, data);
            }
        }

        // --- HÀM TẢI DỮ LIỆU TỪ SESSION ---
        public void LoadCartData()
        {
            flpCartItems.Controls.Clear();
            var items = SessionManager.CartItems;

            // Kiểm tra danh sách sản phẩm
            if (items != null && items.Count > 0)
            {
                // CÓ SẢN PHẨM -> HIỆN DANH SÁCH
                ShowCartData();

                foreach (var item in items)
                {
                    // Fix lỗi hiển thị giá = 0 (nếu có)
                    decimal displayPrice = item.Price > 0 ? item.Price : 0;

                    AddCartItem(item.ProductId, item.ProductName, displayPrice, item.Quantity, item.ImageUrl);
                }
                UpdateSummary();
            }
            else
            {
                // KHÔNG CÓ SẢN PHẨM -> HIỆN MÀN HÌNH TRỐNG
                ShowEmptyCart();
            }
        }

        private void ShowCartData()
        {
            pnlEmptyCart.Visible = false;
            pnlCartData.Visible = true;
            pnlCartData.BringToFront();
        }

        private void ShowEmptyCart()
        {
            pnlCartData.Visible = false;
            pnlEmptyCart.Visible = true;
            pnlEmptyCart.BringToFront();

            // Căn giữa màn hình
            if (this.Width > 0 && this.Height > 0)
            {
                pnlEmptyCart.Location = new Point(
                    (this.Width - pnlEmptyCart.Width) / 2,
                    (this.Height - pnlEmptyCart.Height) / 2
                );
            }
        }

        // --- HÀM VẼ GIAO DIỆN TỪNG SẢN PHẨM ---
        private void AddCartItem(int id, string name, decimal price, int qty, string imgUrl)
        {
            Guna2Panel pnlItem = new Guna2Panel();
            pnlItem.Size = new Size(840, 110);
            pnlItem.BackColor = Color.White;
            pnlItem.BorderColor = Color.FromArgb(235, 235, 235);
            pnlItem.BorderThickness = 1;
            pnlItem.BorderRadius = 3;
            pnlItem.Margin = new Padding(0, 0, 0, 10);

            // Ảnh sản phẩm
            Guna2PictureBox pic = new Guna2PictureBox();
            pic.Size = new Size(70, 70);
            pic.Location = new Point(20, 20);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BorderRadius = 3;
            if (!string.IsNullOrEmpty(imgUrl))
            {
                if (imgUrl.StartsWith("http")) pic.ImageLocation = imgUrl;
                else if (System.IO.File.Exists(imgUrl)) pic.ImageLocation = imgUrl;
                else pic.FillColor = Color.WhiteSmoke;
            }
            else pic.FillColor = Color.WhiteSmoke;

            // Tên sản phẩm
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(110, 20);
            lblName.Size = new Size(200, 50);
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblName.AutoEllipsis = true;

            // Đơn giá
            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("N0", VNCulture) + "₫";
            lblPrice.Location = new Point(320, 45);
            lblPrice.AutoSize = true;
            lblPrice.ForeColor = Color.Gray;

            // Nút Giảm
            Guna2Button btnMinus = CreateQtyButton("-", 450, 40);

            // Số lượng
            Label lblQty = new Label();
            lblQty.Text = qty.ToString();
            lblQty.Location = new Point(480, 40);
            lblQty.Size = new Size(40, 30);
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            lblQty.BackColor = Color.WhiteSmoke;

            // Nút Tăng
            Guna2Button btnPlus = CreateQtyButton("+", 520, 40);

            // Thành tiền
            Label lblTotalItem = new Label();
            decimal totalItem = price * qty;
            lblTotalItem.Text = totalItem.ToString("N0", VNCulture) + "₫";
            lblTotalItem.Location = new Point(600, 45);
            lblTotalItem.AutoSize = true;
            lblTotalItem.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTotalItem.ForeColor = PrimaryColor;
            lblTotalItem.Tag = totalItem; // Lưu giá trị số để tính tổng sau này

            // Nút Xóa
            Guna2Button btnDel = new Guna2Button();
            btnDel.Text = "Xóa";
            btnDel.FillColor = Color.White;
            btnDel.ForeColor = Color.Black;
            btnDel.BorderThickness = 1;
            btnDel.BorderColor = Color.Silver;
            btnDel.Location = new Point(740, 40);
            btnDel.Size = new Size(60, 30);
            btnDel.Cursor = Cursors.Hand;

            // --- SỰ KIỆN NÚT CON ---
            btnDel.Click += (s, e) =>
            {
                SessionManager.RemoveFromCart(id);
                LoadCartData(); // Vẽ lại toàn bộ để cập nhật
            };

            btnMinus.Click += (s, e) =>
            {
                int q = int.Parse(lblQty.Text);
                if (q > 1)
                {
                    // Giảm số lượng (-1)
                    SessionManager.AddToCart(new Skynet_Commerce.BLL.Models.ProductDTO { ProductId = id }, -1);
                    LoadCartData();
                }
            };

            btnPlus.Click += (s, e) =>
            {
                // Tăng số lượng (+1)
                SessionManager.AddToCart(new Skynet_Commerce.BLL.Models.ProductDTO { ProductId = id }, 1);
                LoadCartData();
            };

            // Add controls vào Panel
            pnlItem.Controls.Add(pic);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblPrice);
            pnlItem.Controls.Add(btnMinus);
            pnlItem.Controls.Add(lblQty);
            pnlItem.Controls.Add(btnPlus);
            pnlItem.Controls.Add(lblTotalItem);
            pnlItem.Controls.Add(btnDel);

            flpCartItems.Controls.Add(pnlItem);
        }

        private void UpdateSummary()
        {
            decimal subTotal = SessionManager.GetTotalAmount();
            decimal shipping = subTotal > 0 ? 30000 : 0;
            decimal grandTotal = subTotal + shipping;

            lblSubtotal.Text = $"Tổng tiền hàng: {subTotal.ToString("N0", VNCulture)}₫";
            lblShippingFee.Text = $"Phí vận chuyển: {shipping.ToString("N0", VNCulture)}₫";
            lblTotalAmount.Text = $"{grandTotal.ToString("N0", VNCulture)}₫";
        }

        private Guna2Button CreateQtyButton(string text, int x, int y)
        {
            Guna2Button btn = new Guna2Button();
            btn.Text = text;
            btn.FillColor = Color.White;
            btn.BorderColor = Color.Silver;
            btn.BorderThickness = 1;
            btn.ForeColor = Color.Black;
            btn.Location = new Point(x, y);
            btn.Size = new Size(30, 30);
            btn.Cursor = Cursors.Hand;
            return btn;
        }
    }
}