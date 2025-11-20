using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class VariantControl : UserControl
    {
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


        public string SizeValue => txtSize.Text;
        public string ColorValue => txtColor.Text;
        public string SKUValue => txtSKU.Text;
        public int StockValue => (int)numericStock.Value;
        public decimal PriceValue => numericPrice.Value;
    }
}
