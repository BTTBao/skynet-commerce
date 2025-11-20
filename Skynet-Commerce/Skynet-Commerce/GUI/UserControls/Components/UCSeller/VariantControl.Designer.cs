using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp11
{
    partial class VariantControl
    {

        // Khai báo Controls
        private TextBox txtSize;
        private TextBox txtColor;
        private TextBox txtSKU;
        private NumericUpDown numericStock;
        private NumericUpDown numericPrice;
        private Button btnDelete; // <-- NEW: Nút xóa

        // Khai báo Labels
        private Label lblSize;
        private Label lblColor;
        private Label lblSKU;
        private Label lblStock;
        private Label lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                new FormAddProduct().Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Khởi tạo Controls
            this.txtSize = new TextBox();
            this.txtColor = new TextBox();
            this.txtSKU = new TextBox();
            this.numericStock = new NumericUpDown();
            this.numericPrice = new NumericUpDown();
            this.btnDelete = new Button(); // Khởi tạo nút xóa

            // Khởi tạo Labels
            this.lblSize = new Label();
            this.lblColor = new Label();
            this.lblSKU = new Label();
            this.lblStock = new Label();
            this.lblPrice = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.SuspendLayout();

            int labelY = 5;
            int inputY = 25;
            int padding = 5;
            int controlHeight = 22;

            // Cấu hình UserControl
            this.Width = 520;
            this.Height = 60;
            this.BackColor = Color.LightCyan; // Màu nền để dễ phân biệt

            // --- 1. Size (Phân loại 1) ---
            this.lblSize.Text = "Size:";
            this.lblSize.Top = labelY; this.lblSize.Left = padding; this.lblSize.AutoSize = true;
            this.txtSize.Top = inputY; this.txtSize.Left = padding; this.txtSize.Width = 80; this.txtSize.Height = controlHeight;

            // --- 2. Color (Phân loại 2) ---
            this.lblColor.Text = "Màu:";
            this.lblColor.Top = labelY; this.lblColor.Left = 90 + padding; this.lblColor.AutoSize = true;
            this.txtColor.Top = inputY; this.txtColor.Left = 90 + padding; this.txtColor.Width = 80; this.txtColor.Height = controlHeight;

            // --- 3. SKU/Mã sản phẩm ---
            this.lblSKU.Text = "SKU:";
            this.lblSKU.Top = labelY; this.lblSKU.Left = 180 + padding; this.lblSKU.AutoSize = true;
            this.txtSKU.Top = inputY; this.txtSKU.Left = 180 + padding; this.txtSKU.Width = 100; this.txtSKU.Height = controlHeight;

            // --- 4. Stock (Tồn kho) ---
            this.lblStock.Text = "Kho:";
            this.lblStock.Top = labelY; this.lblStock.Left = 290 + padding; this.lblStock.AutoSize = true;
            this.numericStock.Top = inputY; this.numericStock.Left = 290 + padding; this.numericStock.Width = 60;
            this.numericStock.Minimum = 0;

            // --- 5. Price (Giá) ---
            this.lblPrice.Text = "Giá:";
            this.lblPrice.Top = labelY; this.lblPrice.Left = 360 + padding; this.lblPrice.AutoSize = true;
            this.numericPrice.Top = inputY; this.numericPrice.Left = 360 + padding; this.numericPrice.Width = 80;
            this.numericPrice.Maximum = 999999999;
            this.numericPrice.DecimalPlaces = 0;

            // --- 6. Delete Button (Nút Xóa) ---
            this.btnDelete.Text = "X";
            this.btnDelete.Top = inputY; this.btnDelete.Left = 450 + padding;
            this.btnDelete.Width = 30; this.btnDelete.Height = controlHeight;
            this.btnDelete.ForeColor = Color.Red;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click); // Gán sự kiện click

            // Add controls
            this.Controls.Add(lblSize);
            this.Controls.Add(txtSize);
            this.Controls.Add(lblColor);
            this.Controls.Add(txtColor);
            this.Controls.Add(lblSKU);
            this.Controls.Add(txtSKU);
            this.Controls.Add(lblStock);
            this.Controls.Add(numericStock);
            this.Controls.Add(lblPrice);
            this.Controls.Add(numericPrice);
            this.Controls.Add(btnDelete); // Thêm nút xóa

            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}