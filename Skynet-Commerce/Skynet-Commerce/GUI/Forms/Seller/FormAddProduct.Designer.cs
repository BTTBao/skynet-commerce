using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp11
{
    partial class FormAddProduct
    {
        private System.ComponentModel.IContainer components = null;

        // Controls đã khai báo
        private TextBox txtName;
        private ComboBox cmbCategory;
        private NumericUpDown numericPrice;
        private NumericUpDown numericStock;
        private TextBox txtDescription;
        private Button btnAddVariant;
        private Button btnSave;
        private Panel panelVariants;

        // Các Labels MỚI
        private Label lblName;
        private Label lblCategory;
        private Label lblPrice;
        private Label lblStock;
        private Label lblDescription;
        private Label lblVariants;


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
            // Khởi tạo các Controls
            this.txtName = new TextBox();
            this.cmbCategory = new ComboBox();
            this.numericPrice = new NumericUpDown();
            this.numericStock = new NumericUpDown();
            this.txtDescription = new TextBox();
            this.btnAddVariant = new Button();
            this.btnSave = new Button();
            this.panelVariants = new Panel();

            // Khởi tạo các Labels
            this.lblName = new Label();
            this.lblCategory = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();
            this.lblDescription = new Label();
            this.lblVariants = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            this.SuspendLayout();

            int padding = 20;
            int inputWidth = 300;
            int inputHeight = 25;
            int currentY = padding;
            int spacing = 10;

            // --- Cấu hình Form ---
            this.Text = "Thêm sản phẩm";
            this.Size = new System.Drawing.Size(600, 700);
            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen; // Căn giữa màn hình

            // --- 1. Tên Sản Phẩm ---
            this.lblName.Text = "Tên sản phẩm:";
            this.lblName.Top = currentY; this.lblName.Left = padding; this.lblName.AutoSize = true;
            currentY += this.lblName.Height + 5;

            this.txtName.Top = currentY; this.txtName.Left = padding; this.txtName.Width = inputWidth; this.txtName.Height = inputHeight;
            currentY += this.txtName.Height + spacing * 2;

            // --- 2. Danh mục và Giá ---

            // Label Danh mục
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Top = currentY; this.lblCategory.Left = padding; this.lblCategory.AutoSize = true;

            // Label Giá
            this.lblPrice.Text = "Giá (VND):";
            this.lblPrice.Top = currentY; this.lblPrice.Left = padding + 220; this.lblPrice.AutoSize = true;

            currentY += this.lblCategory.Height + 5;

            // Input Danh mục
            this.cmbCategory.Top = currentY; this.cmbCategory.Left = padding; this.cmbCategory.Width = 200; this.cmbCategory.Height = inputHeight;
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList; // Optional
            this.cmbCategory.Items.AddRange(new object[] { "Thời trang", "Điện tử", "Gia dụng", "Khác" }); // Sample items

            // Input Giá
            this.numericPrice.Top = currentY; this.numericPrice.Left = padding + 220; this.numericPrice.Width = 120; this.numericPrice.Maximum = 999999999;
            this.numericPrice.DecimalPlaces = 0; // Price in VND
            currentY += this.cmbCategory.Height + spacing * 2;

            // --- 3. Tồn Kho ---

            // Label Tồn kho
            this.lblStock.Text = "Số lượng tồn kho ban đầu:";
            this.lblStock.Top = currentY; this.lblStock.Left = padding; this.lblStock.AutoSize = true;
            currentY += this.lblStock.Height + 5;

            // Input Tồn kho
            this.numericStock.Top = currentY; this.numericStock.Left = padding; this.numericStock.Width = 100;
            this.numericStock.Minimum = 0;
            currentY += this.numericStock.Height + spacing * 2;

            // --- 4. Mô tả ---

            // Label Mô tả
            this.lblDescription.Text = "Mô tả sản phẩm:";
            this.lblDescription.Top = currentY; this.lblDescription.Left = padding; this.lblDescription.AutoSize = true;
            currentY += this.lblDescription.Height + 5;

            // Input Mô tả
            this.txtDescription.Top = currentY; this.txtDescription.Left = padding; this.txtDescription.Width = inputWidth + 100; // Increased width
            this.txtDescription.Height = 80; this.txtDescription.Multiline = true;
            currentY += this.txtDescription.Height + spacing * 2;

            // --- 5. Phân loại (Biến thể) ---

            // Label Phân loại
            this.lblVariants.Text = "Các phân loại (Màu, Size, ...):";
            this.lblVariants.Top = currentY; this.lblVariants.Left = padding; this.lblVariants.AutoSize = true;
            currentY += this.lblVariants.Height + 5;

            // Panel chứa các biến thể
            this.panelVariants.Top = currentY; this.panelVariants.Left = padding;
            this.panelVariants.Width = 540; this.panelVariants.Height = 150; // Giảm chiều cao để vừa form
            this.panelVariants.AutoScroll = true;
            this.panelVariants.BorderStyle = BorderStyle.FixedSingle;
            this.panelVariants.BackColor = Color.LightYellow; // Visual cue
            currentY += this.panelVariants.Height + spacing;

            // --- 6. Buttons ---

            // Button Thêm phân loại
            this.btnAddVariant.Text = "Thêm phân loại";
            this.btnAddVariant.BackColor = Color.LightGray; this.btnAddVariant.FlatStyle = FlatStyle.Flat;
            this.btnAddVariant.Top = currentY; this.btnAddVariant.Left = padding; this.btnAddVariant.Click += new EventHandler(this.btnAddVariant_Click);

            // Button Lưu
            this.btnSave.Text = "Đăng sản phẩm";
            this.btnSave.BackColor = Color.Orange; this.btnSave.ForeColor = Color.White; this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Top = currentY; this.btnSave.Left = padding + 150; this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Giảm kích thước form nếu cần
            this.Height = currentY + this.btnSave.Height + padding * 2;

            // --- Add controls ---
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblCategory);
            this.Controls.Add(lblPrice);
            this.Controls.Add(cmbCategory);
            this.Controls.Add(numericPrice);
            this.Controls.Add(lblStock);
            this.Controls.Add(numericStock);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(lblVariants);
            this.Controls.Add(panelVariants);
            this.Controls.Add(btnAddVariant);
            this.Controls.Add(btnSave);

            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}