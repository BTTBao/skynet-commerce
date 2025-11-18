using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCartPage : UserControl
    {
        // Dữ liệu giỏ hàng
        private List<CartItemDTO> _cart;
        private const decimal SHIPPING_FEE = 30000m; // Phí vận chuyển

        // Cần có Panel chứa nội dung chính (từ Designer)
        private Panel pnlContent;

        // Khai báo các Label/Button
        private Label lblSubtotalValue;
        private Label lblShippingValue;
        private Label lblTotalValue;
        private Panel pnlCartItemsContainer;
        private FlowLayoutPanel flpMainLayout;

        public UcCartPage()
        {
            InitializeComponent();

            _cart = GetDummyCartData();

            LoadMainLayout();
            RenderCartPage();
        }

        // --- BỐ CỤC CHUNG ---
        private void LoadMainLayout()
        {
            flpMainLayout = new FlowLayoutPanel();
            flpMainLayout.AutoScroll = false;
            flpMainLayout.FlowDirection = FlowDirection.LeftToRight;
            flpMainLayout.Size = new Size(1100, 700);
            flpMainLayout.Margin = new Padding(30, 20, 30, 20);
            flpMainLayout.BackColor = Color.LightYellow; // DEBUG COLOR

            Control[] pnlContentArray = this.Controls.Find("pnlContent", true);
            if (pnlContentArray.Length > 0 && pnlContentArray[0] is Panel mainContainer)
            {
                mainContainer.Controls.Add(flpMainLayout);
                mainContainer.AutoScroll = true;
            }
            else
            {
                this.Controls.Add(flpMainLayout);
                this.AutoScroll = true;
                flpMainLayout.Dock = DockStyle.Fill;
            }
        }

        private void RenderCartPage()
        {
            flpMainLayout.Controls.Clear();

            if (_cart.Count == 0)
            {
                flpMainLayout.Controls.Add(CreateEmptyCartView());
            }
            else
            {
                Control cartItemsView = CreateCartItemsView(_cart);
                cartItemsView.Size = new Size(700, 650);
                flpMainLayout.Controls.Add(cartItemsView);

                Control summaryView = CreateOrderSummaryView();
                summaryView.Size = new Size(350, 400);
                summaryView.Margin = new Padding(30, 0, 0, 0);
                flpMainLayout.Controls.Add(summaryView);
            }

            UpdateSummaryCalculation();
        }
        private Control CreateEmptyCartView()
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(1100, 500);
            pnl.BackColor = Color.White;

            // Tạo Label hiển thị thông báo
            Label lbl = new Label();
            lbl.Text = "🛒 Giỏ hàng trống. Bạn chưa thêm sản phẩm nào vào giỏ hàng.";
            lbl.Font = new Font("Arial", 16, FontStyle.Regular);
            lbl.Location = new Point(250, 200); // Căn giữa giả định
            lbl.AutoSize = true;

            pnl.Controls.Add(lbl);

            // Tùy chọn: Thêm nút "Tiếp tục mua sắm"
            Button btnShop = new Button();
            btnShop.Text = "Tiếp tục mua sắm";
            btnShop.Size = new Size(200, 40);
            btnShop.Location = new Point(450, 250);
            btnShop.BackColor = Color.FromArgb(255, 87, 34);
            btnShop.ForeColor = Color.White;
            btnShop.Click += (s, e) => FrmMain.Instance.LoadUserControl(new UcHomePage());
            pnl.Controls.Add(btnShop);

            return pnl;
        }

        // --- CỘT 1: HIỂN THỊ SẢN PHẨM ---
        private Control CreateCartItemsView(List<CartItemDTO> cart)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(700, 650);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitle = new Label();
            lblTitle.Text = "Giỏ hàng của bạn";
            lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);
            pnl.Controls.Add(lblTitle);

            // Khung chứa tiêu đề cột
            Panel pnlHeader = new Panel();
            pnlHeader.Size = new Size(680, 30);
            pnlHeader.Location = new Point(10, 50);
            pnlHeader.BackColor = Color.LightGray;

            // Labels tiêu đề cột (Đã tinh chỉnh vị trí cho Checkbox)
            Label lblProduct = new Label { Text = "Sản phẩm", Location = new Point(40, 5), AutoSize = true };
            Label lblPrice = new Label { Text = "Đơn giá", Location = new Point(380, 5), AutoSize = true };
            Label lblQuantity = new Label { Text = "Số lượng", Location = new Point(480, 5), AutoSize = true };
            Label lblTotal = new Label { Text = "Thành tiền", Location = new Point(580, 5), AutoSize = true, TextAlign = ContentAlignment.MiddleRight };

            pnlHeader.Controls.AddRange(new Control[] { lblProduct, lblPrice, lblQuantity, lblTotal });
            pnl.Controls.Add(pnlHeader);

            pnlCartItemsContainer = new Panel();
            pnlCartItemsContainer.Location = new Point(10, 85);
            pnlCartItemsContainer.Size = new Size(680, 550);
            pnlCartItemsContainer.AutoScroll = true;
            pnl.Controls.Add(pnlCartItemsContainer);

            RenderCartItems();

            return pnl;
        }

        private void RenderCartItems()
        {
            pnlCartItemsContainer.Controls.Clear();
            int currentY = 0;

            foreach (var item in _cart)
            {
                Panel itemPanel = CreateCartItemPanel(item, currentY);
                pnlCartItemsContainer.Controls.Add(itemPanel);
                currentY += itemPanel.Height + 1;
            }

            UpdateSummaryCalculation();
        }

        private Panel CreateCartItemPanel(CartItemDTO item, int yPosition)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(680, 90);
            pnl.Location = new Point(0, yPosition);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // --- CẤU TRÚC COLUMN (Theo thứ tự) ---

            // 1. CHECKBOX MỚI
            CheckBox chkSelect = new CheckBox();
            chkSelect.Checked = item.IsSelected;
            chkSelect.Location = new Point(10, 35);
            chkSelect.AutoSize = true;
            chkSelect.CheckedChanged += (s, e) => HandleItemSelection(item.Id, chkSelect.Checked);
            pnl.Controls.Add(chkSelect);

            // 2. Ảnh & Tên & Variant (col-span-6)
            // TẠM THỜI: Chỉ dùng label cho tên (bạn có thể thay bằng PictureBox nếu muốn)
            Label lblName = new Label();
            lblName.Text = item.Name + Environment.NewLine + item.Variant;
            lblName.Location = new Point(40, 35);
            lblName.Size = new Size(300, 40);
            pnl.Controls.Add(lblName);

            // 3. Đơn giá (col-span-2)
            Label lblPrice = new Label();
            lblPrice.Text = item.Price.ToString("N0") + "đ";
            lblPrice.Location = new Point(380, 35);
            pnl.Controls.Add(lblPrice);

            // 4. Số lượng (col-span-2)
            Panel pnlQuantity = CreateQuantityControl(item);
            pnlQuantity.Location = new Point(480, 30);
            pnl.Controls.Add(pnlQuantity);

            // 5. Thành tiền (col-span-2)
            Label lblTotal = new Label();
            lblTotal.Text = item.Subtotal.ToString("N0") + "đ";
            lblTotal.ForeColor = Color.FromArgb(255, 87, 34);
            lblTotal.Location = new Point(580, 35);
            pnl.Controls.Add(lblTotal);

            // 6. NÚT XÓA (Trash Button)
            Button btnRemove = new Button();
            
            btnRemove.Size = new Size(30, 30);
            btnRemove.Location = new Point(640, 30); // Đặt gần mép phải (680 - 40)
            btnRemove.BackColor = Color.White;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.FlatAppearance.BorderSize = 0; // Xóa viền cho đẹp

            try
            {
                // Tải ảnh từ thư mục img (Giả sử bạn có icon tên là 'trash.png' hoặc tương tự)
                string iconPath = System.IO.Path.Combine(Application.StartupPath, @"img\trash.png");
                if (System.IO.File.Exists(iconPath))
                {
                    btnRemove.Image = Image.FromFile(iconPath);
                }
                else
                {
                    btnRemove.Text = "X"; // Nếu không tìm thấy icon, fallback về chữ X
                }
            }
            catch { btnRemove.Text = "X"; } // Bắt lỗi nếu file ảnh lỗi

            // Gán sự kiện gọi hàm xóa
            btnRemove.Click += (s, e) => RemoveItemFromCart(item.Id);
            pnl.Controls.Add(btnRemove);
            return pnl;
        }

        // Hàm xử lý Checkbox (MỚI)
        private void HandleItemSelection(string itemId, bool isChecked)
        {
            var item = _cart.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.IsSelected = isChecked;
                UpdateSummaryCalculation(); // Chỉ cần update Summary là đủ
            }
        }

        // Hàm tạo Control Số lượng (Giữ nguyên)
        private Panel CreateQuantityControl(CartItemDTO item)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(100, 30);
            pnl.BorderStyle = BorderStyle.FixedSingle;

            TextBox txtQuantity = new TextBox();
            txtQuantity.Text = item.Quantity.ToString();
            txtQuantity.Size = new Size(30, 30);
            txtQuantity.Location = new Point(30, 0);
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.ReadOnly = true;
            pnl.Controls.Add(txtQuantity);

            Button btnMinus = new Button();
            btnMinus.Text = "-";
            btnMinus.Size = new Size(30, 30);
            btnMinus.Click += (s, e) => UpdateCartQuantity(item.Id, item.Quantity - 1);
            pnl.Controls.Add(btnMinus);

            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Size = new Size(30, 30);
            btnPlus.Location = new Point(60, 0);
            btnPlus.Click += (s, e) => UpdateCartQuantity(item.Id, item.Quantity + 1);
            pnl.Controls.Add(btnPlus);

            return pnl;
        }

        // --- CỘT 2: TÓM TẮT ĐƠN HÀNG ---
        private Control CreateOrderSummaryView()
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(350, 400);
            pnl.BackColor = Color.White;
            pnl.BorderStyle = BorderStyle.FixedSingle;

            // Labels tiêu đề và giá trị (Code đã được cung cấp ở bước trước)

            // Tiêu đề
            Label lblSummaryTitle = new Label { Text = "Tóm tắt đơn hàng", Font = new Font("Arial", 12, FontStyle.Bold), Location = new Point(10, 10), AutoSize = true };
            pnl.Controls.Add(lblSummaryTitle);

            // Tạm tính (Giá trị)
            lblSubtotalValue = new Label { Location = new Point(200, 50), AutoSize = true };
            pnl.Controls.Add(lblSubtotalValue);

            // Vận chuyển (Giá trị)
            lblShippingValue = new Label { Location = new Point(200, 80), AutoSize = true };
            pnl.Controls.Add(lblShippingValue);

            // Tổng cộng (Giá trị)
            lblTotalValue = new Label { Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.FromArgb(255, 87, 34), Location = new Point(200, 150), AutoSize = true };
            pnl.Controls.Add(lblTotalValue);

            // Nút Thanh toán
            Button btnCheckout = new Button { Text = "Tiến hành thanh toán", Size = new Size(330, 40), Location = new Point(10, 200), BackColor = Color.FromArgb(255, 87, 34), ForeColor = Color.White };
            btnCheckout.Click += (s, e) => HandleCheckout();
            pnl.Controls.Add(btnCheckout);

            return pnl;
        }

        // --- LOGIC XỬ LÝ DỮ LIỆU ---

        private void UpdateSummaryCalculation()
        {
            // CHỈ TÍNH TIỀN CHO CÁC MỤC ĐÃ CHỌN (IsSelected = true)
            decimal subtotal = _cart.Where(i => i.IsSelected).Sum(item => item.Price * item.Quantity);

            decimal shipping = subtotal > 0 ? SHIPPING_FEE : 0m;
            decimal total = subtotal + shipping;

            // Cập nhật giá trị vào các Label
            if (lblSubtotalValue != null)
                lblSubtotalValue.Text = subtotal.ToString("N0") + "đ";

            if (lblShippingValue != null)
                lblShippingValue.Text = shipping.ToString("N0") + "đ";

            if (lblTotalValue != null)
                lblTotalValue.Text = total.ToString("N0") + "đ";
        }

        private void UpdateCartQuantity(string itemId, int newQuantity)
        {
            if (newQuantity < 1) newQuantity = 1;

            var item = _cart.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.Quantity = newQuantity;
                RenderCartPage(); // Render lại toàn bộ trang để cập nhật Total và Subtotal
            }
        }

        private void RemoveItemFromCart(string itemId)
        {
            _cart.RemoveAll(i => i.Id == itemId);
            RenderCartPage();
        }

        private void HandleCheckout()
        {
            if (_cart.Any(i => i.IsSelected))
            {
                MessageBox.Show("Tiến hành thanh toán cho các mục đã chọn!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // FrmMain.Instance.LoadUserControl(new UcCheckoutPage());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để thanh toán.", "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // --- DỮ LIỆU MẪU (TẠM THỜI) ---
        private List<CartItemDTO> GetDummyCartData()
        {
            return new List<CartItemDTO>
            {
                new CartItemDTO
                {
                    Id = "1-L-XanhDen",
                    ProductId = "1",
                    Name = "Áo khoác denim thời trang cao cấp",
                    Image = @"img\download.png",
                    Price = 450000m,
                    Quantity = 2,
                    Variant = "L, Xanh đen",
                    IsSelected = true
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                },
                new CartItemDTO
                {
                    Id = "2-M-Đen",
                    ProductId = "2",
                    Name = "Giày thể thao Nike Air Max",
                    Image = @"img\download.png",
                    Price = 1200000m,
                    Quantity = 1,
                    Variant = "M, Đen",
                    IsSelected = false // Giả lập item này chưa được chọn ban đầu
                }
            };
        }
    }
}