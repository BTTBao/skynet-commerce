using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Ecommerce.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ProductsForm : Form
    {
        private readonly ProductService _productService;

        // [PHÂN TRANG] Khai báo Helper và Cache
        private PaginationHelper _paginationHelper;
        private List<ProductViewModel> _allProductsCache = new List<ProductViewModel>();
        public ProductsForm()
        {
            InitializeComponent();
            _productService = new ProductService();

            SetupGridEvents();
            LoadCategories();

            _paginationHelper = new PaginationHelper(
                _pnlPagination,      // Panel chứa nút số
                _cboPageSelect,      // ComboBox chọn trang
                _lblTotalPageText,   // Label "of Total"
                (page) => RenderProductGrid(), // Callback: Khi đổi trang -> vẽ lại grid
                pageSize: 10         // Số dòng mỗi trang
            );
        }

        private void SetupGridEvents()
        {
            // Hiệu ứng chuột
            _dgvProducts.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvProducts.Cursor = Cursors.Hand; };
            _dgvProducts.CellMouseLeave += (s, e) => { _dgvProducts.Cursor = Cursors.Default; };

            // Đăng ký sự kiện
            _dgvProducts.CellFormatting += _dgvProducts_CellFormatting;
            _dgvProducts.CellContentClick += _dgvProducts_CellContentClick;
            _comboCategory.SelectedIndexChanged += _comboCategory_SelectedIndexChanged;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            if (_comboCategory.Items.Count > 0) _comboCategory.StartIndex = 0;
            LoadProductData();
        }

        // --- LOAD DỮ LIỆU ---
        private void LoadProductData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string keyword = _txtSearch.Text.Trim();
                string category = _comboCategory.SelectedItem != null ? _comboCategory.SelectedItem.ToString() : "All Categories";

                // 1. Lấy toàn bộ dữ liệu
                List<ProductViewModel> productList = _productService.GetAllProducts(keyword, category);

                // 2. Lưu vào Cache
                _allProductsCache = productList;

                // 3. Cập nhật PaginationHelper
                _paginationHelper.SetTotalRecords(productList.Count);

                // 4. Reset về trang 1
                _paginationHelper.SetPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // [HÀM MỚI] Cắt dữ liệu và hiển thị lên Grid
        private void RenderProductGrid()
        {
            int page = _paginationHelper.CurrentPage;
            int size = _paginationHelper.PageSize;

            // Cắt dữ liệu (Client-side pagination)
            var pagedData = _allProductsCache
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToList();

            _dgvProducts.AutoGenerateColumns = false;
            _dgvProducts.DataSource = pagedData;
        }

        // --- ĐỊNH DẠNG HIỂN THỊ (MÀU SẮC, TIỀN TỆ) ---
        private void _dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Format Giá tiền (VND)
            if (_dgvProducts.Columns[e.ColumnIndex].Name == "colPrice" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = string.Format("{0:N0} ₫", price);
                    e.CellStyle.ForeColor = Color.FromArgb(59, 130, 246); // Xanh dương
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }

            // 2. Format Trạng thái
            if (_dgvProducts.Columns[e.ColumnIndex].Name == "colStatus")
            {
                string status = e.Value?.ToString();
                if (status == "Active")
                {
                    e.Value = "● Hiển thị";
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "● Đã ẩn";
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ
                }
            }

            // 3. Format cột Action
            if (_dgvProducts.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.CellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 4. Format cột Tồn kho (Cảnh báo nếu hết hàng)
            if (_dgvProducts.Columns[e.ColumnIndex].Name == "colStock" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int stock) && stock <= 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.Value = "Hết hàng";
                }
            }
        }

        // --- XỬ LÝ MENU CHUỘT PHẢI (ACTION) ---
        private void _dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgvProducts.Columns[e.ColumnIndex].Name != "colAction") return;

            var product = _dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductViewModel;
            if (product == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Font = new Font("Segoe UI", 10F);

            // -- Xem / Sửa --
            var itemEdit = menu.Items.Add("Xem chi tiết");
            itemEdit.Image = SystemIcons.Application.ToBitmap();
            itemEdit.Click += (s, ev) =>
            {
                using (var f = new ProductDetailForm(product.ProductID))
                {
                    if (f.ShowDialog() == DialogResult.OK) LoadProductData();
                }
            };

            // -- Trạng thái --
            var itemStatus = new ToolStripMenuItem("Cập nhật trạng thái");
            itemStatus.Image = SystemIcons.Shield.ToBitmap();

            // Active
            var subActive = itemStatus.DropDownItems.Add("Hiển thị (Active)");
            subActive.Click += (s, ev) => ChangeStatus(product.ProductID, "Active");
            if (product.Status == "Active") ((ToolStripMenuItem)subActive).Checked = true;

            // Hidden (Ẩn)
            var subHidden = itemStatus.DropDownItems.Add("Ẩn sản phẩm (Hidden)");
            subHidden.Click += (s, ev) => ChangeStatus(product.ProductID, "Hidden");
            if (product.Status == "Hidden") ((ToolStripMenuItem)subHidden).Checked = true;

            // *LƯU Ý: Đã bỏ nút "Banned" vì DB không hỗ trợ*

            menu.Items.Add(itemStatus);
            menu.Items.Add(new ToolStripSeparator());

            // -- Xóa --
            //var itemDelete = menu.Items.Add("Xóa sản phẩm");
            //itemDelete.Image = SystemIcons.Error.ToBitmap();
            //itemDelete.ForeColor = Color.Red;
            //itemDelete.Click += (s, ev) => HandleDeleteProduct(product);

            Rectangle cellRect = _dgvProducts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvProducts, cellRect.Left, cellRect.Bottom);
        }

        // Helper: Xử lý thay đổi trạng thái
        private void ChangeStatus(int id, string status)
        {
            try
            {
                _productService.UpdateProductStatus(id, status);
                LoadProductData(); // Refresh Grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        // Helper: Xử lý Xóa (Quan trọng)
        private void HandleDeleteProduct(ProductViewModel product)
        {
            // Kiểm tra xem Service có báo là sản phẩm đang được dùng không (Query nhẹ trước)
            // Lưu ý: Cần expose hàm IsProductInUse ra Interface hoặc Public của Service nếu chưa có
            // Ở đây giả lập logic xử lý tại Client gọi xuống Service

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm: {product.ProductName}?\n\nLưu ý: Nếu sản phẩm đã có đơn hàng, hệ thống sẽ chỉ chuyển sang trạng thái 'Deleted' thay vì xóa vĩnh viễn.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _productService.DeleteProductSafe(product.ProductID);
                    MessageBox.Show("Xử lý thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductData();
                }
                catch (Exception ex)
                {
                    // IN RA LỖI CHI TIẾT
                    string message = ex.Message;
                    if (ex.InnerException != null)
                    {
                        message += "\nChi tiết: " + ex.InnerException.Message;
                        if (ex.InnerException.InnerException != null)
                        {
                            message += "\nSQL Error: " + ex.InnerException.InnerException.Message;
                        }
                    }
                    MessageBox.Show(message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadCategories()
        {
            try
            {
                // Ngắt sự kiện để tránh trigger reload khi đang add item
                _comboCategory.SelectedIndexChanged -= _comboCategory_SelectedIndexChanged;

                List<string> categories = _productService.GetCategoryNames();
                _comboCategory.Items.Clear();
                _comboCategory.Items.Add("Tất cả");
                _comboCategory.Items.AddRange(categories.ToArray());
                _comboCategory.SelectedIndex = 0;

                _comboCategory.SelectedIndexChanged += _comboCategory_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void _comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadProductData();
            }
        }
    }
}