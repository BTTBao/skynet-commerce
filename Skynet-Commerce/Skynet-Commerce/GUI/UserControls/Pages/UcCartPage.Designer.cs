using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcCartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCartPage));

            // Khởi tạo các Panel chính
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLeftContainer = new System.Windows.Forms.Panel();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlListHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.flpCartItems = new System.Windows.Forms.FlowLayoutPanel();

            // Khởi tạo các Label Header
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();

            // Khởi tạo các thành phần trong Summary
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblShippingFee = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.btnContinueShoppingSummary = new Guna.UI2.WinForms.Guna2Button(); // Đổi tên để tránh trùng với nút ở Empty Cart

            // Khởi tạo Giỏ hàng Trống (Giữ nguyên logic cũ)
            this.pnlEmptyCart = new Guna.UI2.WinForms.Guna2Panel();
            this.btnContinueShopping = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmptyCartMessage = new System.Windows.Forms.Label();
            this.lblEmptyCartTitle = new System.Windows.Forms.Label();
            this.pbCartIcon = new Guna.UI2.WinForms.Guna2PictureBox();

            this.pnlContent.SuspendLayout();
            this.pnlLeftContainer.SuspendLayout();
            this.pnlListHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlEmptyCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartIcon)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlContent (Container chính)
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 245, 245); // Màu nền xám nhạt hiện đại
            this.pnlContent.Controls.Add(this.pnlLeftContainer);
            this.pnlContent.Controls.Add(this.pnlSummary);
            this.pnlContent.Controls.Add(this.pnlEmptyCart);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.TabIndex = 0;

            // 
            // 1. CỘT TRÁI (Chứa Header và Danh sách sản phẩm)
            // 
            this.pnlLeftContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftContainer.Controls.Add(this.flpCartItems);
            this.pnlLeftContainer.Controls.Add(this.pnlListHeader);
            this.pnlLeftContainer.Location = new System.Drawing.Point(50, 30); // Căn lề trái 50px, trên 30px
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(800, 700);
            this.pnlLeftContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeftContainer.TabIndex = 1;

            // Header Cột (Sản phẩm | Đơn giá | Số lượng | Thành tiền)
            this.pnlListHeader.BackColor = System.Drawing.Color.White;
            this.pnlListHeader.BorderRadius = 5;
            this.pnlListHeader.Controls.Add(this.label1);
            this.pnlListHeader.Controls.Add(this.label2);
            this.pnlListHeader.Controls.Add(this.label3);
            this.pnlListHeader.Controls.Add(this.label4);
            this.pnlListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.ShadowDecoration.Enabled = true;
            this.pnlListHeader.ShadowDecoration.Parent = this.pnlListHeader;
            this.pnlListHeader.ShadowDecoration.Depth = 2;
            this.pnlListHeader.Size = new System.Drawing.Size(800, 50);
            this.pnlListHeader.TabIndex = 0;

            // Helper tạo Label Header
            CreateHeaderLabel(this.label1, "Sản phẩm", 20, 15);
            CreateHeaderLabel(this.label2, "Đơn giá", 380, 15);
            CreateHeaderLabel(this.label3, "Số lượng", 510, 15);
            CreateHeaderLabel(this.label4, "Thành tiền", 650, 15);

            // FlowLayoutPanel (Chứa các item)
            this.flpCartItems.AutoScroll = true;
            this.flpCartItems.BackColor = System.Drawing.Color.Transparent;
            this.flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCartItems.Location = new System.Drawing.Point(0, 50); // Nằm ngay dưới Header
            this.flpCartItems.Name = "flpCartItems";
            this.flpCartItems.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0); // Cách Header 10px
            this.flpCartItems.Size = new System.Drawing.Size(800, 650);
            this.flpCartItems.TabIndex = 1;
            this.flpCartItems.WrapContents = false;

            // 
            // 2. CỘT PHẢI (Panel Tóm tắt đơn hàng)
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderRadius = 8;
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.Controls.Add(this.lblShippingFee);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.btnCheckout);
            this.pnlSummary.Controls.Add(this.btnContinueShoppingSummary);
            this.pnlSummary.Location = new System.Drawing.Point(870, 30); // Bên phải, cách cột trái 20px (50+800+20)
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.Enabled = true;
            this.pnlSummary.ShadowDecoration.Parent = this.pnlSummary;
            this.pnlSummary.ShadowDecoration.Depth = 5;
            this.pnlSummary.Size = new System.Drawing.Size(300, 280);
            this.pnlSummary.TabIndex = 2;

            // Title Summary
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(149, 21);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Tóm tắt đơn hàng";

            // Subtotal & Shipping
            this.lblSubtotal.Location = new System.Drawing.Point(20, 60);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(260, 20);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Tạm tính: 0₫";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblShippingFee.Location = new System.Drawing.Point(20, 90);
            this.lblShippingFee.Name = "lblShippingFee";
            this.lblShippingFee.Size = new System.Drawing.Size(260, 20);
            this.lblShippingFee.TabIndex = 2;
            this.lblShippingFee.Text = "Phí vận chuyển: 30.000₫";
            this.lblShippingFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Total Amount
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 130);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(260, 30);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "0₫";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Button Checkout
            this.btnCheckout.BorderRadius = 5;
            this.btnCheckout.CheckedState.Parent = this.btnCheckout;
            this.btnCheckout.CustomImages.Parent = this.btnCheckout;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnCheckout.HoverState.Parent = this.btnCheckout;
            this.btnCheckout.Location = new System.Drawing.Point(20, 180);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.ShadowDecoration.Parent = this.btnCheckout;
            this.btnCheckout.Size = new System.Drawing.Size(260, 40);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Tiến hành thanh toán";

            // Button Continue Shopping (Summary)
            this.btnContinueShoppingSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnContinueShoppingSummary.CheckedState.Parent = this.btnContinueShoppingSummary;
            this.btnContinueShoppingSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinueShoppingSummary.CustomImages.Parent = this.btnContinueShoppingSummary;
            this.btnContinueShoppingSummary.FillColor = System.Drawing.Color.Transparent;
            this.btnContinueShoppingSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnContinueShoppingSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnContinueShoppingSummary.HoverState.Parent = this.btnContinueShoppingSummary;
            this.btnContinueShoppingSummary.Location = new System.Drawing.Point(20, 230);
            this.btnContinueShoppingSummary.Name = "btnContinueShoppingSummary";
            this.btnContinueShoppingSummary.ShadowDecoration.Parent = this.btnContinueShoppingSummary;
            this.btnContinueShoppingSummary.Size = new System.Drawing.Size(260, 30);
            this.btnContinueShoppingSummary.TabIndex = 5;
            this.btnContinueShoppingSummary.Text = "Tiếp tục mua sắm";

            // 
            // pnlEmptyCart (Giữ nguyên logic cũ, chỉ cập nhật vị trí nếu cần)
            // 
            this.pnlEmptyCart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEmptyCart.BackColor = System.Drawing.Color.White;
            this.pnlEmptyCart.BorderRadius = 10;
            this.pnlEmptyCart.Controls.Add(this.btnContinueShopping);
            this.pnlEmptyCart.Controls.Add(this.lblEmptyCartMessage);
            this.pnlEmptyCart.Controls.Add(this.lblEmptyCartTitle);
            this.pnlEmptyCart.Controls.Add(this.pbCartIcon);
            this.pnlEmptyCart.Location = new System.Drawing.Point(350, 200);
            this.pnlEmptyCart.Name = "pnlEmptyCart";
            this.pnlEmptyCart.ShadowDecoration.BorderRadius = 10;
            this.pnlEmptyCart.ShadowDecoration.Depth = 10;
            this.pnlEmptyCart.ShadowDecoration.Enabled = true;
            this.pnlEmptyCart.ShadowDecoration.Parent = this.pnlEmptyCart;
            this.pnlEmptyCart.Size = new System.Drawing.Size(500, 300);
            this.pnlEmptyCart.TabIndex = 3;
            this.pnlEmptyCart.Visible = false;

            // ... (Các control con của pnlEmptyCart giữ nguyên)
            // Đảm bảo btnContinueShopping, lblEmptyCartMessage, lblEmptyCartTitle, pbCartIcon đã được khởi tạo ở trên nếu dùng lại

            // 
            // UcCartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "UcCartPage";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.ResumeLayout(false);
            this.pnlLeftContainer.ResumeLayout(false);
            this.pnlListHeader.ResumeLayout(false);
            this.pnlListHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlEmptyCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartIcon)).EndInit();
            this.ResumeLayout(false);
        }

        // Hàm trợ giúp tạo label header
        private void CreateHeaderLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
            lbl.ForeColor = System.Drawing.Color.Gray;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
        }

        #endregion

        // CÁC BIẾN MỚI CẦN KHAI BÁO
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private System.Windows.Forms.Panel pnlLeftContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlListHeader;
        private System.Windows.Forms.Label label1, label2, label3, label4;
        private System.Windows.Forms.FlowLayoutPanel flpCartItems;

        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblShippingFee;
        private System.Windows.Forms.Label lblTotalAmount;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private Guna.UI2.WinForms.Guna2Button btnContinueShoppingSummary;

        // Biến cũ giữ lại
        private Guna.UI2.WinForms.Guna2Panel pnlEmptyCart;
        private Guna.UI2.WinForms.Guna2PictureBox pbCartIcon;
        private System.Windows.Forms.Label lblEmptyCartTitle;
        private System.Windows.Forms.Label lblEmptyCartMessage;
        private Guna.UI2.WinForms.Guna2Button btnContinueShopping;
    }
}