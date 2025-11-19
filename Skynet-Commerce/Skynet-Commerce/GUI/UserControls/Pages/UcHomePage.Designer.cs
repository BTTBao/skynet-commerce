using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms; // Đảm bảo thư viện Guna được sử dụng

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcHomePage
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
            this.components = new System.ComponentModel.Container();
            this.pnlScrollContainer = new System.Windows.Forms.Panel();
            this.flpSections = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBanner = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNextBanner = new System.Windows.Forms.Button();
            this.btnPrevBanner = new System.Windows.Forms.Button();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.pnlCategoryGrid = new System.Windows.Forms.Panel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRecommendedTitle = new System.Windows.Forms.Label();
            this.flpRecommendedProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrBannerSlide = new System.Windows.Forms.Timer(this.components);
            this.pbBanner = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlScrollContainer.SuspendLayout();
            this.flpSections.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.pnlCategoryGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScrollContainer
            // 
            this.pnlScrollContainer.AutoScroll = true;
            this.pnlScrollContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlScrollContainer.Controls.Add(this.flpSections);
            this.pnlScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlScrollContainer.Name = "pnlScrollContainer";
            this.pnlScrollContainer.Size = new System.Drawing.Size(950, 381);
            this.pnlScrollContainer.TabIndex = 0;
            // 
            // flpSections
            // 
            this.flpSections.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpSections.Controls.Add(this.pnlBanner);
            this.flpSections.Controls.Add(this.lblCategoryTitle);
            this.flpSections.Controls.Add(this.pnlCategoryGrid);
            this.flpSections.Controls.Add(this.lblRecommendedTitle);
            this.flpSections.Controls.Add(this.flpRecommendedProducts);
            this.flpSections.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSections.Location = new System.Drawing.Point(-18, 0);
            this.flpSections.Name = "flpSections";
            this.flpSections.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flpSections.Size = new System.Drawing.Size(930, 880);
            this.flpSections.TabIndex = 0;
            this.flpSections.WrapContents = false;
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.Transparent;
            this.pnlBanner.BorderRadius = 15;
            this.pnlBanner.Controls.Add(this.btnNextBanner);
            this.pnlBanner.Controls.Add(this.btnPrevBanner);
            this.pnlBanner.Controls.Add(this.pbBanner);
            this.pnlBanner.Location = new System.Drawing.Point(3, 13);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.ShadowDecoration.BorderRadius = 15;
            this.pnlBanner.ShadowDecoration.Enabled = true;
            this.pnlBanner.Size = new System.Drawing.Size(920, 250);
            this.pnlBanner.TabIndex = 1;
            // 
            // btnNextBanner
            // 
            this.btnNextBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextBanner.BackColor = System.Drawing.Color.White;
            this.btnNextBanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextBanner.Location = new System.Drawing.Point(880, 100);
            this.btnNextBanner.Name = "btnNextBanner";
            this.btnNextBanner.Size = new System.Drawing.Size(30, 40);
            this.btnNextBanner.TabIndex = 2;
            this.btnNextBanner.UseVisualStyleBackColor = false;
            // 
            // btnPrevBanner
            // 
            this.btnPrevBanner.BackColor = System.Drawing.Color.White;
            this.btnPrevBanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevBanner.Location = new System.Drawing.Point(10, 100);
            this.btnPrevBanner.Name = "btnPrevBanner";
            this.btnPrevBanner.Size = new System.Drawing.Size(30, 40);
            this.btnPrevBanner.TabIndex = 1;
            this.btnPrevBanner.UseVisualStyleBackColor = false;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryTitle.Location = new System.Drawing.Point(15, 276);
            this.lblCategoryTitle.Margin = new System.Windows.Forms.Padding(15, 10, 3, 0);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(102, 25);
            this.lblCategoryTitle.TabIndex = 4;
            this.lblCategoryTitle.Text = "Danh mục";
            // 
            // pnlCategoryGrid
            // 
            this.pnlCategoryGrid.Controls.Add(this.flpCategories);
            this.pnlCategoryGrid.Location = new System.Drawing.Point(3, 304);
            this.pnlCategoryGrid.Name = "pnlCategoryGrid";
            this.pnlCategoryGrid.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCategoryGrid.Size = new System.Drawing.Size(920, 151);
            this.pnlCategoryGrid.TabIndex = 5;
            // 
            // flpCategories
            // 
            this.flpCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCategories.Location = new System.Drawing.Point(15, 10);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(890, 131);
            this.flpCategories.TabIndex = 0;
            // 
            // lblRecommendedTitle
            // 
            this.lblRecommendedTitle.AutoSize = true;
            this.lblRecommendedTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendedTitle.Location = new System.Drawing.Point(15, 468);
            this.lblRecommendedTitle.Margin = new System.Windows.Forms.Padding(15, 10, 3, 0);
            this.lblRecommendedTitle.Name = "lblRecommendedTitle";
            this.lblRecommendedTitle.Size = new System.Drawing.Size(140, 25);
            this.lblRecommendedTitle.TabIndex = 7;
            this.lblRecommendedTitle.Text = "Gợi ý hôm nay";
            // 
            // flpRecommendedProducts
            // 
            this.flpRecommendedProducts.BackColor = System.Drawing.Color.White;
            this.flpRecommendedProducts.Location = new System.Drawing.Point(3, 496);
            this.flpRecommendedProducts.Name = "flpRecommendedProducts";
            this.flpRecommendedProducts.Padding = new System.Windows.Forms.Padding(30, 10, 15, 10);
            this.flpRecommendedProducts.Size = new System.Drawing.Size(920, 360);
            this.flpRecommendedProducts.TabIndex = 8;
            // 
            // tmrBannerSlide
            // 
            this.tmrBannerSlide.Interval = 5000;
            // 
            // pbBanner
            // 
            this.pbBanner.BorderRadius = 15;
            this.pbBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBanner.ImageRotate = 0F;
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(920, 250);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // UcHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScrollContainer);
            this.Name = "UcHomePage";
            this.Size = new System.Drawing.Size(950, 381);
            this.pnlScrollContainer.ResumeLayout(false);
            this.flpSections.ResumeLayout(false);
            this.flpSections.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.pnlCategoryGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo lại các controls Banner đã chuyển đổi
        private Guna.UI2.WinForms.Guna2Panel pnlBanner;
        private Guna.UI2.WinForms.Guna2PictureBox pbBanner;

        // ... (Giữ nguyên các khai báo khác)

        private System.Windows.Forms.Panel pnlScrollContainer;
        private System.Windows.Forms.FlowLayoutPanel flpSections;

        private System.Windows.Forms.Button btnPrevBanner;
        private System.Windows.Forms.Button btnNextBanner;
        private System.Windows.Forms.Timer tmrBannerSlide;

        // Category
        private System.Windows.Forms.Panel pnlCategoryGrid;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.Label lblCategoryTitle;

        // Recommended Products
        private System.Windows.Forms.Label lblRecommendedTitle;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendedProducts;
    }
}