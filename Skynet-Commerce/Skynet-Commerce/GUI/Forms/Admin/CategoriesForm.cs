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
                // 1. Lấy dữ liệu từ BLL
                var data = _categoryService.GetAllCategories();

                // 2. Xóa dữ liệu cũ trên UI
                _flowPanel.Controls.Clear();

                // 3. Duyệt danh sách và tạo UserControl
                foreach (var item in data)
                {
                    var row = new UcCategoryRow();

                    // Đổ dữ liệu vào Row (ID, Name, Total, Sub)
                    row.SetData(
                        item.CategoryID,           // VD: CAT-001
                        item.NameDisplay,         // VD: Electronics
                        item.ProductCountDisplay, // VD: 1,234
                        item.SubCatCountDisplay   // VD: 5
                    );

                    // Thêm xử lý sự kiện nút Edit/Delete nếu cần
                    // row.Click += ... 

                    _flowPanel.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}