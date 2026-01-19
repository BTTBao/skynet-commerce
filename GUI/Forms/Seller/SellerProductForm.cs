using Skynet_Ecommerce.BLL.Services.Seller;
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
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

            // Khởi tạo services
            var context = new ApplicationDbContext();
            var unitOfWork = new UnitOfWork(context);
            _productService = new ProductService(unitOfWork);
            _categoryService = new CategoryService(unitOfWork);
        }

        public SellerProductForm() : this(1) // Constructor mặc định với shopId = 1
        {
        }

        private void SellerProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();

            // Thêm event cho textbox search
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void LoadProducts()
        {
            try
            {
                // Lấy tất cả sản phẩm của shop
                _allProducts = _productService.GetProductsByShop(_shopId).ToList();
                _filteredProducts = _allProducts;

                // Tính tổng số trang
                _totalPages = (int)Math.Ceiling((double)_filteredProducts.Count / _pageSize);

                // Reset về trang 1
                _currentPage = 1;

                // Hiển thị dữ liệu
                DisplayProducts();
                UpdatePaginationInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayProducts()
        {
            try
            {
                dgvProducts.Rows.Clear();

                // Lấy sản phẩm của trang hiện tại
                var productsToDisplay = _filteredProducts
                    .Skip((_currentPage - 1) * _pageSize)
                    .Take(_pageSize)
                    .ToList();

                foreach (var product in productsToDisplay)
                {
                    int rowIndex = dgvProducts.Rows.Add();
                    DataGridViewRow row = dgvProducts.Rows[rowIndex];

                    row.Cells["Id"].Value = product.ProductID;
                    row.Cells["Name"].Value = product.Name;
                    row.Cells["Category"].Value = product.Category?.CategoryName ?? "N/A";
                    row.Cells["Price"].Value = product.Price?.ToString("N0") + " VNĐ";
                    row.Cells["Stock"].Value = product.StockQuantity ?? 0;

                    // Lưu trạng thái của sản phẩm vào Tag
                    row.Tag = product;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationInfo()
        {
            if (_totalPages == 0)
            {
                lblPageInfo.Text = "0 / 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
            }
            else
            {
                lblPageInfo.Text = $"{_currentPage} / {_totalPages}";
                btnPrevPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < _totalPages;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                _filteredProducts = _allProducts;
            }
            else
            {
                _filteredProducts = _allProducts.Where(p =>
                    p.Name.ToLower().Contains(searchText) ||
                    (p.Category?.CategoryName.ToLower().Contains(searchText) ?? false)
                ).ToList();
            }

            // Tính lại tổng số trang
            _totalPages = (int)Math.Ceiling((double)_filteredProducts.Count / _pageSize);

            // Reset về trang 1
            _currentPage = 1;

            // Hiển thị lại
            DisplayProducts();
            UpdatePaginationInfo();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form thêm sản phẩm
                AddProductForm addProductForm = new AddProductForm(_shopId);

                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload danh sách sản phẩm sau khi thêm thành công
                    LoadProducts();

                    MessageBox.Show("Đã thêm sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form thêm sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayProducts();
                UpdatePaginationInfo();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                DisplayProducts();
                UpdatePaginationInfo();
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            Product product = row.Tag as Product;

            if (product == null) return;

            // Nút Ẩn/Hiện (cột thứ 2 từ cuối)
            if (e.ColumnIndex == dgvProducts.Columns.Count - 2)
            {
                ToggleProductStatus(product, row);
            }

            // Nút Sửa (cột cuối cùng)
            if (e.ColumnIndex == dgvProducts.Columns.Count - 1)
            {
                EditProduct(product);
            }
        }

        private void ToggleProductStatus(Product product, DataGridViewRow row)
        {
            try
            {
                string currentStatus = product.Status;
                string newStatus = currentStatus == "Active" ? "Hidden" : "Active";
                string action = newStatus == "Active" ? "hiện" : "ẩn";

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn {action} sản phẩm '{product.Name}'?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    product.Status = newStatus;
                    bool success = _productService.UpdateProduct(product);

                    if (success)
                    {
                        MessageBox.Show($"Đã {action} sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật màu sắc của row
                        if (newStatus == "Hidden")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái sản phẩm!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProduct(Product product)
        {
            try
            {
                // TODO: Tạo form EditProductForm tương tự AddProductForm
                MessageBox.Show($"Chức năng sửa sản phẩm '{product.Name}' đang được phát triển.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                /*
                // Code mẫu khi đã có EditProductForm:
                EditProductForm editForm = new EditProductForm(product.ProductID, _shopId);
                
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    MessageBox.Show("Đã cập nhật sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}