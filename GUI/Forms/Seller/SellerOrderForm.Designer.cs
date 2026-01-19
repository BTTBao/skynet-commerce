// SellerOrderForm.Designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Guna2Panel panelControls;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cmbStatusFilter;
        private Guna2DataGridView dgvOrders;
        private Guna2Panel panelPagination;
        private Guna2Button btnPrevPage;
        private Guna2Button btnNextPage;
        private Label lblPageInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Guna2Panel();
            this.lblTitle = new Label();
            this.panelControls = new Guna2Panel();
            this.txtSearch = new Guna2TextBox();
            this.cmbStatusFilter = new Guna2ComboBox();
            this.dgvOrders = new Guna2DataGridView();
            this.panelPagination = new Guna2Panel();
            this.btnPrevPage = new Guna2Button();
            this.btnNextPage = new Guna2Button();
            this.lblPageInfo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.FillColor = System.Drawing.Color.FromArgb(31, 30, 68);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 60);
            this.panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Quản lý Đơn hàng";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 32);
            this.lblTitle.TabIndex = 0;

            // 
            // panelControls
            // 
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Height = 60;
            this.panelControls.FillColor = System.Drawing.Color.Transparent;
            this.panelControls.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.cmbStatusFilter);
            this.panelControls.Location = new System.Drawing.Point(0, 60);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1100, 60);
            this.panelControls.TabIndex = 1;

            // 
            // txtSearch
            // 
            this.txtSearch.PlaceholderText = "Tìm kiếm đơn hàng...";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Location = new System.Drawing.Point(20, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Size = new System.Drawing.Size(200, 40);
            this.cmbStatusFilter.Location = new System.Drawing.Point(340, 10);
            this.cmbStatusFilter.BorderRadius = 10;
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.TabIndex = 1;
            this.cmbStatusFilter.Items.AddRange(new object[]
            {
                "Tất cả",
                "Chờ xác nhận",
                "Đã xác nhận",
                "Đang chuẩn bị",
                "Đang giao",
                "Đã giao",
                "Hoàn thành",
                "Đã hủy"
            });
            this.cmbStatusFilter.SelectedIndex = 0;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.CmbStatusFilter_SelectedIndexChanged);

            // 
            // dgvOrders
            // 
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
            this.dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.RowTemplate.Height = 80;
            this.dgvOrders.GridColor = System.Drawing.Color.LightGray;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Location = new System.Drawing.Point(0, 120);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(1100, 430);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrders_CellClick);

            // Cột Mã đơn
            System.Windows.Forms.DataGridViewTextBoxColumn colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOrderId.Name = "OrderId";
            colOrderId.HeaderText = "Mã đơn";
            colOrderId.Width = 80;
            colOrderId.ReadOnly = true;
            this.dgvOrders.Columns.Add(colOrderId);

            // Cột Ảnh sản phẩm
            System.Windows.Forms.DataGridViewImageColumn colImage = new System.Windows.Forms.DataGridViewImageColumn();
            colImage.Name = "ProductImage";
            colImage.HeaderText = "Ảnh";
            colImage.Width = 80;
            colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            colImage.ReadOnly = true;
            this.dgvOrders.Columns.Add(colImage);

            // Cột Thông tin sản phẩm
            System.Windows.Forms.DataGridViewTextBoxColumn colProductInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProductInfo.Name = "ProductInfo";
            colProductInfo.HeaderText = "Sản phẩm";
            colProductInfo.Width = 280;
            colProductInfo.ReadOnly = true;
            colProductInfo.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.Columns.Add(colProductInfo);

            // Cột Số lượng
            System.Windows.Forms.DataGridViewTextBoxColumn colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colQuantity.Name = "Quantity";
            colQuantity.HeaderText = "Số lượng";
            colQuantity.Width = 80;
            colQuantity.ReadOnly = true;
            colQuantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOrders.Columns.Add(colQuantity);

            // Cột Tổng tiền
            System.Windows.Forms.DataGridViewTextBoxColumn colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Tổng tiền";
            colTotal.Width = 120;
            colTotal.ReadOnly = true;
            colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvOrders.Columns.Add(colTotal);

            // Cột Trạng thái
            System.Windows.Forms.DataGridViewTextBoxColumn colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Width = 120;
            colStatus.ReadOnly = true;
            colStatus.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvOrders.Columns.Add(colStatus);

            // Cột Ngày đặt
            System.Windows.Forms.DataGridViewTextBoxColumn colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDate.Name = "OrderDate";
            colDate.HeaderText = "Ngày đặt";
            colDate.Width = 140;
            colDate.ReadOnly = true;
            this.dgvOrders.Columns.Add(colDate);

            // Cột Cập nhật trạng thái
            System.Windows.Forms.DataGridViewButtonColumn btnUpdateStatus = new System.Windows.Forms.DataGridViewButtonColumn();
            btnUpdateStatus.Name = "UpdateStatus";
            btnUpdateStatus.HeaderText = "Cập nhật";
            btnUpdateStatus.Text = "Cập nhật";
            btnUpdateStatus.UseColumnTextForButtonValue = true;
            btnUpdateStatus.Width = 90;
            btnUpdateStatus.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnUpdateStatus.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvOrders.Columns.Add(btnUpdateStatus);

            // Cột Xem chi tiết
            System.Windows.Forms.DataGridViewButtonColumn btnViewDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            btnViewDetail.Name = "ViewDetail";
            btnViewDetail.HeaderText = "Chi tiết";
            btnViewDetail.Text = "Xem";
            btnViewDetail.UseColumnTextForButtonValue = true;
            btnViewDetail.Width = 80;
            btnViewDetail.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnViewDetail.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvOrders.Columns.Add(btnViewDetail);

            // 
            // panelPagination
            // 
            this.panelPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPagination.Height = 50;
            this.panelPagination.FillColor = System.Drawing.Color.Transparent;
            this.panelPagination.Controls.Add(this.btnPrevPage);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNextPage);
            this.panelPagination.Location = new System.Drawing.Point(0, 550);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1100, 50);
            this.panelPagination.TabIndex = 3;

            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.Size = new System.Drawing.Size(40, 30);
            this.btnPrevPage.Location = new System.Drawing.Point(480, 10);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.BorderRadius = 5;
            this.btnPrevPage.Click += new System.EventHandler(this.BtnPrevPage_Click);

            // 
            // btnNextPage
            // 
            this.btnNextPage.Text = ">";
            this.btnNextPage.Size = new System.Drawing.Size(40, 30);
            this.btnNextPage.Location = new System.Drawing.Point(580, 10);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.BorderRadius = 5;
            this.btnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);

            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Text = "1 / 10";
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(530, 15);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(40, 13);
            this.lblPageInfo.TabIndex = 1;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // SellerOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelHeader);
            this.Name = "SellerOrderForm";
            this.Text = "Quản lý đơn hàng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SellerOrderForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}