using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class OrdersForm : Form
    {
        private readonly OrderService _orderService;
        public OrdersForm()
        {
            InitializeComponent();
            _orderService = new OrderService();
            // Cấu hình UI ban đầu
            SetupFilters();
        }

        private void SetupFilters()
        {
            // Tạo danh sách các lựa chọn
            var statusList = new List<StatusOption>()
    {
        new StatusOption { DisplayName = "Tất cả",         Value = "All" },
        new StatusOption { DisplayName = "Chờ xác nhận",   Value = "Pending" },
        new StatusOption { DisplayName = "Đang xử lý",     Value = "Processing" },
        new StatusOption { DisplayName = "Đang giao",      Value = "Shipped" },
        new StatusOption { DisplayName = "Đã hoàn thành",  Value = "Completed" },
        new StatusOption { DisplayName = "Đã hủy",         Value = "Cancelled" }
    };

            // Cấu hình ComboBox để hiểu hiển thị cái gì và lấy giá trị gì
            _cboStatus.DataSource = statusList;
            _cboStatus.DisplayMember = "DisplayName"; // Tên property hiển thị
            _cboStatus.ValueMember = "Value";         // Tên property lấy giá trị

            _cboStatus.StartIndex = 0; // Mặc định chọn dòng đầu tiên
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                // 1. Lấy tham số từ giao diện
                string keyword = _txtSearch.Text.Trim();
                string status = _cboStatus.SelectedValue != null ? _cboStatus.SelectedValue.ToString() : "All";

                // 2. Gọi BLL với tham số (Hàm đã sửa ở Bước 1)
                var orderList = _orderService.GetAllOrders(keyword, status);

                // 3. Xóa dữ liệu cũ
                _flowPanel.Controls.Clear();

                // 4. Kiểm tra nếu không có dữ liệu
                if (orderList.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Không tìm thấy đơn hàng nào phù hợp.";
                    lblEmpty.AutoSize = true;
                    lblEmpty.Padding = new Padding(20);
                    lblEmpty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
                    _flowPanel.Controls.Add(lblEmpty);
                    return;
                }

                // Đổ dữ liệu vào UserControl
                _flowPanel.SuspendLayout();
                foreach (var item in orderList)
                {
                    var row = new UcOrderRow();

                    // Truyền dữ liệu từ ViewModel vào Row
                    row.SetData(
                        item.OrderID,    
                        item.BuyerDisplay,      // Buyer: Nguyen Van A
                        item.ShopName,          // Shop: TechStore
                        item.TotalItems.ToString(),
                        item.AmountDisplay,     // Amount: 500.000 đ
                        item.DateDisplay,       // Date: 20/11/2025
                        item.Status             // Status: Completed
                    );
                    row.Width = _flowPanel.Width - 25;
                    // Thêm vào panel
                    _flowPanel.Controls.Add(row);
                }
                _flowPanel.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Loại bỏ tiếng "bíp" của Windows
                LoadOrderData();
            }
        }

        private void _cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        public class StatusOption
        {
            public string DisplayName { get; set; } // Tên hiển thị (Tiếng Việt)
            public string Value { get; set; }       // Giá trị thực (Tiếng Anh)
        }
    }
}