using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ProductsForm : Form
    {
        private readonly ProductService _productService;

        public ProductsForm()
        {
            InitializeComponent();
            _productService = new ProductService();

            SetupGridEvents();
            LoadCategories();
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

                List<ProductViewModel> productList = _productService.GetAllProducts(keyword, category);

                _dgvProducts.AutoGenerateColumns = false;
                _dgvProducts.DataSource = productList;
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
            // Kiểm tra click vào cột Action
            if (e.RowIndex < 0 || _dgvProducts.Columns[e.ColumnIndex].Name != "colAction") return;

            var product = _dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductViewModel;
            if (product == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            // 1. Menu Sửa
            var itemEdit = menu.Items.Add("Chỉnh sửa sản phẩm");
            itemEdit.Image = SystemIcons.Information.ToBitmap();
            itemEdit.Click += (s, ev) =>
            {
                using (var f = new ProductDetailForm(product.ProductID))
                {
                    if (f.ShowDialog() == DialogResult.OK) LoadProductData();
                }
            };

            // 2. Menu Ẩn/Hiện
            string toggleText = product.Status == "Active" ? "Ẩn sản phẩm này" : "Hiển thị sản phẩm";
            var itemToggle = menu.Items.Add(toggleText);
            itemToggle.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Bạn có chắc muốn {toggleText.ToLower()}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _productService.ToggleProductStatus(product.ProductID);
                        LoadProductData();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            };

            // 3. Menu Xóa
            var itemDelete = menu.Items.Add("Xóa vĩnh viễn");
            itemDelete.ForeColor = Color.Red;
            itemDelete.Click += (s, ev) =>
            {
                if (MessageBox.Show("Cảnh báo: Hành động này không thể hoàn tác!\nXóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    try
                    {
                        _productService.DeleteProduct(product.ProductID);
                        MessageBox.Show("Đã xóa thành công.");
                        LoadProductData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa (có thể do ràng buộc đơn hàng).\nLỗi: " + ex.Message);
                    }
                }
            };

            // Hiển thị Menu ngay vị trí nút bấm
            Rectangle cellRect = _dgvProducts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvProducts, cellRect.Left, cellRect.Bottom);
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