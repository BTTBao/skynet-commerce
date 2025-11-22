using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
            InitializeCustomSettings();
            LoadSampleData();
        }

        private void InitializeCustomSettings()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.CellPainting += dgvProducts_CellPainting;
            dgvProducts.RowTemplate.Height = 80;
        }

        private void LoadSampleData()
        {
            List<ProductUI> products = new List<ProductUI>
            {
                new ProductUI { ID="SP001", ProductName = "Áo thun nam basic", Price = "148.000₫", Stock = 50, Sold = 245, Status = "Hiển thị", ProductImage = null },
                new ProductUI { ID="SP002", ProductName = "Áo khoác denim", Price = "450.000₫", Stock = 30, Sold = 123, Status = "Hiển thị", ProductImage = null },
                new ProductUI { ID="SP003", ProductName = "Giày thể thao nam", Price = "1.200.000₫", Stock = 15, Sold = 89, Status = "Hiển thị", ProductImage = null }
            };

            dgvProducts.DataSource = products;
            lblItemCount.Text = $"Hiển thị {products.Count} sản phẩm";
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvProducts.Columns["colProduct"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductUI;
                if (product != null)
                {
                    int padding = 5;
                    int imageSize = e.CellBounds.Height - 2 * padding;
                    Rectangle imageRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + padding, imageSize, imageSize);

                    // Vẽ ảnh
                    if (product.ProductImage != null)
                        e.Graphics.DrawImage(product.ProductImage, imageRect);

                    // Vẽ tên sản phẩm
                    var nameRect = new Rectangle(imageRect.Right + padding, e.CellBounds.Y + padding, e.CellBounds.Width - imageRect.Width - 3 * padding, (e.CellBounds.Height - 2 * padding) / 2);
                    TextRenderer.DrawText(e.Graphics, product.ProductName, e.CellStyle.Font, nameRect, Color.Black, TextFormatFlags.Left | TextFormatFlags.Top);

                    // Vẽ ID
                    var idRect = new Rectangle(imageRect.Right + padding, e.CellBounds.Y + padding + nameRect.Height, e.CellBounds.Width - imageRect.Width - 3 * padding, nameRect.Height);
                    TextRenderer.DrawText(e.Graphics, product.ID, e.CellStyle.Font, idRect, Color.Gray, TextFormatFlags.Left | TextFormatFlags.Top);

                    e.Handled = true;
                }
            }
            else if (e.ColumnIndex == dgvProducts.Columns["colAction"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductUI;
                if (product != null)
                {
                    int buttonWidth = 50; // chiều rộng nút
                    int buttonHeight = e.CellBounds.Height - 50; // chiều cao nhỏ hơn hàng
                    int padding = 5;

                    // nút Sửa
                    Rectangle editRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2, buttonWidth, buttonHeight);
                    // nút Xóa
                    Rectangle deleteRect = new Rectangle(editRect.Right + padding, e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2, buttonWidth, buttonHeight);
                    // nút Ẩn/Hiển thị
                    Rectangle toggleRect = new Rectangle(deleteRect.Right + padding, e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2, buttonWidth, buttonHeight);

                    // vẽ các nút
                    ButtonRenderer.DrawButton(e.Graphics, editRect, "Sửa", e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);
                    ButtonRenderer.DrawButton(e.Graphics, deleteRect, "Xóa", e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                    string toggleText = product.Status == "Hiển thị" ? "Ẩn" : "Hiển thị";
                    ButtonRenderer.DrawButton(e.Graphics, toggleRect, toggleText, e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                    e.Handled = true;
                }
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            new FormAddProduct().Show();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍 Tìm kiếm sản phẩm...")
                txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "🔍 Tìm kiếm sản phẩm...";
        }
    }

    public class ProductUI
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        public Image ProductImage { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public string Status { get; set; }
        public int ShopID { get; internal set; }
        public int CategoryID { get; internal set; }
        public int ProductID { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int StockQuantity { get; internal set; }
        public int SoldCount { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
