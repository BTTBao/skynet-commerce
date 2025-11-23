using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using Guna.UI2.WinForms;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.BLL.Helpers;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.BLL.Services;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcCheckoutPage : UserControl
    {
        private decimal _totalAmount = 0;
        private decimal _shippingFee = 30000;
        private string _selectedPaymentMethod = "COD"; // Mặc định

        // Khai báo biến toàn cục cho các nút Radio để dễ điều khiển
        private Guna2CustomRadioButton rbCOD;
        private Guna2CustomRadioButton rbCard;
        private Guna2CustomRadioButton rbBank;

        private Label lblAddressInfo;
        private Label lblSubTotalVal;
        private Label lblTotalVal;

        public UcCheckoutPage()
        {
            InitializeComponent();
            SetupUI();
            LoadRealData();
        }

        private void SetupUI()
        {
            this.Size = new Size(1200, 900);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.AutoScroll = true;

            // Header
            Label lblHeader = new Label
            {
                Text = "Thanh toán",
                Font = new Font("Segoe UI", 16, FontStyle.Regular),
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.Black
            };
            this.Controls.Add(lblHeader);

            // Cột trái
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

            flpLeft.Controls.Add(CreateAddressSection());
            flpLeft.Controls.Add(CreateProductSection());
            flpLeft.Controls.Add(CreatePaymentMethodSection());

            // Cột phải
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

        // --- 1. PHẦN PAYMENT (ĐÃ SỬA LOGIC CHỌN 1) ---
        private Panel CreatePaymentMethodSection()
        {
            Guna2Panel pnl = new Guna2Panel { Size = new Size(800, 200), FillColor = Color.White, BorderRadius = 4, Margin = new Padding(0, 0, 0, 50) };
            pnl.Controls.Add(new Label { Text = "Phương thức thanh toán", Font = new Font("Segoe UI", 12, FontStyle.Regular), Location = new Point(15, 15), AutoSize = true });

            int y = 50;

            // Tạo các nút Radio và gán vào biến toàn cục
            rbCOD = CreateRadioButton("COD");
            rbCard = CreateRadioButton("CARD");
            rbBank = CreateRadioButton("BANK");

            // Mặc định chọn COD
            rbCOD.Checked = true;

            // Thêm vào giao diện
            pnl.Controls.Add(CreatePaymentRow(rbCOD, "Thanh toán khi nhận hàng (COD)", "Thanh toán bằng tiền mặt khi nhận hàng", y));
            y += 50;
            pnl.Controls.Add(CreatePaymentRow(rbCard, "Thẻ tín dụng / Thẻ ghi nợ", "Visa, Mastercard, JCB", y));
            y += 50;
            pnl.Controls.Add(CreatePaymentRow(rbBank, "Chuyển khoản ngân hàng", "Chuyển khoản qua Internet Banking", y));

            return pnl;
        }

        private Guna2CustomRadioButton CreateRadioButton(string tag)
        {
            var rb = new Guna2CustomRadioButton
            {
                CheckedState = { BorderColor = Color.OrangeRed, FillColor = Color.OrangeRed },
                UncheckedState = { BorderColor = Color.Gray },
                Size = new Size(18, 18),
                Location = new Point(0, 5),
                Tag = tag,
                Cursor = Cursors.Hand
            };
            // Gán sự kiện Click chung
            rb.Click += OnPaymentMethodChanged;
            return rb;
        }

        // [LOGIC QUAN TRỌNG] Xử lý chỉ chọn 1 cái
        private void OnPaymentMethodChanged(object sender, EventArgs e)
        {
            var selectedBtn = sender as Guna2CustomRadioButton;

            if (selectedBtn.Checked)
            {
                // Bỏ chọn 2 cái kia
                if (selectedBtn != rbCOD) rbCOD.Checked = false;
                if (selectedBtn != rbCard) rbCard.Checked = false;
                if (selectedBtn != rbBank) rbBank.Checked = false;

                // Cập nhật biến lưu trữ
                _selectedPaymentMethod = selectedBtn.Tag.ToString();
            }
        }

        private Panel CreatePaymentRow(Guna2CustomRadioButton rb, string title, string sub, int y)
        {
            Panel p = new Panel { Location = new Point(20, y), Size = new Size(750, 45) };

            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 10), Location = new Point(30, 2), AutoSize = true };
            Label lblS = new Label { Text = sub, Font = new Font("Segoe UI", 8), ForeColor = Color.Gray, Location = new Point(30, 22), AutoSize = true };

            // Khi bấm vào chữ cũng chọn Radio
            EventHandler labelClick = (s, e) => { rb.Checked = true; OnPaymentMethodChanged(rb, EventArgs.Empty); };
            lblT.Click += labelClick;
            lblS.Click += labelClick;
            p.Click += labelClick;

            p.Controls.Add(rb);
            p.Controls.Add(lblT);
            p.Controls.Add(lblS);
            return p;
        }

        // --- 2. PHẦN ĐỊA CHỈ ---
        private Panel CreateAddressSection()
        {
            Guna2Panel pnl = new Guna2Panel { Size = new Size(800, 120), FillColor = Color.White, BorderRadius = 4, Margin = new Padding(0, 0, 0, 20) };
            pnl.Controls.Add(new Guna2Panel { Dock = DockStyle.Top, Height = 4, FillColor = Color.OrangeRed });

            Label lblTitle = new Label { Text = "📍 Địa chỉ nhận hàng", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.OrangeRed, Location = new Point(15, 20), AutoSize = true };

            lblAddressInfo = new Label
            {
                Text = "Đang tải địa chỉ...",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 50),
                Size = new Size(600, 50)
            };

            Guna2Button btnChange = new Guna2Button { Text = "Thay đổi", FillColor = Color.White, ForeColor = Color.OrangeRed, BorderColor = Color.OrangeRed, BorderThickness = 1, Location = new Point(680, 50), Size = new Size(80, 30) };

            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblAddressInfo);
            pnl.Controls.Add(btnChange);
            return pnl;
        }

        // --- 3. PHẦN SẢN PHẨM ---
        private Panel CreateProductSection()
        {
            Guna2Panel pnl = new Guna2Panel { Size = new Size(800, 10), FillColor = Color.White, BorderRadius = 4, Margin = new Padding(0, 0, 0, 20), AutoSize = true };
            pnl.Controls.Add(new Label { Text = "Sản phẩm đã chọn", Font = new Font("Segoe UI", 12, FontStyle.Regular), Location = new Point(15, 15), AutoSize = true });

            FlowLayoutPanel flpItems = new FlowLayoutPanel { Location = new Point(15, 50), Size = new Size(770, 10), AutoSize = true, FlowDirection = FlowDirection.TopDown };

            foreach (var item in SessionManager.CartItems)
            {
                flpItems.Controls.Add(CreateCheckoutItem(item.ProductName, "Mặc định", item.Price.ToString("N0") + "đ", item.Quantity, item.ImageUrl));
            }

            pnl.Controls.Add(flpItems);
            return pnl;
        }

        private Panel CreateCheckoutItem(string name, string variant, string price, int qty, string imgUrl)
        {
            Panel p = new Panel { Size = new Size(770, 90), BackColor = Color.White };
            Guna2PictureBox pic = new Guna2PictureBox { Size = new Size(70, 70), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.Zoom, BorderRadius = 4 };
            if (!string.IsNullOrEmpty(imgUrl) && imgUrl.StartsWith("http")) pic.ImageLocation = imgUrl; else pic.FillColor = Color.WhiteSmoke;

            p.Controls.Add(pic);
            p.Controls.Add(new Label { Text = name, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(80, 5), AutoSize = true });
            p.Controls.Add(new Label { Text = variant, Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Location = new Point(80, 30), AutoSize = true });
            p.Controls.Add(new Label { Text = "x" + qty, Font = new Font("Segoe UI", 9), Location = new Point(80, 50), AutoSize = true });
            p.Controls.Add(new Label { Text = price, Font = new Font("Segoe UI", 10), ForeColor = Color.OrangeRed, Location = new Point(650, 30), AutoSize = true, TextAlign = ContentAlignment.MiddleRight });
            return p;
        }

        // --- 4. TỔNG KẾT ---
        private void SetupSummarySection(Guna2Panel pnl)
        {
            Label lblTitle = new Label { Text = "Đơn hàng", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 15) };

            Label lblSub = new Label { Text = "Tạm tính", Location = new Point(15, 50), ForeColor = Color.Gray };
            lblSubTotalVal = new Label { Text = "0đ", Location = new Point(200, 50), TextAlign = ContentAlignment.MiddleRight };

            Label lblShip = new Label { Text = "Phí vận chuyển", Location = new Point(15, 80), ForeColor = Color.Gray };
            Label lblShipVal = new Label { Text = "30.000đ", Location = new Point(200, 80), TextAlign = ContentAlignment.MiddleRight };

            Guna2Separator sep = new Guna2Separator { Location = new Point(15, 110), Size = new Size(310, 10) };

            Label lblTotal = new Label { Text = "Tổng cộng", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 130) };
            lblTotalVal = new Label { Text = "0đ", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.OrangeRed, Location = new Point(160, 125), TextAlign = ContentAlignment.MiddleRight };

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

            pnl.Controls.Add(lblTitle); pnl.Controls.Add(lblSub); pnl.Controls.Add(lblSubTotalVal);
            pnl.Controls.Add(lblShip); pnl.Controls.Add(lblShipVal); pnl.Controls.Add(sep);
            pnl.Controls.Add(lblTotal); pnl.Controls.Add(lblTotalVal); pnl.Controls.Add(btnOrder); pnl.Controls.Add(lblNote);
        }

        // --- LOAD DATA ---
        private void LoadRealData()
        {
            LoadUserAddress();
            LoadCartItems();
        }

        private void LoadUserAddress()
        {
            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    var addr = db.UserAddresses.FirstOrDefault(a => a.AccountID == accId && a.IsDefault == true)
                               ?? db.UserAddresses.FirstOrDefault(a => a.AccountID == accId);

                    if (addr != null)
                    {
                        lblAddressInfo.Text = $"{addr.ReceiverFullName} | {addr.ReceiverPhone}\n{addr.AddressLine}, {addr.Ward}, {addr.District}, {addr.Province}";
                    }
                    else
                    {
                        lblAddressInfo.Text = "Chưa có địa chỉ nhận hàng. Vui lòng thêm địa chỉ!";
                        lblAddressInfo.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
        }

        private void LoadCartItems()
        {
            var cartItems = SessionManager.CartItems;
            decimal subTotal = 0;

            foreach (var item in cartItems)
            {
                subTotal += item.Price * item.Quantity;
            }
            _totalAmount = subTotal + _shippingFee;

            if (lblSubTotalVal != null) lblSubTotalVal.Text = subTotal.ToString("N0") + "đ";
            if (lblTotalVal != null) lblTotalVal.Text = _totalAmount.ToString("N0") + "đ";
        }

        // --- SỰ KIỆN ĐẶT HÀNG ---
        private async void BtnOrder_Click(object sender, EventArgs e)
        {
            if (_selectedPaymentMethod != "COD")
            {
                MessageBox.Show("Hệ thống thanh toán Online đang bảo trì. Vui lòng chọn 'Thanh toán khi nhận hàng (COD)'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.CartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    // 1. Kiểm tra địa chỉ
                    var address = db.UserAddresses.FirstOrDefault(a => a.AccountID == accId && a.IsDefault == true)
                                  ?? db.UserAddresses.FirstOrDefault(a => a.AccountID == accId);

                    if (address == null)
                    {
                        MessageBox.Show("Vui lòng thêm địa chỉ nhận hàng trước khi thanh toán!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. [QUAN TRỌNG] Kiểm tra tồn kho trước khi đặt
                    var productIds = SessionManager.CartItems.Select(c => c.ProductId).ToList();
                    var dbProducts = db.Products.Where(p => productIds.Contains(p.ProductID)).ToList();

                    foreach (var item in SessionManager.CartItems)
                    {
                        var productInDb = dbProducts.FirstOrDefault(p => p.ProductID == item.ProductId);
                        if (productInDb == null)
                        {
                            MessageBox.Show($"Sản phẩm '{item.ProductName}' không còn tồn tại!", "Lỗi kho hàng");
                            return;
                        }
                        if (productInDb.StockQuantity < item.Quantity)
                        {
                            MessageBox.Show($"Sản phẩm '{item.ProductName}' chỉ còn {productInDb.StockQuantity} cái trong kho (Bạn đặt {item.Quantity}). Vui lòng giảm số lượng!", "Hết hàng");
                            return;
                        }
                    }

                    // 3. Tạo OrderGroup
                    var orderGroup = new OrderGroup
                    {
                        AccountID = accId,
                        TotalAmount = _totalAmount,
                        CreatedAt = DateTime.Now
                    };
                    db.OrderGroups.Add(orderGroup);
                    await db.SaveChangesAsync();

                    // 4. Tách đơn và Trừ kho
                    var cartByShop = dbProducts.GroupBy(p => p.ShopID);

                    foreach (var shopGroup in cartByShop)
                    {
                        int? shopId = shopGroup.Key;
                        if (shopId == null) continue;

                        decimal shopOrderTotal = 0;
                        List<OrderDetail> details = new List<OrderDetail>();

                        foreach (var prod in shopGroup)
                        {
                            var cartItem = SessionManager.CartItems.First(c => c.ProductId == prod.ProductID);
                            decimal itemTotal = (prod.Price ?? 0) * cartItem.Quantity;
                            shopOrderTotal += itemTotal;

                            details.Add(new OrderDetail
                            {
                                ProductID = prod.ProductID,
                                Quantity = cartItem.Quantity,
                                UnitPrice = prod.Price ?? 0,
                            });

                            // [TRỪ KHO TRỰC TIẾP]
                            prod.StockQuantity -= cartItem.Quantity;
                            prod.SoldCount += cartItem.Quantity;
                        }

                        // Tạo Order
                        var order = new Order
                        {
                            OrderGroupID = orderGroup.OrderGroupID,
                            ShopID = shopId.Value,
                            AccountID = accId,
                            AddressID = address.AddressID,
                            TotalAmount = shopOrderTotal + _shippingFee,
                            Status = "Pending",
                            CreatedAt = DateTime.Now
                        };
                        db.Orders.Add(order);
                        await db.SaveChangesAsync(); // Lưu Order để có ID

                        // Lưu OrderDetails
                        foreach (var detail in details)
                        {
                            detail.OrderID = order.OrderID;
                            db.OrderDetails.Add(detail);
                        }
                    }

                    // 5. Lưu Payment
                    var payment = new Payment
                    {
                        OrderGroupID = orderGroup.OrderGroupID,
                        Method = "COD",
                        Amount = _totalAmount,
                        PaymentStatus = "Pending",
                        CreatedAt = DateTime.Now
                    };
                    db.Payments.Add(payment);

                    // [LƯU TẤT CẢ THAY ĐỔI] (Bao gồm cả việc trừ kho)
                    await db.SaveChangesAsync();

                    // 6. Xóa giỏ hàng
                    SessionManager.ClearCart();
                    try
                    {
                        var dbCart = db.Carts.FirstOrDefault(c => c.AccountID == accId);
                        if (dbCart != null)
                        {
                            db.CartItems.RemoveRange(db.CartItems.Where(ci => ci.CartID == dbCart.CartID));
                            await db.SaveChangesAsync();
                        }
                    }
                    catch { }

                    MessageBox.Show("Đặt hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay về trang chủ
                    FrmMain main = this.FindForm() as FrmMain;
                    if (main != null) main.LoadPage("Home");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt hàng: " + ex.Message);
            }
        }
    }
}