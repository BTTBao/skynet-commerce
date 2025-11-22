using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    public partial class ucOrder : UserControl
    {
        public ucOrder()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Tìm kiếm theo mã đơn hoặc tên khách hàng...")
                txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "🔍 Tìm kiếm theo mã đơn hoặc tên khách hàng...";
        }

        private void LoadSampleData()
        {
            List<Order> orders = new List<Order>
            {
                new Order { OrderID="DH001245", Customer="Nguyễn Văn B\n0912345678", ProductName="Áo thun nam basic", ProductImage=null, OrderDate="2025-11-17 14:30", Total="328.000₫", Status="Chờ xử lý"},
                new Order { OrderID="DH001244", Customer="Trần Thị C\n0987654321", ProductName="Giày thể thao nữ", ProductImage=null, OrderDate="2025-11-17 10:15", Total="920.000₫", Status="Đang giao"},
                new Order { OrderID="DH001243", Customer="Lê Văn D\n0901234567", ProductName="Áo khoác denim", ProductImage=null, OrderDate="2025-11-16 16:45", Total="480.000₫", Status="Hoàn thành"},
                new Order { OrderID="DH001242", Customer="Phạm Thị E\n0911122233", ProductName="Quần jean nam", ProductImage=null, OrderDate="2025-11-16 09:20", Total="429.000₫", Status="Đã hủy"},
            };
            dgvOrders.DataSource = orders;
            UpdateSummary(orders);
        }

        private void UpdateSummary(List<Order> orders)
        {
            lblPending.Text = $"Chờ xử lý: {orders.FindAll(o => o.Status == "Chờ xử lý").Count}";
            lblDelivering.Text = $"Đang giao: {orders.FindAll(o => o.Status == "Đang giao").Count}";
            lblCompleted.Text = $"Hoàn thành: {orders.FindAll(o => o.Status == "Hoàn thành").Count}";
            lblCanceled.Text = $"Đã hủy: {orders.FindAll(o => o.Status == "Đã hủy").Count}";
        }

        private void dgvOrders_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua header

            // Kiểm tra cột tồn tại
            var colProduct = dgvOrders.Columns["colProduct"];
            var colAction = dgvOrders.Columns["colAction"];
            if (colProduct == null || colAction == null) return;

            if (e.ColumnIndex == colProduct.Index)
            {
                e.PaintBackground(e.CellBounds, true);

                var order = dgvOrders.Rows[e.RowIndex].DataBoundItem as Order;
                if (order != null)
                {
                    int padding = 5;
                    int imageSize = e.CellBounds.Height - 2 * padding;
                    Rectangle imageRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + padding, imageSize, imageSize);

                    if (order.ProductImage != null)
                        e.Graphics.DrawImage(order.ProductImage, imageRect);

                    var nameRect = new Rectangle(imageRect.Right + padding, e.CellBounds.Y + padding, e.CellBounds.Width - imageRect.Width - 3 * padding, (e.CellBounds.Height - 2 * padding) / 2);
                    TextRenderer.DrawText(e.Graphics, order.ProductName, e.CellStyle.Font, nameRect, Color.Black, TextFormatFlags.Left | TextFormatFlags.Top);

                    e.Handled = true;
                }
            }
            else if (e.ColumnIndex == colAction.Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int buttonWidth = 40;
                int buttonHeight = 25;
                int padding = 5;

                Rectangle viewRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2, buttonWidth, buttonHeight);
                Rectangle printRect = new Rectangle(viewRect.Right + padding, e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2, buttonWidth, buttonHeight);

                ButtonRenderer.DrawButton(e.Graphics, viewRect, "👁", e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, printRect, "🖨", e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                e.Handled = true;
            }
        }


        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrders.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                MessageBox.Show("Thao tác trên đơn hàng này");
            }
        }
    }

    public class Order
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public Image ProductImage { get; set; }
        public string OrderDate { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
    }
}
