using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Ecommerce.BLL.Helpers;

// using Skynet_Commerce.GUI.UserControls; // Không còn cần thiết
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Dùng cho search đơn giản
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly CategoryService _categoryService;


        private PaginationHelper _paginationHelper;
        private List<CategoryViewModel> _filteredCategoriesCache = new List<CategoryViewModel>();

        public CategoriesForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();

            SetupGridEvents();

            _paginationHelper = new PaginationHelper(
                _pnlPagination,
                _cboPageSelect,
                _lblTotalPageText,
                (page) => RenderCategoryGrid(), // Callback: Gọi khi đổi trang
                pageSize: 10
            );
        }

        private void SetupGridEvents()
        {
            // Hiệu ứng chuột
            _dgvCategories.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvCategories.Cursor = Cursors.Hand; };
            _dgvCategories.CellMouseLeave += (s, e) => { _dgvCategories.Cursor = Cursors.Default; };

            // Đăng ký sự kiện
            _dgvCategories.CellFormatting += _dgvCategories_CellFormatting;
            _dgvCategories.CellContentClick += _dgvCategories_CellContentClick;
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesFromDb();
        }

        private void LoadCategoriesFromDb()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 1. Lấy toàn bộ dữ liệu từ DB
                var data = _categoryService.GetAllCategories(); // Giả sử trả về List<CategoryViewModel>

                // 2. Lọc theo từ khóa (Client-side filtering)
                string keyword = _txtSearch.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    data = data.Where(x => x.NameDisplay.ToLower().Contains(keyword)).ToList();
                }

                // 3. Lưu kết quả đã lọc vào Cache
                _filteredCategoriesCache = data;

                // 4. Cập nhật PaginationHelper
                _paginationHelper.SetTotalRecords(data.Count);

                // 5. Reset về trang 1 (Helper sẽ tự gọi RenderCategoryGrid)
                _paginationHelper.SetPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void RenderCategoryGrid()
        {
            int page = _paginationHelper.CurrentPage;
            int size = _paginationHelper.PageSize;

            // Cắt dữ liệu (Client-side pagination)
            var pagedData = _filteredCategoriesCache
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToList();

            _dgvCategories.AutoGenerateColumns = false;
            _dgvCategories.DataSource = pagedData;
        }

        // --- ĐỊNH DẠNG HIỂN THỊ ---
        private void _dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Format cột Action
            if (_dgvCategories.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.CellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 2. Format số lượng (Màu xanh hoặc đậm để dễ nhìn)
            if (_dgvCategories.Columns[e.ColumnIndex].Name == "colProductCount" ||
                _dgvCategories.Columns[e.ColumnIndex].Name == "colSubCatCount")
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.FromArgb(107, 114, 128); // Gray Text
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // --- XỬ LÝ MENU ACTION ---
        private void _dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click vào cột Action
            if (e.RowIndex < 0 || _dgvCategories.Columns[e.ColumnIndex].Name != "colAction") return;

            // Lấy object tại dòng đó
            // Lưu ý: data bound item phải ép kiểu về ViewModel mà GetAllCategories trả về
            dynamic item = _dgvCategories.Rows[e.RowIndex].DataBoundItem;
            if (item == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            // 1. Menu Sửa
            var itemEdit = menu.Items.Add("Chỉnh sửa");
            itemEdit.Image = SystemIcons.Information.ToBitmap();
            itemEdit.Click += (s, ev) =>
            {
                using (var f = new CategoryDetailForm(item.CategoryID))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                        LoadCategoriesFromDb();
                }
            };

            // 2. Menu Xóa
            var itemDelete = menu.Items.Add("Xóa danh mục");
            itemDelete.ForeColor = Color.Red;
            itemDelete.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục '{item.NameDisplay}'?",
                            "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _categoryService.DeleteCategory(item.CategoryID);
                        MessageBox.Show("Đã xóa thành công.");
                        LoadCategoriesFromDb();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa!\nLý do: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Hiển thị Menu
            Rectangle cellRect = _dgvCategories.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvCategories, cellRect.Left, cellRect.Bottom);
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new CategoryDetailForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadCategoriesFromDb();
                }
            }
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                // Thực hiện tìm kiếm (Bạn cần cài đặt logic lọc trong LoadCategoriesFromDb hoặc gọi Service tìm kiếm)
                LoadCategoriesFromDb();
            }
        }
    }
}