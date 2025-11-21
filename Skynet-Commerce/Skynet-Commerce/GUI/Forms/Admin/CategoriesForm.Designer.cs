namespace Skynet_Commerce.GUI.Forms
{
    partial class CategoriesForm
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
            this._btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this._cardMain = new Guna.UI2.WinForms.Guna2Panel();
            this._lblCardTitle = new System.Windows.Forms.Label();
            this._headerPanel = new System.Windows.Forms.Panel();
            this._lblH_Id = new System.Windows.Forms.Label();
            this._lblH_Name = new System.Windows.Forms.Label();
            this._lblH_Products = new System.Windows.Forms.Label();
            this._lblH_Subcats = new System.Windows.Forms.Label();
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
            this._pageTitle.Size = new System.Drawing.Size(173, 25);
            this._pageTitle.TabIndex = 3;
            this._pageTitle.Text = "Quản lý danh mục";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(255, 19);
            this._pageSub.TabIndex = 2;
            this._pageSub.Text = "Sắp xếp và quản lý danh mục sản phẩm.";
            // 
            // _btnAdd
            // 
            this._btnAdd.BorderRadius = 8;
            this._btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnAdd.ForeColor = System.Drawing.Color.White;
            this._btnAdd.Location = new System.Drawing.Point(871, 20);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(140, 40);
            this._btnAdd.TabIndex = 0;
            this._btnAdd.Text = "+ Thêm danh mục";
            // 
            // _cardMain
            // 
            this._cardMain.BackColor = System.Drawing.Color.Transparent;
            this._cardMain.BorderRadius = 12;
            this._cardMain.Controls.Add(this._lblCardTitle);
            this._cardMain.Controls.Add(this._headerPanel);
            this._cardMain.Controls.Add(this._flowPanel);
            this._cardMain.FillColor = System.Drawing.Color.White;
            this._cardMain.Location = new System.Drawing.Point(25, 90);
            this._cardMain.Name = "_cardMain";
            this._cardMain.ShadowDecoration.Depth = 5;
            this._cardMain.ShadowDecoration.Enabled = true;
            this._cardMain.Size = new System.Drawing.Size(997, 538);
            this._cardMain.TabIndex = 1;
            // 
            // _lblCardTitle
            // 
            this._lblCardTitle.AutoSize = true;
            this._lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblCardTitle.Location = new System.Drawing.Point(25, 25);
            this._lblCardTitle.Name = "_lblCardTitle";
            this._lblCardTitle.Size = new System.Drawing.Size(124, 20);
            this._lblCardTitle.TabIndex = 0;
            this._lblCardTitle.Text = "Tất cả danh mục";
            // 
            // _headerPanel
            // 
            this._headerPanel.Controls.Add(this._lblH_Id);
            this._headerPanel.Controls.Add(this._lblH_Name);
            this._headerPanel.Controls.Add(this._lblH_Products);
            this._headerPanel.Controls.Add(this._lblH_Subcats);
            this._headerPanel.Controls.Add(this._lblH_Actions);
            this._headerPanel.Location = new System.Drawing.Point(20, 60);
            this._headerPanel.Name = "_headerPanel";
            this._headerPanel.Size = new System.Drawing.Size(1060, 30);
            this._headerPanel.TabIndex = 1;
            // 
            // _lblH_Id
            // 
            this._lblH_Id.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Id.Location = new System.Drawing.Point(20, 4);
            this._lblH_Id.Name = "_lblH_Id";
            this._lblH_Id.Size = new System.Drawing.Size(100, 23);
            this._lblH_Id.TabIndex = 0;
            this._lblH_Id.Text = "Mã danh mục";
            // 
            // _lblH_Name
            // 
            this._lblH_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Name.Location = new System.Drawing.Point(150, 4);
            this._lblH_Name.Name = "_lblH_Name";
            this._lblH_Name.Size = new System.Drawing.Size(100, 23);
            this._lblH_Name.TabIndex = 1;
            this._lblH_Name.Text = "Tên danh mục";
            // 
            // _lblH_Products
            // 
            this._lblH_Products.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Products.Location = new System.Drawing.Point(382, 4);
            this._lblH_Products.Name = "_lblH_Products";
            this._lblH_Products.Size = new System.Drawing.Size(100, 23);
            this._lblH_Products.TabIndex = 2;
            this._lblH_Products.Text = "Tổng sản phẩm";
            // 
            // _lblH_Subcats
            // 
            this._lblH_Subcats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Subcats.Location = new System.Drawing.Point(579, 4);
            this._lblH_Subcats.Name = "_lblH_Subcats";
            this._lblH_Subcats.Size = new System.Drawing.Size(100, 23);
            this._lblH_Subcats.TabIndex = 3;
            this._lblH_Subcats.Text = "Danh mục con";
            // 
            // _lblH_Actions
            // 
            this._lblH_Actions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Actions.Location = new System.Drawing.Point(844, 4);
            this._lblH_Actions.Name = "_lblH_Actions";
            this._lblH_Actions.Size = new System.Drawing.Size(71, 23);
            this._lblH_Actions.TabIndex = 4;
            this._lblH_Actions.Text = "Hành động";
            // 
            // _flowPanel
            // 
            this._flowPanel.AutoScroll = true;
            this._flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowPanel.Location = new System.Drawing.Point(20, 95);
            this._flowPanel.Name = "_flowPanel";
            this._flowPanel.Size = new System.Drawing.Size(974, 440);
            this._flowPanel.TabIndex = 2;
            this._flowPanel.WrapContents = false;
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._cardMain);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "CategoriesForm";
            this.Text = "Category Management";
            this.Load += new System.EventHandler(this.CategoriesForm_Load);
            this._cardMain.ResumeLayout(false);
            this._cardMain.PerformLayout();
            this._headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _pageTitle;
        private System.Windows.Forms.Label _pageSub;
        private Guna.UI2.WinForms.Guna2Button _btnAdd;
        private Guna.UI2.WinForms.Guna2Panel _cardMain;
        private System.Windows.Forms.Label _lblCardTitle;
        private System.Windows.Forms.Panel _headerPanel;
        private System.Windows.Forms.FlowLayoutPanel _flowPanel;
        private System.Windows.Forms.Label _lblH_Id, _lblH_Name, _lblH_Products, _lblH_Subcats, _lblH_Actions;
    }
}