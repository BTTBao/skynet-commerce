using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly CategoryService _categoryService;
        public CategoriesForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesFromDb();
        }

        private void LoadCategoriesFromDb()
        {
            try
            {
                _flowPanel.Controls.Clear();
                _flowPanel.SuspendLayout(); // Tối ưu hiệu năng vẽ

                // Luôn lấy dữ liệu mới nhất
                var data = new CategoryService().GetAllCategories();

                foreach (var item in data)
                {
                    var row = new UcCategoryRow();
                    row.SetData(
                        item.CategoryID,
                        item.NameDisplay,
                        item.ProductCountDisplay,
                        item.SubCatCountDisplay
                    );
                    row.Width = _flowPanel.Width - 25; // Chỉnh chiều rộng cho đẹp

                    // --- XỬ LÝ SỰ KIỆN SỬA ---
                    row.OnEditClicked += (s, e) =>
                    {
                        var uc = s as UcCategoryRow;
                        using (var f = new CategoryDetailForm(uc.CategoryID))
                        {
                            if (f.ShowDialog() == DialogResult.OK)
                                LoadCategoriesFromDb(); // Load lại danh sách
                        }
                    };

                    // --- XỬ LÝ SỰ KIỆN XÓA ---
                    row.OnDeleteClicked += (s, e) =>
                    {
                        var uc = s as UcCategoryRow;
                        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục ID {uc.CategoryID}?",
                            "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                new CategoryService().DeleteCategory(uc.CategoryID);
                                MessageBox.Show("Đã xóa thành công.");
                                LoadCategoriesFromDb();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Không thể xóa!\nLý do: " + ex.Message, "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    _flowPanel.Controls.Add(row);
                }

                _flowPanel.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new CategoryDetailForm()) // Constructor không tham số = Thêm mới
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadCategoriesFromDb();
                }
            }
        }
    }
}