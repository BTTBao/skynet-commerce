namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Main Panel
            this.mainPanel = new System.Windows.Forms.Panel();

            // Group Box 1 - Thông tin cơ bản
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            // Group Box 2 - Hình ảnh
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelMainImage = new System.Windows.Forms.Panel();
            this.lblMainImage = new System.Windows.Forms.Label();
            this.btnSelectMainImage = new System.Windows.Forms.Button();
            this.picMainImage = new System.Windows.Forms.PictureBox();
            this.panelSubImages = new System.Windows.Forms.Panel();
            this.lblSubImages = new System.Windows.Forms.Label();
            this.btnAddSubImage = new System.Windows.Forms.Button();
            this.flowLayoutSubImages = new System.Windows.Forms.FlowLayoutPanel();

            // Group Box 3 - Variants
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelVariantHeader = new System.Windows.Forms.Panel();
            this.btnAddVariant = new System.Windows.Forms.Button();
            this.panelVariants = new System.Windows.Forms.Panel();
            this.flowLayoutVariants = new System.Windows.Forms.FlowLayoutPanel();

            // Buttons
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1000, 700);
            this.mainPanel.TabIndex = 0;

            // 
            // groupBox1 - Thông tin cơ bản
            // 
            this.groupBox1.Controls.Add(this.lblProductName);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductName.Location = new System.Drawing.Point(20, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(90, 15);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Tên sản phẩm:";

            // txtProductName
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductName.Location = new System.Drawing.Point(130, 27);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(350, 23);
            this.txtProductName.TabIndex = 1;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(520, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(67, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Danh mục:";

            // cboCategory
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(600, 27);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(300, 23);
            this.cboCategory.TabIndex = 3;

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrice.Location = new System.Drawing.Point(20, 70);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 15);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá:";

            // txtPrice
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrice.Location = new System.Drawing.Point(130, 67);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 23);
            this.txtPrice.TabIndex = 5;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(20, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(46, 15);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Mô tả:";

            // txtDescription
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(130, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(770, 70);
            this.txtDescription.TabIndex = 7;

            // 
            // groupBox2 - Hình ảnh
            // 
            this.groupBox2.Controls.Add(this.panelMainImage);
            this.groupBox2.Controls.Add(this.panelSubImages);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(20, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình ảnh";

            // panelMainImage
            this.panelMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainImage.Controls.Add(this.lblMainImage);
            this.panelMainImage.Controls.Add(this.btnSelectMainImage);
            this.panelMainImage.Controls.Add(this.picMainImage);
            this.panelMainImage.Location = new System.Drawing.Point(20, 30);
            this.panelMainImage.Name = "panelMainImage";
            this.panelMainImage.Size = new System.Drawing.Size(250, 200);
            this.panelMainImage.TabIndex = 0;

            // lblMainImage
            this.lblMainImage.AutoSize = true;
            this.lblMainImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMainImage.Location = new System.Drawing.Point(10, 10);
            this.lblMainImage.Name = "lblMainImage";
            this.lblMainImage.Size = new System.Drawing.Size(80, 15);
            this.lblMainImage.TabIndex = 0;
            this.lblMainImage.Text = "Ảnh chính";

            // picMainImage
            this.picMainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMainImage.Location = new System.Drawing.Point(10, 35);
            this.picMainImage.Name = "picMainImage";
            this.picMainImage.Size = new System.Drawing.Size(230, 120);
            this.picMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainImage.TabIndex = 1;
            this.picMainImage.TabStop = false;

            // btnSelectMainImage
            this.btnSelectMainImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectMainImage.Location = new System.Drawing.Point(10, 165);
            this.btnSelectMainImage.Name = "btnSelectMainImage";
            this.btnSelectMainImage.Size = new System.Drawing.Size(230, 25);
            this.btnSelectMainImage.TabIndex = 2;
            this.btnSelectMainImage.Text = "Chọn ảnh";
            this.btnSelectMainImage.UseVisualStyleBackColor = true;
            this.btnSelectMainImage.Click += new System.EventHandler(this.btnSelectMainImage_Click);

            // panelSubImages
            this.panelSubImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSubImages.Controls.Add(this.lblSubImages);
            this.panelSubImages.Controls.Add(this.btnAddSubImage);
            this.panelSubImages.Controls.Add(this.flowLayoutSubImages);
            this.panelSubImages.Location = new System.Drawing.Point(290, 30);
            this.panelSubImages.Name = "panelSubImages";
            this.panelSubImages.Size = new System.Drawing.Size(630, 200);
            this.panelSubImages.TabIndex = 1;

            // lblSubImages
            this.lblSubImages.AutoSize = true;
            this.lblSubImages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubImages.Location = new System.Drawing.Point(10, 10);
            this.lblSubImages.Name = "lblSubImages";
            this.lblSubImages.Size = new System.Drawing.Size(80, 15);
            this.lblSubImages.TabIndex = 0;
            this.lblSubImages.Text = "Ảnh phụ";

            // btnAddSubImage
            this.btnAddSubImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddSubImage.Location = new System.Drawing.Point(490, 5);
            this.btnAddSubImage.Name = "btnAddSubImage";
            this.btnAddSubImage.Size = new System.Drawing.Size(130, 25);
            this.btnAddSubImage.TabIndex = 1;
            this.btnAddSubImage.Text = "+ Thêm ảnh phụ";
            this.btnAddSubImage.UseVisualStyleBackColor = true;
            this.btnAddSubImage.Click += new System.EventHandler(this.btnAddSubImage_Click);

            // flowLayoutSubImages
            this.flowLayoutSubImages.AutoScroll = true;
            this.flowLayoutSubImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutSubImages.Location = new System.Drawing.Point(10, 35);
            this.flowLayoutSubImages.Name = "flowLayoutSubImages";
            this.flowLayoutSubImages.Size = new System.Drawing.Size(610, 155);
            this.flowLayoutSubImages.TabIndex = 2;

            // 
            // groupBox3 - Variants
            // 
            this.groupBox3.Controls.Add(this.panelVariantHeader);
            this.groupBox3.Controls.Add(this.panelVariants);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(20, 490);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(940, 300);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Biến thể (Variants)";

            // panelVariantHeader
            this.panelVariantHeader.Controls.Add(this.btnAddVariant);
            this.panelVariantHeader.Location = new System.Drawing.Point(20, 30);
            this.panelVariantHeader.Name = "panelVariantHeader";
            this.panelVariantHeader.Size = new System.Drawing.Size(900, 35);
            this.panelVariantHeader.TabIndex = 0;

            // btnAddVariant
            this.btnAddVariant.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddVariant.Location = new System.Drawing.Point(0, 5);
            this.btnAddVariant.Name = "btnAddVariant";
            this.btnAddVariant.Size = new System.Drawing.Size(150, 25);
            this.btnAddVariant.TabIndex = 0;
            this.btnAddVariant.Text = "+ Thêm biến thể";
            this.btnAddVariant.UseVisualStyleBackColor = true;
            this.btnAddVariant.Click += new System.EventHandler(this.btnAddVariant_Click);

            // panelVariants
            this.panelVariants.AutoScroll = true;
            this.panelVariants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVariants.Controls.Add(this.flowLayoutVariants);
            this.panelVariants.Location = new System.Drawing.Point(20, 70);
            this.panelVariants.Name = "panelVariants";
            this.panelVariants.Size = new System.Drawing.Size(900, 210);
            this.panelVariants.TabIndex = 1;

            // flowLayoutVariants
            this.flowLayoutVariants.AutoScroll = true;
            this.flowLayoutVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutVariants.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutVariants.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutVariants.Name = "flowLayoutVariants";
            this.flowLayoutVariants.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutVariants.Size = new System.Drawing.Size(898, 208);
            this.flowLayoutVariants.TabIndex = 0;
            this.flowLayoutVariants.WrapContents = false;

            // 
            // Buttons
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(720, 810);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(850, 810);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 870);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm sản phẩm mới";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMainImage)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelMainImage;
        private System.Windows.Forms.Label lblMainImage;
        private System.Windows.Forms.Button btnSelectMainImage;
        private System.Windows.Forms.PictureBox picMainImage;
        private System.Windows.Forms.Panel panelSubImages;
        private System.Windows.Forms.Label lblSubImages;
        private System.Windows.Forms.Button btnAddSubImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSubImages;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panelVariantHeader;
        private System.Windows.Forms.Button btnAddVariant;
        private System.Windows.Forms.Panel panelVariants;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutVariants;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}