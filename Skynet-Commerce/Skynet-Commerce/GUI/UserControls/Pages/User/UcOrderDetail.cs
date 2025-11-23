using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcOrderDetail : UserControl
    {
        public event EventHandler<int> ButtonCancelClicked;
        public event EventHandler<int> ButtonReceiveClicked;
        public event EventHandler<int> ButtonBuyAgainClicked;

        private int _currentOrderId;

        public UcOrderDetail()
        {
            InitializeComponent();
            btnActionPrimary.Click += BtnActionPrimary_Click;
            btnActionSecondary.Click += BtnActionSecondary_Click;
        }

        // Cập nhật SetData thêm tham số 'address' ở cuối
        public void SetData(int orderId, DateTime? date, string shopName, string status,
                            decimal totalAmount, string prodName, int prodCount,
                            string imgUrl, decimal price, int qty, string address)
        {
            _currentOrderId = orderId;

            lblOrderId.Text = $"Mã đơn: {orderId}";
            lblDate.Text = date.HasValue ? $"| {date.Value:dd/MM/yyyy HH:mm}" : "";
            lblShopName.Text = shopName;
            lblProductName.Text = prodName;
            lblPrice.Text = string.Format("{0:N0}đ", price);
            lblQuantity.Text = $"x{qty}";
            lblTotalMoney.Text = string.Format("{0:N0}đ", totalAmount);

            // Gán địa chỉ
            addressLb.Text = string.IsNullOrEmpty(address) ? "Địa chỉ: Không xác định" : $"Giao đến: {address}";

            if (prodCount > 1) lblVariant.Text = $"Xem thêm {prodCount - 1} sản phẩm khác";
            else lblVariant.Text = "Phân loại: Mặc định";

            SetStatusUI(status);

            if (!string.IsNullOrEmpty(imgUrl))
            {
                try { pbProductImage.LoadAsync(imgUrl); } catch { }
            }
        }

        private void SetStatusUI(string status)
        {
            lblStatus.Text = status.ToUpper();
            btnActionSecondary.Visible = true;
            btnActionPrimary.Visible = true;
            btnActionPrimary.Enabled = true;

            // Lưu trạng thái vào Tag
            btnActionPrimary.Tag = status;
            btnActionSecondary.Tag = status;

            switch (status)
            {
                case "Pending":
                case "Chờ xác nhận":
                    lblStatus.ForeColor = Color.Orange;
                    btnActionPrimary.Text = "Đang xử lý";
                    btnActionPrimary.Enabled = false;
                    btnActionPrimary.FillColor = Color.White;
                    btnActionPrimary.ForeColor = Color.Black;
                    btnActionPrimary.BorderColor = Color.Silver;
                    btnActionPrimary.BorderThickness = 1;
                    btnActionSecondary.Text = "Hủy Đơn";
                    break;

                case "Shipping":
                case "Đang giao":
                    lblStatus.ForeColor = Color.DodgerBlue;
                    btnActionPrimary.Text = "Đã Nhận Hàng";
                    btnActionPrimary.FillColor = Color.Black;
                    btnActionPrimary.ForeColor = Color.White;
                    btnActionSecondary.Visible = false;
                    break;

                case "Completed":
                case "Hoàn thành":
                    lblStatus.ForeColor = Color.Green;
                    btnActionPrimary.Text = "Mua Lại";
                    btnActionPrimary.FillColor = Color.Black;
                    btnActionPrimary.ForeColor = Color.White;
                    btnActionSecondary.Text = "Đánh giá";
                    break;

                case "Cancelled":
                case "Đã hủy":
                    lblStatus.ForeColor = Color.Gray;
                    btnActionPrimary.Text = "Mua Lại";
                    btnActionPrimary.FillColor = Color.Black;
                    btnActionPrimary.ForeColor = Color.White;
                    btnActionSecondary.Visible = false;
                    break;
            }
        }

        private void BtnActionPrimary_Click(object sender, EventArgs e)
        {
            string status = btnActionPrimary.Tag?.ToString();
            if (status == "Shipping" || status == "Đang giao")
            {
                ButtonReceiveClicked?.Invoke(this, _currentOrderId);
            }
            else if (status == "Completed" || status == "Cancelled" || status == "Hoàn thành" || status == "Đã hủy")
            {
                ButtonBuyAgainClicked?.Invoke(this, _currentOrderId);
            }
        }

        private void BtnActionSecondary_Click(object sender, EventArgs e)
        {
            string status = btnActionSecondary.Tag?.ToString();
            if (status == "Pending" || status == "Chờ xác nhận")
            {
                ButtonCancelClicked?.Invoke(this, _currentOrderId);
            }
        }
    }
}