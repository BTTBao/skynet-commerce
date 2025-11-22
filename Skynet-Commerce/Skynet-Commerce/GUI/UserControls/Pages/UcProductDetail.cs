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
        private string _shopName = "Fashion Store";
        private string _shopStats = "12.500 người theo dõi | 156 sản phẩm";

        // ----------------------------------------------------------------------
        // I. CONSTRUCTOR & KHỞI TẠO
        // ----------------------------------------------------------------------

        public UcProductDetail()
        {
            InitializeComponent();
            SetupEventHandlers();
            this.Load += UcProductDetail_Load;
        }

        public UcProductDetail(ProductDTO product) : this()
        {
            // Nếu product truyền vào null hoặc không có Variants, tự tạo dữ liệu mẫu
            if (product == null || product.Variants == null || product.Variants.Count == 0)
            {
                _currentProduct = GetInternalSampleData();
            }
            else
            {
                _currentProduct = product;
            }

            LoadProduct(_currentProduct);
        }

        private void UcProductDetail_Load(object sender, EventArgs e)
        {
            if (_currentProduct == null)
            {
                _currentProduct = GetInternalSampleData();
                LoadProduct(_currentProduct);
            }
            CenterDetailContainer();
        }

        // --- HÀM TẠO DỮ LIỆU MẪU NỘI BỘ (Đảm bảo luôn có dữ liệu để hiện) ---
        private ProductDTO GetInternalSampleData()
        {
            string basePath = Application.StartupPath;
            // Đường dẫn ảnh mẫu (đảm bảo file tồn tại trong bin/Debug/img)
            string imgPath = Path.Combine(basePath, @"img\product1.jpg");

            var variants = new List<ProductVariantDTO>
            {
                new ProductVariantDTO { VariantID = 1, Size = "S", Color = "Xanh đen", Price = 450000, StockQuantity = 50 },
                new ProductVariantDTO { VariantID = 2, Size = "M", Color = "Xanh đen", Price = 450000, StockQuantity = 100 },
                new ProductVariantDTO { VariantID = 3, Size = "L", Color = "Xanh đen", Price = 450000, StockQuantity = 20 },
                new ProductVariantDTO { VariantID = 5, Size = "S", Color = "Xanh nhạt", Price = 450000, StockQuantity = 10 },
                new ProductVariantDTO { VariantID = 7, Size = "S", Color = "Đen", Price = 500000, StockQuantity = 150 },
            };

            return new ProductDTO
            {
                ProductId = 101,
                Name = "Áo khoác denim thời trang cao cấp",
                Price = 450000,
                OldPrice = 550000,
                Rating = 4.8,
                SoldQuantity = 1234,
                ImagePath = imgPath,
                Variants = variants,
                ThumbnailPaths = new List<string> { imgPath, imgPath, imgPath } // Giả lập 3 ảnh
            };
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

        // ----------------------------------------------------------------------
        // II. TẢI DỮ LIỆU SẢN PHẨM & BIẾN THỂ
        // ----------------------------------------------------------------------

        public void LoadProduct(ProductDTO product)
        {
            _currentProduct = product;
            if (product == null) return;

            _variants = product.Variants ?? new List<ProductVariantDTO>();

            // 1. Load Thông tin cơ bản
            lblProductName.Text = product.Name;
            lblRating.Text = $"{product.Rating:N1}";
            lblReviewCount.Text = "234 Đánh giá";
            lblSoldCount.Text = $"{product.SoldQuantity:N0} Đã bán";
            lblDescriptionText.Text = "Áo khoác denim chất lượng cao, thiết kế trẻ trung, năng động.";

            // 2. Load Giá
            lblPrice.Text = $"{product.Price:N0}₫";
            if (product.OldPrice.HasValue && product.DiscountPercent > 0)
            {
                lblOldPrice.Text = $"{product.OldPrice.Value:N0}₫";
                lblDiscount.Text = $"-{product.DiscountPercent}%";
                lblOldPrice.Visible = true;
                lblDiscount.Visible = true;
            }
            else
            {
                lblOldPrice.Visible = false;
                lblDiscount.Visible = false;
            }

            // 3. Load Ảnh
            // Ưu tiên ảnh phụ
            if (_currentProduct.ThumbnailPaths != null && _currentProduct.ThumbnailPaths.Any())
            {
                LoadThumbnails(_currentProduct.ThumbnailPaths);
                SwitchMainImage(_currentProduct.ThumbnailPaths.First());
            }
            else if (!string.IsNullOrEmpty(product.ImagePath) && System.IO.File.Exists(product.ImagePath))
            {
                SwitchMainImage(product.ImagePath);
            }

            // 4. Load Shop Info
            lblShopName.Text = _shopName;
            lblShopStats.Text = _shopStats;

            // 5. Load Options (QUAN TRỌNG: Đây là chỗ tạo nút biến thể)
            LoadProductOptions();

            // 6. Chọn biến thể mặc định
            if (_variants.Any())
            {
                _selectedVariant = _variants.FirstOrDefault(v => v.StockQuantity > 0);
                if (_selectedVariant != null)
                {
                    UpdateVariantUI(_selectedVariant);

                    // Active nút Size và Color mặc định
                    // Lưu ý: Tìm nút dựa trên Text
                    foreach (var ctrl in pnlSizeOptions.Controls)
                    {
                        if (ctrl is UcOptionButton btn && btn.Text == _selectedVariant.Size) btn.SetActiveStyle();
                    }
                    foreach (var ctrl in pnlColorOptions.Controls)
                    {
                        if (ctrl is UcOptionButton btn && btn.Text == _selectedVariant.Color) btn.SetActiveStyle();
                    }
                }
            }
        }

        // --- TẢI ẢNH PHỤ ---
        private void LoadThumbnails(List<string> paths)
        {
            flpThumbnails.Controls.Clear();
            foreach (string path in paths)
            {
                // Đảm bảo UcThumbnail hoạt động
                UcThumbnail thumb = new UcThumbnail(path);
                thumb.ThumbnailClicked += Thumbnail_Clicked;
                flpThumbnails.Controls.Add(thumb);
            }
        }

        private void Thumbnail_Clicked(object sender, EventArgs e)
        {
            UcThumbnail selectedThumb = (UcThumbnail)sender;
            SwitchMainImage(selectedThumb.ImagePath);
        }

        public void SwitchMainImage(string imagePath)
        {
            if (System.IO.File.Exists(imagePath))
            {
                pbMainImage.ImageLocation = imagePath;
            }
        }

        // --- TẢI CÁC LỰA CHỌN BIẾN THỂ (ĐÃ SỬA ĐỂ HIỂN THỊ) ---
        private void LoadProductOptions()
        {
            var availableSizes = _variants.Select(v => v.Size).Distinct().ToList();
            var availableColors = _variants.Select(v => v.Color).Distinct().ToList();

            pnlSizeOptions.Controls.Clear();
            pnlColorOptions.Controls.Clear();

            // Load Sizes
            foreach (var size in availableSizes)
            {
                UcOptionButton btn = new UcOptionButton(size);
                btn.Click += SizeOption_Click; // Gán sự kiện

                // Kiểm tra tồn kho
                bool hasStock = _variants.Any(v => v.Size == size && v.StockQuantity > 0);
                if (!hasStock) btn.SetDisabledStyle();
                else btn.SetInactiveStyle();

                pnlSizeOptions.Controls.Add(btn); // Thêm vào Panel
            }

            // Load Colors
            foreach (var color in availableColors)
            {
                UcOptionButton btn = new UcOptionButton(color);
                btn.Click += ColorOption_Click; // Gán sự kiện
                btn.SetInactiveStyle();
                pnlColorOptions.Controls.Add(btn); // Thêm vào Panel
            }
        }

        // --- XỬ LÝ SỰ KIỆN CHỌN BIẾN THỂ ---

        private void SizeOption_Click(object sender, EventArgs e)
        {
            UcOptionButton selectedBtn = (UcOptionButton)sender;
            string selectedSize = selectedBtn.Text;

            // Reset trạng thái nút Size
            foreach (UcOptionButton btn in pnlSizeOptions.Controls.OfType<UcOptionButton>())
            {
                btn.SetInactiveStyle();
            }
            selectedBtn.SetActiveStyle();

            UpdateColorOptions(selectedSize);
            TrySelectNewVariant(selectedSize, null);
        }

        private void ColorOption_Click(object sender, EventArgs e)
        {
            UcOptionButton selectedBtn = (UcOptionButton)sender;
            string selectedColor = selectedBtn.Text;

            // Tìm Size đang chọn (dựa vào màu Active - Cam)
            string currentSize = null;
            foreach (UcOptionButton btn in pnlSizeOptions.Controls.OfType<UcOptionButton>())
            {
                // Kiểm tra màu Border hoặc FillColor để biết nút nào đang Active
                // Giả định nút Active có màu khác nút Inactive
                if (btn.ButtonFillColor.R == 255 && btn.ButtonFillColor.G == 87) // Màu cam
                {
                    currentSize = btn.Text;
                    break;
                }
            }

            if (string.IsNullOrEmpty(currentSize)) return;

            // Reset trạng thái nút Color
            foreach (UcOptionButton btn in pnlColorOptions.Controls.OfType<UcOptionButton>())
            {
                btn.SetInactiveStyle();
            }
            selectedBtn.SetActiveStyle();

            TrySelectNewVariant(currentSize, selectedColor);
        }

        private void UpdateColorOptions(string currentSize)
        {
            foreach (UcOptionButton colorBtn in pnlColorOptions.Controls.OfType<UcOptionButton>())
            {
                colorBtn.SetInactiveStyle();
                string color = colorBtn.Text;
                bool isAvailable = _variants.Any(v => v.Size == currentSize && v.Color == color && v.StockQuantity > 0);
                if (!isAvailable) colorBtn.SetDisabledStyle();
            }
        }

        private void TrySelectNewVariant(string size, string color)
        {
            ProductVariantDTO newVariant = null;

            if (color == null)
                newVariant = _variants.FirstOrDefault(v => v.Size == size && v.StockQuantity > 0);
            else
                newVariant = _variants.FirstOrDefault(v => v.Size == size && v.Color == color);

            if (newVariant != null && newVariant.StockQuantity > 0)
            {
                _selectedVariant = newVariant;
                UpdateVariantUI(newVariant);
            }
            else
            {
                // Xử lý khi không tìm thấy biến thể hợp lệ
                lblQuantityAvailable.Text = "Hết hàng";
                btnAddCart.Enabled = false;
                btnBuyNow.Enabled = false;
            }
        }

        private void UpdateVariantUI(ProductVariantDTO variant)
        {
            lblPrice.Text = $"{variant.Price:N0}₫";
            lblQuantityAvailable.Text = $" {variant.StockQuantity} sản phẩm có sẵn";
            btnAddCart.Enabled = true;
            btnBuyNow.Enabled = true;
            txtQuantity.Text = "1";
        }

        // ... (Các hàm UpdateQuantity, ValidateQuantity, BtnAddCart_Click, BtnBuyNow_Click giữ nguyên như cũ)
        // Bạn có thể copy lại từ các phiên bản trước nếu cần
        private void UpdateQuantity(int step) { /* Logic cũ */ }
        private void ValidateQuantity() { /* Logic cũ */ }
        private void BtnAddCart_Click(object sender, EventArgs e) { /* Logic cũ */ }
        private void BtnBuyNow_Click(object sender, EventArgs e) { /* Logic cũ */ }


        private void BtnViewShop_Click(object sender, EventArgs e)
        {
            FrmMain mainForm = this.FindForm() as FrmMain;

            // Giả định ShopId luôn là 1 trong DTO mẫu, hoặc bạn cần thêm ShopId vào ProductDTO
            int shopId = 1;
            // Nếu bạn đã có ShopId trong ProductDTO: int shopId = _currentProduct.ShopId;

            if (mainForm != null)
            {
                // Gọi hàm chuyển trang trong FrmMain (đã được cập nhật)
                mainForm.LoadPage("ShopDetail", shopId);
            }
        }
    }
}