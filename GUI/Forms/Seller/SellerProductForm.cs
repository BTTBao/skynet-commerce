using Skynet_Ecommerce.BLL.Services.Seller;
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerProductForm : Form
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly int _shopId;

        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalPages = 0;
        private List<Product> _allProducts;
        private List<Product> _filteredProducts;

        public SellerProductForm(int shopId)
        {
            InitializeComponent();
            _shopId = shopId;

            // Khởi tạo context và services (Nên dùng Dependency Injection nếu có thể)
            var context = new ApplicationDbContext();
            var unitOfWork = new UnitOfWork(context);
            _productService = new ProductService(unitOfWork);
            _categoryService = new CategoryService(unitOfWork);

            this.Load += SellerProductForm_Load;
        }

        public SellerProductForm() : this(1) { }

        private void SellerProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            // Gán sự kiện TextChanged cho tìm kiếm
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void LoadProducts()
        {
            try
            {
                // Lấy toàn bộ sản phẩm của shop từ Service
                _allProducts = _productService.GetProductsByShop(_shopId).ToList();
                _filteredProducts = _allProducts;

                _totalPages = (int)Math.Ceiling((double)_filteredProducts.Count / _pageSize);
                _currentPage = 1;

                DisplayProducts();
                UpdatePaginationInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayProducts()
        {
            try
            {
                dgvProducts.Rows.Clear();
                if (_filteredProducts == null || !_filteredProducts.Any()) return;

                var pagedList = _filteredProducts
                    .Skip((_currentPage - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToList();

                foreach (var p in pagedList)
                {
                    int rowIndex = dgvProducts.Rows.Add();
                    DataGridViewRow row = dgvProducts.Rows[rowIndex];

                    row.Cells["Id"].Value = p.ProductID;
                    row.Cells["ColName"].Value = p.Name;
                    row.Cells["Category"].Value = p.Category?.CategoryName ?? "Khác";
                    row.Cells["Price"].Value = (p.Price ?? 0).ToString("N0");
                    row.Cells["Stock"].Value = p.StockQuantity;
                    row.Cells["Status"].Value = p.Status;

                    row.Tag = p;

                    if (p.Status == "Hidden")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu vẫn lỗi, Message này sẽ chỉ rõ bạn đang thiếu cột nào
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra nếu click vào Header row (index -1) thì bỏ qua
            if (e.RowIndex < 0) return;

            // 2. Lấy Product từ Tag
            Product selectedProduct = dgvProducts.Rows[e.RowIndex].Tag as Product;
            if (selectedProduct == null) return;

            // 3. Lấy tên cột được click
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;

            switch (colName)
            {
                case "ViewProduct": // Phải khớp với Name trong Designer
                    OpenDetailForm(selectedProduct);
                    break;
                case "EditProduct":
                    OpenEditForm(selectedProduct);
                    break;
                case "ToggleStatus":
                    HandleToggleStatus(selectedProduct, dgvProducts.Rows[e.RowIndex]);
                    break;
            }
        }

        private void OpenDetailForm(Product product)
        {
            // Truyền trực tiếp Object Product sang Form Detail
            SellerProductDetailForm detailForm = new SellerProductDetailForm(product);
            detailForm.ShowDialog();
        }

        private void OpenEditForm(Product product)
        {

            AddProductForm editForm = new AddProductForm(_shopId, product);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts(); // Reload lại danh sách
            }
        }

        private void HandleToggleStatus(Product product, DataGridViewRow row)
        {
            string nextStatus = (product.Status == "Active") ? "Hidden" : "Active";
            string actionText = (nextStatus == "Hidden") ? "ẨN" : "HIỆN";

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} sản phẩm này?",
                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                product.Status = nextStatus;
                if (_productService.UpdateProduct(product)) // Cập nhật DB qua Service
                {
                    // Cập nhật UI ngay lập tức không cần load lại toàn bộ Grid
                    row.Cells["Status"].Value = nextStatus;
                    DisplayProducts(); // Hoặc xử lý màu sắc dòng tại đây để tối ưu
                }
            }
        }

        // ==========================================
        // PHÂN TRANG & TÌM KIẾM
        // ==========================================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim().ToLower();
            _filteredProducts = _allProducts.Where(p =>
                p.Name.ToLower().Contains(key) ||
                (p.Category?.CategoryName.ToLower().Contains(key) ?? false)
            ).ToList();

            _totalPages = (int)Math.Ceiling((double)_filteredProducts.Count / _pageSize);
            _currentPage = 1;
            DisplayProducts();
            UpdatePaginationInfo();
        }

        private void UpdatePaginationInfo()
        {
            lblPageInfo.Text = $"{_currentPage} / {Math.Max(1, _totalPages)}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1) { _currentPage--; DisplayProducts(); UpdatePaginationInfo(); }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages) { _currentPage++; DisplayProducts(); UpdatePaginationInfo(); }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm(_shopId);
            if (addForm.ShowDialog() == DialogResult.OK) LoadProducts();
        }
    }
}