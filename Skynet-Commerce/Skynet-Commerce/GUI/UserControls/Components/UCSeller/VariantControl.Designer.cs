using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;

namespace Skynet_Commerce
{
    partial class VariantControl
    {
        private Guna2TextBox txtSize;
        private Guna2TextBox txtColor;
        private Guna2TextBox txtSKU;
        private Guna2NumericUpDown numericStock;
        private Guna2TextBox numericPrice;
        private Guna2Button btnDelete;

        private Label lblSize;
        private Label lblColor;
        private Label lblSKU;
        private Label lblStock;
        private Label lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSize = new Guna2TextBox();
            this.txtColor = new Guna2TextBox();
            this.txtSKU = new Guna2TextBox();
            this.numericStock = new Guna2NumericUpDown();
            this.numericPrice = new Guna2TextBox();
            this.btnDelete = new Guna2Button();

            this.lblSize = new Label();
            this.lblColor = new Label();
            this.lblSKU = new Label();
            this.lblStock = new Label();
            this.lblPrice = new Label();

            this.SuspendLayout();

            int labelY = 5;
            int inputY = 25;
            int padding = 5;
            int controlHeight = 30;

            this.Width = 520;
            this.Height = 70;
            this.BackColor = Color.White;
            this.Margin = new Padding(0, 5, 0, 5);

            Font labelFont = new Font("Segoe UI", 9F);
            Font inputFont = new Font("Segoe UI", 10F); // Tăng font chữ ô nhập

            // --- 1. Size ---
            this.lblSize.Text = "Size:";
            this.lblSize.Top = labelY;
            this.lblSize.Left = padding;
            this.lblSize.AutoSize = true;
            this.lblSize.Font = labelFont;

            this.txtSize.Text = "";         // Tắt placeholder
            this.txtSize.ForeColor = Color.Black;
            this.txtSize.Font = inputFont;
            this.txtSize.Top = inputY;
            this.txtSize.Left = padding;
            this.txtSize.Width = 70;
            this.txtSize.Height = controlHeight;
            this.txtSize.BorderRadius = 5;

            // --- 2. Color ---
            this.lblColor.Text = "Màu:";
            this.lblColor.Top = labelY;
            this.lblColor.Left = 80 + padding;
            this.lblColor.AutoSize = true;
            this.lblColor.Font = labelFont;

            this.txtColor.Text = "";
            this.txtColor.ForeColor = Color.Black;
            this.txtColor.Font = inputFont;
            this.txtColor.Top = inputY;
            this.txtColor.Left = 80 + padding;
            this.txtColor.Width = 70;
            this.txtColor.Height = controlHeight;
            this.txtColor.BorderRadius = 5;

            // --- 3. SKU ---
            this.lblSKU.Text = "SKU:";
            this.lblSKU.Top = labelY;
            this.lblSKU.Left = 160 + padding;
            this.lblSKU.AutoSize = true;
            this.lblSKU.Font = labelFont;

            this.txtSKU.Text = "";
            this.txtSKU.ForeColor = Color.Black;
            this.txtSKU.Font = inputFont;
            this.txtSKU.Top = inputY;
            this.txtSKU.Left = 160 + padding;
            this.txtSKU.Width = 100;
            this.txtSKU.Height = controlHeight;
            this.txtSKU.BorderRadius = 5;

            // --- 4. Stock ---
            this.lblStock.Text = "Kho:";
            this.lblStock.Top = labelY;
            this.lblStock.Left = 270 + padding;
            this.lblStock.AutoSize = true;
            this.lblStock.Font = labelFont;

            this.numericStock.Top = inputY;
            this.numericStock.Left = 270 + padding;
            this.numericStock.Width = 80;
            this.numericStock.Minimum = 0;
            this.numericStock.BorderRadius = 5;
            this.numericStock.Font = inputFont;
            this.numericStock.ForeColor = Color.Black;

            // --- 5. Price ---
            this.lblPrice.Text = "Giá:";
            this.lblPrice.Top = labelY;
            this.lblPrice.Left = 360 + padding;
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = labelFont;

            this.numericPrice.Text = "";
            this.numericPrice.ForeColor = Color.Black;
            this.numericPrice.Font = inputFont;
            this.numericPrice.Top = inputY;
            this.numericPrice.Left = 360 + padding;
            this.numericPrice.Width = 100;
            this.numericPrice.BorderRadius = 5;
            this.numericPrice.Height = controlHeight;

            // --- 6. Delete Button ---
            this.btnDelete.Text = "✖";
            this.btnDelete.FillColor = Color.Transparent;
            this.btnDelete.ForeColor = Color.Red;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.Top = inputY - 3;
            this.btnDelete.Left = 470 + padding;
            this.btnDelete.Width = 50;
            this.btnDelete.Height = 35;
            this.btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

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
            this.Controls.Add(btnDelete);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
