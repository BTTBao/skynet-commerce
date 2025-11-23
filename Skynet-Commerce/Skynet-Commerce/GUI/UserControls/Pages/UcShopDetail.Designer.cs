namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcShopDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- KHAI BÁO CONTROL ---
        private System.Windows.Forms.Panel pnlMainScroll;

        // Header Container
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderContainer;
        private Guna.UI2.WinForms.Guna2PictureBox picBanner;
        private Guna.UI2.WinForms.Guna2Panel pnlInfoArea; // Panel trắng dưới banner
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblLocation;
        private Guna.UI2.WinForms.Guna2Button btnFollow;
        private Guna.UI2.WinForms.Guna2Button btnChat;

        // Filter Bar
        private Guna.UI2.WinForms.Guna2Panel pnlFilters;
        private Guna.UI2.WinForms.Guna2Panel pnlFilterInner; // Panel con chứa nút

        // Danh sách sản phẩm
        private System.Windows.Forms.FlowLayoutPanel flowProducts;

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
            this.pnlMainScroll = new System.Windows.Forms.Panel();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFilterInner = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeaderContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnChat = new Guna.UI2.WinForms.Guna2Button();
            this.btnFollow = new Guna.UI2.WinForms.Guna2Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlInfoArea = new Guna.UI2.WinForms.Guna2Panel();
            this.picBanner = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlMainScroll.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlHeaderContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainScroll
            // 
            this.pnlMainScroll.AutoScroll = true;
            this.pnlMainScroll.Controls.Add(this.flowProducts);
            this.pnlMainScroll.Controls.Add(this.pnlFilters);
            this.pnlMainScroll.Controls.Add(this.pnlHeaderContainer);
            this.pnlMainScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlMainScroll.Name = "pnlMainScroll";
            this.pnlMainScroll.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainScroll.TabIndex = 0;
            // 
            // flowProducts
            // 
            this.flowProducts.AutoSize = true;
            this.flowProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowProducts.Location = new System.Drawing.Point(0, 390);
            this.flowProducts.MinimumSize = new System.Drawing.Size(1150, 500);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 50);
            this.flowProducts.Size = new System.Drawing.Size(1200, 500);
            this.flowProducts.TabIndex = 2;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlFilters.Controls.Add(this.pnlFilterInner);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 320);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlFilters.Size = new System.Drawing.Size(1200, 70);
            this.pnlFilters.TabIndex = 1;
            // 
            // pnlFilterInner
            // 
            this.pnlFilterInner.BackColor = System.Drawing.Color.White;
            this.pnlFilterInner.BorderRadius = 2;
            this.pnlFilterInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterInner.Location = new System.Drawing.Point(20, 15);
            this.pnlFilterInner.Name = "pnlFilterInner";
            this.pnlFilterInner.Size = new System.Drawing.Size(1200, 40);
            this.pnlFilterInner.TabIndex = 0;
            // 
            // pnlHeaderContainer
            // 
            this.pnlHeaderContainer.BackColor = System.Drawing.Color.White;
            this.pnlHeaderContainer.Controls.Add(this.btnChat);
            this.pnlHeaderContainer.Controls.Add(this.btnFollow);
            this.pnlHeaderContainer.Controls.Add(this.lblLocation);
            this.pnlHeaderContainer.Controls.Add(this.lblShopName);
            this.pnlHeaderContainer.Controls.Add(this.picAvatar);
            this.pnlHeaderContainer.Controls.Add(this.pnlInfoArea);
            this.pnlHeaderContainer.Controls.Add(this.picBanner);
            this.pnlHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderContainer.Name = "pnlHeaderContainer";
            this.pnlHeaderContainer.Size = new System.Drawing.Size(1200, 320);
            this.pnlHeaderContainer.TabIndex = 0;
            // 
            // btnChat
            // 
            this.btnChat.BorderColor = System.Drawing.Color.LightGray;
            this.btnChat.BorderRadius = 2;
            this.btnChat.BorderThickness = 1;
            this.btnChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChat.FillColor = System.Drawing.Color.White;
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChat.ForeColor = System.Drawing.Color.Black;
            this.btnChat.Location = new System.Drawing.Point(340, 235);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(110, 36);
            this.btnChat.TabIndex = 6;
            this.btnChat.Text = "Chat";
            // 
            // btnFollow
            // 
            this.btnFollow.BorderRadius = 2;
            this.btnFollow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFollow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFollow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFollow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFollow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFollow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnFollow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFollow.ForeColor = System.Drawing.Color.White;
            this.btnFollow.Location = new System.Drawing.Point(220, 235);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(110, 36);
            this.btnFollow.TabIndex = 5;
            this.btnFollow.Text = "+ Theo dõi";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.White;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblLocation.Location = new System.Drawing.Point(222, 205);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(411, 15);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "⭐ 4.8 (2456 đánh giá)   |   👥 12.500 người theo dõi   |   📍 TP. Hồ Chí Minh";
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.BackColor = System.Drawing.Color.White;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblShopName.Location = new System.Drawing.Point(220, 170);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(164, 32);
            this.lblShopName.TabIndex = 3;
            this.lblShopName.Text = "FashionStore";
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(50, 90);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            this.picAvatar.UseTransparentBackground = true;
            // 
            // pnlInfoArea
            // 
            this.pnlInfoArea.BackColor = System.Drawing.Color.White;
            this.pnlInfoArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfoArea.Location = new System.Drawing.Point(0, 160);
            this.pnlInfoArea.Name = "pnlInfoArea";
            this.pnlInfoArea.Size = new System.Drawing.Size(1200, 160);
            this.pnlInfoArea.TabIndex = 1;
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBanner.FillColor = System.Drawing.Color.DimGray;
            this.picBanner.ImageRotate = 0F;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(1200, 160);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // UcShopDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.pnlMainScroll);
            this.DoubleBuffered = true;
            this.Name = "UcShopDetail";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainScroll.ResumeLayout(false);
            this.pnlMainScroll.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlHeaderContainer.ResumeLayout(false);
            this.pnlHeaderContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}