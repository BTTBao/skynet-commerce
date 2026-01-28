// SellerOrderDetailForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerOrderDetailForm : Form
    {
        private readonly Order _order;

        // Mapping trạng thái
        private Dictionary<string, string> _statusMappingReverse = new Dictionary<string, string>
        {
            { "Pending", "Chờ xác nhận" },
            { "Confirmed", "Đã xác nhận" },
            { "Preparing", "Đang chuẩn bị" },
            { "Shipping", "Đang giao" },
            { "Delivered", "Đã giao" },
            { "Completed", "Hoàn thành" },
            { "Cancelled", "Đã hủy" },
            { "Settled", "Đã quyết toán" }
        };

        private Dictionary<string, string> _shippingStatusMapping = new Dictionary<string, string>
        {
            { "WaitingForPickup", "Chờ lấy hàng" },
            { "Picked", "Đã lấy hàng" },
            { "InTransit", "Đang vận chuyển" },
            { "OutForDelivery", "Đang giao hàng" },
            { "Delivered", "Đã giao hàng" },
            { "Failed", "Giao thất bại" },
            { "Returned", "Đã hoàn trả" }
        };

        public SellerOrderDetailForm(Order order)
        {
            InitializeComponent();
            _order = order;
        }

        private void SellerOrderDetailForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                // KHỐI 1: Thông tin đơn hàng và khách hàng
                LoadOrderInfo();

                // KHỐI 2: Thông tin sản phẩm
                LoadProductInfo();

                // KHỐI 3: Thông tin vận chuyển
                LoadShippingInfo();

                // Tổng tiền
                LoadTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderInfo()
        {
            // Mã đơn hàng
            lblOrderId.Text = $"Mã đơn hàng: #{_order.OrderID}";

            // Ngày đặt
            lblOrderDate.Text = $"Ngày đặt: {_order.CreatedAt?.ToString("dd/MM/yyyy HH:mm") ?? "N/A"}";

            // Trạng thái
            string statusVN = _statusMappingReverse.ContainsKey(_order.Status)
                ? _statusMappingReverse[_order.Status]
                : _order.Status;
            lblStatus.Text = $"Trạng thái: {statusVN}";
            lblStatus.ForeColor = GetStatusColor(_order.Status);

            // Thông tin khách hàng
            if (_order.UserAddress != null)
            {
                lblReceiverName.Text = $"Người nhận: {_order.UserAddress.ReceiverFullName}";
                lblReceiverPhone.Text = $"Số điện thoại: {_order.UserAddress.ReceiverPhone}";

                string fullAddress = $"{_order.UserAddress.AddressLine}, " +
                                   $"{_order.UserAddress.Ward}, " +
                                   $"{_order.UserAddress.District}, " +
                                   $"{_order.UserAddress.Province}";
                lblAddress.Text = $"Địa chỉ: {fullAddress}";
            }
            else
            {
                lblReceiverName.Text = "Người nhận: N/A";
                lblReceiverPhone.Text = "Số điện thoại: N/A";
                lblAddress.Text = "Địa chỉ: N/A";
            }
        }

        private void LoadProductInfo()
        {
            dgvProducts.Rows.Clear();

            if (_order.OrderDetails != null && _order.OrderDetails.Any())
            {
                foreach (var detail in _order.OrderDetails)
                {
                    // Thông tin variant
                    string variantInfo = "";
                    if (detail.ProductVariant != null)
                    {
                        List<string> variants = new List<string>();
                        if (!string.IsNullOrEmpty(detail.ProductVariant.Color))
                            variants.Add($"Màu: {detail.ProductVariant.Color}");
                        if (!string.IsNullOrEmpty(detail.ProductVariant.Size))
                            variants.Add($"Size: {detail.ProductVariant.Size}");
                        variantInfo = string.Join(", ", variants);
                    }

                    // Tính toán
                    int quantity = detail.Quantity ?? 0;
                    decimal unitPrice = detail.UnitPrice ?? 0;
                    decimal total = quantity * unitPrice;

                    // Thêm row
                    dgvProducts.Rows.Add(
                        detail.Product?.Name ?? "N/A",
                        string.IsNullOrEmpty(variantInfo) ? "Không có" : variantInfo,
                        quantity,
                        unitPrice.ToString("N0") + " VNĐ",
                        total.ToString("N0") + " VNĐ"
                    );
                }
            }
        }

        private void LoadShippingInfo()
        {
            // Lấy thông tin vận chuyển
            var shippingInfo = _order.OrderShippingInfoes?.FirstOrDefault();

            if (shippingInfo != null)
            {
                // Đơn vị vận chuyển
                string shipperName = shippingInfo.ShippingPartner?.Name ?? "Chưa chọn";
                lblShipper.Text = $"Đơn vị vận chuyển: {shipperName}";

                // Mã vận đơn
                string trackingCode = string.IsNullOrEmpty(shippingInfo.TrackingCode)
                    ? "Chưa có"
                    : shippingInfo.TrackingCode;
                lblTrackingCode.Text = $"Mã vận đơn: {trackingCode}";

                // Phí vận chuyển
                decimal shippingFee = shippingInfo.ShippingFee ?? 0;
                lblShippingFee.Text = $"Phí vận chuyển: {shippingFee.ToString("N0")} VNĐ";

                // Ngày dự kiến giao
                string estimatedDate = shippingInfo.EstimatedDeliveryDate?.ToString("dd/MM/yyyy") ?? "Chưa xác định";
                lblEstimatedDate.Text = $"Dự kiến giao: {estimatedDate}";

                // Trạng thái vận chuyển
                string shippingStatus = _shippingStatusMapping.ContainsKey(shippingInfo.Status)
                    ? _shippingStatusMapping[shippingInfo.Status]
                    : shippingInfo.Status;
                lblShippingStatus.Text = $"Trạng thái: {shippingStatus}";
                lblShippingStatus.ForeColor = GetShippingStatusColor(shippingInfo.Status);
            }
            else
            {
                lblShipper.Text = "Đơn vị vận chuyển: Chưa có thông tin";
                lblTrackingCode.Text = "Mã vận đơn: N/A";
                lblShippingFee.Text = "Phí vận chuyển: 0 VNĐ";
                lblEstimatedDate.Text = "Dự kiến giao: N/A";
                lblShippingStatus.Text = "Trạng thái: Chưa có thông tin";
            }
        }

        private void LoadTotalAmount()
        {
            decimal totalAmount = _order.TotalAmount ?? 0;
            lblTotalAmount.Text = $"Tổng cộng: {totalAmount.ToString("N0")} VNĐ";
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

        private Color GetShippingStatusColor(string status)
        {
            switch (status)
            {
                case "WaitingForPickup":
                case "Picked":
                    return Color.Orange;
                case "InTransit":
                case "OutForDelivery":
                    return Color.Blue;
                case "Delivered":
                    return Color.Green;
                case "Failed":
                case "Returned":
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}