using Skynet_Commerce.BLL.Services.Admin;
// using Skynet_Commerce.GUI.UserControls; // Không còn cần thiết
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq; // Dùng cho search đơn giản

namespace Skynet_Commerce.GUI.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly CategoryService _categoryService;

        // Biến lưu danh sách gốc để hỗ trợ tìm kiếm local (nếu muốn)
        private dynamic _allCategories;

        public CategoriesForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();

            SetupGridEvents();
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

                // Lấy dữ liệu
                var data = _categoryService.GetAllCategories();
                _allCategories = data; // Lưu lại để tìm kiếm

                // Lọc theo từ khóa (nếu có)
                string keyword = _txtSearch.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Giả sử 'data' là List<T>, ta dùng LINQ để lọc
                    // Lưu ý: Cần cast về đúng kiểu ViewModel của bạn nếu dùng 'var'
                    // Ở đây tôi viết generic, bạn có thể cần điều chỉnh .Where(...)
                     data = data.Where(x => x.NameDisplay.ToLower().Contains(keyword)).ToList();
                }

                _dgvCategories.AutoGenerateColumns = false;
                _dgvCategories.DataSource = data;
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