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

        public ucOrder(int shopId)
        {
            InitializeComponent();
            _orderService = new OrderServiceForSeller();
            this.Load += ucOrder_Load;
            _currentShopId = shopId;


        }

        private void ucOrder_Load(object sender, EventArgs e)
        {
            LoadOrderData();
            cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;
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
                    lblConfirmed.Text = "Đã xác nhận: 0";
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
            lblConfirmed.Text = $"Đã xác nhận: {confirmed}   ";
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


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrders()
        {
            if (_allOrders == null || !_allOrders.Any())
                return;

            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText) )
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
            
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "";
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

                int padding = 8;
                int imageSize = e.CellBounds.Height - 2 * padding;
                Rectangle imageRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + padding,
                    imageSize,
                    imageSize);

                // Vẽ ảnh sản phẩm
                if (orderData.ProductImage != null)
                {
                    e.Graphics.DrawImage(orderData.ProductImage, imageRect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, imageRect);
                    e.Graphics.DrawRectangle(Pens.Gray, imageRect);
                }

                // Vẽ text (tên sản phẩm + variant)
                var textRect = new Rectangle(
                    imageRect.Right + padding,
                    e.CellBounds.Y + padding,
                    e.CellBounds.Width - imageRect.Width - 3 * padding,
                    e.CellBounds.Height - 2 * padding);

                // Tên sản phẩm (dòng 1)
                Font productFont = new Font("Segoe UI", 10, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, orderData.ProductName,
                    productFont, textRect,
                    Color.Black, TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak);

                // Variant (dòng 2 - dưới tên sản phẩm)
                if (!string.IsNullOrEmpty(orderData.Variant) && orderData.Variant != "Không có")
                {
                    Font variantFont = new Font("Segoe UI", 9, FontStyle.Regular);
                    var variantRect = new Rectangle(
                        textRect.X,
                        textRect.Y + 24, // Cách tên sản phẩm 24px
                        textRect.Width,
                        textRect.Height - 24);

                    TextRenderer.DrawText(e.Graphics, orderData.Variant,
                        variantFont, variantRect,
                        Color.Gray, TextFormatFlags.Left | TextFormatFlags.Top);
                }

                e.Handled = true;
            }
            // Custom paint cho Customer column
            else if (e.ColumnIndex == dgvOrders.Columns["colCustomer"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 8;
                var textRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + padding,
                    e.CellBounds.Width - 2 * padding,
                    e.CellBounds.Height - 2 * padding);

                // Lấy tên và số điện thoại từ orderData
                var orderItems = _allOrders.Where(o => o.OrderID == orderData.RawOrderID).FirstOrDefault();
                if (orderItems != null)
                {
                    // Tên khách hàng (dòng 1)
                    Font nameFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    var nameRect = new Rectangle(textRect.X, textRect.Y, textRect.Width, 20);
                    TextRenderer.DrawText(e.Graphics, orderItems.CustomerName ?? "",
                        nameFont, nameRect,
                        Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                    // Số điện thoại (dòng 2)
                    Font phoneFont = new Font("Segoe UI", 9, FontStyle.Regular);
                    var phoneRect = new Rectangle(textRect.X, textRect.Y + 24, textRect.Width, 20);
                    TextRenderer.DrawText(e.Graphics, orderItems.CustomerPhone ?? "",
                        phoneFont, phoneRect,
                        Color.FromArgb(100, 100, 100), TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }

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
                OrderDetailForm detailForm = new OrderDetailForm(orderId, orderItems);
                detailForm.ShowDialog();
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
                Width = 400,
                Height = 220,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Cập nhật trạng thái",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            Label textLabel = new Label()
            {
                Left = 30,
                Top = 30,
                Text = "Chọn trạng thái mới:",
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            ComboBox comboBox = new ComboBox()
            {
                Left = 30,
                Top = 65,
                Width = 330,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11),
                Height = 35
            };

            foreach (var option in options)
                comboBox.Items.Add(TranslateStatus(option));

            comboBox.SelectedIndex = 0;

            Button confirmation = new Button()
            {
                Text = "Xác nhận",
                Left = 120,
                Width = 130,
                Height = 40,
                Top = 120,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            confirmation.FlatAppearance.BorderSize = 0;

            Button cancel = new Button()
            {
                Text = "Hủy",
                Left = 280,
                Width = 80,
                Height = 40,
                Top = 120,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            cancel.FlatAppearance.BorderSize = 0;

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

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterOrders2();
        }

        private void FilterOrders2()
        {
            if (_allOrders == null || !_allOrders.Any())
                return;

            string searchText = txtSearch.Text.ToLower();
            string statusFilter = cbStatusFilter.SelectedItem.ToString(); 
            if (statusFilter == "Tất cả trạng thái")
                statusFilter = "Tất cả";
            else if (statusFilter == "Chờ xử lý")
                statusFilter = "Pending";
            else if (statusFilter == "Đã xác nhận")
                statusFilter = "Confirmed";
            else if (statusFilter == "Đang giao")
                statusFilter = "Shipping";
            else if (statusFilter == "Hoàn thành")
                statusFilter = "Delivered";
            else if (statusFilter == "Đã hủy")
                statusFilter = "Cancelled";

            // 1. Lọc theo Text Search (OrderID, CustomerName, CustomerPhone)
            var searchFiltered = string.IsNullOrWhiteSpace(searchText)
                    ? _allOrders
                    : _allOrders
                        .Where(o =>
                            ("DH" + o.OrderID.ToString().PadLeft(6, '0')).ToLower().Contains(searchText) ||
                            (o.CustomerName ?? "").ToLower().Contains(searchText) ||
                            (o.CustomerPhone ?? "").Contains(searchText))
                        .ToList();

            // 2. Lọc theo Status
            if (statusFilter == "Tất cả")
            {
                _filteredOrders = searchFiltered;
            }
            else
            {
                // Lọc những đơn hàng có trạng thái (RawStatus) khớp với statusFilter
                _filteredOrders = searchFiltered
                    .Where(o => o.Status == statusFilter)
                    .ToList();
            }

            BindOrdersToGrid(_filteredOrders);
            UpdateSummary(_filteredOrders);
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