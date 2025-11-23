using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms; // Cần thiết để gọi FrmMain

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCartPage : UserControl
    {
        // --- CẤU HÌNH MÀU SẮC & FORMAT ---
        private Color PrimaryColor = Color.FromArgb(238, 77, 45); // Cam Shopee
        private CultureInfo VNCulture = new CultureInfo("vi-VN");

        public UcCartPage()
        {
            InitializeComponent();

            // --- ĐĂNG KÝ SỰ KIỆN ---

            // Nút "Mua ngay" (khi giỏ hàng trống) -> Quay về trang chủ
            btnShopNow.Click += (s, e) =>
            {
                FrmMain main = this.FindForm() as FrmMain;
                if (main != null) main.LoadPage("Home");
            };

            // [CẬP NHẬT] Nút "Mua Hàng" -> Chuyển sang trang Thanh Toán (Checkout)
            btnCheckout.Click += (s, e) =>
            {
                FrmMain main = this.FindForm() as FrmMain;

                // Kiểm tra giỏ hàng có trống không trước khi chuyển
                if (flpCartItems.Controls.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng đang trống, vui lòng chọn sản phẩm!", "Thông báo");
                    return;
                }

                if (main != null)
                {
                    main.LoadPage("Checkout");
                }
            };

            // Tải dữ liệu giả lập ban đầu
            LoadDummyData();
        }

        /// <summary>
        /// Hàm giả lập tải dữ liệu giỏ hàng
        /// </summary>
        public void LoadDummyData()
        {
            flpCartItems.Controls.Clear();

            // Giả lập: Kiểm tra nếu muốn test giỏ hàng trống thì comment dòng for bên dưới lại
            bool hasItem = true;

            if (hasItem)
            {
                ShowCartData();

                AddCartItem(1, "Áo khoác denim thời trang nam nữ unisex", 450000, 1, "https://cf.shopee.vn/file/5c48983458307d95651950f3b8a27d6c");
                AddCartItem(2, "Giày thể thao Nike Air Force 1", 1200000, 2, "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e6da41fa-1be4-4ce5-b89c-22be4f1f02d6/air-force-1-07-shoes-WrLlWX.png");
                AddCartItem(3, "Quần Jean ống rộng phong cách Hàn Quốc", 350000, 1, "https://cf.shopee.vn/file/sg-11134201-22100-0j1g4k3h3liv64");

                UpdateSummary();
            }
            else
            {
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
            pnlEmptyCart.Location = new Point(
                (this.Width - pnlEmptyCart.Width) / 2,
                (this.Height - pnlEmptyCart.Height) / 2
            );
        }

        private void AddCartItem(int id, string name, decimal price, int qty, string imgUrl)
        {
            Guna2Panel pnlItem = new Guna2Panel();
            pnlItem.Size = new Size(840, 110);
            pnlItem.BackColor = Color.White;
            pnlItem.BorderColor = Color.FromArgb(235, 235, 235);
            pnlItem.BorderThickness = 1;
            pnlItem.BorderRadius = 3;
            pnlItem.Margin = new Padding(0, 0, 0, 10);
            pnlItem.UseTransparentBackground = true;

            // Ảnh sản phẩm
            Guna2PictureBox pic = new Guna2PictureBox();
            pic.Size = new Size(70, 70);
            pic.Location = new Point(20, 20);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BorderRadius = 3;
            if (!string.IsNullOrEmpty(imgUrl)) pic.ImageLocation = imgUrl;
            else pic.FillColor = Color.WhiteSmoke;

            // Tên sản phẩm
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(110, 20);
            lblName.Size = new Size(200, 50);
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblName.ForeColor = Color.FromArgb(50, 50, 50);
            lblName.AutoEllipsis = true;

            // Đơn giá
            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("N0", VNCulture) + "₫";
            lblPrice.Location = new Point(320, 45);
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPrice.ForeColor = Color.Gray;

            // Bộ chỉnh số lượng
            Guna2Button btnMinus = CreateQtyButton("-", 450, 40);

            Label lblQty = new Label();
            lblQty.Text = qty.ToString();
            lblQty.Location = new Point(480, 40);
            lblQty.Size = new Size(40, 30);
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            lblQty.Font = new Font("Segoe UI", 10);
            lblQty.BackColor = Color.WhiteSmoke;

            Guna2Button btnPlus = CreateQtyButton("+", 520, 40);

            // Thành tiền
            Label lblTotalItem = new Label();
            decimal totalItem = price * qty;
            lblTotalItem.Text = totalItem.ToString("N0", VNCulture) + "₫";
            lblTotalItem.Location = new Point(600, 45);
            lblTotalItem.AutoSize = true;
            lblTotalItem.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTotalItem.ForeColor = PrimaryColor;
            lblTotalItem.Tag = totalItem;

            // Nút Xóa
            Guna2Button btnDel = new Guna2Button();
            btnDel.Text = "Xóa";
            btnDel.FillColor = Color.White;
            btnDel.ForeColor = Color.Black;
            btnDel.HoverState.FillColor = Color.FromArgb(255, 240, 240);
            btnDel.HoverState.ForeColor = PrimaryColor;
            btnDel.Font = new Font("Segoe UI", 9);
            btnDel.Location = new Point(740, 40);
            btnDel.Size = new Size(60, 30);
            btnDel.BorderRadius = 3;
            btnDel.Cursor = Cursors.Hand;

            btnDel.Click += (s, e) =>
            {
                flpCartItems.Controls.Remove(pnlItem);
                UpdateSummary();
                if (flpCartItems.Controls.Count == 0) ShowEmptyCart();
            };

            // Logic Tăng/Giảm số lượng
            btnMinus.Click += (s, e) =>
            {
                int currentQty = int.Parse(lblQty.Text);
                if (currentQty > 1)
                {
                    currentQty--;
                    lblQty.Text = currentQty.ToString();
                    decimal newTotal = currentQty * price;
                    lblTotalItem.Text = newTotal.ToString("N0", VNCulture) + "₫";
                    lblTotalItem.Tag = newTotal;
                    UpdateSummary();
                }
            };

            btnPlus.Click += (s, e) =>
            {
                int currentQty = int.Parse(lblQty.Text);
                currentQty++;
                lblQty.Text = currentQty.ToString();
                decimal newTotal = currentQty * price;
                lblTotalItem.Text = newTotal.ToString("N0", VNCulture) + "₫";
                lblTotalItem.Tag = newTotal;
                UpdateSummary();
            };

            // Add Controls vào Panel Item
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
            decimal subTotal = 0;

            foreach (Control control in flpCartItems.Controls)
            {
                if (control is Guna2Panel pnl)
                {
                    foreach (Control c in pnl.Controls)
                    {
                        if (c is Label && c.Tag != null)
                        {
                            subTotal += (decimal)c.Tag;
                        }
                    }
                }
            }

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