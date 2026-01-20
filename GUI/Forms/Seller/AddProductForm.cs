using Skynet_Ecommerce.BLL.Services.Seller;
using Skynet_Ecommerce.DAL.Repositories.Seller;
using Skynet_Ecommerce.Repositories;
using Skynet_Ecommerce.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class AddProductForm : Form
    {
        private string mainImagePath = null;
        private List<string> subImagePaths = new List<string>();
        private List<VariantControl> variantControls = new List<VariantControl>();

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly int _shopId; // ID của shop hiện tại

        public AddProductForm(int shopId)
        {
            InitializeComponent();

            _shopId = shopId;

            // Khởi tạo services
            var context = new ApplicationDbContext();
            var unitOfWork = new UnitOfWork(context);
            _categoryService = new CategoryService(unitOfWork);
            _productService = new ProductService(unitOfWork);
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Load danh mục sản phẩm từ database
            LoadCategories();

            // Thêm một variant mặc định
            AddVariantControl();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();

                cboCategory.DataSource = categories.ToList();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";

                if (cboCategory.Items.Count > 0)
                    cboCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback: Load dữ liệu mẫu nếu có lỗi
                LoadCategoriesFallback();
            }
        }

        private void LoadCategoriesFallback()
        {
            // Dữ liệu mẫu khi không kết nối được database
            cboCategory.Items.Add("Điện thoại");
            cboCategory.Items.Add("Laptop");
            cboCategory.Items.Add("Tablet");
            cboCategory.Items.Add("Phụ kiện");
            cboCategory.Items.Add("Thiết bị âm thanh");

            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        #region Main Image Events
        private void btnSelectMainImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh chính";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mainImagePath = openFileDialog.FileName;
                        picMainImage.Image = Image.FromFile(mainImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Sub Images Events
        private void btnAddSubImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh phụ";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        if (!subImagePaths.Contains(fileName))
                        {
                            subImagePaths.Add(fileName);
                            AddSubImageToPanel(fileName);
                        }
                    }
                }
            }
        }

        private void AddSubImageToPanel(string imagePath)
        {
            try
            {
                // Tạo panel chứa ảnh và nút xóa
                Panel imagePanel = new Panel();
                imagePanel.Size = new Size(120, 140);
                imagePanel.BorderStyle = BorderStyle.FixedSingle;
                imagePanel.Margin = new Padding(5);

                // PictureBox hiển thị ảnh
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(110, 100);
                pictureBox.Location = new Point(5, 5);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = Image.FromFile(imagePath);
                pictureBox.BorderStyle = BorderStyle.FixedSingle;

                // Button xóa
                Button btnRemove = new Button();
                btnRemove.Text = "Xóa";
                btnRemove.Size = new Size(110, 25);
                btnRemove.Location = new Point(5, 110);
                btnRemove.Tag = imagePath;
                btnRemove.Click += BtnRemoveSubImage_Click;

                imagePanel.Controls.Add(pictureBox);
                imagePanel.Controls.Add(btnRemove);

                flowLayoutSubImages.Controls.Add(imagePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ảnh: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveSubImage_Click(object sender, EventArgs e)
        {
            Button btnRemove = sender as Button;
            if (btnRemove != null)
            {
                string imagePath = btnRemove.Tag.ToString();

                subImagePaths.Remove(imagePath);

                Panel imagePanel = btnRemove.Parent as Panel;
                if (imagePanel != null)
                {
                    foreach (Control ctrl in imagePanel.Controls)
                    {
                        if (ctrl is PictureBox picBox && picBox.Image != null)
                        {
                            picBox.Image.Dispose();
                        }
                    }

                    flowLayoutSubImages.Controls.Remove(imagePanel);
                    imagePanel.Dispose();
                }
            }
        }
        #endregion

        #region Variant Events
        private void btnAddVariant_Click(object sender, EventArgs e)
        {
            AddVariantControl();
        }

        private void AddVariantControl()
        {
            VariantControl variantControl = new VariantControl();
            variantControl.OnRemove += VariantControl_OnRemove;
            variantControl.Margin = new Padding(5);

            flowLayoutVariants.Controls.Add(variantControl);
            variantControls.Add(variantControl);
        }

        private void VariantControl_OnRemove(object sender, EventArgs e)
        {
            VariantControl variantControl = sender as VariantControl;
            if (variantControl != null && variantControls.Count > 1)
            {
                variantControls.Remove(variantControl);
                flowLayoutVariants.Controls.Remove(variantControl);
                variantControl.Dispose();
            }
            else if (variantControls.Count == 1)
            {
                MessageBox.Show("Phải có ít nhất một biến thể!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Save and Cancel Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    // Tạo ProductDTO
                    var productDto = new ProductDTO
                    {
                        Name = txtProductName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Price = decimal.Parse(txtPrice.Text.Trim()),
                        CategoryId = (int)cboCategory.SelectedValue,
                        MainImagePath = mainImagePath,
                        SubImagePaths = subImagePaths,
                        Variants = variantControls.Select(v => v.GetVariantData()).ToList()
                    };

                    // Lưu vào database
                    bool success = _productService.AddProduct(productDto, _shopId);

                    if (success)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu sản phẩm!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            // Kiểm tra tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            // Kiểm tra danh mục
            if (cboCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            // Kiểm tra giá
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            // Kiểm tra ảnh chính
            if (string.IsNullOrEmpty(mainImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh chính cho sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra variants
            foreach (var variantControl in variantControls)
            {
                if (!variantControl.ValidateVariant())
                {
                    return false;
                }
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy? Dữ liệu chưa lưu sẽ bị mất.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Giải phóng resources
            if (picMainImage.Image != null)
            {
                picMainImage.Image.Dispose();
            }

            foreach (Control ctrl in flowLayoutSubImages.Controls)
            {
                if (ctrl is Panel panel)
                {
                    foreach (Control subCtrl in panel.Controls)
                    {
                        if (subCtrl is PictureBox picBox && picBox.Image != null)
                        {
                            picBox.Image.Dispose();
                        }
                    }
                }
            }
        }
    }

    #region VariantControl UserControl
    public class VariantControl : UserControl
    {
        private TextBox txtColor;
        private TextBox txtSize;
        private TextBox txtPrice;
        private TextBox txtStock;
        private TextBox txtSKU;
        private Button btnRemove;

        private Label lblColor;
        private Label lblSize;
        private Label lblPrice;
        private Label lblStock;
        private Label lblSKU;

        public event EventHandler OnRemove;

        public VariantControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(860, 60);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            int labelWidth = 60;
            int textBoxWidth = 120;
            int spacing = 10;
            int currentX = 10;
            int labelY = 10;
            int textBoxY = 30;

            // Màu sắc
            lblColor = new Label();
            lblColor.Text = "Màu:";
            lblColor.Location = new Point(currentX, labelY);
            lblColor.Size = new Size(labelWidth, 20);
            lblColor.Font = new Font("Segoe UI", 8F);

            txtColor = new TextBox();
            txtColor.Location = new Point(currentX, textBoxY);
            txtColor.Size = new Size(textBoxWidth, 20);
            txtColor.Font = new Font("Segoe UI", 9F);

            currentX += textBoxWidth + spacing;

            // Size
            lblSize = new Label();
            lblSize.Text = "Size:";
            lblSize.Location = new Point(currentX, labelY);
            lblSize.Size = new Size(labelWidth, 20);
            lblSize.Font = new Font("Segoe UI", 8F);

            txtSize = new TextBox();
            txtSize.Location = new Point(currentX, textBoxY);
            txtSize.Size = new Size(textBoxWidth, 20);
            txtSize.Font = new Font("Segoe UI", 9F);

            currentX += textBoxWidth + spacing;

            // Giá
            lblPrice = new Label();
            lblPrice.Text = "Giá:";
            lblPrice.Location = new Point(currentX, labelY);
            lblPrice.Size = new Size(labelWidth, 20);
            lblPrice.Font = new Font("Segoe UI", 8F);

            txtPrice = new TextBox();
            txtPrice.Location = new Point(currentX, textBoxY);
            txtPrice.Size = new Size(textBoxWidth, 20);
            txtPrice.Font = new Font("Segoe UI", 9F);

            currentX += textBoxWidth + spacing;

            // Tồn kho
            lblStock = new Label();
            lblStock.Text = "Tồn kho:";
            lblStock.Location = new Point(currentX, labelY);
            lblStock.Size = new Size(labelWidth, 20);
            lblStock.Font = new Font("Segoe UI", 8F);

            txtStock = new TextBox();
            txtStock.Location = new Point(currentX, textBoxY);
            txtStock.Size = new Size(textBoxWidth, 20);
            txtStock.Font = new Font("Segoe UI", 9F);

            currentX += textBoxWidth + spacing;

            // SKU
            lblSKU = new Label();
            lblSKU.Text = "SKU:";
            lblSKU.Location = new Point(currentX, labelY);
            lblSKU.Size = new Size(labelWidth, 20);
            lblSKU.Font = new Font("Segoe UI", 8F);

            txtSKU = new TextBox();
            txtSKU.Location = new Point(currentX, textBoxY);
            txtSKU.Size = new Size(textBoxWidth, 20);
            txtSKU.Font = new Font("Segoe UI", 9F);

            currentX += textBoxWidth + spacing;

            // Button xóa
            btnRemove = new Button();
            btnRemove.Text = "Xóa";
            btnRemove.Location = new Point(currentX, 20);
            btnRemove.Size = new Size(60, 25);
            btnRemove.Font = new Font("Segoe UI", 9F);
            btnRemove.Click += BtnRemove_Click;

            // Thêm controls vào UserControl
            this.Controls.Add(lblColor);
            this.Controls.Add(txtColor);
            this.Controls.Add(lblSize);
            this.Controls.Add(txtSize);
            this.Controls.Add(lblPrice);
            this.Controls.Add(txtPrice);
            this.Controls.Add(lblStock);
            this.Controls.Add(txtStock);
            this.Controls.Add(lblSKU);
            this.Controls.Add(txtSKU);
            this.Controls.Add(btnRemove);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            OnRemove?.Invoke(this, EventArgs.Empty);
        }

        public bool ValidateVariant()
        {
            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Vui lòng nhập màu sắc cho biến thể!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                MessageBox.Show("Vui lòng nhập size cho biến thể!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSize.Focus();
                return false;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Giá biến thể không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            int stock;
            if (!int.TryParse(txtStock.Text.Trim(), out stock) || stock < 0)
            {
                MessageBox.Show("Số lượng tồn kho không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show("Vui lòng nhập SKU cho biến thể!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSKU.Focus();
                return false;
            }

            return true;
        }

        public VariantData GetVariantData()
        {
            return new VariantData
            {
                Color = txtColor.Text.Trim(),
                Size = txtSize.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Stock = int.Parse(txtStock.Text.Trim()),
                SKU = txtSKU.Text.Trim()
            };
        }
    }
    #endregion

    #region VariantData Class
    public class VariantData
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; }
    }
    #endregion
}