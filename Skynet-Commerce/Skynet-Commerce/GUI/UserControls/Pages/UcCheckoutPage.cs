using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCheckoutPage : UserControl
    {
        public UcCheckoutPage()
        {
            // Gọi hàm của Designer (được tạo tự động trong file .Designer.cs)
            InitializeComponent();

            // Gọi hàm vẽ giao diện thủ công của chúng ta
            SetupUI();
            LoadDummyData();
        }

        // --- [QUAN TRỌNG] ĐÃ XÓA HÀM InitializeComponent() GÂY LỖI ---

        private void SetupUI()
        {
            // 1. Cài đặt thuộc tính cơ bản cho trang (Chuyển từ hàm lỗi sang đây)
            this.Size = new Size(1200, 900);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.AutoScroll = true; // Cho phép cuộn trang nếu dài

            // --- 2. TIÊU ĐỀ ---
            Label lblHeader = new Label
            {
                Text = "Thanh toán",
                Font = new Font("Segoe UI", 16, FontStyle.Regular),
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.Black
            };
            this.Controls.Add(lblHeader);

            // --- 3. CỘT TRÁI (Địa chỉ + Sản phẩm + Phương thức TT) ---
            FlowLayoutPanel flpLeft = new FlowLayoutPanel
            {
                Location = new Point(20, 70),
                Size = new Size(800, 800),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(flpLeft);

            // [A] Phần Địa chỉ
            flpLeft.Controls.Add(CreateAddressSection());

            // [B] Phần Danh sách sản phẩm
            flpLeft.Controls.Add(CreateProductSection());

            // [C] Phần Phương thức thanh toán
            flpLeft.Controls.Add(CreatePaymentMethodSection());


            // --- 4. CỘT PHẢI (Tổng tiền + Nút Đặt hàng) ---
            Guna2Panel pnlSummary = new Guna2Panel
            {
                Location = new Point(840, 70),
                Size = new Size(340, 250),
                FillColor = Color.White,
                BorderRadius = 4
            };
            SetupSummarySection(pnlSummary);
            this.Controls.Add(pnlSummary);
        }

        // --- SECTION A: ĐỊA CHỈ ---
        private Panel CreateAddressSection()
        {
            Guna2Panel pnl = new Guna2Panel
            {
                Size = new Size(800, 120),
                FillColor = Color.White,
                BorderRadius = 4,
                Margin = new Padding(0, 0, 0, 20)
            };
            // Viền màu cam trên cùng như Shopee
            Guna2Panel pnlTopLine = new Guna2Panel { Dock = DockStyle.Top, Height = 4, FillColor = Color.OrangeRed };
            pnl.Controls.Add(pnlTopLine);

            Label lblTitle = new Label { Text = "📍 Địa chỉ nhận hàng", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.OrangeRed, Location = new Point(15, 20), AutoSize = true };

            Label lblInfo = new Label
            {
                Text = "Nguyễn Văn A | (+84) 912 345 678\n123 Đường ABC, Phường XYZ, Quận 1, TP. Hồ Chí Minh",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 50),
                Size = new Size(600, 50)
            };

            Guna2Button btnChange = new Guna2Button { Text = "Mặc định", FillColor = Color.White, ForeColor = Color.OrangeRed, BorderColor = Color.OrangeRed, BorderThickness = 1, Location = new Point(680, 50), Size = new Size(80, 30) };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblInfo);
            pnl.Controls.Add(btnChange);
            return pnl;
        }

        // --- SECTION B: SẢN PHẨM ---
        private Panel CreateProductSection()
        {
            Guna2Panel pnl = new Guna2Panel
            {
                Size = new Size(800, 10), // Height sẽ tự giãn theo Flow
                FillColor = Color.White,
                BorderRadius = 4,
                Margin = new Padding(0, 0, 0, 20),
                AutoSize = true
            };

            Label lblTitle = new Label { Text = "Sản phẩm đã chọn", Font = new Font("Segoe UI", 12, FontStyle.Regular), Location = new Point(15, 15), AutoSize = true };
            pnl.Controls.Add(lblTitle);

            FlowLayoutPanel flpItems = new FlowLayoutPanel { Location = new Point(15, 50), Size = new Size(770, 10), AutoSize = true, FlowDirection = FlowDirection.TopDown };

            // Thêm các item giả lập
            flpItems.Controls.Add(CreateCheckoutItem("Áo khoác denim thời trang", "Màu xanh, Size M", "900.000đ", 2, "https://cf.shopee.vn/file/5c48983458307d95651950f3b8a27d6c"));
            flpItems.Controls.Add(CreateCheckoutItem("Điện thoại thông minh", "Màu đen, 128GB", "8.500.000đ", 1, "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-qwerty12345"));
            flpItems.Controls.Add(CreateCheckoutItem("Giày thể thao nam", "Màu trắng, Size 42", "1.200.000đ", 1, "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e6da41fa-1be4-4ce5-b89c-22be4f1f02d6/air-force-1-07-shoes-WrLlWX.png"));

            pnl.Controls.Add(flpItems);
            return pnl;
        }

        private Panel CreateCheckoutItem(string name, string variant, string price, int qty, string imgUrl)
        {
            Panel p = new Panel { Size = new Size(770, 90), BackColor = Color.White };

            Guna2PictureBox pic = new Guna2PictureBox { Size = new Size(70, 70), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.Zoom, ImageLocation = imgUrl, BorderRadius = 4 };
            if (string.IsNullOrEmpty(imgUrl)) pic.FillColor = Color.WhiteSmoke;

            Label lblName = new Label { Text = name, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(80, 5), AutoSize = true };
            Label lblVariant = new Label { Text = variant, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(80, 30), AutoSize = true };
            Label lblQty = new Label { Text = "x" + qty, Font = new Font("Segoe UI", 9, FontStyle.Regular), Location = new Point(80, 50), AutoSize = true };

            Label lblPrice = new Label { Text = price, Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.OrangeRed, Location = new Point(650, 30), AutoSize = true, TextAlign = ContentAlignment.MiddleRight };

            p.Controls.Add(pic);
            p.Controls.Add(lblName);
            p.Controls.Add(lblVariant);
            p.Controls.Add(lblQty);
            p.Controls.Add(lblPrice);
            return p;
        }

        // --- SECTION C: PHƯƠNG THỨC THANH TOÁN ---
        private Panel CreatePaymentMethodSection()
        {
            Guna2Panel pnl = new Guna2Panel
            {
                Size = new Size(800, 200),
                FillColor = Color.White,
                BorderRadius = 4,
                Margin = new Padding(0, 0, 0, 50) // Cách bottom chút
            };

            Label lblTitle = new Label { Text = "Phương thức thanh toán", Font = new Font("Segoe UI", 12, FontStyle.Regular), Location = new Point(15, 15), AutoSize = true };
            pnl.Controls.Add(lblTitle);

            int y = 50;
            pnl.Controls.Add(CreateRadioOption("Thanh toán khi nhận hàng (COD)", "Thanh toán bằng tiền mặt khi nhận hàng", y, true)); y += 50;
            pnl.Controls.Add(CreateRadioOption("Thẻ tín dụng / Thẻ ghi nợ", "Visa, Mastercard, JCB", y, false)); y += 50;
            pnl.Controls.Add(CreateRadioOption("Chuyển khoản ngân hàng", "Chuyển khoản qua Internet Banking", y, false));

            return pnl;
        }

        private Panel CreateRadioOption(string title, string sub, int y, bool isChecked)
        {
            Panel p = new Panel { Location = new Point(20, y), Size = new Size(750, 45) };
            Guna2CustomRadioButton rb = new Guna2CustomRadioButton { CheckedState = { BorderColor = Color.OrangeRed, FillColor = Color.OrangeRed }, UncheckedState = { BorderColor = Color.Gray }, Size = new Size(18, 18), Location = new Point(0, 5), Checked = isChecked };
            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 10, FontStyle.Regular), Location = new Point(30, 2), AutoSize = true };
            Label lblS = new Label { Text = sub, Font = new Font("Segoe UI", 8, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(30, 22), AutoSize = true };

            p.Controls.Add(rb); p.Controls.Add(lblT); p.Controls.Add(lblS);
            return p;
        }

        // --- SIDEBAR: TỔNG KẾT ---
        private void SetupSummarySection(Guna2Panel pnl)
        {
            Label lblTitle = new Label { Text = "Đơn hàng", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 15) };

            Label lblSub = new Label { Text = "Tạm tính", Location = new Point(15, 50), ForeColor = Color.Gray };
            Label lblSubVal = new Label { Text = "12.437.000đ", Location = new Point(200, 50), TextAlign = ContentAlignment.MiddleRight };

            Label lblShip = new Label { Text = "Phí vận chuyển", Location = new Point(15, 80), ForeColor = Color.Gray };
            Label lblShipVal = new Label { Text = "30.000đ", Location = new Point(200, 80), TextAlign = ContentAlignment.MiddleRight };

            Guna2Separator sep = new Guna2Separator { Location = new Point(15, 110), Size = new Size(310, 10) };

            Label lblTotal = new Label { Text = "Tổng cộng", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 130) };
            Label lblTotalVal = new Label { Text = "12.467.000đ", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.OrangeRed, Location = new Point(160, 125), TextAlign = ContentAlignment.MiddleRight };

            Guna2Button btnOrder = new Guna2Button
            {
                Text = "Đặt hàng",
                FillColor = Color.FromArgb(238, 77, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BorderRadius = 4,
                Location = new Point(15, 180),
                Size = new Size(310, 45),
                Cursor = Cursors.Hand
            };
            btnOrder.Click += BtnOrder_Click;

            Label lblNote = new Label { Text = "Nhấn \"Đặt hàng\" đồng nghĩa với việc bạn đồng ý tuân theo Điều khoản ShopViet", Font = new Font("Segoe UI", 8, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(15, 230), Size = new Size(310, 30), TextAlign = ContentAlignment.TopCenter };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblSub); pnl.Controls.Add(lblSubVal);
            pnl.Controls.Add(lblShip); pnl.Controls.Add(lblShipVal);
            pnl.Controls.Add(sep);
            pnl.Controls.Add(lblTotal); pnl.Controls.Add(lblTotalVal);
            pnl.Controls.Add(btnOrder);
            pnl.Controls.Add(lblNote);
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo đặt hàng thành công
            MessageBox.Show("Đặt hàng thành công! Mã đơn hàng của bạn là #SV123456.", "ShopViet", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Quay về trang chủ
            FrmMain main = this.FindForm() as FrmMain;
            if (main != null) main.LoadPage("Home");
        }

        private void LoadDummyData()
        {
            // Ở đây có thể load dữ liệu thật từ biến toàn cục hoặc CartDTO truyền sang
        }
    }
}