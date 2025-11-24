using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models.Seller;
using Skynet_Commerce.BLL.Services.Seller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Skynet_Commerce
{
    public partial class FormAddProduct : Form
    {
        private List<string> uploadedImages = new List<string>();
        private const int MAX_IMAGES = 5;
        private const int THUMBNAIL_SIZE = 100;
        private const int THUMBNAIL_MARGIN = 10;

        private ProductServiceForSeller _productService;
        private int _currentShopId;
        private ProductFullSellerDTO _editingProduct;
        private bool _isEditMode;

        // Thêm mới
        public FormAddProduct(int shopId)
        {
            InitializeComponent();

            _productService = new ProductServiceForSeller();
            _currentShopId = shopId;
            _isEditMode = false;

            this.Text = "Thêm sản phẩm mới";
            btnSave.Text = "Thêm sản phẩm";
            LoadCategories();
        }

        // Chỉnh sửa
        public FormAddProduct(ProductFullSellerDTO product)
        {
            InitializeComponent();

            _productService = new ProductServiceForSeller();
            _editingProduct = product;
            _isEditMode = true;

            this.Text = $"Chỉnh sửa sản phẩm: {product.ProductName}";
            btnSave.Text = "Cập nhật";
            LoadCategories();
            LoadProductData();
        }

        // Trong FormAddProduct.cs
        private void LoadCategories()
        {
            try
            {
                // 1. Gọi hàm service để lấy danh sách tên danh mục
                List<string> categoryNames = _productService.GetAllCategories();

                if (categoryNames != null)
                {
                    // 2. Gán danh sách tên vào ComboBox
                    cmbCategory.DataSource = categoryNames;

                    // 3. (Tùy chọn) Chọn mục đầu tiên
                    if (cmbCategory.Items.Count > 0)
                    {
                        cmbCategory.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}");
            }
        }

        private void LoadProductData()
        {
            if (_editingProduct == null) return;

            try
            {
                txtName.Text = _editingProduct.ProductName;
                txtDescription.Text = _editingProduct.Description;
                numericPrice.Text = _editingProduct.Price.ToString();
                numericStock.Value = _editingProduct.StockQuantity;

                // Set danh mục
                if (!string.IsNullOrEmpty(_editingProduct.CategoryName))
                {
                    // Set giá trị TÊN danh mục trực tiếp vào Text
                    cmbCategory.Text = _editingProduct.CategoryName;
                }
                else
                {
                    // Thêm cảnh báo nếu CategoryName bị thiếu
                    MessageBox.Show("Cảnh báo: Tên danh mục của sản phẩm này không xác định.", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // --- Load ảnh ---
                if (_editingProduct.Images != null && _editingProduct.Images.Any())
                {
                    foreach (var img in _editingProduct.Images)
                    {
                        AddImageThumbnail(img.ImageURL);
                    }
                }
                else
                {
                    // Cảnh báo nếu Images bị null hoặc rỗng
                    MessageBox.Show("Cảnh báo: Sản phẩm không có ảnh nào để tải.", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // --- Load Variants ---
                if (_editingProduct.Variants != null && _editingProduct.Variants.Any())
                {
                    foreach (var v in _editingProduct.Variants)
                    {
                        VariantControl vc = new VariantControl();
                        vc.Dock = DockStyle.Top;

                        vc.SetData(v.Size, v.Color, v.SKU, v.StockQuantity, v.Price.ToString());

                        vc.DeleteRequested += Variant_DeleteRequested;

                        panelVariants.Controls.Add(vc);
                        panelVariants.Controls.SetChildIndex(vc, 0);
                    }
                }
                else
                {
                    // Cảnh báo nếu Variants bị null hoặc rỗng
                    MessageBox.Show("Cảnh báo: Sản phẩm không có biến thể nào để tải.", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load sản phẩm: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddVariant_Click(object sender, EventArgs e)
        {
            VariantControl vc = new VariantControl();
            vc.Dock = DockStyle.Top;
            vc.DeleteRequested += Variant_DeleteRequested;

            panelVariants.Controls.Add(vc);
            panelVariants.Controls.SetChildIndex(vc, 0);
        }

        private void Variant_DeleteRequested(object sender, EventArgs e)
        {
            VariantControl vc = sender as VariantControl;
            panelVariants.Controls.Remove(vc);
            vc.Dispose();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (panelImages.Controls.Count >= MAX_IMAGES)
            {
                MessageBox.Show($"Tối đa {MAX_IMAGES} ảnh.");
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddImageThumbnail(dlg.FileName);
            }
        }

        private void AddImageThumbnail(string imagePath)
        {
            Guna2PictureBox pb = new Guna2PictureBox();
            pb.Size = new Size(THUMBNAIL_SIZE, THUMBNAIL_SIZE);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderRadius = 8;
            pb.Cursor = Cursors.Hand;
            pb.Tag = imagePath;

            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                pb.Image = new Bitmap(Image.FromStream(fs));
            }

            pb.Click += ImageThumbnail_Click;

            panelImages.Controls.Add(pb);
            RelayoutImageControls();

            uploadedImages.Add(imagePath);
        }

        private void ImageThumbnail_Click(object sender, EventArgs e)
        {
            var pb = sender as Guna2PictureBox;
            if (pb == null) return;

            if (MessageBox.Show("Xóa ảnh này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                uploadedImages.Remove(pb.Tag.ToString());
                panelImages.Controls.Remove(pb);
                pb.Dispose();
                RelayoutImageControls();
            }
        }

        private void RelayoutImageControls()
        {
            int x = THUMBNAIL_MARGIN;
            int y = THUMBNAIL_MARGIN;
            int perRow = (panelImages.Width - THUMBNAIL_MARGIN) / (THUMBNAIL_SIZE + THUMBNAIL_MARGIN);
            if (perRow < 1) perRow = 1;

            int count = 0;
            foreach (Control c in panelImages.Controls)
            {
                c.Location = new Point(x, y);

                x += THUMBNAIL_SIZE + THUMBNAIL_MARGIN;
                count++;

                if (count % perRow == 0)
                {
                    x = THUMBNAIL_MARGIN;
                    y += THUMBNAIL_SIZE + THUMBNAIL_MARGIN;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductFullSellerDTO dto = null;
            if (_editingProduct != null && !string.IsNullOrEmpty(_editingProduct.CategoryName))
                cmbCategory.Text = _editingProduct.CategoryName;

            try
            {
                string name = txtName.Text.Trim();
                string desc = txtDescription.Text.Trim();

                // 1. Lấy và Validate Price
                // Xử lý loại bỏ dấu phẩy (,) và dấu chấm (.) trước khi parse
                string priceText = numericPrice.Text.Replace(",", "").Replace(".", "");
                decimal price;

                if (!decimal.TryParse(priceText, out price) || price < 50000 || price > 5000000)
                {
                    MessageBox.Show("Giá sản phẩm không hợp lệ. (Phải là số, từ 50,000 đến 5,000,000).");
                    return;
                }

                // 2. Lấy và Validate Stock
                int mainStock = (int)numericStock.Value;
                if (mainStock < 0 || mainStock > 10000)
                {
                    MessageBox.Show("Số lượng tồn kho chính không hợp lệ. (Phải là số, từ 0 đến 10,000).");
                    return;
                }

                // 3. Validate Text Fields
                if (name == "")
                {
                    MessageBox.Show("Tên sản phẩm không được để trống");
                    return;
                }
                if (cmbCategory.Text == "" || cmbCategory.Text == null)
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Danh mục sản phẩm.");
                    return;
                }

                // 4. Validate Images Count
                if (uploadedImages.Count == 0 || uploadedImages.Count > 7)
                {
                    MessageBox.Show("Sản phẩm phải có ít nhất 1 ảnh và không quá 7 ảnh.");
                    return;
                }

                // 5. Lấy và Validate Variants
                List<ProductVariantDTO> variants = new List<ProductVariantDTO>();
                foreach (VariantControl vc in panelVariants.Controls.OfType<VariantControl>())
                {
                    if (!vc.ValidateData(out string variantError))
                    {
                        // Thông báo lỗi và dừng quá trình lưu
                        MessageBox.Show($"Lỗi biến thể: {variantError}\n(Tại biến thể Size/Color: {vc.SizeValue}/{vc.ColorValue})", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    variants.Add(vc.GetVariantDTO());
                }

                // Kiểm tra rỗng và trùng SKU cục bộ tiếp tục như cũ
                if (variants == null || !variants.Any())
                {
                    MessageBox.Show("Sản phẩm phải có ít nhất một Biến thể (Variant).");
                    return;
                }
                // Kiểm tra trùng SKU cục bộ (trong cùng một lần nhập)
                if (variants.GroupBy(v => v.SKU).Any(g => g.Count() > 1))
                {
                    MessageBox.Show("Có Biến thể bị trùng mã SKU. Vui lòng kiểm tra lại.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (variants == null || !variants.Any())
                {
                    MessageBox.Show("Sản phẩm phải có ít nhất một Biến thể (Variant).");
                    return;
                }

                // Kiểm tra SKU trùng lặp cục bộ (trong cùng một lần nhập)
                if (variants.GroupBy(v => v.SKU).Any(g => g.Count() > 1))
                {
                    MessageBox.Show("Có Biến thể bị trùng mã SKU. Vui lòng kiểm tra lại.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // a) Tính tổng Stock từ các Variant
                int totalVariantStock = variants.Sum(v => v.StockQuantity);

                // b) Tính Price nhỏ nhất từ các Variant
                decimal minVariantPrice = (decimal)variants.Min(v => v.Price);

                // c) Logic Stock: Lấy giá trị lớn hơn giữa Stock chính và Tổng Stock Variants
                int finalStockQuantity = Math.Max(mainStock, totalVariantStock);

                // d) Logic Price: Lấy giá trị nhỏ hơn giữa Price chính và Price nhỏ nhất của Variants
                decimal finalPrice = Math.Min(price, minVariantPrice);

                // Khởi tạo DTO
                dto = new ProductFullSellerDTO
                {
                    ProductID = _isEditMode ? _editingProduct.ProductID : 0,
                    ProductName = name,
                    Description = desc,
                    CategoryName = cmbCategory.Text.Trim(), // Luôn lấy từ Text vì đã bỏ SelectedValue

                    // SỬ DỤNG GIÁ TRỊ TÍNH TOÁN
                    Price = finalPrice,
                    StockQuantity = finalStockQuantity,

                    Images = uploadedImages.Select(p => new ProductImageDTO { ImageURL = p }).ToList(),
                    Variants = variants
                };

                bool success;
                if (_isEditMode)
                {
                    success = _productService.UpdateProductFullSeller(dto);
                }
                else
                {
                    // Kiểm tra trùng SKU phải được thực hiện trong Service (Xem mục 2)
                    int newId = _productService.AddProductFullSeller(dto, _currentShopId);
                    success = newId > 0;
                }

                if (success)
                {
                    MessageBox.Show("Lưu thành công!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    string dtoContent = FormatProductDto(dto);
                    MessageBox.Show($"Lưu thất bại!\n\nDữ liệu đã gửi:\n{dtoContent}",
                                    "Lỗi Lưu Sản Phẩm",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                string dtoContent = dto != null ? FormatProductDto(dto) : "Không thể tạo DTO.";
                MessageBox.Show($"Lỗi hệ thống khi lưu: {ex.Message}\n\nDữ liệu đã gửi:\n{dtoContent}",
                                "Lỗi Hệ Thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Hàm trợ giúp để định dạng DTO thành chuỗi dễ đọc
        private string FormatProductDto(ProductFullSellerDTO dto)
        {
            if (dto == null) return "DTO rỗng (NULL).";

            var variantsInfo = dto.Variants != null && dto.Variants.Any()
                ? string.Join(", ", dto.Variants.Select(v => $"({v.Size}/{v.Color}, SL: {v.StockQuantity})"))
                : "Không có biến thể";

            var imagesCount = dto.Images?.Count ?? 0;

            return
                $"ID: {dto.ProductID}\n" +
                $"Tên: {dto.ProductName}\n" +
                $"Mô tả: {dto.Description.Substring(0, Math.Min(dto.Description.Length, 50))}...\n" +
                $"Danh mục ID: {dto.CategoryID}\n" +
                $"Giá: {dto.Price:N0} VNĐ\n" +
                $"Tồn kho (Chính): {dto.StockQuantity}\n" +
                $"Số ảnh: {imagesCount}\n" +
                $"Biến thể: {variantsInfo}";
        }

        private List<ProductVariantDTO> GetVariantsFromControl()
        {
            List<ProductVariantDTO> list = panelVariants.Controls.OfType<VariantControl>().Select(vc => vc.GetVariantDTO()) .ToList();

            return list;
        }
    }
}



