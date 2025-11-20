namespace Skynet_Commerce.GUI.Forms
{
    partial class OrdersForm
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
            this._headerPanel = new System.Windows.Forms.Panel();
            this._lblH_Id = new System.Windows.Forms.Label();
            this._lblH_Buyer = new System.Windows.Forms.Label();
            this._lblH_Shop = new System.Windows.Forms.Label();
            this._lblH_Items = new System.Windows.Forms.Label();
            this._lblH_Amount = new System.Windows.Forms.Label();
            this._lblH_Date = new System.Windows.Forms.Label();
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
            this._pageTitle.Size = new System.Drawing.Size(187, 25);
            this._pageTitle.TabIndex = 2;
            this._pageTitle.Text = "Order Management";
            // 
            // _pageSub
            // 
            this._pageSub.AutoSize = true;
            this._pageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pageSub.ForeColor = System.Drawing.Color.Gray;
            this._pageSub.Location = new System.Drawing.Point(22, 50);
            this._pageSub.Name = "_pageSub";
            this._pageSub.Size = new System.Drawing.Size(300, 19);
            this._pageSub.TabIndex = 1;
            this._pageSub.Text = "Track and manage all orders in the marketplace.";
            // 
            // _cardMain
            // 
            this._cardMain.BackColor = System.Drawing.Color.Transparent;
            this._cardMain.BorderRadius = 12;
            this._cardMain.Controls.Add(this._lblCardTitle);
            this._cardMain.Controls.Add(this._txtSearch);
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
            this._lblCardTitle.Size = new System.Drawing.Size(79, 20);
            this._lblCardTitle.TabIndex = 0;
            this._lblCardTitle.Text = "All Orders";
            // 
            // _txtSearch
            // 
            this._txtSearch.BorderRadius = 8;
            this._txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtSearch.DefaultText = "";
            this._txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtSearch.Location = new System.Drawing.Point(719, 20);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.PlaceholderText = "Search orders...";
            this._txtSearch.SelectedText = "";
            this._txtSearch.Size = new System.Drawing.Size(250, 36);
            this._txtSearch.TabIndex = 1;
            // 
            // _headerPanel
            // 
            this._headerPanel.Controls.Add(this._lblH_Id);
            this._headerPanel.Controls.Add(this._lblH_Buyer);
            this._headerPanel.Controls.Add(this._lblH_Shop);
            this._headerPanel.Controls.Add(this._lblH_Items);
            this._headerPanel.Controls.Add(this._lblH_Amount);
            this._headerPanel.Controls.Add(this._lblH_Date);
            this._headerPanel.Controls.Add(this._lblH_Status);
            this._headerPanel.Controls.Add(this._lblH_Actions);
            this._headerPanel.Location = new System.Drawing.Point(20, 70);
            this._headerPanel.Name = "_headerPanel";
            this._headerPanel.Size = new System.Drawing.Size(1060, 30);
            this._headerPanel.TabIndex = 2;
            // 
            // _lblH_Id
            // 
            this._lblH_Id.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Id.Location = new System.Drawing.Point(20, 4);
            this._lblH_Id.Name = "_lblH_Id";
            this._lblH_Id.Size = new System.Drawing.Size(100, 23);
            this._lblH_Id.TabIndex = 0;
            this._lblH_Id.Text = "Order ID";
            // 
            // _lblH_Buyer
            // 
            this._lblH_Buyer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Buyer.Location = new System.Drawing.Point(130, 4);
            this._lblH_Buyer.Name = "_lblH_Buyer";
            this._lblH_Buyer.Size = new System.Drawing.Size(57, 23);
            this._lblH_Buyer.TabIndex = 1;
            this._lblH_Buyer.Text = "Buyer";
            // 
            // _lblH_Shop
            // 
            this._lblH_Shop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Shop.Location = new System.Drawing.Point(280, 4);
            this._lblH_Shop.Name = "_lblH_Shop";
            this._lblH_Shop.Size = new System.Drawing.Size(49, 23);
            this._lblH_Shop.TabIndex = 2;
            this._lblH_Shop.Text = "Shop";
            // 
            // _lblH_Items
            // 
            this._lblH_Items.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Items.Location = new System.Drawing.Point(417, 4);
            this._lblH_Items.Name = "_lblH_Items";
            this._lblH_Items.Size = new System.Drawing.Size(50, 23);
            this._lblH_Items.TabIndex = 3;
            this._lblH_Items.Text = "Items";
            // 
            // _lblH_Amount
            // 
            this._lblH_Amount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Amount.Location = new System.Drawing.Point(500, 4);
            this._lblH_Amount.Name = "_lblH_Amount";
            this._lblH_Amount.Size = new System.Drawing.Size(100, 23);
            this._lblH_Amount.TabIndex = 4;
            this._lblH_Amount.Text = "Amount";
            // 
            // _lblH_Date
            // 
            this._lblH_Date.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Date.Location = new System.Drawing.Point(614, 4);
            this._lblH_Date.Name = "_lblH_Date";
            this._lblH_Date.Size = new System.Drawing.Size(50, 23);
            this._lblH_Date.TabIndex = 5;
            this._lblH_Date.Text = "Date";
            // 
            // _lblH_Status
            // 
            this._lblH_Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Status.Location = new System.Drawing.Point(736, 4);
            this._lblH_Status.Name = "_lblH_Status";
            this._lblH_Status.Size = new System.Drawing.Size(59, 23);
            this._lblH_Status.TabIndex = 6;
            this._lblH_Status.Text = "Status";
            // 
            // _lblH_Actions
            // 
            this._lblH_Actions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblH_Actions.Location = new System.Drawing.Point(909, 4);
            this._lblH_Actions.Name = "_lblH_Actions";
            this._lblH_Actions.Size = new System.Drawing.Size(100, 23);
            this._lblH_Actions.TabIndex = 7;
            this._lblH_Actions.Text = "Actions";
            // 
            // _flowPanel
            // 
            this._flowPanel.AutoScroll = true;
            this._flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowPanel.Location = new System.Drawing.Point(20, 100);
            this._flowPanel.Name = "_flowPanel";
            this._flowPanel.Size = new System.Drawing.Size(974, 435);
            this._flowPanel.TabIndex = 3;
            this._flowPanel.WrapContents = false;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this._cardMain);
            this.Controls.Add(this._pageSub);
            this.Controls.Add(this._pageTitle);
            this.Name = "OrdersForm";
            this.Text = "Order Management";
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
        private System.Windows.Forms.Panel _headerPanel;
        private System.Windows.Forms.FlowLayoutPanel _flowPanel;
        private System.Windows.Forms.Label _lblH_Id, _lblH_Buyer, _lblH_Shop, _lblH_Items, _lblH_Amount, _lblH_Date, _lblH_Status, _lblH_Actions;
    }
}