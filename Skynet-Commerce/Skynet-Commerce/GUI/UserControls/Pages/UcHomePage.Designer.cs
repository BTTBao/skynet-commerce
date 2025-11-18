using System.Drawing;
using System.Windows.Forms;

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
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.btnNextBanner = new System.Windows.Forms.Button();
            this.btnPrevBanner = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.pnlCategoryGrid = new System.Windows.Forms.Panel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.lblRecommendedTitle = new System.Windows.Forms.Label();
            this.flpRecommendedProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrBannerSlide = new System.Windows.Forms.Timer(this.components);
            this.pnlScrollContainer.SuspendLayout();
            this.flpSections.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.pnlCategoryGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScrollContainer
            // 
            this.pnlScrollContainer.AutoScroll = true;
            this.pnlScrollContainer.Controls.Add(this.flpSections);
            this.pnlScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlScrollContainer.Name = "pnlScrollContainer";
            this.pnlScrollContainer.Size = new System.Drawing.Size(1200, 800);
            this.pnlScrollContainer.TabIndex = 0;
            // 
            // flpSections
            // 
            this.flpSections.AutoSize = true;
            this.flpSections.Controls.Add(this.pnlBanner);
            this.flpSections.Controls.Add(this.pnlCategoryGrid);
            this.flpSections.Controls.Add(this.lblRecommendedTitle);
            this.flpSections.Controls.Add(this.flpRecommendedProducts);
            this.flpSections.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSections.Location = new System.Drawing.Point(0, 0);
            this.flpSections.Name = "flpSections";
            this.flpSections.Size = new System.Drawing.Size(1106, 879);
            this.flpSections.TabIndex = 0;
            this.flpSections.WrapContents = false;
            // 
            // pnlBanner
            // 
            this.pnlBanner.Controls.Add(this.btnNextBanner);
            this.pnlBanner.Controls.Add(this.btnPrevBanner);
            this.pnlBanner.Controls.Add(this.pbBanner);
            this.pnlBanner.Location = new System.Drawing.Point(3, 3);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1100, 300);
            this.pnlBanner.TabIndex = 0;
            // 
            // btnNextBanner
            // 
            this.btnNextBanner.Location = new System.Drawing.Point(1040, 130);
            this.btnNextBanner.Name = "btnNextBanner";
            this.btnNextBanner.Size = new System.Drawing.Size(40, 40);
            this.btnNextBanner.TabIndex = 2;
            this.btnNextBanner.Text = ">";
            this.btnNextBanner.UseVisualStyleBackColor = true;
            // 
            // btnPrevBanner
            // 
            this.btnPrevBanner.Location = new System.Drawing.Point(20, 130);
            this.btnPrevBanner.Name = "btnPrevBanner";
            this.btnPrevBanner.Size = new System.Drawing.Size(40, 40);
            this.btnPrevBanner.TabIndex = 1;
            this.btnPrevBanner.Text = "<";
            this.btnPrevBanner.UseVisualStyleBackColor = true;
            // 
            // pbBanner
            // 
            this.pbBanner.BackColor = System.Drawing.Color.LightGray;
            this.pbBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(1100, 300);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // pnlCategoryGrid
            // 
            this.pnlCategoryGrid.Controls.Add(this.flpCategories);
            this.pnlCategoryGrid.Controls.Add(this.lblCategoryTitle);
            this.pnlCategoryGrid.Location = new System.Drawing.Point(3, 309);
            this.pnlCategoryGrid.Name = "pnlCategoryGrid";
            this.pnlCategoryGrid.Size = new System.Drawing.Size(1100, 150);
            this.pnlCategoryGrid.TabIndex = 1;
            // 
            // flpCategories
            // 
            this.flpCategories.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpCategories.Location = new System.Drawing.Point(0, 40);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(1100, 110);
            this.flpCategories.TabIndex = 1;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(104, 22);
            this.lblCategoryTitle.TabIndex = 0;
            this.lblCategoryTitle.Text = "Danh mục";
            // 
            // lblRecommendedTitle
            // 
            this.lblRecommendedTitle.AutoSize = true;
            this.lblRecommendedTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblRecommendedTitle.Location = new System.Drawing.Point(3, 482);
            this.lblRecommendedTitle.Margin = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.lblRecommendedTitle.Name = "lblRecommendedTitle";
            this.lblRecommendedTitle.Size = new System.Drawing.Size(145, 22);
            this.lblRecommendedTitle.TabIndex = 3;
            this.lblRecommendedTitle.Text = "Gợi ý hôm nay";
            // 
            // flpRecommendedProducts
            // 
            this.flpRecommendedProducts.AutoSize = true;
            this.flpRecommendedProducts.Location = new System.Drawing.Point(3, 517);
            this.flpRecommendedProducts.Name = "flpRecommendedProducts";
            this.flpRecommendedProducts.Size = new System.Drawing.Size(0, 0);
            this.flpRecommendedProducts.TabIndex = 4;
            // 
            // tmrBannerSlide
            // 
            this.tmrBannerSlide.Interval = 5000;
            // 
            // UcHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScrollContainer);
            this.Name = "UcHomePage";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlScrollContainer.ResumeLayout(false);
            this.pnlScrollContainer.PerformLayout();
            this.flpSections.ResumeLayout(false);
            this.flpSections.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.pnlCategoryGrid.ResumeLayout(false);
            this.pnlCategoryGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScrollContainer;
        private System.Windows.Forms.FlowLayoutPanel flpSections;

        // Banner
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Button btnPrevBanner;
        private System.Windows.Forms.Button btnNextBanner;
        private System.Windows.Forms.Timer tmrBannerSlide;

        // Category
        private System.Windows.Forms.Panel pnlCategoryGrid;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.Label lblCategoryTitle;

        // Product Listing
        private System.Windows.Forms.Label lblRecommendedTitle;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendedProducts;
    }
}