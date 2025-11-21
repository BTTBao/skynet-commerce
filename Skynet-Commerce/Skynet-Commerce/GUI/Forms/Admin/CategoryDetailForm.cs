using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class CategoryDetailForm : Form
    {
        private readonly int _categoryId; // 0 = Thêm mới, >0 = Sửa
        private readonly CategoryService _categoryService;

        // Constructor cho Thêm mới
        public CategoryDetailForm()
        {
            InitializeComponent();
            new Guna.UI2.WinForms.Guna2ShadowForm(this);
            _categoryId = 0;
            _categoryService = new CategoryService();

            _lblTitle.Text = "Thêm danh mục mới";

            InitEvents();
            LoadParentCategories();
        }

        // Constructor cho Sửa
        public CategoryDetailForm(int id)
        {
            InitializeComponent();
            new Guna.UI2.WinForms.Guna2ShadowForm(this);
            _categoryId = id;
            _categoryService = new CategoryService();

            _lblTitle.Text = "Chỉnh sửa danh mục";

            InitEvents();
            LoadParentCategories();
            LoadDataForEdit();
        }

        private void InitEvents()
        {
            _btnCancel.Click += (s, e) => this.Close();
            _btnSave.Click += _btnSave_Click;
        }

        private void LoadParentCategories()
        {
            try
            {
                var parents = _categoryService.GetParentCategories();

                // Thêm tùy chọn "Không có danh mục cha"
                var list = new List<Category>
                {
                    new Category { CategoryID = -1, CategoryName = "-- Không có --" }
                };
                list.AddRange(parents);

                _cboParent.DataSource = list;
                _cboParent.DisplayMember = "CategoryName";
                _cboParent.ValueMember = "CategoryID";
                _cboParent.SelectedValue = -1; // Mặc định chọn không có cha
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục cha: " + ex.Message);
            }
        }

        private void LoadDataForEdit()
        {
            try
            {
                var cat = _categoryService.GetCategoryById(_categoryId);
                if (cat == null)
                {
                    MessageBox.Show("Danh mục không tồn tại.");
                    this.Close();
                    return;
                }

                _txtName.Text = cat.CategoryName;
                if (cat.ParentCategoryID.HasValue)
                {
                    _cboParent.SelectedValue = cat.ParentCategoryID.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = _txtName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục.");
                    return;
                }

                // Xử lý Parent ID
                int selectedParent = (int)_cboParent.SelectedValue;
                int? parentId = (selectedParent == -1) ? (int?)null : selectedParent;

                if (_categoryId == 0)
                {
                    // Thêm mới
                    _categoryService.AddCategory(name, parentId);
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else
                {
                    // Cập nhật
                    _categoryService.UpdateCategory(_categoryId, name, parentId);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}