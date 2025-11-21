using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    partial class UcProductDetail
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
            this.pnlScrollContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDetailContainer = new System.Windows.Forms.Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDescription = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDescriptionText = new System.Windows.Forms.Label();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.pnlShopInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFollow = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewShop = new Guna.UI2.WinForms.Guna2Button();
            this.lblShopStats = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.pbShopLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tblProductMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlProductActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBuyNow = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddCart = new Guna.UI2.WinForms.Guna2Button();
            this.pnlQuantityControl = new System.Windows.Forms.Panel();
            this.lblQuantityAvailable = new System.Windows.Forms.Label();
            this.btnQuantityDecrease = new Guna.UI2.WinForms.Guna2Button();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnQuantityIncrease = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuantityLabel = new System.Windows.Forms.Label();
            this.pnlColorOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblColorLabel = new System.Windows.Forms.Label();
            this.pnlSizeOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSizeLabel = new System.Windows.Forms.Label();
            this.pnlPrice = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblOldPrice = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlRating = new System.Windows.Forms.Panel();
            this.lblSoldCount = new System.Windows.Forms.Label();
            this.lblReviewCount = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pnlImageGallery = new Guna.UI2.WinForms.Guna2Panel();
            this.flpThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.pbMainImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlScrollContainer.SuspendLayout();
            this.pnlDetailContainer.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDescription.SuspendLayout();
            this.pnlShopInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopLogo)).BeginInit();
            this.tblProductMain.SuspendLayout();
            this.pnlProductActions.SuspendLayout();
            this.pnlQuantityControl.SuspendLayout();
            this.pnlPrice.SuspendLayout();
            this.pnlRating.SuspendLayout();
            this.pnlImageGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScrollContainer
            // 
            this.pnlScrollContainer.AutoScroll = true;
            this.pnlScrollContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlScrollContainer.Controls.Add(this.pnlDetailContainer);
            this.pnlScrollContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlScrollContainer.Name = "pnlScrollContainer";
            this.pnlScrollContainer.Size = new System.Drawing.Size(1200, 950);
            this.pnlScrollContainer.TabIndex = 0;
            // 
            // pnlDetailContainer
            // 
            this.pnlDetailContainer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlDetailContainer.Controls.Add(this.pnlContent);
            this.pnlDetailContainer.Controls.Add(this.tblProductMain);
            this.pnlDetailContainer.Location = new System.Drawing.Point(100, 30);
            this.pnlDetailContainer.Name = "pnlDetailContainer";
            this.pnlDetailContainer.Size = new System.Drawing.Size(1000, 850);
            this.pnlDetailContainer.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlDescription);
            this.pnlContent.Controls.Add(this.pnlShopInfo);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(0, 480);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(1000, 350);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlDescription
            // 
            this.pnlDescription.BackColor = System.Drawing.Color.Transparent;
            this.pnlDescription.BorderRadius = 8;
            this.pnlDescription.Controls.Add(this.lblDescriptionText);
            this.pnlDescription.Controls.Add(this.lblDescriptionTitle);
            this.pnlDescription.Location = new System.Drawing.Point(0, 150);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDescription.ShadowDecoration.BorderRadius = 8;
            this.pnlDescription.ShadowDecoration.Enabled = true;
            this.pnlDescription.Size = new System.Drawing.Size(1000, 150);
            this.pnlDescription.TabIndex = 1;
            // 
            // lblDescriptionText
            // 
            this.lblDescriptionText.Location = new System.Drawing.Point(15, 60);
            this.lblDescriptionText.Name = "lblDescriptionText";
            this.lblDescriptionText.Size = new System.Drawing.Size(970, 75);
            this.lblDescriptionText.TabIndex = 1;
            // 
            // lblDescriptionTitle
            // 
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionTitle.Location = new System.Drawing.Point(15, 20);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(132, 21);
            this.lblDescriptionTitle.TabIndex = 0;
            this.lblDescriptionTitle.Text = "Mô tả sản phẩm";
            // 
            // pnlShopInfo
            // 
            this.pnlShopInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlShopInfo.BorderRadius = 8;
            this.pnlShopInfo.Controls.Add(this.btnFollow);
            this.pnlShopInfo.Controls.Add(this.btnViewShop);
            this.pnlShopInfo.Controls.Add(this.lblShopStats);
            this.pnlShopInfo.Controls.Add(this.lblShopName);
            this.pnlShopInfo.Controls.Add(this.pbShopLogo);
            this.pnlShopInfo.Location = new System.Drawing.Point(0, 20);
            this.pnlShopInfo.Name = "pnlShopInfo";
            this.pnlShopInfo.ShadowDecoration.BorderRadius = 8;
            this.pnlShopInfo.ShadowDecoration.Enabled = true;
            this.pnlShopInfo.Size = new System.Drawing.Size(1000, 100);
            this.pnlShopInfo.TabIndex = 0;
            // 
            // btnFollow
            // 
            this.btnFollow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnFollow.BorderRadius = 5;
            this.btnFollow.BorderThickness = 1;
            this.btnFollow.FillColor = System.Drawing.Color.White;
            this.btnFollow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFollow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnFollow.Location = new System.Drawing.Point(850, 35);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(120, 30);
            this.btnFollow.TabIndex = 4;
            this.btnFollow.Text = "Theo dõi";
            // 
            // btnViewShop
            // 
            this.btnViewShop.BorderColor = System.Drawing.Color.Gray;
            this.btnViewShop.BorderRadius = 5;
            this.btnViewShop.BorderThickness = 1;
            this.btnViewShop.FillColor = System.Drawing.Color.White;
            this.btnViewShop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewShop.ForeColor = System.Drawing.Color.Black;
            this.btnViewShop.Location = new System.Drawing.Point(720, 35);
            this.btnViewShop.Name = "btnViewShop";
            this.btnViewShop.Size = new System.Drawing.Size(120, 30);
            this.btnViewShop.TabIndex = 3;
            this.btnViewShop.Text = "Xem Shop";
            this.btnViewShop.Click += new System.EventHandler(this.BtnViewShop_Click);
            // 
            // lblShopStats
            // 
            this.lblShopStats.AutoSize = true;
            this.lblShopStats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopStats.ForeColor = System.Drawing.Color.Gray;
            this.lblShopStats.Location = new System.Drawing.Point(100, 55);
            this.lblShopStats.Name = "lblShopStats";
            this.lblShopStats.Size = new System.Drawing.Size(0, 15);
            this.lblShopStats.TabIndex = 2;
            // 
            // lblShopName
            // 
            this.lblShopName.AutoSize = true;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShopName.Location = new System.Drawing.Point(100, 30);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(0, 20);
            this.lblShopName.TabIndex = 1;
            // 
            // pbShopLogo
            // 
            this.pbShopLogo.BorderRadius = 30;
            this.pbShopLogo.ImageRotate = 0F;
            this.pbShopLogo.Location = new System.Drawing.Point(20, 20);
            this.pbShopLogo.Name = "pbShopLogo";
            this.pbShopLogo.ShadowDecoration.BorderRadius = 30;
            this.pbShopLogo.Size = new System.Drawing.Size(60, 60);
            this.pbShopLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShopLogo.TabIndex = 0;
            this.pbShopLogo.TabStop = false;
            // 
            // tblProductMain
            // 
            this.tblProductMain.ColumnCount = 2;
            this.tblProductMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProductMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProductMain.Controls.Add(this.pnlProductActions, 1, 0);
            this.tblProductMain.Controls.Add(this.pnlImageGallery, 0, 0);
            this.tblProductMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblProductMain.Location = new System.Drawing.Point(0, 0);
            this.tblProductMain.Name = "tblProductMain";
            this.tblProductMain.RowCount = 1;
            this.tblProductMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProductMain.Size = new System.Drawing.Size(1000, 480);
            this.tblProductMain.TabIndex = 0;
            // 
            // pnlProductActions
            // 
            this.pnlProductActions.BackColor = System.Drawing.Color.White;
            this.pnlProductActions.Controls.Add(this.btnBuyNow);
            this.pnlProductActions.Controls.Add(this.btnAddCart);
            this.pnlProductActions.Controls.Add(this.pnlQuantityControl);
            this.pnlProductActions.Controls.Add(this.lblQuantityLabel);
            this.pnlProductActions.Controls.Add(this.pnlColorOptions);
            this.pnlProductActions.Controls.Add(this.lblColorLabel);
            this.pnlProductActions.Controls.Add(this.pnlSizeOptions);
            this.pnlProductActions.Controls.Add(this.lblSizeLabel);
            this.pnlProductActions.Controls.Add(this.pnlPrice);
            this.pnlProductActions.Controls.Add(this.pnlRating);
            this.pnlProductActions.Controls.Add(this.lblProductName);
            this.pnlProductActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductActions.Location = new System.Drawing.Point(503, 3);
            this.pnlProductActions.Name = "pnlProductActions";
            this.pnlProductActions.Padding = new System.Windows.Forms.Padding(15);
            this.pnlProductActions.Size = new System.Drawing.Size(494, 474);
            this.pnlProductActions.TabIndex = 1;
            // 
            // btnBuyNow
            // 
            this.btnBuyNow.BorderRadius = 5;
            this.btnBuyNow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnBuyNow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyNow.ForeColor = System.Drawing.Color.White;
            this.btnBuyNow.Location = new System.Drawing.Point(260, 410);
            this.btnBuyNow.Name = "btnBuyNow";
            this.btnBuyNow.Size = new System.Drawing.Size(180, 40);
            this.btnBuyNow.TabIndex = 10;
            this.btnBuyNow.Text = "Mua ngay";
            // 
            // btnAddCart
            // 
            this.btnAddCart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnAddCart.BorderRadius = 5;
            this.btnAddCart.BorderThickness = 1;
            this.btnAddCart.FillColor = System.Drawing.Color.White;
            this.btnAddCart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnAddCart.Location = new System.Drawing.Point(60, 410);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(180, 40);
            this.btnAddCart.TabIndex = 9;
            this.btnAddCart.Text = "🛒 Thêm vào giỏ";
            // 
            // pnlQuantityControl
            // 
            this.pnlQuantityControl.Controls.Add(this.lblQuantityAvailable);
            this.pnlQuantityControl.Controls.Add(this.btnQuantityDecrease);
            this.pnlQuantityControl.Controls.Add(this.txtQuantity);
            this.pnlQuantityControl.Controls.Add(this.btnQuantityIncrease);
            this.pnlQuantityControl.Location = new System.Drawing.Point(120, 350);
            this.pnlQuantityControl.Name = "pnlQuantityControl";
            this.pnlQuantityControl.Size = new System.Drawing.Size(250, 30);
            this.pnlQuantityControl.TabIndex = 8;
            // 
            // lblQuantityAvailable
            // 
            this.lblQuantityAvailable.AutoSize = true;
            this.lblQuantityAvailable.Location = new System.Drawing.Point(116, 8);
            this.lblQuantityAvailable.Name = "lblQuantityAvailable";
            this.lblQuantityAvailable.Size = new System.Drawing.Size(118, 13);
            this.lblQuantityAvailable.TabIndex = 3;
            this.lblQuantityAvailable.Text = "+ 150 sản phẩm có sẵn";
            // 
            // btnQuantityDecrease
            // 
            this.btnQuantityDecrease.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnQuantityDecrease.BorderRadius = 5;
            this.btnQuantityDecrease.BorderThickness = 1;
            this.btnQuantityDecrease.FillColor = System.Drawing.Color.White;
            this.btnQuantityDecrease.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuantityDecrease.ForeColor = System.Drawing.Color.Black;
            this.btnQuantityDecrease.Location = new System.Drawing.Point(0, 0);
            this.btnQuantityDecrease.Name = "btnQuantityDecrease";
            this.btnQuantityDecrease.Size = new System.Drawing.Size(30, 30);
            this.btnQuantityDecrease.TabIndex = 2;
            this.btnQuantityDecrease.Text = "-";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtQuantity.BorderRadius = 5;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "1";
            this.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(30, 0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(50, 30);
            this.txtQuantity.TabIndex = 1;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnQuantityIncrease
            // 
            this.btnQuantityIncrease.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnQuantityIncrease.BorderRadius = 5;
            this.btnQuantityIncrease.BorderThickness = 1;
            this.btnQuantityIncrease.FillColor = System.Drawing.Color.White;
            this.btnQuantityIncrease.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuantityIncrease.ForeColor = System.Drawing.Color.Black;
            this.btnQuantityIncrease.Location = new System.Drawing.Point(80, 0);
            this.btnQuantityIncrease.Name = "btnQuantityIncrease";
            this.btnQuantityIncrease.Size = new System.Drawing.Size(30, 30);
            this.btnQuantityIncrease.TabIndex = 0;
            this.btnQuantityIncrease.Text = "+";
            // 
            // lblQuantityLabel
            // 
            this.lblQuantityLabel.AutoSize = true;
            this.lblQuantityLabel.Location = new System.Drawing.Point(40, 358);
            this.lblQuantityLabel.Name = "lblQuantityLabel";
            this.lblQuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.lblQuantityLabel.TabIndex = 7;
            this.lblQuantityLabel.Text = "Số lượng";
            // 
            // pnlColorOptions
            // 
            this.pnlColorOptions.Location = new System.Drawing.Point(120, 272);
            this.pnlColorOptions.Name = "pnlColorOptions";
            this.pnlColorOptions.Size = new System.Drawing.Size(350, 38);
            this.pnlColorOptions.TabIndex = 6;
            // 
            // lblColorLabel
            // 
            this.lblColorLabel.AutoSize = true;
            this.lblColorLabel.Location = new System.Drawing.Point(41, 284);
            this.lblColorLabel.Name = "lblColorLabel";
            this.lblColorLabel.Size = new System.Drawing.Size(48, 13);
            this.lblColorLabel.TabIndex = 5;
            this.lblColorLabel.Text = "Màu sắc";
            // 
            // pnlSizeOptions
            // 
            this.pnlSizeOptions.Location = new System.Drawing.Point(120, 207);
            this.pnlSizeOptions.Name = "pnlSizeOptions";
            this.pnlSizeOptions.Size = new System.Drawing.Size(350, 44);
            this.pnlSizeOptions.TabIndex = 4;
            // 
            // lblSizeLabel
            // 
            this.lblSizeLabel.AutoSize = true;
            this.lblSizeLabel.Location = new System.Drawing.Point(40, 218);
            this.lblSizeLabel.Name = "lblSizeLabel";
            this.lblSizeLabel.Size = new System.Drawing.Size(60, 13);
            this.lblSizeLabel.TabIndex = 3;
            this.lblSizeLabel.Text = "Kích thước";
            // 
            // pnlPrice
            // 
            this.pnlPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(231)))));
            this.pnlPrice.Controls.Add(this.lblDiscount);
            this.pnlPrice.Controls.Add(this.lblOldPrice);
            this.pnlPrice.Controls.Add(this.lblPrice);
            this.pnlPrice.Location = new System.Drawing.Point(3, 125);
            this.pnlPrice.Name = "pnlPrice";
            this.pnlPrice.Size = new System.Drawing.Size(494, 50);
            this.pnlPrice.TabIndex = 2;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblDiscount.Location = new System.Drawing.Point(300, 15);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(0, 17);
            this.lblDiscount.TabIndex = 2;
            // 
            // lblOldPrice
            // 
            this.lblOldPrice.AutoSize = true;
            this.lblOldPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblOldPrice.Location = new System.Drawing.Point(200, 15);
            this.lblOldPrice.Name = "lblOldPrice";
            this.lblOldPrice.Size = new System.Drawing.Size(0, 20);
            this.lblOldPrice.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblPrice.Location = new System.Drawing.Point(20, 5);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(50, 37);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "0₫";
            // 
            // pnlRating
            // 
            this.pnlRating.Controls.Add(this.lblSoldCount);
            this.pnlRating.Controls.Add(this.lblReviewCount);
            this.pnlRating.Controls.Add(this.lblRating);
            this.pnlRating.Location = new System.Drawing.Point(0, 50);
            this.pnlRating.Name = "pnlRating";
            this.pnlRating.Size = new System.Drawing.Size(494, 30);
            this.pnlRating.TabIndex = 1;
            // 
            // lblSoldCount
            // 
            this.lblSoldCount.AutoSize = true;
            this.lblSoldCount.Location = new System.Drawing.Point(220, 10);
            this.lblSoldCount.Name = "lblSoldCount";
            this.lblSoldCount.Size = new System.Drawing.Size(69, 13);
            this.lblSoldCount.TabIndex = 2;
            this.lblSoldCount.Text = "1234 Đã bán";
            // 
            // lblReviewCount
            // 
            this.lblReviewCount.AutoSize = true;
            this.lblReviewCount.ForeColor = System.Drawing.Color.Gray;
            this.lblReviewCount.Location = new System.Drawing.Point(120, 10);
            this.lblReviewCount.Name = "lblReviewCount";
            this.lblReviewCount.Size = new System.Drawing.Size(71, 13);
            this.lblReviewCount.TabIndex = 1;
            this.lblReviewCount.Text = "234 Đánh giá";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblRating.Location = new System.Drawing.Point(20, 7);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(42, 17);
            this.lblRating.TabIndex = 0;
            this.lblRating.Text = "4.8 ★";
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(15, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(464, 35);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            // 
            // pnlImageGallery
            // 
            this.pnlImageGallery.BackColor = System.Drawing.Color.White;
            this.pnlImageGallery.BorderRadius = 8;
            this.pnlImageGallery.Controls.Add(this.flpThumbnails);
            this.pnlImageGallery.Controls.Add(this.pbMainImage);
            this.pnlImageGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageGallery.Location = new System.Drawing.Point(3, 3);
            this.pnlImageGallery.Name = "pnlImageGallery";
            this.pnlImageGallery.Size = new System.Drawing.Size(494, 474);
            this.pnlImageGallery.TabIndex = 0;
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.Location = new System.Drawing.Point(20, 395);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(450, 70);
            this.flpThumbnails.TabIndex = 1;
            // 
            // pbMainImage
            // 
            this.pbMainImage.BorderRadius = 8;
            this.pbMainImage.ImageRotate = 0F;
            this.pbMainImage.Location = new System.Drawing.Point(20, 20);
            this.pbMainImage.Name = "pbMainImage";
            this.pbMainImage.Size = new System.Drawing.Size(450, 360);
            this.pbMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMainImage.TabIndex = 0;
            this.pbMainImage.TabStop = false;
            // 
            // UcProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScrollContainer);
            this.Name = "UcProductDetail";
            this.Size = new System.Drawing.Size(1200, 950);
            this.pnlScrollContainer.ResumeLayout(false);
            this.pnlDetailContainer.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.pnlShopInfo.ResumeLayout(false);
            this.pnlShopInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopLogo)).EndInit();
            this.tblProductMain.ResumeLayout(false);
            this.pnlProductActions.ResumeLayout(false);
            this.pnlProductActions.PerformLayout();
            this.pnlQuantityControl.ResumeLayout(false);
            this.pnlQuantityControl.PerformLayout();
            this.pnlPrice.ResumeLayout(false);
            this.pnlPrice.PerformLayout();
            this.pnlRating.ResumeLayout(false);
            this.pnlRating.PerformLayout();
            this.pnlImageGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainImage)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Guna2Panel pnlScrollContainer;
        private System.Windows.Forms.Panel pnlDetailContainer;
        private System.Windows.Forms.TableLayoutPanel tblProductMain;
        private Guna2Panel pnlImageGallery;
        private Guna2PictureBox pbMainImage;
        private System.Windows.Forms.FlowLayoutPanel flpThumbnails;
        private Guna2Panel pnlProductActions;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlRating;
        private System.Windows.Forms.Label lblReviewCount;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblSoldCount;
        private System.Windows.Forms.Panel pnlPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblOldPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblSizeLabel;
        private System.Windows.Forms.FlowLayoutPanel pnlSizeOptions;
        private System.Windows.Forms.FlowLayoutPanel pnlColorOptions;
        private System.Windows.Forms.Label lblColorLabel;
        private System.Windows.Forms.Panel pnlQuantityControl;
        private Guna2Button btnQuantityIncrease;
        private Guna2TextBox txtQuantity;
        private Guna2Button btnQuantityDecrease;
        private Guna2Button btnBuyNow;
        private Guna2Button btnAddCart;
        private System.Windows.Forms.Label lblQuantityAvailable;
        private System.Windows.Forms.Label lblQuantityLabel;
        private Guna2Panel pnlContent;
        private Guna2Panel pnlShopInfo;
        private Guna2PictureBox pbShopLogo;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.Label lblShopStats;
        private Guna2Button btnViewShop;
        private Guna2Button btnFollow;
        private Guna2Panel pnlDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.Label lblDescriptionText;
    }
}