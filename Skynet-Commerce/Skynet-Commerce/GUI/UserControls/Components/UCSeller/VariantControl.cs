using Skynet_Commerce.BLL.Models.Seller;
using System;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    public partial class VariantControl : UserControl
    {
        public class VariantUIData
        {
            public string Size { get; set; }
            public string Color { get; set; }
            public string SKU { get; set; }
            public int StockQuantity { get; set; }
            public decimal? Price { get; set; } 
        }

        public delegate void DeleteRequestedEventHandler(object sender, EventArgs e);

        // 2. Định nghĩa Event
        public event DeleteRequestedEventHandler DeleteRequested;

        // Cần thêm System.ComponentModel.IContainer components
        private System.ComponentModel.IContainer components = null;

        public VariantControl()
        {
            InitializeComponent();
        }

        // 3. Xử lý sự kiện click nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Bắn (trigger) sự kiện DeleteRequested
            DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        public bool ValidateData(out string errorMessage)
        {
            errorMessage = "";

            // 1. Validate Text Fields
            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                errorMessage = "Kích cỡ (Size) không được để trống.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                errorMessage = "Màu sắc (Color) không được để trống.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                errorMessage = "Mã SKU không được để trống.";
                return false;
            }

            // 2. Validate Stock Quantity (Đã có kiểm tra giới hạn min/max trong NumericUpDown control)
            int stock = (int)numericStock.Value;
            if (stock < 0 || stock > 10000)
            {
                errorMessage = "Số lượng tồn kho phải từ 0 đến 10,000.";
                return false;
            }

            // 3. Validate Price
            string priceText = numericPrice.Text.Replace(",", "").Replace(".", "");
            decimal price;

            if (!decimal.TryParse(priceText, out price))
            {
                errorMessage = "Giá biến thể không phải là số hợp lệ.";
                return false;
            }

            if (price < 50000 || price > 5000000)
            {
                errorMessage = "Giá biến thể phải từ 50,000 đến 5,000,000.";
                return false;
            }

            return true;
        }

        public ProductVariantDTO GetVariantDTO()
        {
            decimal? variantPrice = null;
            if (decimal.TryParse(numericPrice.Text.Replace(".", "").Replace(",", ""), out decimal parsedPrice))
            {
                variantPrice = parsedPrice;
            }
            return new ProductVariantDTO
            {
                Size = txtSize.Text.Trim(),
                Color = txtColor.Text.Trim(),
                SKU = txtSKU.Text.Trim(),
                StockQuantity = (int)numericStock.Value,
                Price = (decimal)variantPrice
            };
                
        }
        

        public void SetData(string size, string color, string sku, int stockQuantity, string price)
        {
            txtSize.Text = size ?? "";
            txtColor.Text = color ?? "";
            txtSKU.Text = sku ?? "";

            // Stock
            if (stockQuantity >= numericStock.Minimum && stockQuantity <= numericStock.Maximum)
                numericStock.Value = stockQuantity;
            else
                numericStock.Value = numericStock.Minimum;

            // Price
            numericPrice.Text = price.ToString();
        }



        public string SizeValue => txtSize.Text;
        public string ColorValue => txtColor.Text;
        public string SKUValue => txtSKU.Text;
        public int StockValue => (int)numericStock.Value;
        public decimal PriceValue => decimal.Parse(numericPrice.Text.ToString());
    }
}
