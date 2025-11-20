namespace Skynet_Commerce.GUI.Forms
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this._pageTitle = new System.Windows.Forms.Label();
            this._pageSub = new System.Windows.Forms.Label();
            this._cardMain = new Guna.UI2.WinForms.Guna2Panel();
            this._lblCardTitle = new System.Windows.Forms.Label();
            this._txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this._comboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this._headerPanel = new System.Windows.Forms.Panel();
            this._lblH_Product = new System.Windows.Forms.Label();
            this._lblH_Shop = new System.Windows.Forms.Label();
            this._lblH_Category = new System.Windows.Forms.Label();
            this._lblH_Price = new System.Windows.Forms.Label();
            this._lblH_Stock = new System.Windows.Forms.Label();
            this._lblH_Status = new System.Windows.Forms.Label();
            this._lblH_Actions = new System.Windows.Forms.Label();
            this._flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._cardMain.SuspendLayout();
            this._headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pageTitle
            // 
            this._pageTitle.AutoSize = true;
            this._pageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._pageTitle.Location = new System.Drawing.Point(20, 20);
            this._pageTitle.Name = "_pageTitle";
            this._pageTitle.Size = new System.Drawing.Size(207, 25);
            this._pageTitle.TabIndex = 2;
            this._pageTitle.Text = "Product Management";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(281, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Manage all products across the marketplace.";
            // 
            // _cardMain
            // 
            this._cardMain.BackColor = System.Drawing.Color.Transparent;
            this._cardMain.BorderRadius = 12;
            this._cardMain.Controls.Add(this._lblCardTitle);
            this._cardMain.Controls.Add(this._txtSearch);
            this._cardMain.Controls.Add(this._comboCategory);
            this._cardMain.Controls.Add(this._headerPanel);
            this._cardMain.Controls.Add(this._flowPanel);
            this._cardMain.FillColor = System.Drawing.Color.White;
            this._cardMain.Location = new System.Drawing.Point(25, 90);
            this._cardMain.Name = "_cardMain";
            this._cardMain.ShadowDecoration.Depth = 5;
            this._cardMain.ShadowDecoration.Enabled = true;
            this._cardMain.Size = new System.Drawing.Size(997, 538);
            this._cardMain.TabIndex = 0;
            // 
            // _lblCardTitle
            // 
            this._lblCardTitle.AutoSize = true;
            this._lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblCardTitle.Location = new System.Drawing.Point(25, 25);
            this._lblCardTitle.Name = "_lblCardTitle";
            this._lblCardTitle.Size = new System.Drawing.Size(94, 20);
            this._lblCardTitle.TabIndex = 0;
            this._lblCardTitle.Text = "All Products";
            // 
            // _txtSearch
            // 
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(558, 18);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Search products...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            this._txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._txtSearch_KeyDown);
            // 
            // _comboCategory
            // 
            this._comboCategory.BackColor = System.Drawing.Color.Transparent;
            this._comboCategory.BorderRadius = 8;
            this._comboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboCategory.FocusedColor = System.Drawing.Color.Empty;
            this._comboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._comboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this._comboCategory.ItemHeight = 30;
            this._comboCategory.Items.AddRange(new object[] {
            "All Categories",
            "Electronics",
            "Fashion",
            "Furniture",
            "Sports"});
            this._comboCategory.Location = new System.Drawing.Point(827, 18);
            this._comboCategory.Name = "_comboCategory";
            this._comboCategory.Size = new System.Drawing.Size(150, 36);
            this._comboCategory.StartIndex = 0;
            this._comboCategory.TabIndex = 2;
            // 
            // _headerPanel
            // 
            this._headerPanel.Controls.Add(this._lblH_Product);
            this._headerPanel.Controls.Add(this._lblH_Shop);
            this._headerPanel.Controls.Add(this._lblH_Category);
            this._headerPanel.Controls.Add(this._lblH_Price);
            this._headerPanel.Controls.Add(this._lblH_Stock);
            this._headerPanel.Controls.Add(this._lblH_Status);
            this._headerPanel.Controls.Add(this._lblH_Actions);
            this._headerPanel.Location = new System.Drawing.Point(20, 70);
            this._headerPanel.Name = "_headerPanel";
            this._headerPanel.Size = new System.Drawing.Size(1060, 30);
            this._headerPanel.TabIndex = 3;
            // 
            // _lblH_Product
            // 
            this._lblH_Product.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Product.Location = new System.Drawing.Point(47, 4);
            this._lblH_Product.Name = "_lblH_Product";
            this._lblH_Product.Size = new System.Drawing.Size(61, 23);
            this._lblH_Product.TabIndex = 0;
            this._lblH_Product.Text = "Product";
            // 
            // _lblH_Shop
            // 
            this._lblH_Shop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Shop.Location = new System.Drawing.Point(266, 4);
            this._lblH_Shop.Name = "_lblH_Shop";
            this._lblH_Shop.Size = new System.Drawing.Size(44, 23);
            this._lblH_Shop.TabIndex = 1;
            this._lblH_Shop.Text = "Shop";
            // 
            // _lblH_Category
            // 
            this._lblH_Category.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Category.Location = new System.Drawing.Point(384, 4);
            this._lblH_Category.Name = "_lblH_Category";
            this._lblH_Category.Size = new System.Drawing.Size(68, 23);
            this._lblH_Category.TabIndex = 2;
            this._lblH_Category.Text = "Category";
            // 
            // _lblH_Price
            // 
            this._lblH_Price.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Price.Location = new System.Drawing.Point(503, 4);
            this._lblH_Price.Name = "_lblH_Price";
            this._lblH_Price.Size = new System.Drawing.Size(46, 23);
            this._lblH_Price.TabIndex = 3;
            this._lblH_Price.Text = "Price";
            // 
            // _lblH_Stock
            // 
            this._lblH_Stock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Stock.Location = new System.Drawing.Point(579, 4);
            this._lblH_Stock.Name = "_lblH_Stock";
            this._lblH_Stock.Size = new System.Drawing.Size(45, 23);
            this._lblH_Stock.TabIndex = 4;
            this._lblH_Stock.Text = "Stock";
            // 
            // _lblH_Status
            // 
            this._lblH_Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Status.Location = new System.Drawing.Point(667, 5);
            this._lblH_Status.Name = "_lblH_Status";
            this._lblH_Status.Size = new System.Drawing.Size(49, 23);
            this._lblH_Status.TabIndex = 5;
            this._lblH_Status.Text = "Status";
            // 
            // _lblH_Actions
            // 
            this._lblH_Actions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Actions.Location = new System.Drawing.Point(846, 4);
            this._lblH_Actions.Name = "_lblH_Actions";
            this._lblH_Actions.Size = new System.Drawing.Size(53, 23);
            this._lblH_Actions.TabIndex = 6;
            this._lblH_Actions.Text = "Actions";
            // 
            // _flowPanel
            // 
            this._flowPanel.AutoScroll = true;
            this._flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowPanel.Location = new System.Drawing.Point(20, 100);
            this._flowPanel.Name = "_flowPanel";
            this._flowPanel.Size = new System.Drawing.Size(974, 435);
            this._flowPanel.TabIndex = 4;
            this._flowPanel.WrapContents = false;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this._cardMain);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "ProductsForm";
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this._cardMain.ResumeLayout(false);
            this._cardMain.PerformLayout();
            this._headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;
        private Guna.UI2.WinForms.Guna2Panel _cardMain;
        private System.Windows.Forms.Label _lblCardTitle;
        private Guna.UI2.WinForms.Guna2TextBox _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox _comboCategory;
        private System.Windows.Forms.Panel _headerPanel;
        private System.Windows.Forms.FlowLayoutPanel _flowPanel;
        private System.Windows.Forms.Label _lblH_Product, _lblH_Shop, _lblH_Category, _lblH_Price, _lblH_Stock, _lblH_Status, _lblH_Actions;
    }
}