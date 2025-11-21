namespace Skynet_Commerce.GUI.Forms
{
    partial class OrderDetailForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this._btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this._lblTitle = new System.Windows.Forms.Label();
            this._pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this._lblStatusVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._lblTotalVal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblDateVal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblBuyerVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._gridItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnOK = new Guna.UI2.WinForms.Guna2Button();
            this._pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridItems)).BeginInit();
            this.SuspendLayout();
            // 
            // _dragControl
            // 
            this._dragControl.TargetControl = this;
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.FillColor = System.Drawing.Color.Transparent;
            this._btnClose.IconColor = System.Drawing.Color.Gray;
            this._btnClose.Location = new System.Drawing.Point(548, 12);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(40, 29);
            this._btnClose.TabIndex = 0;
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.Location = new System.Drawing.Point(24, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(169, 25);
            this._lblTitle.TabIndex = 1;
            this._lblTitle.Text = "Chi tiết đơn hàng";
            // 
            // _pnlInfo
            // 
            this._pnlInfo.BackColor = System.Drawing.Color.Transparent;
            this._pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._pnlInfo.BorderRadius = 8;
            this._pnlInfo.BorderThickness = 1;
            this._pnlInfo.Controls.Add(this._lblStatusVal);
            this._pnlInfo.Controls.Add(this.label6);
            this._pnlInfo.Controls.Add(this._lblTotalVal);
            this._pnlInfo.Controls.Add(this.label4);
            this._pnlInfo.Controls.Add(this._lblDateVal);
            this._pnlInfo.Controls.Add(this.label2);
            this._pnlInfo.Controls.Add(this._lblBuyerVal);
            this._pnlInfo.Controls.Add(this.label1);
            this._pnlInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this._pnlInfo.Location = new System.Drawing.Point(29, 60);
            this._pnlInfo.Name = "_pnlInfo";
            this._pnlInfo.Size = new System.Drawing.Size(543, 110);
            this._pnlInfo.TabIndex = 2;
            // 
            // _lblStatusVal
            // 
            this._lblStatusVal.AutoSize = true;
            this._lblStatusVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblStatusVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._lblStatusVal.Location = new System.Drawing.Point(380, 65);
            this._lblStatusVal.Name = "_lblStatusVal";
            this._lblStatusVal.Size = new System.Drawing.Size(69, 15);
            this._lblStatusVal.TabIndex = 7;
            this._lblStatusVal.Text = "Completed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(300, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trạng thái:";
            // 
            // _lblTotalVal
            // 
            this._lblTotalVal.AutoSize = true;
            this._lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this._lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this._lblTotalVal.Location = new System.Drawing.Point(380, 20);
            this._lblTotalVal.Name = "_lblTotalVal";
            this._lblTotalVal.Size = new System.Drawing.Size(92, 20);
            this._lblTotalVal.TabIndex = 5;
            this._lblTotalVal.Text = "1,200,000 đ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(300, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng tiền:";
            // 
            // _lblDateVal
            // 
            this._lblDateVal.AutoSize = true;
            this._lblDateVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblDateVal.Location = new System.Drawing.Point(100, 65);
            this._lblDateVal.Name = "_lblDateVal";
            this._lblDateVal.Size = new System.Drawing.Size(73, 15);
            this._lblDateVal.TabIndex = 3;
            this._lblDateVal.Text = "20/11/2025";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày đặt:";
            // 
            // _lblBuyerVal
            // 
            this._lblBuyerVal.AutoSize = true;
            this._lblBuyerVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._lblBuyerVal.Location = new System.Drawing.Point(100, 24);
            this._lblBuyerVal.Name = "_lblBuyerVal";
            this._lblBuyerVal.Size = new System.Drawing.Size(84, 15);
            this._lblBuyerVal.TabIndex = 1;
            this._lblBuyerVal.Text = "Nguyen Van A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người mua:";
            // 
            // _gridItems
            // 
            this._gridItems.AllowUserToAddRows = false;
            this._gridItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._gridItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._gridItems.ColumnHeadersHeight = 35;
            this._gridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this._gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduct,
            this.colQty,
            this.colPrice,
            this.colSubTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridItems.DefaultCellStyle = dataGridViewCellStyle3;
            this._gridItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.Location = new System.Drawing.Point(29, 190);
            this._gridItems.Name = "_gridItems";
            this._gridItems.ReadOnly = true;
            this._gridItems.RowHeadersVisible = false;
            this._gridItems.RowTemplate.Height = 30;
            this._gridItems.Size = new System.Drawing.Size(543, 200);
            this._gridItems.TabIndex = 3;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._gridItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._gridItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this._gridItems.ThemeStyle.HeaderStyle.Height = 35;
            this._gridItems.ThemeStyle.ReadOnly = true;
            this._gridItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._gridItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._gridItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._gridItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._gridItems.ThemeStyle.RowsStyle.Height = 30;
            this._gridItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._gridItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "Sản phẩm";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "SL";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colSubTotal
            // 
            this.colSubTotal.HeaderText = "Thành tiền";
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.ReadOnly = true;
            // 
            // _btnOK
            // 
            this._btnOK.BorderRadius = 6;
            this._btnOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this._btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnOK.ForeColor = System.Drawing.Color.White;
            this._btnOK.Location = new System.Drawing.Point(432, 410);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(140, 36);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "Đóng";
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 470);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._gridItems);
            this.Controls.Add(this._pnlInfo);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "OrderDetailForm";
            this.Text = "OrderDetailForm";
            this._pnlInfo.ResumeLayout(false);
            this._pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl _dragControl;
        private Guna.UI2.WinForms.Guna2ControlBox _btnClose;
        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2Panel _pnlInfo;
        private System.Windows.Forms.Label _lblBuyerVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblDateVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblTotalVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblStatusVal;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DataGridView _gridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private Guna.UI2.WinForms.Guna2Button _btnOK;
    }
}