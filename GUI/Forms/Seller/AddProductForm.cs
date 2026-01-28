using Skynet_Ecommerce.BLL.Helpers;
using Skynet_Ecommerce.BLL.Services.Seller;
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Skynet_Ecommerce.BLL.Helpers;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class AddProductForm : Form
    {
        private string mainImagePath = null;
        private List<string> subImagePaths = new List<string>();
        private List<VariantControl> variantControls = new List<VariantControl>();

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly int _shopId;

        // Thêm biến để xác định mode và lưu product đang edit
        private bool _isEditMode = false;
        private Product _editingProduct = null;

        // Constructor cho chế độ Thêm mới
        public AddProductForm(int shopId)
        {
            InitializeComponent();

            _shopId = shopId;
            _isEditMode = false;

            // Khởi tạo services
            var context = new ApplicationDbContext();
            var unitOfWork = new UnitOfWork(context);
            _categoryService = new CategoryService(unitOfWork);
            _productService = new ProductService(unitOfWork);
        }

        // Constructor cho chế độ Sửa
        public AddProductForm(int shopId, Product product) : this(shopId)
        {
            _isEditMode = true;
            _editingProduct = product;
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Load danh mục sản phẩm từ database
            LoadCategories();

            if (_isEditMode && _editingProduct != null)
            {
                // Chế độ sửa: Load dữ liệu sản phẩm
                this.Text = "Chỉnh sửa sản phẩm";
                btnSave.Text = "Cập nhật";
                LoadProductData();
            }
            else
            {
                // Chế độ thêm: Thêm một variant mặc định
                this.Text = "Thêm sản phẩm mới";
                btnSave.Text = "Lưu";
                AddVariantControl();
            }
        }

        private void LoadProductData()
        {
            if (_editingProduct == null) return;

            try
            {
                // Load thông tin cơ bản
                txtProductName.Text = _editingProduct.Name;
                txtDescription.Text = _editingProduct.Description;
                txtPrice.Text = _editingProduct.Price.ToString();

                // Chọn category
                if (_editingProduct.CategoryID.HasValue)
                {
                    cboCategory.SelectedValue = _editingProduct.CategoryID.Value;
                }

                // Load ảnh chính
                if (_editingProduct.ProductImages != null && _editingProduct.ProductImages.Any())
                {
                    var primaryImage = _editingProduct.ProductImages.FirstOrDefault(img => img.IsPrimary == true);
                    if (primaryImage != null)
                    {
                        mainImagePath = primaryImage.ImageURL;
                        try
                        {
                            // Nếu là URL, load từ URL
                            if (mainImagePath.StartsWith("http"))
                            {
                                picMainImage.Load(mainImagePath);
                            }
                            else
                            {
                                // Nếu là đường dẫn local
                                picMainImage.Image = Image.FromFile(mainImagePath);
                            }
                        }
                        catch
                        {
                            // Nếu load ảnh thất bại, giữ nguyên path
                        }
                    }

                    // Load ảnh phụ
                    var subImages = _editingProduct.ProductImages.Where(img => img.IsPrimary != true).ToList();
                    foreach (var img in subImages)
                    {
                        subImagePaths.Add(img.ImageURL);
                        AddSubImageToPanel(img.ImageURL);
                    }
                }

                // Load variants
                if (_editingProduct.ProductVariants != null && _editingProduct.ProductVariants.Any())
                {
                    foreach (var variant in _editingProduct.ProductVariants)
                    {
                        var variantControl = new VariantControl();
                        variantControl.OnRemove += VariantControl_OnRemove;
                        variantControl.Margin = new Padding(5);

                        // Set dữ liệu cho variant
                        variantControl.SetVariantData(new VariantData
                        {
                            Color = variant.Color,
                            Size = variant.Size,
                            Price = (decimal)variant.Price,
                            Stock = (int)variant.StockQuantity,
                            SKU = variant.SKU
                        });

                        flowLayoutVariants.Controls.Add(variantControl);
                        variantControls.Add(variantControl);
                    }
                }
                else
                {
                    // Nếu không có variant, thêm một variant mặc định với thông tin sản phẩm
                    var variantControl = new VariantControl();
                    variantControl.OnRemove += VariantControl_OnRemove;
                    variantControl.Margin = new Padding(5);

                    variantControl.SetVariantData(new VariantData
                    {
                        Color = "Mặc định",
                        Size = "Mặc định",
                        Price = (decimal)_editingProduct.Price,
                        Stock = (int)_editingProduct.StockQuantity,
                        SKU = ""
                    });

                    flowLayoutVariants.Controls.Add(variantControl);
                    variantControls.Add(variantControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                pictureBox.BorderStyle = BorderStyle.FixedSingle;

                // Load ảnh (hỗ trợ cả URL và local path)
                if (imagePath.StartsWith("http"))
                {
                    pictureBox.Load(imagePath);
                }
                else
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }

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
            // 1. Kiểm tra dữ liệu nhập vào (Validate)
            if (!ValidateForm()) return;

            // 2. Bật chế độ "Đang xử lý" (để người dùng biết đang upload)
            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;
            btnSave.Text = "Đang lưu..."; // Đổi text nút cho chuyên nghiệp

            try
            {
                // --- BƯỚC QUAN TRỌNG: UPLOAD ẢNH LÊN CLOUD ---

                // A. Upload ảnh chính
                // Hàm UploadImage đã có logic: Nếu là link online rồi thì bỏ qua, nếu là file máy thì upload.
                if (!string.IsNullOrEmpty(mainImagePath))
                {
                    mainImagePath = CloudinaryHelper.UploadImage(mainImagePath);
                }

                // B. Upload danh sách ảnh phụ
                List<string> onlineSubImages = new List<string>();
                foreach (string path in subImagePaths)
                {
                    // Upload từng ảnh và lấy link về
                    string onlineUrl = CloudinaryHelper.UploadImage(path);
                    onlineSubImages.Add(onlineUrl);
                }
                // Cập nhật lại list ảnh phụ thành list link online
                subImagePaths = onlineSubImages;

                // ------------------------------------------------

                // 3. Gọi hàm Lưu/Cập nhật (Các hàm này sẽ dùng mainImagePath mới là URL)
                if (_isEditMode)
                {
                    UpdateProduct();
                }
                else
                {
                    AddProduct();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default; // Trả lại chuột bình thường nếu lỗi
                MessageBox.Show($"Lỗi xử lý ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 4. Khôi phục trạng thái form
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
                btnSave.Text = _isEditMode ? "Cập nhật" : "Lưu";
            }
        }

        private void AddProduct()
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

        private List<ProductImage> GetProductImages()
        {
            var images = new List<ProductImage>();

            // Ảnh chính
            if (!string.IsNullOrEmpty(mainImagePath))
            {
                images.Add(new ProductImage
                {
                    ProductID = _editingProduct?.ProductID ?? 0,
                    ImageURL = mainImagePath,
                    IsPrimary = true
                });
            }

            // Ảnh phụ
            foreach (var imagePath in subImagePaths)
            {
                images.Add(new ProductImage
                {
                    ProductID = _editingProduct?.ProductID ?? 0,
                    ImageURL = imagePath,
                    IsPrimary = false
                });
            }

            return images;
        }

        private List<ProductVariant> GetProductVariants()
        {
            var variants = new List<ProductVariant>();

            foreach (var variantControl in variantControls)
            {
                var variantData = variantControl.GetVariantData();

                variants.Add(new ProductVariant
                {
                    ProductID = _editingProduct?.ProductID ?? 0,
                    Size = variantData.Size,
                    Color = variantData.Color,
                    SKU = variantData.SKU,
                    Price = variantData.Price,
                    StockQuantity = variantData.Stock
                });
            }

            return variants;
        }

        private void UpdateProduct()
        {
            if (_editingProduct == null) return;

            // Tạo ProductDTO với ID của sản phẩm đang edit
            // Thu thập dữ liệu từ các controls trên Form
            var product = new Product
            {
                ProductID = _editingProduct.ProductID,
                Name = txtProductName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Price = decimal.TryParse(txtPrice.Text.Trim(), out decimal price) ? price : 0,
                CategoryID = cboCategory.SelectedValue != null ? (int?)cboCategory.SelectedValue : null,
                ShopID = _shopId,
                Status = "Active",
                ProductImages = GetProductImages(),
                ProductVariants = GetProductVariants()
            };
            // Cập nhật vào database
            bool success = _productService.UpdateProduct(product);

            if (success)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật sản phẩm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Thêm method để set dữ liệu cho variant (dùng khi edit)
        public void SetVariantData(VariantData data)
        {
            txtColor.Text = data.Color ?? "";
            txtSize.Text = data.Size ?? "";
            txtPrice.Text = data.Price.ToString();
            txtStock.Text = data.Stock.ToString();
            txtSKU.Text = data.SKU ?? "";
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

    #region ProductDTO Class
    
    #endregion
}