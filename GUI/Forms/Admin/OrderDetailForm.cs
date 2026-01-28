using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Services.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class OrderDetailForm : Form
    {
        private readonly int _orderId;
        private readonly OrderService _orderService;

        // Các controls hiển thị dữ liệu
        private Guna2TextBox _txtOrderId, _txtDate, _txtStatus, _txtTotal, _txtShop, _txtBuyer;
        private Guna2TextBox _txtReceiver, _txtPhone, _txtAddress, _txtPartner, _txtTracking;

        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            new Guna.UI2.WinForms.Guna2ShadowForm(this);

            _orderId = orderId;
            _orderService = new OrderService();

            // 1. Setup giao diện (Tạo các TextBox hiển thị)
            SetupTabGeneralUI();
            SetupTabShippingUI();
            SetupGrids();

            LoadData();
        }

        private void SetupGrids()
        {
            // Grid Sản phẩm
            _gridItems.AutoGenerateColumns = false;
            _gridItems.Columns.Add("colName", "Sản phẩm");
            _gridItems.Columns.Add("colVar", "Phân loại");
            _gridItems.Columns.Add("colQty", "SL");
            _gridItems.Columns.Add("colPrice", "Đơn giá");
            _gridItems.Columns.Add("colSub", "Thành tiền");

            _gridItems.Columns[0].DataPropertyName = "ProductName";
            _gridItems.Columns[1].DataPropertyName = "VariantInfo";
            _gridItems.Columns[2].DataPropertyName = "Quantity";
            _gridItems.Columns[3].DataPropertyName = "Price";
            _gridItems.Columns[4].DataPropertyName = "SubTotal";

            // Format cột tiền
            _gridItems.Columns[3].DefaultCellStyle.Format = "N0";
            _gridItems.Columns[4].DefaultCellStyle.Format = "N0";

            // Grid Lịch sử
            _gridHistory.AutoGenerateColumns = false;
            _gridHistory.Columns.Add("colOld", "Trạng thái cũ");
            _gridHistory.Columns.Add("colNew", "Trạng thái mới");
            _gridHistory.Columns.Add("colTime", "Thời gian");

            _gridHistory.Columns[0].DataPropertyName = "OldStatus";
            _gridHistory.Columns[1].DataPropertyName = "NewStatus";
            _gridHistory.Columns[2].DataPropertyName = "ChangedAt";
            _gridHistory.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void SetupTabGeneralUI()
        {
            int y = 20;
            _txtOrderId = AddField(_tabGeneral, "Mã đơn hàng:", 20, y);
            _txtDate = AddField(_tabGeneral, "Ngày đặt:", 320, y);
            _txtStatus = AddField(_tabGeneral, "Trạng thái:", 620, y);

            y += 70;
            _txtShop = AddField(_tabGeneral, "Cửa hàng (Seller):", 20, y, 280);
            _txtBuyer = AddField(_tabGeneral, "Người mua (Account):", 320, y, 280);
            _txtTotal = AddField(_tabGeneral, "Tổng tiền (gồm Ship):", 620, y);
            _txtTotal.ForeColor = Color.Red;
            _txtTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void SetupTabShippingUI()
        {
            int y = 20;
            _txtReceiver = AddField(_tabShipping, "Người nhận hàng:", 20, y, 300);
            _txtPhone = AddField(_tabShipping, "Số điện thoại:", 350, y, 200);

            y += 70;
            _txtAddress = AddField(_tabShipping, "Địa chỉ giao hàng:", 20, y, 530, true); // Multiline

            y += 90; // Cách xa hơn vì Address multiline
            _txtPartner = AddField(_tabShipping, "Đơn vị vận chuyển:", 20, y, 300);
            _txtTracking = AddField(_tabShipping, "Mã vận đơn (Tracking):", 350, y, 200);
        }

        // Helper tạo TextBox nhanh
        private Guna2TextBox AddField(TabPage page, string label, int x, int y, int w = 200, bool multiline = false)
        {
            Label lbl = new Label { Text = label, Location = new Point(x, y), AutoSize = true, ForeColor = Color.Gray };
            Guna2TextBox txt = new Guna2TextBox
            {
                Location = new Point(x, y + 25),
                Size = new Size(w, multiline ? 60 : 36),
                ReadOnly = true,
                BorderRadius = 5,
                FillColor = Color.WhiteSmoke,
                Multiline = multiline
            };
            page.Controls.Add(lbl);
            page.Controls.Add(txt);
            return txt;
        }

        private void LoadData()
        {
            try
            {
                var data = _orderService.GetOrderDetail(_orderId);
                if (data == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu đơn hàng.");
                    this.Close();
                    return;
                }

                _lblTitle.Text = $"Chi tiết đơn hàng #{data.OrderID}";

                // Tab 1: General
                _txtOrderId.Text = data.OrderID.ToString();
                _txtDate.Text = data.OrderDate.ToString("dd/MM/yyyy HH:mm");
                _txtStatus.Text = data.Status;
                _txtTotal.Text = data.TotalAmount.ToString("N0") + " đ";
                _txtShop.Text = data.ShopName;
                _txtBuyer.Text = $"{data.BuyerName} ({data.BuyerEmail})";

                // Bind Grid Items
                _gridItems.DataSource = data.Items;

                // Tab 2: Shipping
                _txtReceiver.Text = data.ReceiverName;
                _txtPhone.Text = data.ReceiverPhone;
                _txtAddress.Text = data.DeliveryAddress;
                _txtPartner.Text = data.ShippingPartner;
                _txtTracking.Text = data.TrackingCode;

                // Tab 3: History
                _gridHistory.DataSource = data.HistoryLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}