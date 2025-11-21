using System;
using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;

namespace Skynet_Commerce
{
    partial class FormAddProduct
    {
        private System.ComponentModel.IContainer components = null;

        // Controls đã chuyển sang Guna
        private Guna2TextBox txtName;
        private Guna2ComboBox cmbCategory;
        private Guna2TextBox numericPrice; // Giữ nguyên Guna2TextBox cho Giá theo yêu cầu mới
        private Guna2NumericUpDown numericStock;
        private Guna2TextBox txtDescription;
        private Guna2Button btnAddVariant;
        private Guna2Button btnSave;
        private Guna2Panel panelVariants;

        // **********************************
        // * NEW: IMAGE CONTROLS
        // **********************************
        private Guna2Button btnUploadImage;
        private Guna2Panel panelImages;
        private Label lblImages;
        // **********************************

        // Các Labels
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
            // Khởi tạo các Controls Guna
            this.txtName = new Guna2TextBox();
            this.cmbCategory = new Guna2ComboBox();
            this.numericPrice = new Guna2TextBox(); // Khởi tạo Guna2TextBox cho Giá
            this.numericStock = new Guna2NumericUpDown();
            this.txtDescription = new Guna2TextBox();
            this.btnAddVariant = new Guna2Button();
            this.btnSave = new Guna2Button();
            this.panelVariants = new Guna2Panel();

            // * NEW: IMAGE CONTROLS *
            this.btnUploadImage = new Guna2Button();
            this.panelImages = new Guna2Panel();
            this.lblImages = new Label();

            // Khởi tạo các Labels
            this.lblName = new Label();
            this.lblCategory = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();
            this.lblDescription = new Label();
            this.lblVariants = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            this.SuspendLayout();

            int padding = 20;
            int inputWidth = 300;
            int inputHeight = 35;
            int currentY = padding;
            int spacing = 15;
            int column2X = padding + inputWidth + 100 + spacing; // Khoảng 435

            // --- Cấu hình Form ---
            this.Text = "📝 Thêm sản phẩm mới";
            this.Size = new System.Drawing.Size(950, 850); // Tăng chiều rộng Form để chứa cột ảnh
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- CỘT 1: THÔNG TIN CƠ BẢN (Left side) ---

            // --- 1. Tên Sản Phẩm ---
            this.lblName.Text = "Tên sản phẩm:";
            this.lblName.Top = currentY; this.lblName.Left = padding; this.lblName.AutoSize = true;
            this.lblName.Font = new Font("Segoe UI", 10F);
            currentY += this.lblName.Height + 5;

            this.txtName.PlaceholderText = "Nhập tên sản phẩm";
            this.txtName.Top = currentY; this.txtName.Left = padding; this.txtName.Width = inputWidth + 100;
            this.txtName.Height = inputHeight;
            this.txtName.BorderRadius = 8;
            currentY += this.txtName.Height + spacing;

            // --- 2. Danh mục và Giá ---

            // Label Danh mục
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Top = currentY; this.lblCategory.Left = padding; this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 10F);

            // Label Giá
            this.lblPrice.Text = "Giá (VND):";
            this.lblPrice.Top = currentY; this.lblPrice.Left = padding + 220; this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new Font("Segoe UI", 10F);

            currentY += this.lblCategory.Height + 5;

            // Input Danh mục (Guna2ComboBox)
            this.cmbCategory.Top = currentY; this.cmbCategory.Left = padding; this.cmbCategory.Width = 200; this.cmbCategory.Height = inputHeight;
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Thời trang", "Điện tử", "Gia dụng", "Khác" });
            this.cmbCategory.BorderRadius = 8;
            this.cmbCategory.FillColor = Color.White;
            this.cmbCategory.BackColor = Color.Transparent;

            // Input Giá (Guna2TextBox)
            this.numericPrice.PlaceholderText = "Ví dụ: 500000";
            this.numericPrice.Top = currentY; this.numericPrice.Left = padding + 220; this.numericPrice.Width = 140;
            this.numericPrice.Height = inputHeight;
            this.numericPrice.BorderRadius = 8;
            this.numericPrice.KeyPress += new KeyPressEventHandler(this.numericPrice_KeyPress); // Chỉ cho phép nhập số
            currentY += this.cmbCategory.Height + spacing;

            // --- 3. Tồn Kho ---

            // Label Tồn kho
            this.lblStock.Text = "Số lượng tồn kho ban đầu:";
            this.lblStock.Top = currentY; this.lblStock.Left = padding; this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Segoe UI", 10F);
            currentY += this.lblStock.Height + 5;

            // Input Tồn kho (Guna2NumericUpDown)
            this.numericStock.Top = currentY; this.numericStock.Left = padding; this.numericStock.Width = 120;
            this.numericStock.Height = inputHeight;
            this.numericStock.Minimum = 0;
            this.numericStock.BorderRadius = 8;
            currentY += this.numericStock.Height + spacing;

            // --- 4. Mô tả ---

            // Label Mô tả
            this.lblDescription.Text = "Mô tả sản phẩm:";
            this.lblDescription.Top = currentY; this.lblDescription.Left = padding; this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new Font("Segoe UI", 10F);
            currentY += this.lblDescription.Height + 5;

            // Input Mô tả (Guna2TextBox)
            this.txtDescription.PlaceholderText = "Mô tả chi tiết sản phẩm...";
            this.txtDescription.Top = currentY; this.txtDescription.Left = padding; this.txtDescription.Width = inputWidth + 100;
            this.txtDescription.Height = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.BorderRadius = 8;
            currentY += this.txtDescription.Height + spacing;

            // --- 5. Phân loại (Biến thể) ---

            // Label Phân loại
            this.lblVariants.Text = "Các phân loại (Màu, Size, ...):";
            this.lblVariants.Top = currentY; this.lblVariants.Left = padding; this.lblVariants.AutoSize = true;
            this.lblVariants.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            currentY += this.lblVariants.Height + 5;

            // Panel chứa các biến thể (Guna2Panel)
            this.panelVariants.Top = currentY; this.panelVariants.Left = padding;
            this.panelVariants.Width = 580; // Giảm chiều rộng cho cột 1
            this.panelVariants.Height = 180;
            this.panelVariants.AutoScroll = true;
            this.panelVariants.BorderRadius = 10;
            this.panelVariants.BorderThickness = 1;
            this.panelVariants.BorderColor = Color.LightGray;
            this.panelVariants.FillColor = Color.WhiteSmoke;
            int panelVariantsBottomY = currentY + this.panelVariants.Height;
            currentY += this.panelVariants.Height + spacing;

            // Button Thêm phân loại (Guna2Button)
            this.btnAddVariant.Text = "Thêm phân loại";
            this.btnAddVariant.FillColor = Color.FromArgb(100, 150, 255);
            this.btnAddVariant.ForeColor = Color.White;
            this.btnAddVariant.BorderRadius = 8;
            this.btnAddVariant.Top = panelVariantsBottomY - this.btnAddVariant.Height + 60; // Đặt bên dưới panel variants
            this.btnAddVariant.Left = padding + this.panelVariants.Width + 10 - 160; // Đặt bên phải panel variants
            this.btnAddVariant.Width = 170; this.btnAddVariant.Height = inputHeight +5;
            this.btnAddVariant.Click += new EventHandler(this.btnAddVariant_Click);


            // --- CỘT 2: QUẢN LÝ ẢNH (Right side) ---

            int imageColumnX = 460;
            int imageCurrentY = padding;

            // Label Ảnh
            this.lblImages.Text = "📸 Hình ảnh sản phẩm (Tối đa 5 ảnh):";
            this.lblImages.Top = imageCurrentY; this.lblImages.Left = imageColumnX; this.lblImages.AutoSize = true;
            this.lblImages.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            imageCurrentY += this.lblImages.Height + 5;

            // Panel chứa ảnh (Thumbnails)
            this.panelImages.Top = imageCurrentY; this.panelImages.Left = imageColumnX;
            this.panelImages.Width = 400;
            this.panelImages.Height = 300;
            this.panelImages.AutoScroll = true;
            this.panelImages.BorderRadius = 10;
            this.panelImages.BorderThickness = 1;
            this.panelImages.BorderColor = Color.LightGray;
            this.panelImages.FillColor = Color.White;
            imageCurrentY += this.panelImages.Height + spacing;

            // Button Upload Ảnh
            this.btnUploadImage.Text = "⬆️ Tải lên Ảnh";
            this.btnUploadImage.FillColor = Color.FromArgb(0, 192, 0); // Màu xanh lá
            this.btnUploadImage.ForeColor = Color.White;
            this.btnUploadImage.BorderRadius = 8;
            this.btnUploadImage.Top = imageCurrentY; this.btnUploadImage.Left = imageColumnX;
            this.btnUploadImage.Width = 150; this.btnUploadImage.Height = inputHeight;
            this.btnUploadImage.Click += new EventHandler(this.btnUploadImage_Click); // Gán sự kiện


            // --- Nút ĐĂNG SẢN PHẨM (Đặt ở dưới cùng, căn giữa/trái) ---

            this.btnSave.Text = "Đăng sản phẩm";
            this.btnSave.FillColor = Color.FromArgb(255, 128, 0);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.BorderRadius = 8;
            this.btnSave.Top = Math.Max(currentY, imageCurrentY) + spacing - 15; // Đặt dưới phần dài hơn
            this.btnSave.Left = padding;
            this.btnSave.Width = 200; this.btnSave.Height = inputHeight + 5;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Cập nhật lại kích thước form
            this.Height = this.btnSave.Top + this.btnSave.Height + padding * 2;


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

            // * NEW: ADD IMAGE CONTROLS *
            this.Controls.Add(lblImages);
            this.Controls.Add(panelImages);
            this.Controls.Add(btnUploadImage);

            this.Controls.Add(btnSave);

            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}