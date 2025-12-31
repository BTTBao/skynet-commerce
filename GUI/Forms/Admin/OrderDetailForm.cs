using Skynet_Commerce.BLL.Services.Admin;
using System;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class OrderDetailForm : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService;

        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            new Guna.UI2.WinForms.Guna2ShadowForm(this);

            _orderId = orderId;
            _orderService = new OrderService();

            // Sự kiện đóng
            _btnOK.Click += (s, e) => this.Close();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _orderService.GetOrderDetail(_orderId);
                if (data == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.");
                    this.Close();
                    return;
                }

                // Bind thông tin chung
                _lblTitle.Text = $"Chi tiết đơn hàng #{data.OrderID}";
                _lblBuyerVal.Text = data.BuyerName + (!string.IsNullOrEmpty(data.BuyerEmail) ? $" ({data.BuyerEmail})" : "");
                _lblDateVal.Text = data.OrderDate.ToString("dd/MM/yyyy HH:mm");
                _lblStatusVal.Text = data.Status;
                _lblTotalVal.Text = data.TotalAmount.ToString("N0") + " đ";

                // Bind GridView
                _gridItems.Rows.Clear();
                foreach (var item in data.Items)
                {
                    _gridItems.Rows.Add(
                        item.ProductName,
                        item.Quantity,
                        item.Price.ToString("N0"),
                        item.SubTotal.ToString("N0")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}