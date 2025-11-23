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

        public VariantUIData GetVariantData()
        {
            // Xử lý giá
            decimal? variantPrice = null;
            if (decimal.TryParse(numericPrice.Text.Replace(".", "").Replace(",", ""), out decimal parsedPrice))
            {
                variantPrice = parsedPrice;
            }

            return new VariantUIData
            {
                Size = txtSize.Text.Trim(),
                Color = txtColor.Text.Trim(),
                SKU = txtSKU.Text.Trim(),
                StockQuantity = (int)numericStock.Value,
                Price = variantPrice
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
