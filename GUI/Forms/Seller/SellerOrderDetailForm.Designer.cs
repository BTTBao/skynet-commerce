// SellerOrderDetailForm.Designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerOrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Guna2Button btnClose;

        private Guna2Panel panelMain;

        // Khối 1: Thông tin đơn hàng và khách hàng
        private Guna2GroupBox grpOrderInfo;
        private Label lblOrderId;
        private Label lblOrderDate;
        private Label lblStatus;
        private Label lblReceiverName;
        private Label lblReceiverPhone;
        private Label lblAddress;

        // Khối 2: Thông tin sản phẩm
        private Guna2GroupBox grpProductInfo;
        private Guna2DataGridView dgvProducts;

        // Khối 3: Thông tin vận chuyển
        private Guna2GroupBox grpShippingInfo;
        private Label lblShipper;
        private Label lblTrackingCode;
        private Label lblShippingFee;
        private Label lblEstimatedDate;
        private Label lblShippingStatus;

        // Tổng tiền
        private Guna2Panel panelTotal;
        private Label lblTotalAmount;

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
            this.btnClose = new Guna2Button();
            this.panelMain = new Guna2Panel();
            this.grpOrderInfo = new Guna2GroupBox();
            this.lblOrderId = new Label();
            this.lblOrderDate = new Label();
            this.lblStatus = new Label();
            this.lblReceiverName = new Label();
            this.lblReceiverPhone = new Label();
            this.lblAddress = new Label();
            this.grpProductInfo = new Guna2GroupBox();
            this.dgvProducts = new Guna2DataGridView();
            this.grpShippingInfo = new Guna2GroupBox();
            this.lblShipper = new Label();
            this.lblTrackingCode = new Label();
            this.lblShippingFee = new Label();
            this.lblEstimatedDate = new Label();
            this.lblShippingStatus = new Label();
            this.panelTotal = new Guna2Panel();
            this.lblTotalAmount = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpOrderInfo.SuspendLayout();
            this.grpProductInfo.SuspendLayout();
            this.grpShippingInfo.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.FillColor = Color.FromArgb(31, 30, 68);
            this.panelHeader.Size = new Size(900, 70);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnClose);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Chi tiết đơn hàng";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 20);

            // 
            // btnClose
            // 
            this.btnClose.Text = "✕";
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Location = new Point(840, 15);
            this.btnClose.FillColor = Color.FromArgb(220, 53, 69);
            this.btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnClose.BorderRadius = 5;
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // 
            // panelMain
            // 
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.AutoScroll = true;
            this.panelMain.Padding = new Padding(20);
            this.panelMain.FillColor = Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.grpOrderInfo);
            this.panelMain.Controls.Add(this.grpProductInfo);
            this.panelMain.Controls.Add(this.grpShippingInfo);
            this.panelMain.Controls.Add(this.panelTotal);

            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Text = "Thông tin đơn hàng & Khách hàng";
            this.grpOrderInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpOrderInfo.ForeColor = Color.FromArgb(31, 30, 68);
            this.grpOrderInfo.Location = new Point(20, 20);
            this.grpOrderInfo.Size = new Size(840, 200);
            this.grpOrderInfo.BorderRadius = 10;
            this.grpOrderInfo.Controls.Add(this.lblOrderId);
            this.grpOrderInfo.Controls.Add(this.lblOrderDate);
            this.grpOrderInfo.Controls.Add(this.lblStatus);
            this.grpOrderInfo.Controls.Add(this.lblReceiverName);
            this.grpOrderInfo.Controls.Add(this.lblReceiverPhone);
            this.grpOrderInfo.Controls.Add(this.lblAddress);

            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new Point(15, 50);
            this.lblOrderId.Font = new Font("Segoe UI", 10F);
            this.lblOrderId.ForeColor = Color.Black;
            this.lblOrderId.Text = "Mã đơn hàng: ";

            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new Point(300, 50);
            this.lblOrderDate.Font = new Font("Segoe UI", 10F);
            this.lblOrderDate.ForeColor = Color.Black;
            this.lblOrderDate.Text = "Ngày đặt: ";

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(600, 50);
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatus.Text = "Trạng thái: ";

            // 
            // lblReceiverName
            // 
            this.lblReceiverName.AutoSize = true;
            this.lblReceiverName.Location = new Point(15, 85);
            this.lblReceiverName.Font = new Font("Segoe UI", 10F);
            this.lblReceiverName.ForeColor = Color.Black;
            this.lblReceiverName.Text = "Người nhận: ";

            // 
            // lblReceiverPhone
            // 
            this.lblReceiverPhone.AutoSize = true;
            this.lblReceiverPhone.Location = new Point(15, 115);
            this.lblReceiverPhone.Font = new Font("Segoe UI", 10F);
            this.lblReceiverPhone.ForeColor = Color.Black;
            this.lblReceiverPhone.Text = "Số điện thoại: ";

            // 
            // lblAddress
            // 
            this.lblAddress.Location = new Point(15, 145);
            this.lblAddress.Font = new Font("Segoe UI", 10F);
            this.lblAddress.ForeColor = Color.Black;
            this.lblAddress.Text = "Địa chỉ: ";
            this.lblAddress.Size = new Size(800, 40);

            // 
            // grpProductInfo
            // 
            this.grpProductInfo.Text = "Thông tin sản phẩm";
            this.grpProductInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpProductInfo.ForeColor = Color.FromArgb(31, 30, 68);
            this.grpProductInfo.Location = new Point(20, 240);
            this.grpProductInfo.Size = new Size(840, 280);
            this.grpProductInfo.BorderRadius = 10;
            this.grpProductInfo.Controls.Add(this.dgvProducts);

            // 
            // dgvProducts
            // 
            this.dgvProducts.Location = new Point(15, 50);
            this.dgvProducts.Size = new Size(810, 210);
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = Color.White;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.RowTemplate.Height = 50;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.BorderStyle = BorderStyle.None;

            // Cột Sản phẩm
            DataGridViewTextBoxColumn colProductName = new DataGridViewTextBoxColumn();
            colProductName.Name = "ProductName";
            colProductName.HeaderText = "Sản phẩm";
            colProductName.FillWeight = 35;
            this.dgvProducts.Columns.Add(colProductName);

            // Cột Phân loại
            DataGridViewTextBoxColumn colVariant = new DataGridViewTextBoxColumn();
            colVariant.Name = "Variant";
            colVariant.HeaderText = "Phân loại";
            colVariant.FillWeight = 25;
            this.dgvProducts.Columns.Add(colVariant);

            // Cột Số lượng
            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn();
            colQuantity.Name = "Quantity";
            colQuantity.HeaderText = "Số lượng";
            colQuantity.FillWeight = 15;
            colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvProducts.Columns.Add(colQuantity);

            // Cột Đơn giá
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.Name = "Price";
            colPrice.HeaderText = "Đơn giá";
            colPrice.FillWeight = 20;
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvProducts.Columns.Add(colPrice);

            // Cột Thành tiền
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Thành tiền";
            colTotal.FillWeight = 20;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvProducts.Columns.Add(colTotal);

            // 
            // grpShippingInfo
            // 
            this.grpShippingInfo.Text = "Thông tin vận chuyển";
            this.grpShippingInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpShippingInfo.ForeColor = Color.FromArgb(31, 30, 68);
            this.grpShippingInfo.Location = new Point(20, 540);
            this.grpShippingInfo.Size = new Size(840, 180);
            this.grpShippingInfo.BorderRadius = 10;
            this.grpShippingInfo.Controls.Add(this.lblShipper);
            this.grpShippingInfo.Controls.Add(this.lblTrackingCode);
            this.grpShippingInfo.Controls.Add(this.lblShippingFee);
            this.grpShippingInfo.Controls.Add(this.lblEstimatedDate);
            this.grpShippingInfo.Controls.Add(this.lblShippingStatus);

            // 
            // lblShipper
            // 
            this.lblShipper.AutoSize = true;
            this.lblShipper.Location = new Point(15, 50);
            this.lblShipper.Font = new Font("Segoe UI", 10F);
            this.lblShipper.ForeColor = Color.Black;
            this.lblShipper.Text = "Đơn vị vận chuyển: ";

            // 
            // lblTrackingCode
            // 
            this.lblTrackingCode.AutoSize = true;
            this.lblTrackingCode.Location = new Point(15, 80);
            this.lblTrackingCode.Font = new Font("Segoe UI", 10F);
            this.lblTrackingCode.ForeColor = Color.Black;
            this.lblTrackingCode.Text = "Mã vận đơn: ";

            // 
            // lblShippingFee
            // 
            this.lblShippingFee.AutoSize = true;
            this.lblShippingFee.Location = new Point(15, 110);
            this.lblShippingFee.Font = new Font("Segoe UI", 10F);
            this.lblShippingFee.ForeColor = Color.Black;
            this.lblShippingFee.Text = "Phí vận chuyển: ";

            // 
            // lblEstimatedDate
            // 
            this.lblEstimatedDate.AutoSize = true;
            this.lblEstimatedDate.Location = new Point(450, 50);
            this.lblEstimatedDate.Font = new Font("Segoe UI", 10F);
            this.lblEstimatedDate.ForeColor = Color.Black;
            this.lblEstimatedDate.Text = "Dự kiến giao: ";

            // 
            // lblShippingStatus
            // 
            this.lblShippingStatus.AutoSize = true;
            this.lblShippingStatus.Location = new Point(450, 80);
            this.lblShippingStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblShippingStatus.Text = "Trạng thái: ";

            // 
            // panelTotal
            // 
            this.panelTotal.Location = new Point(20, 740);
            this.panelTotal.Size = new Size(840, 60);
            this.panelTotal.FillColor = Color.FromArgb(31, 30, 68);
            this.panelTotal.BorderRadius = 10;
            this.panelTotal.Controls.Add(this.lblTotalAmount);

            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Text = "Tổng cộng: 0 VNĐ";
            this.lblTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.White;
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new Point(20, 18);

            // 
            // SellerOrderDetailForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Name = "SellerOrderDetailForm";
            this.Text = "Chi tiết đơn hàng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += new EventHandler(this.SellerOrderDetailForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            this.grpProductInfo.ResumeLayout(false);
            this.grpShippingInfo.ResumeLayout(false);
            this.grpShippingInfo.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}