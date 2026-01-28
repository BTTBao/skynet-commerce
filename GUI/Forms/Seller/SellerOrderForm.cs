// SellerOrderForm.cs
using Skynet_Ecommerce.BLL.Services.Seller;
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerOrderForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly int _shopId;

        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 0;
        private List<Order> _allOrders;
        private List<Order> _filteredOrders;

        // Mapping trạng thái tiếng Việt sang tiếng Anh
        private Dictionary<string, string> _statusMapping = new Dictionary<string, string>
        {
            { "Tất cả", "All" },
            { "Chờ xác nhận", "Pending" },
            { "Đã xác nhận", "Confirmed" },
            { "Đang chuẩn bị", "Preparing" },
            { "Đang giao", "Shipping" },
            { "Đã giao", "Delivered" },
            { "Hoàn thành", "Completed" },
            { "Đã hủy", "Cancelled" }
        };

        private Dictionary<string, string> _statusMappingReverse = new Dictionary<string, string>
        {
            { "Pending", "Chờ xác nhận" },
            { "Confirmed", "Đã xác nhận" },
            { "Preparing", "Đang chuẩn bị" },
            { "Shipping", "Đang giao" },
            { "Delivered", "Đã giao" },
            { "Completed", "Hoàn thành" },
            { "Cancelled", "Đã hủy" }
        };

        public SellerOrderForm(int shopId)
        {
            InitializeComponent();

            _shopId = shopId;

            // Khởi tạo services
            var context = new ApplicationDbContext();
            var unitOfWork = new UnitOfWork(context);
            _orderService = new OrderService(unitOfWork);
        }

        public SellerOrderForm() : this(1) // Constructor mặc định với shopId = 1
        {
        }

        private void SellerOrderForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                _allOrders = _orderService.GetOrdersByShop(_shopId).ToList();
                _filteredOrders = _allOrders;

                _totalPages = (int)Math.Ceiling((double)_filteredOrders.Count / _pageSize);
                if (_totalPages == 0) _totalPages = 1;
                _currentPage = 1;

                DisplayOrders();
                UpdatePaginationInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrders()
        {
            try
            {
                dgvOrders.Rows.Clear();

                var ordersToDisplay = _filteredOrders
                    .Skip((_currentPage - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToList();

                foreach (var order in ordersToDisplay)
                {
                    // Lấy sản phẩm đầu tiên trong đơn hàng
                    var firstOrderDetail = order.OrderDetails?.FirstOrDefault();
                    if (firstOrderDetail == null) continue;

                    int rowIndex = dgvOrders.Rows.Add();
                    DataGridViewRow row = dgvOrders.Rows[rowIndex];

                    // Mã đơn
                    row.Cells["OrderId"].Value = "#" + order.OrderID;

                    // Ảnh sản phẩm
                    var productImage = firstOrderDetail.Product?.ProductImages?.FirstOrDefault(img => img.IsPrimary == true)
                                      ?? firstOrderDetail.Product?.ProductImages?.FirstOrDefault();

                    if (productImage != null && !string.IsNullOrEmpty(productImage.ImageURL))
                    {
                        try
                        {
                            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, productImage.ImageURL);
                            if (File.Exists(imagePath))
                            {
                                Image originalImage = Image.FromFile(imagePath);
                                row.Cells["ProductImage"].Value = originalImage;
                            }
                            else
                            {
                                row.Cells["ProductImage"].Value = null;
                            }
                        }
                        catch
                        {
                            row.Cells["ProductImage"].Value = null;
                        }
                    }

                    // Thông tin sản phẩm
                    string productInfo = firstOrderDetail.Product?.Name ?? "N/A";

                    // Thêm thông tin variant nếu có
                    if (firstOrderDetail.ProductVariant != null)
                    {
                        var variant = firstOrderDetail.ProductVariant;
                        List<string> variantInfo = new List<string>();

                        if (!string.IsNullOrEmpty(variant.Color))
                            variantInfo.Add($"Màu: {variant.Color}");

                        if (!string.IsNullOrEmpty(variant.Size))
                            variantInfo.Add($"Size: {variant.Size}");

                        if (variantInfo.Any())
                            productInfo += "\n" + string.Join(", ", variantInfo);
                    }

                    // Nếu có nhiều sản phẩm, thêm thông báo
                    if (order.OrderDetails.Count > 1)
                    {
                        productInfo += $"\n(+{order.OrderDetails.Count - 1} sản phẩm khác)";
                    }

                    row.Cells["ProductInfo"].Value = productInfo;

                    // Số lượng (tổng số lượng tất cả sản phẩm)
                    int totalQuantity = order.OrderDetails.Sum(od => od.Quantity ?? 0);
                    row.Cells["Quantity"].Value = totalQuantity;

                    // Tổng tiền
                    row.Cells["Total"].Value = (order.TotalAmount ?? 0).ToString("N0") + " VNĐ";

                    // Trạng thái
                    string statusVN = _statusMappingReverse.ContainsKey(order.Status)
                        ? _statusMappingReverse[order.Status]
                        : order.Status;
                    row.Cells["Status"].Value = statusVN;

                    // Ngày đặt
                    row.Cells["OrderDate"].Value = order.CreatedAt?.ToString("dd/MM/yyyy HH:mm") ?? "";

                    // Tô màu theo trạng thái
                    Color statusColor = GetStatusColor(order.Status);
                    row.Cells["Status"].Style.ForeColor = statusColor;
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    

                    // Lưu order vào Tag
                    row.Tag = order;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị đơn hàng: " + ex.Message + "\n" + ex.StackTrace, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Pending":
                    return Color.Orange;
                case "Confirmed":
                case "Preparing":
                    return Color.Blue;
                case "Shipping":
                    return Color.Purple;
                case "Delivered":
                case "Completed":
                    return Color.Green;
                case "Cancelled":
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        private void UpdatePaginationInfo()
        {
            if (_totalPages == 0)
            {
                lblPageInfo.Text = "0 / 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
            }
            else
            {
                lblPageInfo.Text = $"{_currentPage} / {_totalPages}";
                btnPrevPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < _totalPages;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrders()
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();
                string selectedStatusVN = cmbStatusFilter.SelectedItem?.ToString() ?? "Tất cả";
                string selectedStatus = _statusMapping.ContainsKey(selectedStatusVN)
                    ? _statusMapping[selectedStatusVN]
                    : "All";

                _filteredOrders = _allOrders;

                // Lọc theo trạng thái
                if (selectedStatus != "All")
                {
                    _filteredOrders = _filteredOrders.Where(o => o.Status == selectedStatus).ToList();
                }

                // Lọc theo từ khóa tìm kiếm
                if (!string.IsNullOrEmpty(searchText))
                {
                    _filteredOrders = _filteredOrders.Where(o =>
                        o.OrderID.ToString().Contains(searchText) ||
                        (o.OrderDetails != null && o.OrderDetails.Any(od =>
                            od.Product != null && od.Product.Name.ToLower().Contains(searchText)))
                    ).ToList();
                }

                _totalPages = (int)Math.Ceiling((double)_filteredOrders.Count / _pageSize);
                if (_totalPages == 0) _totalPages = 1;
                _currentPage = 1;

                DisplayOrders();
                UpdatePaginationInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc đơn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayOrders();
                UpdatePaginationInfo();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayOrders();
                UpdatePaginationInfo();
            }
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
            Order order = row.Tag as Order;

            if (order == null) return;

            // Nút Cập nhật trạng thái
            if (dgvOrders.Columns[e.ColumnIndex].Name == "UpdateStatus")
            {
                UpdateOrderStatus(order, row);
            }

            // Nút Xem chi tiết
            if (dgvOrders.Columns[e.ColumnIndex].Name == "ViewDetail")
            {
                ViewOrderDetail(order);
            }
        }

        private void UpdateOrderStatus(Order order, DataGridViewRow row)
        {
            try
            {
                string currentStatus = order.Status;

                // Kiểm tra nếu đơn đã hoàn thành hoặc hủy
                if (currentStatus == "Completed" || currentStatus == "Cancelled")
                {
                    MessageBox.Show("Đơn hàng này không thể cập nhật trạng thái!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string newStatus = GetNextStatus(currentStatus);

                if (newStatus == null)
                {
                    MessageBox.Show("Đơn hàng này không thể cập nhật trạng thái!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string currentStatusVN = _statusMappingReverse.ContainsKey(currentStatus)
                    ? _statusMappingReverse[currentStatus]
                    : currentStatus;

                string newStatusVN = _statusMappingReverse.ContainsKey(newStatus)
                    ? _statusMappingReverse[newStatus]
                    : newStatus;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn cập nhật trạng thái đơn hàng #{order.OrderID}\n" +
                    $"Từ: {currentStatusVN}\n" +
                    $"Sang: {newStatusVN}?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = _orderService.UpdateOrderStatus(order.OrderID, newStatus);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại order
                        order.Status = newStatus;
                        row.Cells["Status"].Value = newStatusVN;
                        row.Cells["Status"].Style.ForeColor = GetStatusColor(newStatus);

                        // Vô hiệu hóa nút nếu đạt trạng thái cuối
                       
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNextStatus(string currentStatus)
        {
            // Quy trình trạng thái: Pending -> Confirmed -> Preparing -> Shipping -> Delivered -> Completed
            switch (currentStatus)
            {
                case "Pending":
                    return "Confirmed";
                case "Confirmed":
                    return "Preparing";
                case "Preparing":
                    return "Shipping";
                case "Shipping":
                    return "Delivered";
                case "Delivered":
                    return "Completed";
                case "Completed":
                case "Cancelled":
                    return null; // Không thể cập nhật thêm
                default:
                    return null;
            }
        }

        private void ViewOrderDetail(Order order)
        {
            try
            {
                // Mở form chi tiết đơn hàng mới
                SellerOrderDetailForm detailForm = new SellerOrderDetailForm(order);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem chi tiết đơn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}