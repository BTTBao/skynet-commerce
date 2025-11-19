namespace Skynet_Commerce.GUI.UserControls.General
{
    partial class UcHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcHeader));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlMainBar = new System.Windows.Forms.Panel();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlUserActions = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.btnSellerDashboard = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.profileIcon = new System.Windows.Forms.PictureBox();
            this.cartIcon = new System.Windows.Forms.PictureBox();
            this.pnlMainBar.SuspendLayout();
            this.tlpMainContent.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlUserActions.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1200, 35);
            this.pnlTopBar.TabIndex = 1;
            // 
            // pnlMainBar
            // 
            this.pnlMainBar.BackColor = System.Drawing.Color.White;
            this.pnlMainBar.Controls.Add(this.tlpMainContent);
            this.pnlMainBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBar.Location = new System.Drawing.Point(0, 35);
            this.pnlMainBar.Name = "pnlMainBar";
            this.pnlMainBar.Size = new System.Drawing.Size(1200, 60);
            this.pnlMainBar.TabIndex = 0;
            // 
            // tlpMainContent
            // 
            this.tlpMainContent.ColumnCount = 3;
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.91379F));
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMainContent.Controls.Add(this.pnlLogo, 0, 0);
            this.tlpMainContent.Controls.Add(this.pnlUserActions, 2, 0);
            this.tlpMainContent.Controls.Add(this.pnlSearch, 1, 0);
            this.tlpMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainContent.Location = new System.Drawing.Point(0, 0);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainContent.Size = new System.Drawing.Size(1200, 60);
            this.tlpMainContent.TabIndex = 0;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblAppName);
            this.pnlLogo.Controls.Add(this.pbLogo);
            this.pnlLogo.Location = new System.Drawing.Point(23, 8);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 44);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(100, 23);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "ShopViet";
            this.lblAppName.Click += new System.EventHandler(this.lblAppName_Click);
            // 
            // pnlUserActions
            // 
            this.pnlUserActions.Controls.Add(this.profileIcon);
            this.pnlUserActions.Controls.Add(this.cartIcon);
            this.pnlUserActions.Location = new System.Drawing.Point(950, 8);
            this.pnlUserActions.Name = "pnlUserActions";
            this.pnlUserActions.Size = new System.Drawing.Size(200, 44);
            this.pnlUserActions.TabIndex = 2;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Location = new System.Drawing.Point(370, 8);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(542, 44);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(3, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(465, 35);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnSearch.Location = new System.Drawing.Point(468, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 38);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblHome
            // 
            this.lblHome.Location = new System.Drawing.Point(0, 0);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(100, 23);
            this.lblHome.TabIndex = 0;
            // 
            // lblOrders
            // 
            this.lblOrders.Location = new System.Drawing.Point(0, 0);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(100, 23);
            this.lblOrders.TabIndex = 0;
            // 
            // btnSellerDashboard
            // 
            this.btnSellerDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnSellerDashboard.Name = "btnSellerDashboard";
            this.btnSellerDashboard.Size = new System.Drawing.Size(75, 23);
            this.btnSellerDashboard.TabIndex = 0;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(0, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(100, 23);
            this.lblAccount.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 50);
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // profileIcon
            // 
            this.profileIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.profileIcon.Image = global::Skynet_Commerce.Properties.Resources.trash;
            this.profileIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("profileIcon.InitialImage")));
            this.profileIcon.Location = new System.Drawing.Point(128, -2);
            this.profileIcon.Name = "profileIcon";
            this.profileIcon.Size = new System.Drawing.Size(56, 46);
            this.profileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profileIcon.TabIndex = 1;
            this.profileIcon.TabStop = false;
            this.profileIcon.Click += new System.EventHandler(this.profileIcon_Click);
            // 
            // cartIcon
            // 
            this.cartIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cartIcon.Image = global::Skynet_Commerce.Properties.Resources.trash;
            this.cartIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("cartIcon.InitialImage")));
            this.cartIcon.Location = new System.Drawing.Point(44, 3);
            this.cartIcon.Name = "cartIcon";
            this.cartIcon.Size = new System.Drawing.Size(46, 35);
            this.cartIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cartIcon.TabIndex = 0;
            this.cartIcon.TabStop = false;
            this.cartIcon.Click += new System.EventHandler(this.cartIcon_Click);
            // 
            // UcHeader
            // 
            this.Controls.Add(this.pnlMainBar);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "UcHeader";
            this.Size = new System.Drawing.Size(1200, 95);
            this.pnlMainBar.ResumeLayout(false);
            this.tlpMainContent.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlUserActions.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartIcon)).EndInit();
            this.ResumeLayout(false);

        }

        // KHAI BÁO CÁC CONTROL PRIVATE Ở ĐÂY
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlMainBar;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlUserActions;

        // Top Bar Controls
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Button btnSellerDashboard;
        private System.Windows.Forms.Label lblAccount;


        #endregion

        private System.Windows.Forms.PictureBox cartIcon;
        private System.Windows.Forms.PictureBox profileIcon;
    }
}
