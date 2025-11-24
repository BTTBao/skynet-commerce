using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Services.Seller;
using Skynet_Commerce.BLL.Models.Seller;



namespace Skynet_Commerce
{
    public partial class ucProduct : UserControl
    {
        private ProductServiceForSeller _productService;
        private int _currentShopId;
        private List<ProductSellerDTO> _allProducts;
        private List<ProductSellerDTO> _filteredProducts;


        public ucProduct(int shopId)
        {
            InitializeComponent();
            InitializeCustomSettings();
            SetupDataGridView();
            _productService = new ProductServiceForSeller();
            this.Load += ucProduct_Load;
            _currentShopId = shopId;
        }

        private void InitializeCustomSettings()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.CellPainting += dgvProducts_CellPainting;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.RowTemplate.Height = 80;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;

            txtSearch.TextChanged += txtSearch_TextChanged;
            cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;
        }

        private void SetupDataGridView()
        {
            // Xóa columns cũ nếu có
            dgvProducts.Columns.Clear();

            // Column 1: Sản phẩm (ảnh + tên + ID)
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProduct",
                HeaderText = "Sản phẩm",
                Width = 300,
                ReadOnly = true
            });

            // Column 2: Giá
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Giá",
                DataPropertyName = "Price",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                }
            });

            // Column 3: Tồn kho
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStock",
                HeaderText = "Tồn kho",
                DataPropertyName = "StockQuantity",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Column 4: Đã bán
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSold",
                HeaderText = "Đã bán",
                DataPropertyName = "SoldCount",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.Blue
                }
            });

            // Column 5: Trạng thái
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                Width = 100,
                ReadOnly = true
            });

            // Column 6: Thao tác
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAction",
                HeaderText = "Thao tác",
                Width = 180,
                ReadOnly = true
            });
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private async void LoadProductData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"=== LoadProductData: ShopID = {_currentShopId} ===");

                // Clear grid
                dgvProducts.Rows.Clear();
                lblItemCount.Text = "Đang tải...";

                // Load data từ service (chạy async)
                await Task.Run(() =>
                {
                    _allProducts = _productService.GetAllProducts(_currentShopId);
                });

                System.Diagnostics.Debug.WriteLine($"Loaded {_allProducts.Count} products");

                if (_allProducts.Count == 0)
                {
                    MessageBox.Show(
                        $"Không có sản phẩm nào cho ShopID: {_currentShopId}\n\n" +
                        "Shop này chưa có sản phẩm.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    lblItemCount.Text = "Hiển thị 0 sản phẩm";
                    return;
                }

                _filteredProducts = _allProducts;
                BindProductsToGrid(_filteredProducts);
                UpdateSummary(_filteredProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu sản phẩm:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex}");
            }
        }

        private void BindProductsToGrid(List<ProductSellerDTO> products)
        {
            try
            {
                dgvProducts.Rows.Clear();

                foreach (var product in products)
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.ProductName, // colProduct (sẽ custom paint)
                        product.Price.ToString("N0") + "₫", // colPrice
                        product.StockQuantity, // colStock
                        product.SoldCount, // colSold
                        TranslateStatus(product.Status), // colStatus
                        "Thao tác" // colAction (sẽ custom paint)
                    );

                    // Lưu data vào Tag để dễ truy xuất
                    dgvProducts.Rows[rowIndex].Tag = product;

                    // Đổi màu nếu hết hàng
                    if (product.StockQuantity == 0)
                    {
                        dgvProducts.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
                        dgvProducts.Rows[rowIndex].Cells["colStock"].Style.ForeColor = Color.Red;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Bound {dgvProducts.Rows.Count} products to grid");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bind dữ liệu: {ex.Message}", "Lỗi");
                System.Diagnostics.Debug.WriteLine($"BindProductsToGrid Error: {ex}");
            }
        }

        private void UpdateSummary(List<ProductSellerDTO> products)
        {
            int totalProducts = products.Count;
            int activeProducts = products.Count(p => p.Status == "Active");
            int outOfStockProducts = products.Count(p => p.Status == "OutOfStock" || p.StockQuantity == 0);
            int hiddenProducts = products.Count(p => p.Status == "Hidden");
            int totalSold = products.Sum(p => p.SoldCount);

            lblItemCount.Text = $"Hiển thị {totalProducts} sản phẩm " +
                $"(Đang bán: {activeProducts}, Hết hàng: {outOfStockProducts}, Ẩn: {hiddenProducts})";
        }

        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var product = dgvProducts.Rows[e.RowIndex].Tag as ProductSellerDTO;
            if (product == null) return;

            // Custom paint cho cột Sản phẩm (ảnh + tên + ID)
            if (e.ColumnIndex == dgvProducts.Columns["colProduct"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int imageSize = e.CellBounds.Height - 2 * padding;
                Rectangle imageRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + padding,
                    imageSize,
                    imageSize);

                // Load và vẽ ảnh
                Image productImage = LoadImageFromUrl(product.ImageUrl);
                if (productImage != null)
                {
                    e.Graphics.DrawImage(productImage, imageRect);
                }
                else
                {
                    // Vẽ placeholder
                    e.Graphics.FillRectangle(Brushes.LightGray, imageRect);
                    e.Graphics.DrawRectangle(Pens.Gray, imageRect);
                    TextRenderer.DrawText(e.Graphics, "No Image", e.CellStyle.Font,
                        imageRect, Color.DarkGray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                // Vẽ tên sản phẩm
                var nameRect = new Rectangle(
                    imageRect.Right + padding,
                    e.CellBounds.Y + padding,
                    e.CellBounds.Width - imageRect.Width - 3 * padding,
                    (e.CellBounds.Height - 2 * padding) / 2);

                TextRenderer.DrawText(e.Graphics, product.ProductName,
                    e.CellStyle.Font, nameRect,
                    e.CellStyle.ForeColor, TextFormatFlags.Left | TextFormatFlags.Top);

                // Vẽ ID sản phẩm
                var idRect = new Rectangle(
                    imageRect.Right + padding,
                    nameRect.Bottom,
                    nameRect.Width,
                    nameRect.Height);

                TextRenderer.DrawText(e.Graphics, $"SP{product.ProductID.ToString().PadLeft(6, '0')}",
                    e.CellStyle.Font, idRect,
                    Color.Gray, TextFormatFlags.Left | TextFormatFlags.Top);

                e.Handled = true;
            }
            // Custom paint cho cột Thao tác
            else if (e.ColumnIndex == dgvProducts.Columns["colAction"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int buttonWidth = 50;
                int buttonHeight = 25;
                int padding = 5;

                // Nút Sửa
                Rectangle editRect = new Rectangle(
                    e.CellBounds.X + padding,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth,
                    buttonHeight);

                // Nút Xóa
                Rectangle deleteRect = new Rectangle(
                    editRect.Right + padding,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth,
                    buttonHeight);

                // Nút Ẩn/Hiển thị
                Rectangle toggleRect = new Rectangle(
                    deleteRect.Right + padding,
                    e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2,
                    buttonWidth,
                    buttonHeight);

                // Vẽ các nút
                ButtonRenderer.DrawButton(e.Graphics, editRect, "✏️",
                    e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "🗑️",
                    e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                string toggleText = product.Status == "Active" ? "👁️" : "🔒";
                ButtonRenderer.DrawButton(e.Graphics, toggleRect, toggleText,
                    e.CellStyle.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var product = dgvProducts.Rows[e.RowIndex].Tag as ProductSellerDTO;
            if (product == null) return;

            // Kiểm tra nếu click vào cột Action
            if (e.ColumnIndex == dgvProducts.Columns["colAction"].Index)
            {
                var cellBounds = dgvProducts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPoint = dgvProducts.PointToClient(Cursor.Position);
                int relativeX = clickPoint.X - cellBounds.X;

                // Xác định nút nào được click
                if (relativeX < 60) // Nút Sửa
                {
                    EditProduct(product.ProductID);
                }
                else if (relativeX < 120) // Nút Xóa
                {
                    DeleteProduct(product.ProductID);
                }
                else // Nút Toggle Status
                {
                    ToggleProductStatus(product.ProductID, product.Status);
                }
            }
        }

        private void EditProduct(int productId)
        {
            try
            {
                // Lấy thông tin đầy đủ của sản phẩm
                var productFull = _productService.GetProductFullSellerDTO(productId);

                if (productFull != null)
                {
                    // Mở form edit và truyền data vào
                    FormAddProduct editForm = new FormAddProduct(productFull);
                    editForm.FormClosed += (s, e) => LoadProductData(); // Reload khi đóng form
                    editForm.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct(int productId)
        {
            try
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này?\n\nLưu ý: Hành động này không thể hoàn tác!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = _productService.DeleteProductFullSeller(productId);

                    if (success)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProductData(); // Reload lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleProductStatus(int productId, string currentStatus)
        {
            try
            {
                // Xác định trạng thái mới
                string newStatus;
                if (currentStatus == "Active")
                    newStatus = "Hidden";
                else if (currentStatus == "Hidden")
                    newStatus = "Active";
                else
                {
                    MessageBox.Show("Sản phẩm hết hàng không thể thay đổi trạng thái.\nVui lòng nhập thêm hàng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = _productService.UpdateProductStatus(productId, newStatus);

                if (success)
                {
                    MessageBox.Show($"Đã chuyển trạng thái sang: {TranslateStatus(newStatus)}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductData(); // Reload lại danh sách
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct addForm = new FormAddProduct(_currentShopId);
            addForm.FormClosed += (s, ev) => LoadProductData(); // Reload khi đóng form
            addForm.Show();
        }

        

        

        private void txtSearch_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // Helper methods
        private Image LoadImageFromUrl(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return null;

                using (var webClient = new System.Net.WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(data))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading image from {url}: {ex.Message}");
                return null;
            }
        }

        private string TranslateStatus(string status)
        {
            switch (status)
            {
                case "Active": return "Hiển thị";
                case "Hidden": return "Ẩn";
                case "OutOfStock": return "Hết hàng";
                default: return status;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        // THÊM: Xử lý sự kiện khi ComboBox Trạng thái thay đổi
        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }


        private void FilterProducts()
        {
            if (_allProducts == null || !_allProducts.Any())
                return;

            string searchText = txtSearch.Text.ToLower();
            string selectedStatus = cbStatusFilter.SelectedItem?.ToString(); // Lấy mục được chọn

            // 1. Lọc theo Text Search
            IEnumerable<ProductSellerDTO> query = _allProducts;

            if (!string.IsNullOrWhiteSpace(searchText) && searchText != "🔍 tìm kiếm sản phẩm...")
            {
                query = query.Where(p =>
                    (p.ProductName ?? "").ToLower().Contains(searchText) ||
                    ("SP" + p.ProductID.ToString().PadLeft(6, '0')).ToLower().Contains(searchText));
            }

            // 2. Lọc theo Trạng thái (chỉ khi không phải "Tất cả trạng thái")
            if (selectedStatus != null && selectedStatus != "Tất cả trạng thái")
            {
                // Chuyển ngôn ngữ hiển thị về ngôn ngữ DB để lọc
                string statusToFilter;
                switch (selectedStatus)
                {
                    case "Hiển thị":
                        statusToFilter = "Active";
                        break;
                    case "Ẩn":
                        statusToFilter = "Hidden";
                        break;
                    // Trường hợp "Hết hàng" (OutOfStock)
                    case "Hết hàng":
                        statusToFilter = "OutOfStock";
                        break;
                    default:
                        statusToFilter = null; // Không lọc
                        break;
                }

                if (statusToFilter != null)
                {
                    query = query.Where(p => p.Status == statusToFilter);
                }
            }

            _filteredProducts = query.ToList();

            BindProductsToGrid(_filteredProducts);
            UpdateSummary(_filteredProducts);
        }
    }
}