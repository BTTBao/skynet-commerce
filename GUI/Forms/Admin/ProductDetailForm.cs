using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Ecommerce.BLL.Models.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ProductDetailForm : Form
    {
        private readonly int _productId;
        private readonly ProductService _productService;
        private ProductFullDetailViewModel _productData;

        public ProductDetailForm(int productId)
        {
            InitializeComponent();
            SetupViewOnlyMode();

            _productId = productId;
            _productService = new ProductService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadFullData();
        }

        private void LoadFullData()
        {
            try
            {
                _productData = _productService.GetProductFullDetail(_productId);
                if (_productData == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu sản phẩm.");
                    this.Close();
                    return;
                }

                // 1. Bind Header & Status
                _lblTitle.Text = $"Chi tiết: {_productData.ProductName}";
                UpdateStatusUI(_productData.Status);

                // 2. Bind Tab Info
                _txtName.Text = _productData.ProductName;
                _txtShop.Text = $"{_productData.ShopName} (Chủ: {_productData.ShopOwner})";
                _txtCategory.Text = _productData.CategoryName;
                _txtDesc.Text = _productData.Description;

                // 3. Bind Tab Variants (Grid)
                _dgvVariants.DataSource = _productData.Variants;
                // Format grid nếu cần (Tự động tạo cột dựa trên List<VariantViewModel>)

                // 4. Bind Tab Images
                _flowImages.Controls.Clear();
                if (_productData.Images != null)
                {
                    foreach (var imgUrl in _productData.Images)
                    {
                        var pic = new PictureBox
                        {
                            Width = 150,
                            Height = 150,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10)
                        };
                        // Dùng thư viện load ảnh hoặc gán URL (Giả sử bạn có hàm load)
                        // pic.LoadAsync(imgUrl); 
                        // Vì demo nên mình set BackColor để thấy khung
                        pic.BackColor = Color.LightGray;

                        _flowImages.Controls.Add(pic);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateStatusUI(string status)
        {
            if (status == "Active")
            {
                _lblStatus.Text = "● ĐANG HIỂN THỊ";
                _lblStatus.ForeColor = Color.Green;

                _btnAction.Text = "Ẩn sản phẩm";
                _btnAction.FillColor = Color.Red; // Nút màu đỏ để cảnh báo hành động ẩn
            }
            else if (status == "Hidden")
            {
                _lblStatus.Text = "● ĐANG BỊ ẨN";
                _lblStatus.ForeColor = Color.Orange;

                _btnAction.Text = "Cho hiển thị";
                _btnAction.FillColor = Color.Green;
            }
            else
            {
                _lblStatus.Text = $"● {status.ToUpper()}";
                _lblStatus.ForeColor = Color.Gray;
                _btnAction.Visible = false; // Trạng thái lạ thì không cho action
            }
        }

        private void _btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic: Nếu đang Active -> Hidden và ngược lại
                string newStatus = _productData.Status == "Active" ? "Hidden" : "Active";
                string actionName = newStatus == "Active" ? "cho phép hiển thị" : "ẩn";

                var confirm = MessageBox.Show($"Bạn có chắc muốn {actionName} sản phẩm này?\n(Hành động này sẽ thay đổi trạng thái ngay lập tức trên sàn)",
                                              "Xác nhận quyền Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _productService.UpdateProductStatus(_productId, newStatus);
                    MessageBox.Show("Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK; // Báo cho Form cha reload grid
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void SetupViewOnlyMode()
        {
            // 1. Khoá các ô TextBox (Tên, Shop, Danh mục, Mô tả)
            LockTextBox(_txtName);
            LockTextBox(_txtShop);
            LockTextBox(_txtCategory);
            LockTextBox(_txtDesc);

            // 2. Khoá GridView (Biến thể)
            if (_dgvVariants != null)
            {
                _dgvVariants.ReadOnly = true;
                _dgvVariants.AllowUserToAddRows = false;
                _dgvVariants.AllowUserToDeleteRows = false;
                _dgvVariants.RowHeadersVisible = false;
            }
        }

        // Hàm khoá TextBox nhưng vẫn giữ màu sắc dễ đọc
        private void LockTextBox(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            if (txt == null) return;

            txt.ReadOnly = true;                // Không cho nhập
            txt.BorderThickness = 0;            // Bỏ viền để nhìn giống Label
            txt.FillColor = Color.White;        // Nền trắng (không bị xám xịt)
            txt.ForeColor = Color.Black;        // Chữ đen rõ ràng
            txt.Cursor = Cursors.IBeam;         // Vẫn cho phép bôi đen copy

            // Nếu muốn nhìn rõ hơn là đang bị disable, có thể dùng màu nền rất nhạt:
            // txt.FillColor = Color.FromArgb(250, 250, 250); 
        }
    }
}