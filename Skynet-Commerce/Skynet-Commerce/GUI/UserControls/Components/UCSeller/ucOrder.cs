using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Services.Seller;
using Skynet_Commerce.BLL.Models.Admin;

namespace Skynet_Commerce
{
    public partial class ucOrder : UserControl
    {
        private OrderServiceForSeller _orderService;
        private int _currentShopId;
        private List<OrderSellerDTO> _allOrders;
        private List<OrderSellerDTO> _filteredOrders;
        private List<OrderDisplayModel> _displayOrders;

        public ucOrder()
        {
            InitializeComponent();
            _orderService = new OrderServiceForSeller();
            _currentShopId = 1;

            // QUAN TRỌNG: Setup DataGridView nếu chưa có columns
            SetupDataGridView();
            this.Load += ucOrder_Load;
        }

        public ucOrder(int shopId) : this()
        {
            _currentShopId = shopId;
        }

        // BƯỚC 1: Setup columns cho DataGridView
        private void SetupDataGridView()
        {
            // Xóa hết columns cũ (nếu có)
            dgvOrders.Columns.Clear();

            // Tắt auto generate columns
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.RowTemplate.Height = 80;

            // Tạo các columns
            // Column 1: Mã đơn hàng
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrderID",
                HeaderText = "Mã đơn",
                DataPropertyName = "OrderID",
                Width = 60,
                ReadOnly = true
            });

            // Column 2: Khách hàng
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = "Khách hàng",
                DataPropertyName = "Customer",
                Width = 150,
                ReadOnly = true
            });

            // Column 3: Sản phẩm (custom paint)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                HeaderText = "Sản phẩm",
                DataPropertyName = "ProductName",
                Width = 250,
                ReadOnly = true
            });

            // Column 4: Ngày đặt
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrderDate",
                HeaderText = "Ngày đặt",
                DataPropertyName = "OrderDate",
                Width = 130,
                ReadOnly = true
            });

            // Column 5: Tổng tiền
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Tổng tiền",
                DataPropertyName = "Total",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                }
            });

            // Column 6: Trạng thái (custom paint)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                Width = 120,
                ReadOnly = true
            });

            // Column 7: Thao tác (custom paint)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAction",
                HeaderText = "Thao tác",
                Width = 120,
                ReadOnly = true
            });
        }

        private void ucOrder_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private async void LoadOrderData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"=== LoadOrderData: ShopID = {_currentShopId} ===");

                // Hiển thị loading
                dgvOrders.Rows.Clear();
                lblPending.Text = "Đang tải...";

                // Lấy dữ liệu từ service
                _allOrders = await _orderService.GetOrdersForSeller(_currentShopId);

                System.Diagnostics.Debug.WriteLine($"Đã load: {_allOrders.Count} order details");

                if (_allOrders.Count == 0)
                {
                    MessageBox.Show(
                        $"Không có đơn hàng nào cho ShopID: {_currentShopId}\n\n" +
                        "Kiểm tra:\n" +
                        "1. ShopID có đúng không?\n" +
                        "2. Có dữ liệu Orders trong database?\n" +
                        "3. Orders.ShopID = {_currentShopId}?",
                        "Không có dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    lblPending.Text = "Chờ xử lý: 0";
                    lblDelivering.Text = "Đang giao: 0";
                    lblCompleted.Text = "Hoàn thành: 0";
                    lblCanceled.Text = "Đã hủy: 0";
                    return;
                }

                _filteredOrders = _allOrders;

                // Bind vào DataGridView
                BindOrdersToGrid(_filteredOrders);

                // Cập nhật summary
                UpdateSummary(_filteredOrders);

            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi tải dữ liệu:\n\n{ex.Message}";
                if (ex.InnerException != null)
                    errorMsg += $"\n\nInner: {ex.InnerException.Message}";

                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex}");
            }
        }

        // BƯỚC 2: Bind dữ liệu vào DataGridView
        private void BindOrdersToGrid(List<OrderSellerDTO> orders)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"BindOrdersToGrid: {orders.Count} items");

                // Nhóm theo OrderID
                var groupedOrders = orders
                    .GroupBy(o => o.OrderID)
                    .Select(g => new OrderDisplayModel
                    {
                        OrderID = "DH" + g.Key.ToString().PadLeft(6, '0'),
                        Customer = $"{g.First().CustomerName}\n{g.First().CustomerPhone}",
                        ProductName = g.Count() > 1
                            ? $"{g.First().ProductName} (+{g.Count() - 1} sản phẩm khác)"
                            : g.First().ProductName,
                        ProductImage = LoadImageFromUrl(g.First().ImageURL),
                        Variant = g.First().Variant,
                        OrderDate = g.First().CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                        Total = g.First().TotalOrderAmount.ToString("N0") + "₫",
                        Status = TranslateStatus(g.First().Status),
                        StatusColor = GetStatusColor(g.First().Status),
                        Address = g.First().AddressFull,
                        RawOrderID = g.Key,
                        RawStatus = g.First().Status,
                        Items = g.ToList()
                    })
                    .OrderByDescending(o => o.RawOrderID)
                    .ToList();

                System.Diagnostics.Debug.WriteLine($"Grouped: {groupedOrders.Count} orders");

                // Xóa dữ liệu cũ
                dgvOrders.Rows.Clear();

                // CÁCH 1: Thêm từng row thủ công (RECOMMENDED)
                foreach (var order in groupedOrders)
                {
                    int rowIndex = dgvOrders.Rows.Add(
                        order.OrderID,
                        order.Customer,
                        order.ProductName,
                        order.OrderDate,
                        order.Total,
                        order.Status,
                        "Thao tác" // Placeholder cho action column
                    );

                    // Lưu data ẩn vào Tag
                    dgvOrders.Rows[rowIndex].Tag = order;
                }

                // CÁCH 2: Dùng DataSource (nếu muốn)
                // _displayOrders = groupedOrders;
                // dgvOrders.DataSource = _displayOrders;

                System.Diagnostics.Debug.WriteLine($"Added {dgvOrders.Rows.Count} rows to DataGridView");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bind dữ liệu: {ex.Message}\n\n{ex.StackTrace}", "Lỗi");
                System.Diagnostics.Debug.WriteLine($"BindOrdersToGrid Error: {ex}");
            }
        }

        private void UpdateSummary(List<OrderSellerDTO> orders)
        {
            // Nhóm theo OrderID để đếm số đơn hàng (không phải số OrderDetails)
            var grouped = orders.GroupBy(o => o.OrderID).Select(g => g.First()).ToList();

            // Đếm số lượng đơn hàng theo từng trạng thái
            int pending = grouped.Count(o => o.Status == "Pending" || o.Status == "Chờ xử lý");
            int confirmed = grouped.Count(o => o.Status == "Confirmed" || o.Status == "Đã xác nhận");
            int delivering = grouped.Count(o => o.Status == "Shipping" || o.Status == "Đang giao");
            int delivered = grouped.Count(o => o.Status == "Delivered" || o.Status == "Đã giao hàng");
            int completed = grouped.Count(o => o.Status == "Completed" || o.Status == "Hoàn thành");
            int canceled = grouped.Count(o => o.Status == "Cancelled" || o.Status == "Đã hủy");

            // Tính tổng doanh thu theo trạng thái
            decimal totalPendingRevenue = grouped
                .Where(o => o.Status == "Pending" || o.Status == "Chờ xử lý")
                .Sum(o => o.TotalOrderAmount);

            decimal totalDeliveringRevenue = grouped
                .Where(o => o.Status == "Shipping" || o.Status == "Đang giao")
                .Sum(o => o.TotalOrderAmount);

            decimal totalCompletedRevenue = grouped
                .Where(o => o.Status == "Completed" || o.Status == "Delivered" || o.Status == "Hoàn thành" || o.Status == "Đã giao hàng")
                .Sum(o => o.TotalOrderAmount);

            // Cập nhật text cho các label với số lượng và tổng tiền
            lblPending.Text = $"Chờ xử lý: {pending}   ";
            lblDelivering.Text = $"Đang giao: {delivering}   ";
            lblCompleted.Text = $"Hoàn thành: {completed + delivered}   ";
            lblCanceled.Text = $"Đã hủy: {canceled}   ";

            // Styling cho labels
            lblPending.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPending.ForeColor = Color.FromArgb(255, 193, 7); // Vàng

            lblDelivering.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDelivering.ForeColor = Color.FromArgb(156, 39, 176); // Tím

            lblCompleted.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCompleted.ForeColor = Color.FromArgb(76, 175, 80); // Xanh lá

            lblCanceled.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCanceled.ForeColor = Color.FromArgb(244, 67, 54); // Đỏ

            // Log debug
            System.Diagnostics.Debug.WriteLine($"Summary: Pending={pending}, Delivering={delivering}, Completed={completed + delivered}, Canceled={canceled}");
        }

        // Helper method để format tiền tệ
        private string FormatCurrency(decimal amount)
        {
            if (amount >= 1000000000) // Tỷ
                return $"{amount / 1000000000:0.##} tỷ";
            else if (amount >= 1000000) // Triệu
                return $"{amount / 1000000:0.##} tr";
            else if (amount >= 1000) // Nghìn
                return $"{amount / 1000:0.##}k";
            else
                return $"{amount:N0}₫";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrders()
        {
            if (_allOrders == null || !_allOrders.Any())
                return;

            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText) ||
                searchText == "🔍 tìm kiếm theo mã đơn hoặc tên khách hàng...")
            {
                _filteredOrders = _allOrders;
            }
            else
            {
                _filteredOrders = _allOrders
                    .Where(o =>
                        ("DH" + o.OrderID.ToString().PadLeft(6, '0')).ToLower().Contains(searchText) ||
                        (o.CustomerName ?? "").ToLower().Contains(searchText) ||
                        (o.CustomerPhone ?? "").Contains(searchText))
                    .ToList();
            }

            BindOrdersToGrid(_filteredOrders);
            UpdateSummary(_filteredOrders);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Tìm kiếm theo mã đơn hoặc tên khách hàng...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "🔍 Tìm kiếm theo mã đơn hoặc tên khách hàng...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void dgvOrders_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy data từ Tag
            var orderData = dgvOrders.Rows[e.RowIndex].Tag as OrderDisplayModel;
            if (orderData == null) return;

            // Custom paint cho Product column
            if (e.ColumnIndex == dgvOrders.Columns["colProduct"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int imageSize = e.CellBounds.Height - 2 * padding;
                Rectangle imageRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + padding,
                    imageSize,
                    imageSize);

                if (orderData.ProductImage != null)
                {
                    e.Graphics.DrawImage(orderData.ProductImage, imageRect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, imageRect);
                    e.Graphics.DrawRectangle(Pens.Gray, imageRect);
                }

                var textRect = new Rectangle(
                    imageRect.Right + padding,
                    e.CellBounds.Y + padding,
                    e.CellBounds.Width - imageRect.Width - 3 * padding,
                    e.CellBounds.Height - 2 * padding);

                TextRenderer.DrawText(e.Graphics, orderData.ProductName,
                    new Font(e.CellStyle.Font, FontStyle.Bold), textRect,
                    Color.Black, TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak);

                e.Handled = true;
            }
            // Custom paint cho Status column
            else if (e.ColumnIndex == dgvOrders.Columns["colStatus"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                using (Brush brush = new SolidBrush(orderData.StatusColor))
                {
                    var rect = new Rectangle(
                        e.CellBounds.X + 5,
                        e.CellBounds.Y + (e.CellBounds.Height - 25) / 2,
                        e.CellBounds.Width - 10,
                        25);

                    // Bo tròn góc
                    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddArc(rect.X, rect.Y, 10, 10, 180, 90);
                    path.AddArc(rect.Right - 10, rect.Y, 10, 10, 270, 90);
                    path.AddArc(rect.Right - 10, rect.Bottom - 10, 10, 10, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - 10, 10, 10, 90, 90);
                    path.CloseFigure();

                    e.Graphics.FillPath(brush, path);
                    TextRenderer.DrawText(e.Graphics, orderData.Status, e.CellStyle.Font,
                        rect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
            // Custom paint cho Action column
            else if (e.ColumnIndex == dgvOrders.Columns["colAction"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int buttonWidth = 40;
                int buttonHeight = 25;
                int padding = 5;

                Rectangle viewRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth,
                    buttonHeight);

                Rectangle updateRect = new Rectangle(
                    viewRect.Right + padding,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth + 20,
                    buttonHeight);

                ButtonRenderer.DrawButton(e.Graphics, viewRect, "👁",
                    e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                ButtonRenderer.DrawButton(e.Graphics, updateRect, "✏️",
                    new Font(e.CellStyle.Font.FontFamily, 8), false,
                    System.Windows.Forms.VisualStyles.PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var orderData = dgvOrders.Rows[e.RowIndex].Tag as OrderDisplayModel;
            if (orderData == null) return;

            if (e.ColumnIndex == dgvOrders.Columns["colAction"].Index)
            {
                var cellBounds = dgvOrders.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPoint = dgvOrders.PointToClient(Cursor.Position);
                int relativeX = clickPoint.X - cellBounds.X;

                if (relativeX < 50)
                {
                    ShowOrderDetails(orderData.RawOrderID);
                }
                else
                {
                    UpdateOrderStatus(orderData.RawOrderID, orderData.RawStatus);
                }
            }
        }

        private void ShowOrderDetails(int orderId)
        {
            var orderItems = _allOrders.Where(o => o.OrderID == orderId).ToList();

            if (orderItems.Any())
            {
                var first = orderItems.First();
                string details = $"Mã đơn: DH{orderId.ToString().PadLeft(6, '0')}\n";
                details += $"Khách hàng: {first.CustomerName}\n";
                details += $"SĐT: {first.CustomerPhone}\n";
                details += $"Địa chỉ: {first.AddressFull}\n";
                details += $"Ngày đặt: {first.CreatedAt:dd/MM/yyyy HH:mm}\n";
                details += $"Trạng thái: {TranslateStatus(first.Status)}\n\n";
                details += "Sản phẩm:\n";

                foreach (var item in orderItems)
                {
                    details += $"- {item.ProductName}";
                    if (item.Variant != "Không có")
                        details += $" ({item.Variant})";
                    details += $"\n  SL: {item.Quantity} x {item.UnitPrice:N0}₫ = {item.SubTotal:N0}₫\n";
                }

                details += $"\nTổng tiền: {first.TotalOrderAmount:N0}₫";

                MessageBox.Show(details, "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void UpdateOrderStatus(int orderId, string currentStatus)
        {
            var statusOptions = new List<string>();

            switch (currentStatus)
            {
                case "Pending":
                    statusOptions = new List<string> { "Confirmed", "Cancelled" };
                    break;
                case "Confirmed":
                    statusOptions = new List<string> { "Shipping", "Cancelled" };
                    break;
                case "Shipping":
                    statusOptions = new List<string> { "Delivered" };
                    break;
                default:
                    MessageBox.Show("Không thể cập nhật trạng thái đơn hàng này.", "Thông báo");
                    return;
            }

            string newStatus = ShowStatusSelectionDialog(statusOptions);

            if (!string.IsNullOrEmpty(newStatus))
            {
                try
                {
                    bool success = _orderService.UpdateOrderStatus(orderId, newStatus);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrderData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ShowStatusSelectionDialog(List<string> options)
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Cập nhật trạng thái",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Chọn trạng thái mới:", AutoSize = true };
            ComboBox comboBox = new ComboBox() { Left = 20, Top = 50, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };

            foreach (var option in options)
                comboBox.Items.Add(TranslateStatus(option));

            comboBox.SelectedIndex = 0;

            Button confirmation = new Button() { Text = "OK", Left = 160, Width = 70, Top = 100, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Hủy", Left = 240, Width = 70, Top = 100, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? options[comboBox.SelectedIndex] : null;
        }

        private Image LoadImageFromUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return null;

                using (var webClient = new System.Net.WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private string TranslateStatus(string status)
        {
            switch (status)
            {
                case "Pending": return "Chờ xử lý";
                case "Confirmed": return "Đã xác nhận";
                case "Shipping": return "Đang giao";
                case "Delivered": return "Đã giao hàng";
                case "Completed": return "Hoàn thành";
                case "Cancelled": return "Đã hủy";
                default: return status;
            }
        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Pending": return Color.FromArgb(255, 193, 7);
                case "Confirmed": return Color.FromArgb(33, 150, 243);
                case "Shipping": return Color.FromArgb(156, 39, 176);
                case "Delivered":
                case "Completed": return Color.FromArgb(76, 175, 80);
                case "Cancelled": return Color.FromArgb(244, 67, 54);
                default: return Color.Gray;
            }
        }
    }

    // Model để hiển thị
    public class OrderDisplayModel
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public Image ProductImage { get; set; }
        public string Variant { get; set; }
        public string OrderDate { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public Color StatusColor { get; set; }
        public string Address { get; set; }
        public int RawOrderID { get; set; }
        public string RawStatus { get; set; }
        public List<OrderSellerDTO> Items { get; set; }
    }
}