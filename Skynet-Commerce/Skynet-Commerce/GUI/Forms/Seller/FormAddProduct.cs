using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Models.Seller;
using Skynet_Commerce.BLL.Services.Seller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

            LoadProductData();
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
                if (_editingProduct.CategoryID > 0)
                    cmbCategory.SelectedValue = _editingProduct.CategoryID;

                // Load ảnh
                if (_editingProduct.Images != null)
                {
                    foreach (var img in _editingProduct.Images)
                    {
                        AddImageThumbnail(img.ImageURL);
                    }
                }

                // Load Variants
                if (_editingProduct.Variants != null)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load sản phẩm: {ex.Message}");
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
            try
            {
                string name = txtName.Text.Trim();
                string desc = txtDescription.Text.Trim();
                decimal price = decimal.Parse(numericPrice.Text);
                int stock = (int)numericStock.Value;

                if (name == "")
                {
                    MessageBox.Show("Tên sản phẩm không được để trống");
                    return;
                }

                var dto = new ProductFullSellerDTO
                {
                    ProductID = _isEditMode ? _editingProduct.ProductID : 0,
                    ProductName = name,
                    Description = desc,
                    CategoryID = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    Price = price,
                    StockQuantity = stock,
                    Images = uploadedImages.Select(p => new ProductImageDTO { ImageURL = p }).ToList(),
                    Variants = GetVariantsFromControl()
                };

                bool success;
                if (_isEditMode)
                {
                    success = _productService.UpdateProductFullSeller(dto);
                }
                else
                {
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
                    MessageBox.Show("Lưu thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private List<ProductVariantDTO> GetVariantsFromControl()
        {
            List<ProductVariantDTO> list = new List<ProductVariantDTO>();

            foreach (VariantControl vc in panelVariants.Controls)
            {
                list.Add(new ProductVariantDTO
                {
                    Size = vc.SizeValue,
                    Color = vc.ColorValue,
                    SKU = vc.SKUValue,
                    Price = vc.PriceValue,
                    StockQuantity = vc.StockValue
                });
            }

            return list;
        }
    }
}



