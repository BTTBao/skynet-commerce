namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerProductDetailForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblSoldCount = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlReviews = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVariants = new Guna.UI2.WinForms.Guna2DataGridView();
            this.picMain = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlThumbnails
            // 
            this.pnlThumbnails.AutoScroll = true;
            this.pnlThumbnails.Location = new System.Drawing.Point(20, 371);
            this.pnlThumbnails.Name = "pnlThumbnails";
            this.pnlThumbnails.Size = new System.Drawing.Size(400, 80);
            this.pnlThumbnails.TabIndex = 1;
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(440, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(520, 40);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên Sản Phẩm";
            // 
            // lblSoldCount
            // 
            this.lblSoldCount.AutoSize = true;
            this.lblSoldCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldCount.Location = new System.Drawing.Point(444, 72);
            this.lblSoldCount.Name = "lblSoldCount";
            this.lblSoldCount.Size = new System.Drawing.Size(83, 28);
            this.lblSoldCount.TabIndex = 8;
            this.lblSoldCount.Text = "Đã bán: 0";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.Location = new System.Drawing.Point(595, 72);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(120, 28);
            this.lblRating.TabIndex = 9;
            this.lblRating.Text = "⭐ 0.0/5";
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.Crimson;
            this.lblPrice.Location = new System.Drawing.Point(441, 116);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(200, 52);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "0 đ";
            // 
            // pnlReviews
            // 
            this.pnlReviews.AutoScroll = true;
            this.pnlReviews.BorderColor = System.Drawing.Color.Silver;
            this.pnlReviews.BorderThickness = 1;
            this.pnlReviews.Location = new System.Drawing.Point(20, 511);
            this.pnlReviews.Name = "pnlReviews";
            this.pnlReviews.Size = new System.Drawing.Size(940, 189);
            this.pnlReviews.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "ĐÁNH GIÁ TỪ NGƯỜI DÙNG";
            // 
            // dgvVariants
            // 
            this.dgvVariants.AllowUserToAddRows = false;
            this.dgvVariants.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvVariants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVariants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVariants.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVariants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVariants.ColumnHeadersHeight = 40;
            this.dgvVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVariants.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVariants.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVariants.Location = new System.Drawing.Point(449, 190);
            this.dgvVariants.Name = "dgvVariants";
            this.dgvVariants.ReadOnly = true;
            this.dgvVariants.RowHeadersVisible = false;
            this.dgvVariants.RowHeadersWidth = 51;
            this.dgvVariants.RowTemplate.Height = 35;
            this.dgvVariants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVariants.Size = new System.Drawing.Size(511, 163);
            this.dgvVariants.TabIndex = 10;
            this.dgvVariants.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVariants.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvVariants.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvVariants.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvVariants.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvVariants.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvVariants.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVariants.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvVariants.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVariants.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVariants.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVariants.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvVariants.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvVariants.ThemeStyle.ReadOnly = true;
            this.dgvVariants.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVariants.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVariants.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVariants.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVariants.ThemeStyle.RowsStyle.Height = 35;
            this.dgvVariants.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVariants.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // picMain
            // 
            this.picMain.BorderRadius = 10;
            this.picMain.FillColor = System.Drawing.Color.LightGray;
            this.picMain.ImageRotate = 0F;
            this.picMain.Location = new System.Drawing.Point(20, 20);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(400, 333);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(449, 390);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(511, 61);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(445, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mô tả:";
            // 
            // SellerProductDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dgvVariants);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblSoldCount);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.pnlThumbnails);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.pnlReviews);
            this.Controls.Add(this.label1);
            this.Name = "SellerProductDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết sản phẩm - Skynet";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2PictureBox picMain;
        private System.Windows.Forms.FlowLayoutPanel pnlThumbnails;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2Panel pnlReviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblSoldCount;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVariants;
    }
}