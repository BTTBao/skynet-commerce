using Skynet_Commerce.BLL.Helpers; // [QUAN TRỌNG] Để gọi SessionManager
using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProductDetail : UserControl
    {
        private ProductDTO _currentProduct;
        private List<ProductVariantDTO> _variants;
        private ProductVariantDTO _selectedVariant;

        // Biến lưu thông tin Shop thật
        private int _shopId = 0;
        private string _shopName = "Đang tải...";
        private string _shopStats = "98% Phản hồi | 5.0 Đánh giá";

        public UcProductDetail()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // Constructor chính nhận dữ liệu thật
        public UcProductDetail(ProductDTO product) : this()
        {
            _currentProduct = product;
            LoadProduct(_currentProduct);
        }

        private void UcProductDetail_Load(object sender, EventArgs e)
        {
            CenterDetailContainer();

            if (_currentProduct == null)
            {
                MessageBox.Show("Không thể tải thông tin sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadProduct(ProductDTO product)
        {
            if (product == null) return;
            _currentProduct = product;

            // Lấy thông tin Shop
            _shopId = product.ShopId;
            if (!string.IsNullOrEmpty(product.ShopName))
            {
                _shopName = product.ShopName;
            }
            else
            {
                _shopName = "Skynet Store"; // Fallback nếu tên shop rỗng
            }

            // Nếu Variants null thì khởi tạo list rỗng
            _variants = product.Variants ?? new List<ProductVariantDTO>();

            // 1. Load Thông tin cơ bản
            lblProductName.Text = product.Name;

            if (product.Rating.HasValue)
                lblRating.Text = $"{product.Rating.Value:N1}";
            else
                lblRating.Text = "New";

            lblReviewCount.Text = "(Chưa có đánh giá)";
            lblSoldCount.Text = $"{product.SoldQuantity.GetValueOrDefault(0):N0} Đã bán";
            lblDescriptionText.Text = "Sản phẩm chính hãng, chất lượng cao từ Skynet Commerce.";

            // 2. Load Giá
            lblPrice.Text = $"{product.Price:N0}₫";

            if (product.OldPrice.HasValue && product.Price < product.OldPrice.Value)
            {
                lblOldPrice.Text = $"{product.OldPrice.Value:N0}₫";
                int discount = product.DiscountPercent > 0 ? product.DiscountPercent :
                               (int)((1 - product.Price / product.OldPrice.Value) * 100);
                lblDiscount.Text = $"-{discount}%";
                lblOldPrice.Visible = true;
                lblDiscount.Visible = true;
            }
            else
            {
                lblOldPrice.Visible = false;
                lblDiscount.Visible = false;
            }

            // 3. Load Ảnh
            if (_currentProduct.ThumbnailPaths != null && _currentProduct.ThumbnailPaths.Count > 0)
            {
                LoadThumbnails(_currentProduct.ThumbnailPaths);
                SwitchMainImage(_currentProduct.ThumbnailPaths.First());
            }
            else if (!string.IsNullOrEmpty(product.ImagePath))
            {
                var singleImgList = new List<string> { product.ImagePath };
                LoadThumbnails(singleImgList);
                SwitchMainImage(product.ImagePath);
            }

            // 4. Load Shop Info
            lblShopName.Text = _shopName;
            lblShopStats.Text = _shopStats;

            // 5. Load Options (Variants)
            if (_variants.Count > 0)
            {
                LoadProductOptions();

                // Tự động chọn biến thể đầu tiên còn hàng
                _selectedVariant = _variants.FirstOrDefault(v => v.StockQuantity > 0);
                if (_selectedVariant != null)
                {
                    UpdateVariantUI(_selectedVariant);
                    HighlightSelectedVariant(_selectedVariant);
                }
            }
            else
            {
                // Sản phẩm không có biến thể
                pnlSizeOptions.Controls.Clear();
                pnlColorOptions.Controls.Clear();
                lblSizeLabel.Visible = false;
                lblColorLabel.Visible = false;
                lblQuantityAvailable.Text = "Sẵn hàng";
            }
        }

        // [CẬP NHẬT QUAN TRỌNG] Logic thêm vào giỏ hàng (Có xử lý Variant)
        private void BtnAddCart_Click(object sender, EventArgs e)
        {
            if (_currentProduct == null) return;

            int qty = 1;
            int.TryParse(txtQuantity.Text, out qty);

            // Nếu sản phẩm có biến thể mà chưa chọn -> Báo lỗi
            if (_variants != null && _variants.Count > 0)
            {
                if (_selectedVariant == null)
                {
                    MessageBox.Show("Vui lòng chọn Phân loại hàng (Màu sắc, Kích thước)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Chuẩn bị thông tin để thêm vào giỏ
            int? variantId = _selectedVariant?.VariantID;
            string variantName = _selectedVariant != null ? $"{_selectedVariant.Color}, {_selectedVariant.Size}" : "";
            decimal finalPrice = _selectedVariant != null ? _selectedVariant.Price : _currentProduct.Price;

            // Tạo bản sao ProductDTO với giá đúng của biến thể
            ProductDTO productToAdd = new ProductDTO
            {
                ProductId = _currentProduct.ProductId,
                Name = _currentProduct.Name,
                Price = finalPrice,
                ImagePath = _currentProduct.ImagePath,
                ShopId = _currentProduct.ShopId,
                ShopName = _currentProduct.ShopName
            };

            // Gọi SessionManager để thêm vào giỏ
            SessionManager.AddToCart(productToAdd, qty, variantId, variantName);

            MessageBox.Show($"Đã thêm {qty} sản phẩm vào giỏ hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnBuyNow_Click(object sender, EventArgs e)
        {
            if (_currentProduct == null) return;

            // 1. Validate số lượng
            int qty = 1;
            int.TryParse(txtQuantity.Text, out qty);

            // 2. Validate Biến thể (Size/Màu)
            if (_variants != null && _variants.Count > 0 && _selectedVariant == null)
            {
                MessageBox.Show("Vui lòng chọn Phân loại hàng (Màu sắc, Kích thước)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. THÊM VÀO GIỎ HÀNG (Vẫn cần bước này để SessionManager nắm dữ liệu)
            // Gọi lại logic thêm giỏ hàng nhưng KHÔNG hiện MessageBox thông báo thành công để đỡ phiền
            int? variantId = _selectedVariant?.VariantID;
            string variantName = _selectedVariant != null ? $"{_selectedVariant.Color}, {_selectedVariant.Size}" : "";
            decimal finalPrice = _selectedVariant != null ? _selectedVariant.Price : _currentProduct.Price;

            ProductDTO productToAdd = new ProductDTO
            {
                ProductId = _currentProduct.ProductId,
                Name = _currentProduct.Name,
                Price = finalPrice,
                ImagePath = _currentProduct.ImagePath,
                ShopId = _currentProduct.ShopId,
                ShopName = _currentProduct.ShopName
            };

            // Thêm vào Session
            SessionManager.AddToCart(productToAdd, qty, variantId, variantName);

            // 4. ĐIỀU HƯỚNG THÔNG MINH
            FrmMain mainForm = this.FindForm() as FrmMain;
            if (mainForm != null)
            {
                if (AppSession.Instance.IsLoggedIn)
                {
                    // Nếu đã đăng nhập -> Sang thẳng trang Thanh Toán
                    mainForm.LoadPage("Checkout");
                }
                else
                {
                    // Nếu chưa đăng nhập -> Sang trang Login (Login xong tự sang Checkout)
                    mainForm.LoadPage("Login", "Checkout");
                }
            }
        }

        // --- CÁC HÀM HỖ TRỢ KHÁC ---

        private void HighlightSelectedVariant(ProductVariantDTO variant)
        {
            foreach (var ctrl in pnlSizeOptions.Controls)
                if (ctrl is UcOptionButton btn && btn.Text == variant.Size) btn.SetActiveStyle();
            foreach (var ctrl in pnlColorOptions.Controls)
                if (ctrl is UcOptionButton btn && btn.Text == variant.Color) btn.SetActiveStyle();
        }

        private void LoadThumbnails(List<string> paths)
        {
            flpThumbnails.Controls.Clear();
            if (paths == null) return;
            foreach (string path in paths)
            {
                if (!string.IsNullOrEmpty(path))
                {
                    UcThumbnail thumb = new UcThumbnail(path);
                    thumb.ThumbnailClicked += Thumbnail_Clicked;
                    flpThumbnails.Controls.Add(thumb);
                }
            }
        }

        private void Thumbnail_Clicked(object sender, EventArgs e)
        {
            UcThumbnail selectedThumb = (UcThumbnail)sender;
            SwitchMainImage(selectedThumb.ImagePath);
        }

        public void SwitchMainImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && imagePath.StartsWith("http"))
            {
                pbMainImage.ImageLocation = imagePath;
            }
            else if (File.Exists(imagePath))
            {
                pbMainImage.ImageLocation = imagePath;
            }
            else
            {
                pbMainImage.Image = null;
            }
        }

        private void LoadProductOptions()
        {
            var availableSizes = _variants.Where(v => !string.IsNullOrEmpty(v.Size)).Select(v => v.Size).Distinct().ToList();
            var availableColors = _variants.Where(v => !string.IsNullOrEmpty(v.Color)).Select(v => v.Color).Distinct().ToList();

            pnlSizeOptions.Controls.Clear();
            pnlColorOptions.Controls.Clear();
            lblSizeLabel.Visible = availableSizes.Count > 0;
            lblColorLabel.Visible = availableColors.Count > 0;

            foreach (var size in availableSizes)
            {
                UcOptionButton btn = new UcOptionButton(size);
                btn.Click += SizeOption_Click;
                if (!_variants.Any(v => v.Size == size && v.StockQuantity > 0)) btn.SetDisabledStyle();
                else btn.SetInactiveStyle();
                pnlSizeOptions.Controls.Add(btn);
            }
            foreach (var color in availableColors)
            {
                UcOptionButton btn = new UcOptionButton(color);
                btn.Click += ColorOption_Click;
                btn.SetInactiveStyle();
                pnlColorOptions.Controls.Add(btn);
            }
        }

        private void SizeOption_Click(object sender, EventArgs e)
        {
            UcOptionButton selectedBtn = (UcOptionButton)sender;
            ResetButtons(pnlSizeOptions);
            selectedBtn.SetActiveStyle();
            TrySelectNewVariant(selectedBtn.Text, null);
        }

        private void ColorOption_Click(object sender, EventArgs e)
        {
            UcOptionButton selectedBtn = (UcOptionButton)sender;
            ResetButtons(pnlColorOptions);
            selectedBtn.SetActiveStyle();

            // Sửa lỗi IsActive bằng cách check màu
            string currentSize = null;
            foreach (Control c in pnlSizeOptions.Controls)
            {
                if (c is UcOptionButton btn && btn.FillColor.R == 255 && btn.FillColor.G == 87)
                {
                    currentSize = btn.Text; break;
                }
            }
            TrySelectNewVariant(currentSize, selectedBtn.Text);
        }

        private void ResetButtons(Panel pnl)
        {
            foreach (UcOptionButton btn in pnl.Controls.OfType<UcOptionButton>()) btn.SetInactiveStyle();
        }

        private void TrySelectNewVariant(string size, string color)
        {
            ProductVariantDTO newVariant = null;
            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color))
                newVariant = _variants.FirstOrDefault(v => v.Size == size && v.Color == color);
            else if (!string.IsNullOrEmpty(size))
                newVariant = _variants.FirstOrDefault(v => v.Size == size && v.StockQuantity > 0);
            else if (!string.IsNullOrEmpty(color))
                newVariant = _variants.FirstOrDefault(v => v.Color == color && v.StockQuantity > 0);

            if (newVariant != null)
            {
                _selectedVariant = newVariant;
                UpdateVariantUI(newVariant);
            }
        }

        private void UpdateVariantUI(ProductVariantDTO variant)
        {
            lblPrice.Text = $"{variant.Price:N0}₫";
            lblQuantityAvailable.Text = $"Kho: {variant.StockQuantity}";
            btnAddCart.Enabled = variant.StockQuantity > 0;
            btnBuyNow.Enabled = variant.StockQuantity > 0;
            txtQuantity.Text = "1";
        }

        private void CenterDetailContainer()
        {
            int containerWidth = 1000;
            if (this.pnlScrollContainer.Width > containerWidth)
            {
                int x = (this.pnlScrollContainer.Width - containerWidth) / 2;
                this.pnlDetailContainer.Location = new Point(x, this.pnlDetailContainer.Location.Y);
            }
        }

        private void SetupEventHandlers()
        {
            btnQuantityIncrease.Click += (s, e) => UpdateQuantity(1);
            btnQuantityDecrease.Click += (s, e) => UpdateQuantity(-1);
            txtQuantity.Leave += (s, e) => ValidateQuantity();
            btnAddCart.Click += BtnAddCart_Click;
            btnBuyNow.Click += BtnBuyNow_Click;
        }

        private void UpdateQuantity(int step)
        {
            int q = 1;
            int.TryParse(txtQuantity.Text, out q);
            q += step;
            if (q < 1) q = 1;
            txtQuantity.Text = q.ToString();
        }

        private void ValidateQuantity()
        {
            if (!int.TryParse(txtQuantity.Text, out int q) || q < 1) txtQuantity.Text = "1";
        }

        private void BtnViewShop_Click(object sender, EventArgs e)
        {
            if (_shopId <= 0)
            {
                MessageBox.Show("Sản phẩm này không thuộc Shop nào (ShopID = 0).", "Lỗi dữ liệu");
                return;
            }
            FrmMain mainForm = this.FindForm() as FrmMain;
            if (mainForm != null) mainForm.LoadPage("ShopDetail", _shopId);
        }
    }
}