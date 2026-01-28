using Skynet_Commerce.BLL.Models.Admin; // Giả định namespace chứa ViewModel
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Ecommerce.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class OrdersForm : Form
    {
        private readonly OrderService _orderService;

        private PaginationHelper _paginationHelper;
        private List<OrderViewModel> _allOrdersCache = new List<OrderViewModel>(); // Giả sử ViewModel là OrderViewModel
        public OrdersForm()
        {
            InitializeComponent();
            _orderService = new OrderService();

            SetupFilters();
            SetupGridEvents();

            _paginationHelper = new PaginationHelper(
                _pnlPagination,
                _cboPageSelect,
                _lblTotalPageText,
                (page) => RenderOrderGrid(), // Callback
                pageSize: 10
            );

        }

        private void SetupGridEvents()
        {
            // Hiệu ứng chuột
            _dgvOrders.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvOrders.Cursor = Cursors.Hand; };
            _dgvOrders.CellMouseLeave += (s, e) => { _dgvOrders.Cursor = Cursors.Default; };

            // Đăng ký sự kiện
            _dgvOrders.CellFormatting += _dgvOrders_CellFormatting;
            _dgvOrders.CellContentClick += _dgvOrders_CellContentClick;
        }

        private void SetupFilters()
        {
            _cboStatus.SelectedIndexChanged -= _cboStatus_SelectedIndexChanged;

            // Danh sách trạng thái chuẩn Tiếng Việt
            var statusList = new List<StatusOption>()
            {
                new StatusOption { DisplayName = "Tất cả trạng thái", Value = "All" },
                new StatusOption { DisplayName = "Chờ xác nhận",      Value = "Pending" },    // Mới đặt
                new StatusOption { DisplayName = "Đang xử lý",        Value = "Processing" }, // Shop đang đóng gói
                new StatusOption { DisplayName = "Đang vận chuyển",   Value = "Shipping" },   // Đã giao bưu tá
                new StatusOption { DisplayName = "Giao thành công",   Value = "Delivered" },  // Khách đã nhận
                new StatusOption { DisplayName = "Đã quyết toán",     Value = "Settled" },    // Admin đã trả tiền Shop
                new StatusOption { DisplayName = "Đã hủy",            Value = "Cancelled" }   // Đơn hủy
            };

            _cboStatus.DataSource = statusList;
            _cboStatus.DisplayMember = "DisplayName";
            _cboStatus.ValueMember = "Value";
            _cboStatus.StartIndex = 0;
            _cboStatus.SelectedIndexChanged += _cboStatus_SelectedIndexChanged;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string keyword = _txtSearch.Text.Trim();
                string status = _cboStatus.SelectedValue != null ? _cboStatus.SelectedValue.ToString() : "All";

                // 1. Lấy toàn bộ dữ liệu từ Service
                var orderList = _orderService.GetAllOrders(keyword, status);

                // 2. Lưu vào Cache
                _allOrdersCache = orderList;

                // 3. Cập nhật PaginationHelper
                _paginationHelper.SetTotalRecords(orderList.Count);

                // 4. Reset về trang 1 (Helper sẽ tự gọi RenderOrderGrid)
                _paginationHelper.SetPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void RenderOrderGrid()
        {
            int page = _paginationHelper.CurrentPage;
            int size = _paginationHelper.PageSize;

            // Cắt dữ liệu (Client-side pagination)
            var pagedData = _allOrdersCache
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToList();

            _dgvOrders.AutoGenerateColumns = false;
            _dgvOrders.DataSource = pagedData;
        }
        // --- ĐỊNH DẠNG HIỂN THỊ (MÀU SẮC, TIỀN TỆ) ---
        private void _dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Format Status (Việt hóa và Tô màu)
            if (_dgvOrders.Columns[e.ColumnIndex].Name == "colStatus")
            {
                string status = e.Value?.ToString();

                // Mặc định
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

                switch (status)
                {
                    case "Pending":
                        e.Value = "● Chờ xác nhận";
                        e.CellStyle.ForeColor = Color.FromArgb(245, 158, 11); // Cam (Amber)
                        break;
                    case "Processing":
                        e.Value = "● Đang xử lý";
                        e.CellStyle.ForeColor = Color.FromArgb(59, 130, 246); // Xanh dương (Blue)
                        break;
                    case "Shipping":
                        e.Value = "● Đang giao";
                        e.CellStyle.ForeColor = Color.FromArgb(139, 92, 246); // Tím (Purple)
                        break;
                    case "Delivered":
                        e.Value = "● Giao thành công";
                        e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá (Green)
                        break;
                    case "Settled":
                        e.Value = "● Đã quyết toán";
                        e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105); // Xanh đậm (Emerald)
                        break;
                    case "Cancelled":
                        e.Value = "● Đã hủy";
                        e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ (Red)
                        break;
                    default:
                        e.Value = "● " + status;
                        e.CellStyle.ForeColor = Color.Gray;
                        break;
                }
            }

            // 2. Format Cột Tiền (Bold)
            if (_dgvOrders.Columns[e.ColumnIndex].Name == "colAmount")
            {
                e.CellStyle.ForeColor = Color.FromArgb(59, 130, 246); // Blue Text
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }

            // 3. Format Cột Action
            if (_dgvOrders.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.CellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // --- XỬ LÝ CLICK ---
        private void _dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click vào cột Action
            if (e.RowIndex < 0 || _dgvOrders.Columns[e.ColumnIndex].Name != "colAction") return;

            // Lấy object Order tại dòng đó (Cần cast về ViewModel của bạn)
            // Giả sử tên class ViewModel là OrderViewModel như trong code cũ
            dynamic order = _dgvOrders.Rows[e.RowIndex].DataBoundItem;
            if (order == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            var itemView = menu.Items.Add("Xem chi tiết");
            itemView.Image = SystemIcons.Information.ToBitmap();
            itemView.Click += (s, ev) =>
            {
                using (var frmDetail = new OrderDetailForm(order.OrderID))
                {
                    frmDetail.ShowDialog();
                }
            };

            // Hiển thị Menu
            Rectangle cellRect = _dgvOrders.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvOrders, cellRect.Left, cellRect.Bottom);
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadOrderData();
            }
        }

        private void _cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        public class StatusOption
        {
            public string DisplayName { get; set; }
            public string Value { get; set; }
        }
    }
}