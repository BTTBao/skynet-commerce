namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcShopDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcShopDetail));
            this.pnlMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilterBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFilterGiaCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilterGiaThap = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilterBanChay = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilterMoiNhat = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilterTatCa = new Guna.UI2.WinForms.Guna2Button();
            this.pnlShopInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStats = new Guna.UI2.WinForms.Guna2Panel();
            this.statTime = new System.Windows.Forms.Label();
            this.lblStatTimeTitle = new System.Windows.Forms.Label();
            this.statRate = new System.Windows.Forms.Label();
            this.lblStatRateTitle = new System.Windows.Forms.Label();
            this.statProducts = new System.Windows.Forms.Label();
            this.lblStatProductsTitle = new System.Windows.Forms.Label();
            this.statJoin = new System.Windows.Forms.Label();
            this.lblStatJoinTitle = new System.Windows.Forms.Label();
            this.btnChat = new Guna.UI2.WinForms.Guna2Button();
            this.btnFollow = new Guna.UI2.WinForms.Guna2Button();
            this.lblShopAddress = new System.Windows.Forms.Label();
            this.lblFollowers = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.pbShopAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbBanner = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlMainContent.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            this.pnlShopInfo.SuspendLayout();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.AutoScroll = true;
            this.pnlMainContent.Controls.Add(this.flpProducts);
            this.pnlMainContent.Controls.Add(this.pnlFilterBar);
            this.pnlMainContent.Controls.Add(this.pnlShopInfo);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainContent.TabIndex = 0;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpProducts.Location = new System.Drawing.Point(100, 480);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flpProducts.Size = new System.Drawing.Size(1000, 300);
            this.flpProducts.TabIndex = 2;
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.BackColor = System.Drawing.Color.White;
            this.pnlFilterBar.Controls.Add(this.btnFilterGiaCao);
            this.pnlFilterBar.Controls.Add(this.btnFilterGiaThap);
            this.pnlFilterBar.Controls.Add(this.btnFilterBanChay);
            this.pnlFilterBar.Controls.Add(this.btnFilterMoiNhat);
            this.pnlFilterBar.Controls.Add(this.btnFilterTatCa);
            this.pnlFilterBar.Location = new System.Drawing.Point(100, 430);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1000, 50);
            this.pnlFilterBar.TabIndex = 1;
            // 
            // btnFilterGiaCao
            // 
            this.btnFilterGiaCao.BorderRadius = 5;
            this.btnFilterGiaCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterGiaCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterGiaCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterGiaCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterGiaCao.FillColor = System.Drawing.Color.Transparent;
            this.btnFilterGiaCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterGiaCao.ForeColor = System.Drawing.Color.Black;
            this.btnFilterGiaCao.Location = new System.Drawing.Point(370, 10);
            this.btnFilterGiaCao.Name = "btnFilterGiaCao";
            this.btnFilterGiaCao.Size = new System.Drawing.Size(80, 30);
            this.btnFilterGiaCao.TabIndex = 4;
            this.btnFilterGiaCao.Text = "Giá cao";
            // 
            // btnFilterGiaThap
            // 
            this.btnFilterGiaThap.BorderRadius = 5;
            this.btnFilterGiaThap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterGiaThap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterGiaThap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterGiaThap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterGiaThap.FillColor = System.Drawing.Color.Transparent;
            this.btnFilterGiaThap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterGiaThap.ForeColor = System.Drawing.Color.Black;
            this.btnFilterGiaThap.Location = new System.Drawing.Point(280, 10);
            this.btnFilterGiaThap.Name = "btnFilterGiaThap";
            this.btnFilterGiaThap.Size = new System.Drawing.Size(80, 30);
            this.btnFilterGiaThap.TabIndex = 3;
            this.btnFilterGiaThap.Text = "Giá thấp";
            // 
            // btnFilterBanChay
            // 
            this.btnFilterBanChay.BorderRadius = 5;
            this.btnFilterBanChay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterBanChay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterBanChay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterBanChay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterBanChay.FillColor = System.Drawing.Color.Transparent;
            this.btnFilterBanChay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterBanChay.ForeColor = System.Drawing.Color.Black;
            this.btnFilterBanChay.Location = new System.Drawing.Point(190, 10);
            this.btnFilterBanChay.Name = "btnFilterBanChay";
            this.btnFilterBanChay.Size = new System.Drawing.Size(80, 30);
            this.btnFilterBanChay.TabIndex = 2;
            this.btnFilterBanChay.Text = "Bán chạy";
            // 
            // btnFilterMoiNhat
            // 
            this.btnFilterMoiNhat.BorderRadius = 5;
            this.btnFilterMoiNhat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterMoiNhat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterMoiNhat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterMoiNhat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterMoiNhat.FillColor = System.Drawing.Color.Transparent;
            this.btnFilterMoiNhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterMoiNhat.ForeColor = System.Drawing.Color.Black;
            this.btnFilterMoiNhat.Location = new System.Drawing.Point(100, 10);
            this.btnFilterMoiNhat.Name = "btnFilterMoiNhat";
            this.btnFilterMoiNhat.Size = new System.Drawing.Size(80, 30);
            this.btnFilterMoiNhat.TabIndex = 1;
            this.btnFilterMoiNhat.Text = "Mới nhất";
            // 
            // btnFilterTatCa
            // 
            this.btnFilterTatCa.BorderRadius = 5;
            this.btnFilterTatCa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterTatCa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterTatCa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterTatCa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterTatCa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnFilterTatCa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilterTatCa.ForeColor = System.Drawing.Color.White;
            this.btnFilterTatCa.Location = new System.Drawing.Point(10, 10);
            this.btnFilterTatCa.Name = "btnFilterTatCa";
            this.btnFilterTatCa.Size = new System.Drawing.Size(80, 30);
            this.btnFilterTatCa.TabIndex = 0;
            this.btnFilterTatCa.Text = "Tất cả sản phẩm";
            // 
            // pnlShopInfo
            // 
            this.pnlShopInfo.BackColor = System.Drawing.Color.White;
            this.pnlShopInfo.Controls.Add(this.pnlStats);
            this.pnlShopInfo.Controls.Add(this.btnChat);
            this.pnlShopInfo.Controls.Add(this.btnFollow);
            this.pnlShopInfo.Controls.Add(this.lblShopAddress);
            this.pnlShopInfo.Controls.Add(this.lblFollowers);
            this.pnlShopInfo.Controls.Add(this.lblShopName);
            this.pnlShopInfo.Controls.Add(this.pbShopAvatar);
            this.pnlShopInfo.Controls.Add(this.pbBanner);
            this.pnlShopInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlShopInfo.Name = "pnlShopInfo";
            this.pnlShopInfo.Size = new System.Drawing.Size(1200, 430);
            this.pnlShopInfo.TabIndex = 0;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlStats.BorderRadius = 8;
            this.pnlStats.Controls.Add(this.statTime);
            this.pnlStats.Controls.Add(this.lblStatTimeTitle);
            this.pnlStats.Controls.Add(this.statRate);
            this.pnlStats.Controls.Add(this.lblStatRateTitle);
            this.pnlStats.Controls.Add(this.statProducts);
            this.pnlStats.Controls.Add(this.lblStatProductsTitle);
            this.pnlStats.Controls.Add(this.statJoin);
            this.pnlStats.Controls.Add(this.lblStatJoinTitle);
            this.pnlStats.Location = new System.Drawing.Point(100, 360);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1000, 50);
            this.pnlStats.TabIndex = 7;
            // 
            // statTime
            // 
            this.statTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.statTime.Location = new System.Drawing.Point(400, 10);
            this.statTime.Name = "statTime";
            this.statTime.Size = new System.Drawing.Size(120, 18);
            this.statTime.TabIndex = 7;
            this.statTime.Text = "2 giờ";
            this.statTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatTimeTitle
            // 
            this.lblStatTimeTitle.Location = new System.Drawing.Point(400, 28);
            this.lblStatTimeTitle.Name = "lblStatTimeTitle";
            this.lblStatTimeTitle.Size = new System.Drawing.Size(120, 15);
            this.lblStatTimeTitle.TabIndex = 6;
            this.lblStatTimeTitle.Text = "Thời gian phản hồi";
            this.lblStatTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statRate
            // 
            this.statRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.statRate.Location = new System.Drawing.Point(260, 10);
            this.statRate.Name = "statRate";
            this.statRate.Size = new System.Drawing.Size(120, 18);
            this.statRate.TabIndex = 5;
            this.statRate.Text = "98%";
            this.statRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatRateTitle
            // 
            this.lblStatRateTitle.Location = new System.Drawing.Point(260, 28);
            this.lblStatRateTitle.Name = "lblStatRateTitle";
            this.lblStatRateTitle.Size = new System.Drawing.Size(120, 15);
            this.lblStatRateTitle.TabIndex = 4;
            this.lblStatRateTitle.Text = "Tỷ lệ phản hồi";
            this.lblStatRateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statProducts
            // 
            this.statProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.statProducts.Location = new System.Drawing.Point(120, 10);
            this.statProducts.Name = "statProducts";
            this.statProducts.Size = new System.Drawing.Size(120, 18);
            this.statProducts.TabIndex = 3;
            this.statProducts.Text = "156";
            this.statProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatProductsTitle
            // 
            this.lblStatProductsTitle.Location = new System.Drawing.Point(120, 28);
            this.lblStatProductsTitle.Name = "lblStatProductsTitle";
            this.lblStatProductsTitle.Size = new System.Drawing.Size(120, 15);
            this.lblStatProductsTitle.TabIndex = 2;
            this.lblStatProductsTitle.Text = "Sản phẩm";
            this.lblStatProductsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statJoin
            // 
            this.statJoin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statJoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.statJoin.Location = new System.Drawing.Point(540, 10);
            this.statJoin.Name = "statJoin";
            this.statJoin.Size = new System.Drawing.Size(120, 18);
            this.statJoin.TabIndex = 1;
            this.statJoin.Text = "tháng 01, 2023";
            this.statJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatJoinTitle
            // 
            this.lblStatJoinTitle.Location = new System.Drawing.Point(540, 28);
            this.lblStatJoinTitle.Name = "lblStatJoinTitle";
            this.lblStatJoinTitle.Size = new System.Drawing.Size(120, 15);
            this.lblStatJoinTitle.TabIndex = 0;
            this.lblStatJoinTitle.Text = "Tham gia";
            this.lblStatJoinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChat
            // 
            this.btnChat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnChat.BorderRadius = 5;
            this.btnChat.BorderThickness = 1;
            this.btnChat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChat.FillColor = System.Drawing.Color.White;
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnChat.Location = new System.Drawing.Point(730, 320);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(80, 35);
            this.btnChat.TabIndex = 6;
            this.btnChat.Text = "Chat";
            // 
            // btnFollow
            // 
            this.btnFollow.BorderRadius = 5;
            this.btnFollow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFollow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFollow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFollow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFollow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnFollow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFollow.ForeColor = System.Drawing.Color.White;
            this.btnFollow.Location = new System.Drawing.Point(630, 320);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(90, 35);
            this.btnFollow.TabIndex = 5;
            this.btnFollow.Text = "Theo dõi";
            // 
            // lblShopAddress
            // 
            this.lblShopAddress.AutoSize = true;
            this.lblShopAddress.Location = new System.Drawing.Point(340, 335);
            this.lblShopAddress.Name = "lblShopAddress";
            this.lblShopAddress.Size = new System.Drawing.Size(107, 13);
            this.lblShopAddress.TabIndex = 4;
            this.lblShopAddress.Text = "TP. Hồ Chí Minh";
            // 
            // lblFollowers
            // 
            this.lblFollowers.AutoSize = true;
            this.lblFollowers.Location = new System.Drawing.Point(230, 335);
            this.lblFollowers.Name = "lblFollowers";
            this.lblFollowers.Size = new System.Drawing.Size(78, 13);
            this.lblFollowers.TabIndex = 3;
            this.lblFollowers.Text = "12.500 người theo dõi";
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblShopName.Location = new System.Drawing.Point(230, 310);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(117, 21);
            this.lblShopName.TabIndex = 2;
            this.lblShopName.Text = "FashionStore";
            // 
            // pbShopAvatar
            // 
            this.pbShopAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pbShopAvatar.FillColor = System.Drawing.Color.White;

            this.pbShopAvatar.ImageRotate = 0F;
            this.pbShopAvatar.Location = new System.Drawing.Point(100, 290);
            this.pbShopAvatar.Name = "pbShopAvatar";
            this.pbShopAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbShopAvatar.Size = new System.Drawing.Size(100, 100);
            this.pbShopAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShopAvatar.TabIndex = 1;
            this.pbShopAvatar.TabStop = false;
            // 
            // pbBanner
            // 

            this.pbBanner.ImageRotate = 0F;
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(1200, 250);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // UcShopDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainContent);
            this.Name = "UcShopDetail";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainContent.ResumeLayout(false);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlShopInfo.ResumeLayout(false);
            this.pnlShopInfo.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbShopAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMainContent;
        private Guna.UI2.WinForms.Guna2Panel pnlShopInfo;
        private Guna.UI2.WinForms.Guna2PictureBox pbBanner;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbShopAvatar;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblFollowers;
        private System.Windows.Forms.Label lblShopAddress;
        private Guna.UI2.WinForms.Guna2Button btnFollow;
        private Guna.UI2.WinForms.Guna2Button btnChat;
        private Guna.UI2.WinForms.Guna2Panel pnlStats;
        private System.Windows.Forms.Label statProducts;
        private System.Windows.Forms.Label lblStatProductsTitle;
        private System.Windows.Forms.Label statJoin;
        private System.Windows.Forms.Label lblStatJoinTitle;
        private System.Windows.Forms.Label statTime;
        private System.Windows.Forms.Label lblStatTimeTitle;
        private System.Windows.Forms.Label statRate;
        private System.Windows.Forms.Label lblStatRateTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlFilterBar;
        private Guna.UI2.WinForms.Guna2Button btnFilterTatCa;
        private Guna.UI2.WinForms.Guna2Button btnFilterGiaCao;
        private Guna.UI2.WinForms.Guna2Button btnFilterGiaThap;
        private Guna.UI2.WinForms.Guna2Button btnFilterBanChay;
        private Guna.UI2.WinForms.Guna2Button btnFilterMoiNhat;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
    }
}