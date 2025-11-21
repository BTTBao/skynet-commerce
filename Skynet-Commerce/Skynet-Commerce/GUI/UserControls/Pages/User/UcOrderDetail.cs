using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcOrderDetail : UserControl
    {
        public UcOrderDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm nhận dữ liệu và hiển thị lên thẻ đơn hàng
        /// </summary>
        public void SetData(string orderId, string date, string shopName, string productName,
                            string variant, int quantity, string price, string totalMoney,
                            Image productImage, string status)
        {
            lblOrderId.Text = "Mã đơn: " + orderId;
            lblDate.Text = "|   " + date;
            lblShopName.Text = shopName;
            lblProductName.Text = productName;
            lblVariant.Text = "Phân loại: " + variant;
            lblQuantity.Text = "x" + quantity;
            lblPrice.Text = price;
            lblTotalMoney.Text = totalMoney;

            if (productImage != null)
                pbProductImage.Image = productImage;

            SetStatusStyle(status);
        }

        /// <summary>
        /// Xử lý giao diện theo trạng thái đơn hàng
        /// </summary>
        private void SetStatusStyle(string status)
        {
            lblStatus.Text = status.ToUpper();

            // Reset về mặc định
            btnActionSecondary.Visible = true;
            btnActionPrimary.FillColor = Color.FromArgb(238, 77, 45); // Cam Shopee
            btnActionPrimary.ForeColor = Color.White;
            btnActionPrimary.BorderColor = Color.FromArgb(238, 77, 45);
            btnActionPrimary.BorderThickness = 1;

            switch (status)
            {
                case "Hoàn thành":
                    lblStatus.ForeColor = Color.FromArgb(46, 204, 113); // Xanh lá
                    btnActionPrimary.Text = "Mua lại";
                    btnActionSecondary.Text = "Đánh giá";
                    break;

                case "Đang giao":
                    lblStatus.ForeColor = Color.FromArgb(52, 152, 219); // Xanh dương
                    btnActionPrimary.Text = "Đã nhận hàng";
                    btnActionSecondary.Visible = false;
                    break;

                case "Chờ xác nhận":
                    lblStatus.ForeColor = Color.FromArgb(243, 156, 18); // Vàng cam

                    // Đổi nút chính sang màu trắng, viền xám
                    btnActionPrimary.Text = "Chi tiết";
                    btnActionPrimary.FillColor = Color.White;
                    btnActionPrimary.ForeColor = Color.Black;
                    btnActionPrimary.BorderColor = Color.Silver;

                    btnActionSecondary.Text = "Hủy đơn";
                    break;

                case "Đã hủy":
                    lblStatus.ForeColor = Color.Gray; // Xám
                    btnActionPrimary.Text = "Mua lại";
                    btnActionSecondary.Visible = false;
                    break;

                default:
                    lblStatus.ForeColor = Color.Black;
                    break;
            }
        }
    }
}