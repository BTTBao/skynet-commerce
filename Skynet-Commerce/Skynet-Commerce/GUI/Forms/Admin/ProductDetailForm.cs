using Skynet_Commerce.BLL.Services.Admin;
using System;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ProductDetailForm : Form
    {
        private readonly int _productId;
        private readonly ProductService _productService;

        public ProductDetailForm(int productId)
        {
            InitializeComponent();
            new Guna.UI2.WinForms.Guna2ShadowForm(this);

            _productId = productId;
            _productService = new ProductService();

            // Events
            _btnCancel.Click += (s, e) => this.Close();
            _btnSave.Click += _btnSave_Click;

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var p = _productService.GetProductById(_productId);
                if (p == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!");
                    this.Close();
                    return;
                }

                _txtName.Text = p.Name;
                _txtPrice.Value = p.Price ?? 0;
                _txtStock.Value = p.StockQuantity ?? 0;
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
                decimal price = _txtPrice.Value;
                int stock = (int)_txtStock.Value;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.");
                    return;
                }

                _productService.UpdateProduct(_productId, name, price, stock);

                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }
    }
}