using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Components
{
    partial class UcProductItem
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSold = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblOldPrice = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pbProductImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard.BorderRadius = 12;
            this.pnlCard.Controls.Add(this.lblSold);
            this.pnlCard.Controls.Add(this.lblRating);
            this.pnlCard.Controls.Add(this.lblPrice);
            this.pnlCard.Controls.Add(this.lblOldPrice);
            this.pnlCard.Controls.Add(this.lblProductName);
            this.pnlCard.Controls.Add(this.pbProductImage);
            this.pnlCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.ShadowDecoration.BorderRadius = 12;
            this.pnlCard.ShadowDecoration.Depth = 5;
            this.pnlCard.ShadowDecoration.Enabled = true;
            this.pnlCard.Size = new System.Drawing.Size(180, 300);
            this.pnlCard.TabIndex = 0;
            // 
            // lblSold
            // 
            this.lblSold.AutoSize = true;
            this.lblSold.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSold.ForeColor = System.Drawing.Color.Gray;
            this.lblSold.Location = new System.Drawing.Point(60, 230);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(77, 13);
            this.lblSold.TabIndex = 5;
            this.lblSold.Text = "| Đã bán 1234";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.lblRating.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRating.Location = new System.Drawing.Point(10, 230);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(35, 13);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "★ 4.8";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblPrice.Location = new System.Drawing.Point(10, 255);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(77, 20);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "450.000₫";
            // 
            // lblOldPrice
            // 
            this.lblOldPrice.AutoSize = true;
            this.lblOldPrice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPrice.ForeColor = System.Drawing.Color.Silver;
            this.lblOldPrice.Location = new System.Drawing.Point(10, 275);
            this.lblOldPrice.Name = "lblOldPrice";
            this.lblOldPrice.Size = new System.Drawing.Size(52, 13);
            this.lblOldPrice.TabIndex = 2;
            this.lblOldPrice.Text = "550.000₫";
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(10, 185);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(160, 40);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Áo khoác denim thời trang cao cấp...";
            // 
            // pbProductImage
            // 
            this.pbProductImage.BorderRadius = 12;
            this.pbProductImage.Image = global::Skynet_Commerce.Properties.Resources.anh_nen;
            this.pbProductImage.ImageRotate = 0F;
            this.pbProductImage.Location = new System.Drawing.Point(0, 0);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(180, 180);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductImage.TabIndex = 0;
            this.pbProductImage.TabStop = false;
            // 
            // UcProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCard);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.Name = "UcProductItem";
            this.Size = new System.Drawing.Size(180, 300);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel pnlCard;
        private Guna2PictureBox pbProductImage;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblOldPrice;
        private Label lblRating;
        private Label lblSold;
    }
}