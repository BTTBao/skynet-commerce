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
            // Resource Manager cần thiết để tải hình ảnh/icon
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCartPage));

            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLeftContainer = new System.Windows.Forms.Panel();
            this.flpCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlListHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblShippingFee = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.btnContinueShoppingSummary = new Guna.UI2.WinForms.Guna2Button();
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
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.pnlLeftContainer);
            this.pnlContent.Controls.Add(this.pnlSummary);
            this.pnlContent.Controls.Add(this.pnlEmptyCart);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlLeftContainer
            // 
            this.pnlLeftContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeftContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftContainer.Controls.Add(this.flpCartItems);
            this.pnlLeftContainer.Controls.Add(this.pnlListHeader);
            this.pnlLeftContainer.Location = new System.Drawing.Point(50, 30);
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(800, 700);
            this.pnlLeftContainer.TabIndex = 1;
            // 
            // flpCartItems
            // 
            this.flpCartItems.AutoScroll = true;
            this.flpCartItems.BackColor = System.Drawing.Color.Transparent;
            this.flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCartItems.Location = new System.Drawing.Point(0, 50);
            this.flpCartItems.Name = "flpCartItems";
            this.flpCartItems.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpCartItems.Size = new System.Drawing.Size(800, 650);
            this.flpCartItems.TabIndex = 1;
            this.flpCartItems.WrapContents = false;
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.BackColor = System.Drawing.Color.White;
            this.pnlListHeader.BorderRadius = 5;
            this.pnlListHeader.Controls.Add(this.label1);
            this.pnlListHeader.Controls.Add(this.label2);
            this.pnlListHeader.Controls.Add(this.label3);
            this.pnlListHeader.Controls.Add(this.label4);
            this.pnlListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.ShadowDecoration.Depth = 2;
            this.pnlListHeader.ShadowDecoration.Enabled = true;
            this.pnlListHeader.Size = new System.Drawing.Size(800, 50);
            this.pnlListHeader.TabIndex = 0;
            // 
            // label1
            // 
            CreateHeaderLabel(this.label1, "Sản phẩm", 20, 15);
            // 
            // label2
            // 
            CreateHeaderLabel(this.label2, "Đơn giá", 380, 15);
            // 
            // label3
            // 
            CreateHeaderLabel(this.label3, "Số lượng", 510, 15);
            // 
            // label4
            // 
            CreateHeaderLabel(this.label4, "Thành tiền", 650, 15);
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderRadius = 8;
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.Controls.Add(this.lblShippingFee);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.btnCheckout);
            this.pnlSummary.Controls.Add(this.btnContinueShoppingSummary);
            this.pnlSummary.Location = new System.Drawing.Point(870, 30);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.Depth = 5;
            this.pnlSummary.ShadowDecoration.Enabled = true;
            this.pnlSummary.Size = new System.Drawing.Size(300, 280);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(145, 21);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Tóm tắt đơn hàng";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(20, 60);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(260, 20);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Tạm tính: 0₫";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblShippingFee
            // 
            this.lblShippingFee.Location = new System.Drawing.Point(20, 90);
            this.lblShippingFee.Name = "lblShippingFee";
            this.lblShippingFee.Size = new System.Drawing.Size(260, 20);
            this.lblShippingFee.TabIndex = 2;
            this.lblShippingFee.Text = "Phí vận chuyển: 30.000₫";
            this.lblShippingFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 130);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(260, 30);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "0₫";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 5;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnCheckout.Location = new System.Drawing.Point(20, 180);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(260, 40);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Tiến hành thanh toán";
            // 
            // btnContinueShoppingSummary
            // 
            this.btnContinueShoppingSummary.BackColor = System.Drawing.Color.Transparent;
            this.btnContinueShoppingSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinueShoppingSummary.FillColor = System.Drawing.Color.Transparent;
            this.btnContinueShoppingSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnContinueShoppingSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnContinueShoppingSummary.Location = new System.Drawing.Point(20, 230);
            this.btnContinueShoppingSummary.Name = "btnContinueShoppingSummary";
            this.btnContinueShoppingSummary.Size = new System.Drawing.Size(260, 30);
            this.btnContinueShoppingSummary.TabIndex = 5;
            this.btnContinueShoppingSummary.Text = "Tiếp tục mua sắm";
            // 
            // pnlEmptyCart
            // 
            this.pnlEmptyCart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEmptyCart.BackColor = System.Drawing.Color.White; // Đổi từ Transparent sang White để thấy nội dung
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
            this.pnlEmptyCart.Size = new System.Drawing.Size(500, 300);
            this.pnlEmptyCart.TabIndex = 3;
            this.pnlEmptyCart.Visible = false;
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.BorderRadius = 5;
            this.btnContinueShopping.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnContinueShopping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinueShopping.ForeColor = System.Drawing.Color.White;
            this.btnContinueShopping.Location = new System.Drawing.Point(170, 220); // Vị trí mới
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(160, 40);
            this.btnContinueShopping.TabIndex = 0;
            this.btnContinueShopping.Text = "Tiếp tục mua sắm";
            // 
            // lblEmptyCartMessage
            // 
            this.lblEmptyCartMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmptyCartMessage.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyCartMessage.Location = new System.Drawing.Point(100, 185); // Vị trí mới
            this.lblEmptyCartMessage.Name = "lblEmptyCartMessage";
            this.lblEmptyCartMessage.Size = new System.Drawing.Size(300, 20);
            this.lblEmptyCartMessage.TabIndex = 1;
            this.lblEmptyCartMessage.Text = "Bạn chưa thêm sản phẩm nào vào giỏ hàng";
            this.lblEmptyCartMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmptyCartTitle
            // 
            this.lblEmptyCartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmptyCartTitle.Location = new System.Drawing.Point(150, 150); // Vị trí mới
            this.lblEmptyCartTitle.Name = "lblEmptyCartTitle";
            this.lblEmptyCartTitle.Size = new System.Drawing.Size(200, 25);
            this.lblEmptyCartTitle.TabIndex = 2;
            this.lblEmptyCartTitle.Text = "Giỏ hàng trống";
            this.lblEmptyCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCartIcon
            // 
            this.pbCartIcon.ImageRotate = 0F;
            this.pbCartIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbCartIcon.Image"))); // Bạn cần đảm bảo đã load resource icon giỏ hàng
            this.pbCartIcon.Location = new System.Drawing.Point(210, 50); // Vị trí Icon (500/2 - 40)
            this.pbCartIcon.Name = "pbCartIcon";
            this.pbCartIcon.Size = new System.Drawing.Size(80, 80);
            this.pbCartIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCartIcon.TabIndex = 3;
            this.pbCartIcon.TabStop = false;
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
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlEmptyCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartIcon)).EndInit();
            this.ResumeLayout(false);
        }

        // HÀM TRỢ GIÚP ĐÃ ĐƯỢC DI CHUYỂN
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