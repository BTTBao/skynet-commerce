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
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                // 1. Gọi BLL để lấy dữ liệu
                var orderList = _orderService.GetAllOrders();

                // 2. Xóa dữ liệu cũ trên giao diện
                _flowPanel.Controls.Clear();

                // 3. Đổ dữ liệu vào UserControl
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

                    // Thêm vào panel
                    _flowPanel.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}