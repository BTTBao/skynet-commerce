using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
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

            // Load dữ liệu khi form khởi tạo
            this.Load += ProductsForm_Load;
            LoadCategories();
            // Gán sự kiện combobox
            _comboCategory.SelectedIndexChanged += _comboCategory_SelectedIndexChanged;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // Đảm bảo ComboBox chọn mặc định là dòng đầu tiên ("All Categories")
            if (_comboCategory.Items.Count > 0)
                _comboCategory.StartIndex = 0;

            // Load lần đầu
            LoadProductData();
        }

        // --- HÀM LOAD DATA TRUNG TÂM ---
        private void LoadProductData()
        {
            // 1. Lấy giá trị từ giao diện
            string keyword = _txtSearch.Text.Trim();

            // Kiểm tra null để tránh lỗi khi form mới khởi tạo chưa select gì
            string category = _comboCategory.SelectedItem != null ? _comboCategory.SelectedItem.ToString() : "All Categories";

            try
            {
                // 2. Gọi Service với các tham số lọc
                List<ProductViewModel> productList = _productService.GetAllProducts(keyword, category);

                // 3. Xóa cũ và Vẽ mới
                _flowPanel.Controls.Clear();
                _flowPanel.SuspendLayout(); // Tối ưu hiệu năng vẽ UI (chống giật)

                foreach (var item in productList)
                {
                    var row = new UcProductRow();
                    row.SetData(item);
                    row.Margin = new Padding(0, 0, 0, 5);
                    _flowPanel.Controls.Add(row);
                }

                _flowPanel.ResumeLayout(); // Kết thúc tối ưu vẽ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- Khi chọn danh mục ---
        private void _comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi lại hàm Load, nó sẽ tự lấy category mới nhất để query
            LoadProductData();
        }

        private void LoadCategories()
        {
            try
            {

                // 1. Lấy danh sách từ DB
                List<string> categories = _productService.GetCategoryNames();

                // 2. Xóa các item cũ (nếu có)
                _comboCategory.Items.Clear();

                // 3. Thêm item mặc định đầu tiên
                _comboCategory.Items.Add("Tất cả");

                // 4. Thêm danh sách từ DB vào
                // Hàm AddRange nhận mảng object[], nên cần convert hoặc add từng cái
                _comboCategory.Items.AddRange(categories.ToArray());

                // 5. Chọn mặc định mục đầu tiên
                _comboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
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