using System;
using System.Drawing;
using System.Globalization;
using System.Linq; // Cần thiết để tính tổng
using System.Windows.Forms;
using Guna.UI2.WinForms;

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

            // Đăng ký sự kiện click cho các nút chính
            btnShopNow.Click += (s, e) => { MessageBox.Show("Chuyển hướng về Trang chủ..."); };
            btnCheckout.Click += (s, e) => { MessageBox.Show("Tiến hành thanh toán..."); };

            // Tải dữ liệu giả lập ban đầu
            LoadDummyData();
        }

        /// <summary>
        /// Hàm giả lập tải dữ liệu giỏ hàng
        /// </summary>
        public void LoadDummyData()
        {
            // Xóa dữ liệu cũ
            flpCartItems.Controls.Clear();

            // Giả lập: Kiểm tra nếu muốn test giỏ hàng trống thì comment dòng for bên dưới lại
            bool hasItem = true;

            if (hasItem)
            {
                ShowCartData();

                // Thêm sản phẩm mẫu
                AddCartItem(1, "Áo khoác denim thời trang nam nữ unisex", 450000, 1, "https://cf.shopee.vn/file/5c48983458307d95651950f3b8a27d6c");
                AddCartItem(2, "Giày thể thao Nike Air Force 1", 1200000, 2, "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e6da41fa-1be4-4ce5-b89c-22be4f1f02d6/air-force-1-07-shoes-WrLlWX.png");
                AddCartItem(3, "Quần Jean ống rộng phong cách Hàn Quốc", 350000, 1, "https://cf.shopee.vn/file/sg-11134201-22100-0j1g4k3h3liv64");

                // Cập nhật tổng tiền lần đầu
                UpdateSummary();
            }
            else
            {
                ShowEmptyCart();
            }
        }

        /// <summary>
        /// Hiển thị giao diện giỏ hàng có dữ liệu
        /// </summary>
        private void ShowCartData()
        {
            pnlEmptyCart.Visible = false;
            pnlCartData.Visible = true;
            pnlCartData.BringToFront();
        }

        /// <summary>
        /// Hiển thị giao diện giỏ hàng trống
        /// </summary>
        private void ShowEmptyCart()
        {
            pnlCartData.Visible = false;
            pnlEmptyCart.Visible = true;
            pnlEmptyCart.BringToFront();
            // Căn giữa Panel Empty trong Form
            pnlEmptyCart.Location = new Point(
                (this.Width - pnlEmptyCart.Width) / 2,
                (this.Height - pnlEmptyCart.Height) / 2
            );
        }

        /// <summary>
        /// Hàm vẽ một dòng sản phẩm (Row) trong giỏ hàng
        /// </summary>
        private void AddCartItem(int id, string name, decimal price, int qty, string imgUrl)
        {
            // 1. Panel chứa (Row)
            Guna2Panel pnlItem = new Guna2Panel();
            pnlItem.Size = new Size(840, 110); // Chiều rộng bằng Header (840), Cao 110
            pnlItem.BackColor = Color.White;

            // --- TẠO VIỀN ĐẸP ---
            pnlItem.BorderColor = Color.FromArgb(235, 235, 235); // Màu xám rất nhạt
            pnlItem.BorderThickness = 1;
            pnlItem.BorderRadius = 3; // Bo góc nhẹ
            pnlItem.Margin = new Padding(0, 0, 0, 10); // Cách dòng dưới 10px

            // Hiệu ứng khi rê chuột vào sản phẩm (Hover)
            pnlItem.UseTransparentBackground = true;

            // 2. Ảnh sản phẩm (Cột 1 - Left: 20)
            Guna2PictureBox pic = new Guna2PictureBox();
            pic.Size = new Size(70, 70);
            pic.Location = new Point(20, 20);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BorderRadius = 3; // Bo góc ảnh
            if (!string.IsNullOrEmpty(imgUrl)) pic.ImageLocation = imgUrl;
            else pic.FillColor = Color.WhiteSmoke;

            // 3. Tên sản phẩm (Bên cạnh ảnh)
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Location = new Point(110, 20);
            lblName.Size = new Size(200, 50);
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblName.ForeColor = Color.FromArgb(50, 50, 50);
            lblName.AutoEllipsis = true;

            // 4. Đơn giá (Cột 2 - Left: 320)
            Label lblPrice = new Label();
            lblPrice.Text = price.ToString("N0", VNCulture) + "₫";
            lblPrice.Location = new Point(320, 45);
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPrice.ForeColor = Color.Gray;

            // 5. Bộ chỉnh số lượng (Cột 3 - Left: 450)
            Guna2Button btnMinus = CreateQtyButton("-", 450, 40);

            Label lblQty = new Label();
            lblQty.Text = qty.ToString();
            lblQty.Location = new Point(480, 40);
            lblQty.Size = new Size(40, 30);
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            lblQty.Font = new Font("Segoe UI", 10);
            // Tạo viền cho ô số lượng bằng Label Border (nếu Label thường hỗ trợ) hoặc dùng Panel lót
            lblQty.BackColor = Color.WhiteSmoke;

            Guna2Button btnPlus = CreateQtyButton("+", 520, 40);

            // 6. Thành tiền (Cột 4 - Left: 600)
            Label lblTotalItem = new Label();
            decimal totalItem = price * qty;
            lblTotalItem.Text = totalItem.ToString("N0", VNCulture) + "₫";
            lblTotalItem.Location = new Point(600, 45);
            lblTotalItem.AutoSize = true;
            lblTotalItem.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTotalItem.ForeColor = PrimaryColor;
            lblTotalItem.Tag = totalItem;

            // 7. Nút Xóa (Cột 5 - Left: 740)
            Guna2Button btnDel = new Guna2Button();
            btnDel.Text = "Xóa";
            btnDel.FillColor = Color.White;
            btnDel.ForeColor = Color.Black;
            btnDel.HoverState.FillColor = Color.FromArgb(255, 240, 240); // Màu nền đỏ nhạt khi hover
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

            // --- LOGIC ---
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

            // Add Controls
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

        /// <summary>
        /// Hàm tính toán lại tổng tiền đơn hàng
        /// </summary>
        private void UpdateSummary()
        {
            decimal subTotal = 0;

            // Duyệt qua tất cả các item trong FlowLayoutPanel
            foreach (Control control in flpCartItems.Controls)
            {
                if (control is Guna2Panel pnl)
                {
                    // Tìm Label thành tiền (lblTotalItem) - Cách tìm theo Index hoặc Type
                    // Ở trên ta add lblTotalItem ở vị trí index thứ 6 (pic, name, price, minus, qty, plus, TOTAL, del)
                    // Tuy nhiên tìm theo Tag an toàn hơn
                    foreach (Control c in pnl.Controls)
                    {
                        if (c is Label && c.Tag != null) // Chỉ lblTotalItem có Tag chứa decimal
                        {
                            subTotal += (decimal)c.Tag;
                        }
                    }
                }
            }

            decimal shipping = subTotal > 0 ? 30000 : 0; // Phí ship cố định 30k nếu có hàng
            decimal grandTotal = subTotal + shipping;

            // Cập nhật UI Summary
            lblSubtotal.Text = $"Tổng tiền hàng: {subTotal.ToString("N0", VNCulture)}₫";
            lblShippingFee.Text = $"Phí vận chuyển: {shipping.ToString("N0", VNCulture)}₫";
            lblTotalAmount.Text = $"{grandTotal.ToString("N0", VNCulture)}₫";
        }

        // Helper tạo nút +/-
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