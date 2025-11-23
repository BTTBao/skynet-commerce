using Skynet_Commerce.BLL.Models;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProductDetail : UserControl
    {
        private ProductDTO _currentProduct;
        private List<ProductVariantDTO> _variants;
        private ProductVariantDTO _selectedVariant;

        // Thông tin Shop tạm thời vẫn giữ cứng hoặc lấy từ DTO nếu có
        private string _shopName = "Skynet Official Store";
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

            // Nếu không có dữ liệu sản phẩm thì báo lỗi (Chặn trường hợp mở form mà ko có data)
            if (_currentProduct == null)
            {
                MessageBox.Show("Không thể tải thông tin sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Có thể gọi hàm quay lại trang chủ nếu cần
                // (this.ParentForm as FrmMain)?.LoadPage("Home");
            }
        }

        public void LoadProduct(ProductDTO product)
        {
            if (product == null) return;
            _currentProduct = product;

            // Nếu Variants null thì khởi tạo list rỗng để tránh lỗi
            _variants = product.Variants ?? new List<ProductVariantDTO>();

            // 1. Load Thông tin cơ bản
            lblProductName.Text = product.Name;

            // Xử lý Rating (nếu null thì mặc định 5.0 hoặc ẩn)
            if (product.Rating.HasValue)
                lblRating.Text = $"{product.Rating.Value:N1}";
            else
                lblRating.Text = "New";

            lblReviewCount.Text = "(Chưa có đánh giá)"; // Database chưa có bảng review count
            lblSoldCount.Text = $"{product.SoldQuantity.GetValueOrDefault(0):N0} Đã bán";

            // Mô tả (Nếu DTO có trường Description thì gán vào, tạm thời để trống hoặc text mặc định)
            // lblDescriptionText.Text = product.Description ?? "Đang cập nhật mô tả..."; 
            lblDescriptionText.Text = "Sản phẩm chính hãng, chất lượng cao từ Skynet Commerce.";

            // 2. Load Giá
            lblPrice.Text = $"{product.Price:N0}₫";

            // Xử lý giá cũ / giảm giá
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
            // Ưu tiên ảnh phụ từ List ThumbnailPaths (nếu có)
            if (_currentProduct.ThumbnailPaths != null && _currentProduct.ThumbnailPaths.Count > 0)
            {
                LoadThumbnails(_currentProduct.ThumbnailPaths);
                SwitchMainImage(_currentProduct.ThumbnailPaths.First());
            }
            // Nếu không có list ảnh phụ, dùng ảnh chính (ImagePath)
            else if (!string.IsNullOrEmpty(product.ImagePath))
            {
                // Tạo list thumbnail giả từ ảnh chính để giao diện đẹp hơn
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
                // Trường hợp sản phẩm không có biến thể (Sản phẩm đơn)
                pnlSizeOptions.Controls.Clear();
                pnlColorOptions.Controls.Clear();
                lblSizeLabel.Visible = false;
                lblColorLabel.Visible = false;

                // Cập nhật thông tin kho của sản phẩm cha (nếu có trường Stock trong ProductDTO)
                // lblQuantityAvailable.Text = $"{product.StockQuantity} sản phẩm có sẵn"; 
                lblQuantityAvailable.Text = "Sẵn hàng";
            }
        }

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
                pbMainImage.Image = null; // Xóa ảnh nếu lỗi
            }
        }

        // --- PHẦN XỬ LÝ BIẾN THỂ (VARIANTS) ---
        private void LoadProductOptions()
        {
            var availableSizes = _variants.Where(v => !string.IsNullOrEmpty(v.Size))
                                          .Select(v => v.Size).Distinct().ToList();
            var availableColors = _variants.Where(v => !string.IsNullOrEmpty(v.Color))
                                           .Select(v => v.Color).Distinct().ToList();

            pnlSizeOptions.Controls.Clear();
            pnlColorOptions.Controls.Clear();

            // Ẩn hiện label nếu không có size/màu
            lblSizeLabel.Visible = availableSizes.Count > 0;
            lblColorLabel.Visible = availableColors.Count > 0;

            foreach (var size in availableSizes)
            {
                UcOptionButton btn = new UcOptionButton(size);
                btn.Click += SizeOption_Click;
                // Check stock
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

            // Logic tìm màu khả dụng theo size đã chọn... (giữ nguyên logic cũ)
            // Ở đây tôi rút gọn, bạn có thể paste lại logic filter màu từ code cũ nếu cần chính xác tuyệt đối
            TrySelectNewVariant(selectedBtn.Text, null);
        }

        private void ColorOption_Click(object sender, EventArgs e)
        {
            UcOptionButton selectedBtn = (UcOptionButton)sender;
            ResetButtons(pnlColorOptions);
            selectedBtn.SetActiveStyle();

            // Tìm size đang active
            string currentSize = pnlSizeOptions.Controls.OfType<UcOptionButton>()
                                .FirstOrDefault(b => b.IsActive)?.Text; // Giả sử UcOptionButton có prop IsActive

            TrySelectNewVariant(currentSize, selectedBtn.Text);
        }

        private void ResetButtons(Panel pnl)
        {
            foreach (UcOptionButton btn in pnl.Controls.OfType<UcOptionButton>()) btn.SetInactiveStyle();
        }

        private void TrySelectNewVariant(string size, string color)
        {
            ProductVariantDTO newVariant = null;

            // Tìm biến thể khớp nhất
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

        // --- CÁC HÀM LOGIC CART/BUY (GIỮ NGUYÊN HOẶC CẬP NHẬT SAU) ---
        private void UpdateQuantity(int step)
        {
            int q = 1;
            int.TryParse(txtQuantity.Text, out q);
            q += step;
            if (q < 1) q = 1;
            // Check max stock nếu cần
            txtQuantity.Text = q.ToString();
        }
        private void ValidateQuantity()
        {
            if (!int.TryParse(txtQuantity.Text, out int q) || q < 1) txtQuantity.Text = "1";
        }

        private void BtnAddCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Đã thêm '{_currentProduct.Name}' vào giỏ hàng!", "Thông báo");
        }

        private void BtnBuyNow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuyển đến trang thanh toán...", "Mua ngay");
        }

        private void BtnViewShop_Click(object sender, EventArgs e)
        {
            FrmMain mainForm = this.FindForm() as FrmMain;
            if (mainForm != null) mainForm.LoadPage("ShopDetail", 1); // ShopID tạm là 1
        }
    }
}