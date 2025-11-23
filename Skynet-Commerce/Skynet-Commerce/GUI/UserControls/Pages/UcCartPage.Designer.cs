namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcCartPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCartData = new System.Windows.Forms.Panel();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblShippingFee = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLeftContainer = new System.Windows.Forms.Panel();
            this.flpCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlListHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHdrAction = new System.Windows.Forms.Label();
            this.lblHdrTotal = new System.Windows.Forms.Label();
            this.lblHdrQty = new System.Windows.Forms.Label();
            this.lblHdrPrice = new System.Windows.Forms.Label();
            this.lblHdrProduct = new System.Windows.Forms.Label();
            this.pnlEmptyCart = new Guna.UI2.WinForms.Guna2Panel();
            this.btnShopNow = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmptyMessage = new System.Windows.Forms.Label();
            this.pbEmptyCart = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlContent.SuspendLayout();
            this.pnlCartData.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlLeftContainer.SuspendLayout();
            this.pnlListHeader.SuspendLayout();
            this.pnlEmptyCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.pnlCartData);
            this.pnlContent.Controls.Add(this.pnlEmptyCart);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlCartData
            // 
            this.pnlCartData.Controls.Add(this.pnlSummary);
            this.pnlCartData.Controls.Add(this.pnlLeftContainer);
            this.pnlCartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCartData.Location = new System.Drawing.Point(0, 0);
            this.pnlCartData.Name = "pnlCartData";
            this.pnlCartData.Size = new System.Drawing.Size(1200, 800);
            this.pnlCartData.TabIndex = 4;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlSummary.BorderRadius = 4;
            this.pnlSummary.BorderThickness = 1;
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.Controls.Add(this.lblShippingFee);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.btnCheckout);
            this.pnlSummary.Location = new System.Drawing.Point(880, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.Depth = 5;
            this.pnlSummary.ShadowDecoration.Enabled = true;
            this.pnlSummary.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlSummary.Size = new System.Drawing.Size(300, 300);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(103, 21);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Thanh Toán";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubtotal.Location = new System.Drawing.Point(20, 60);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(260, 20);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Tổng tiền hàng: 0₫";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblShippingFee
            // 
            this.lblShippingFee.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShippingFee.Location = new System.Drawing.Point(20, 90);
            this.lblShippingFee.Name = "lblShippingFee";
            this.lblShippingFee.Size = new System.Drawing.Size(260, 20);
            this.lblShippingFee.TabIndex = 2;
            this.lblShippingFee.Text = "Phí vận chuyển: 0₫";
            this.lblShippingFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 140);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(260, 35);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "0₫";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 2;
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnCheckout.Location = new System.Drawing.Point(20, 220);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(260, 45);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Mua Hàng";
            // 
            // pnlLeftContainer
            // 
            this.pnlLeftContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLeftContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftContainer.Controls.Add(this.flpCartItems);
            this.pnlLeftContainer.Controls.Add(this.pnlListHeader);
            this.pnlLeftContainer.Location = new System.Drawing.Point(20, 20);
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(840, 760);
            this.pnlLeftContainer.TabIndex = 1;
            // 
            // flpCartItems
            // 
            this.flpCartItems.AutoScroll = true;
            this.flpCartItems.BackColor = System.Drawing.Color.Transparent;
            this.flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCartItems.Location = new System.Drawing.Point(0, 55);
            this.flpCartItems.Name = "flpCartItems";
            this.flpCartItems.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpCartItems.Size = new System.Drawing.Size(840, 705);
            this.flpCartItems.TabIndex = 1;
            this.flpCartItems.WrapContents = false;
            // 
            // pnlListHeader
            // 
            this.pnlListHeader.BackColor = System.Drawing.Color.White;
            this.pnlListHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlListHeader.BorderRadius = 2;
            this.pnlListHeader.BorderThickness = 1;
            this.pnlListHeader.Controls.Add(this.lblHdrAction);
            this.pnlListHeader.Controls.Add(this.lblHdrTotal);
            this.pnlListHeader.Controls.Add(this.lblHdrQty);
            this.pnlListHeader.Controls.Add(this.lblHdrPrice);
            this.pnlListHeader.Controls.Add(this.lblHdrProduct);
            this.pnlListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlListHeader.Name = "pnlListHeader";
            this.pnlListHeader.ShadowDecoration.Depth = 2;
            this.pnlListHeader.ShadowDecoration.Enabled = true;
            this.pnlListHeader.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.pnlListHeader.Size = new System.Drawing.Size(840, 55);
            this.pnlListHeader.TabIndex = 0;
            // 
            // lblHdrAction
            // 
            this.lblHdrAction.AutoSize = true;
            this.lblHdrAction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHdrAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHdrAction.Location = new System.Drawing.Point(740, 18);
            this.lblHdrAction.Name = "lblHdrAction";
            this.lblHdrAction.Size = new System.Drawing.Size(66, 17);
            this.lblHdrAction.TabIndex = 4;
            this.lblHdrAction.Text = "Thao Thác";
            // 
            // lblHdrTotal
            // 
            this.lblHdrTotal.AutoSize = true;
            this.lblHdrTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHdrTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHdrTotal.Location = new System.Drawing.Point(600, 18);
            this.lblHdrTotal.Name = "lblHdrTotal";
            this.lblHdrTotal.Size = new System.Drawing.Size(53, 17);
            this.lblHdrTotal.TabIndex = 3;
            this.lblHdrTotal.Text = "Số Tiền";
            // 
            // lblHdrQty
            // 
            this.lblHdrQty.AutoSize = true;
            this.lblHdrQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHdrQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHdrQty.Location = new System.Drawing.Point(450, 18);
            this.lblHdrQty.Name = "lblHdrQty";
            this.lblHdrQty.Size = new System.Drawing.Size(61, 17);
            this.lblHdrQty.TabIndex = 2;
            this.lblHdrQty.Text = "Số Lượng";
            // 
            // lblHdrPrice
            // 
            this.lblHdrPrice.AutoSize = true;
            this.lblHdrPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHdrPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHdrPrice.Location = new System.Drawing.Point(320, 18);
            this.lblHdrPrice.Name = "lblHdrPrice";
            this.lblHdrPrice.Size = new System.Drawing.Size(54, 17);
            this.lblHdrPrice.TabIndex = 1;
            this.lblHdrPrice.Text = "Đơn Giá";
            // 
            // lblHdrProduct
            // 
            this.lblHdrProduct.AutoSize = true;
            this.lblHdrProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHdrProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHdrProduct.Location = new System.Drawing.Point(20, 18);
            this.lblHdrProduct.Name = "lblHdrProduct";
            this.lblHdrProduct.Size = new System.Drawing.Size(65, 17);
            this.lblHdrProduct.TabIndex = 0;
            this.lblHdrProduct.Text = "Sản Phẩm";
            // 
            // pnlEmptyCart
            // 
            this.pnlEmptyCart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEmptyCart.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmptyCart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlEmptyCart.BorderRadius = 10;
            this.pnlEmptyCart.BorderThickness = 1;
            this.pnlEmptyCart.Controls.Add(this.btnShopNow);
            this.pnlEmptyCart.Controls.Add(this.lblEmptyMessage);
            this.pnlEmptyCart.Controls.Add(this.pbEmptyCart);
            this.pnlEmptyCart.FillColor = System.Drawing.Color.White;
            this.pnlEmptyCart.Location = new System.Drawing.Point(350, 200);
            this.pnlEmptyCart.Name = "pnlEmptyCart";
            this.pnlEmptyCart.Size = new System.Drawing.Size(500, 350);
            this.pnlEmptyCart.TabIndex = 3;
            this.pnlEmptyCart.Visible = false;
            // 
            // btnShopNow
            // 
            this.btnShopNow.BorderRadius = 2;
            this.btnShopNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShopNow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnShopNow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnShopNow.ForeColor = System.Drawing.Color.White;
            this.btnShopNow.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnShopNow.Location = new System.Drawing.Point(150, 240);
            this.btnShopNow.Name = "btnShopNow";
            this.btnShopNow.Size = new System.Drawing.Size(200, 45);
            this.btnShopNow.TabIndex = 2;
            this.btnShopNow.Text = "MUA NGAY";
            // 
            // lblEmptyMessage
            // 
            this.lblEmptyMessage.BackColor = System.Drawing.Color.White;
            this.lblEmptyMessage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmptyMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEmptyMessage.Location = new System.Drawing.Point(50, 190);
            this.lblEmptyMessage.Name = "lblEmptyMessage";
            this.lblEmptyMessage.Size = new System.Drawing.Size(400, 30);
            this.lblEmptyMessage.TabIndex = 1;
            this.lblEmptyMessage.Text = "Giỏ hàng của bạn còn trống";
            this.lblEmptyMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbEmptyCart
            // 
            this.pbEmptyCart.BackColor = System.Drawing.Color.White;
            this.pbEmptyCart.ImageLocation = "https://deo.shopeemobile.com/shopee/shopee-pcmall-live-sg/cart/9bdd8040b334d31946f49e36beaf32db.png";
            this.pbEmptyCart.ImageRotate = 0F;
            this.pbEmptyCart.Location = new System.Drawing.Point(175, 30);
            this.pbEmptyCart.Name = "pbEmptyCart";
            this.pbEmptyCart.Size = new System.Drawing.Size(150, 150);
            this.pbEmptyCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmptyCart.TabIndex = 0;
            this.pbEmptyCart.TabStop = false;
            // 
            // UcCartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "UcCartPage";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlContent.ResumeLayout(false);
            this.pnlCartData.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlLeftContainer.ResumeLayout(false);
            this.pnlListHeader.ResumeLayout(false);
            this.pnlListHeader.PerformLayout();
            this.pnlEmptyCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // --- KHAI BÁO CÁC CONTROL ---
        private Guna.UI2.WinForms.Guna2Panel pnlContent;

        // 1. Phần Giỏ hàng có dữ liệu
        private System.Windows.Forms.Panel pnlCartData;

        // Bên Trái: List sản phẩm
        private System.Windows.Forms.Panel pnlLeftContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlListHeader;
        private System.Windows.Forms.Label lblHdrProduct;
        private System.Windows.Forms.Label lblHdrPrice;
        private System.Windows.Forms.Label lblHdrQty;
        private System.Windows.Forms.Label lblHdrTotal;
        private System.Windows.Forms.Label lblHdrAction;
        private System.Windows.Forms.FlowLayoutPanel flpCartItems;

        // Bên Phải: Tổng tiền
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblShippingFee;
        private System.Windows.Forms.Label lblTotalAmount;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;

        // 2. Phần Giỏ hàng Trống
        private Guna.UI2.WinForms.Guna2Panel pnlEmptyCart;
        private Guna.UI2.WinForms.Guna2PictureBox pbEmptyCart;
        private System.Windows.Forms.Label lblEmptyMessage;
        private Guna.UI2.WinForms.Guna2Button btnShopNow;
    }
}