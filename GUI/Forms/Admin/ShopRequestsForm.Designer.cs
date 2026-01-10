namespace Skynet_Commerce.GUI.Forms
{
    partial class ShopRequestsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._lblTitle = new System.Windows.Forms.Label();
            this._mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this._dgvPending = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colP_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this._mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPending)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.Black;
            this._lblTitle.Location = new System.Drawing.Point(20, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(238, 25);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "Duyệt Đăng Ký Cửa Hàng";
            // 
            // _mainPanel
            // 
            this._mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainPanel.BackColor = System.Drawing.Color.Transparent;
            this._mainPanel.BorderRadius = 12;
            this._mainPanel.Controls.Add(this._dgvPending);
            this._mainPanel.FillColor = System.Drawing.Color.White;
            this._mainPanel.Location = new System.Drawing.Point(25, 60);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.ShadowDecoration.Depth = 5;
            this._mainPanel.ShadowDecoration.Enabled = true;
            this._mainPanel.Size = new System.Drawing.Size(1015, 620);
            this._mainPanel.TabIndex = 1;
            // 
            // _dgvPending
            // 
            this._dgvPending.AllowUserToAddRows = false;
            this._dgvPending.AllowUserToDeleteRows = false;
            this._dgvPending.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._dgvPending.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._dgvPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this._dgvPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._dgvPending.ColumnHeadersHeight = 40;
            this._dgvPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colP_Id,
            this.colP_Name,
            this.colP_Owner,
            this.colP_Email,
            this.colP_Date,
            this.colP_Action});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgvPending.DefaultCellStyle = dataGridViewCellStyle3;
            this._dgvPending.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvPending.Location = new System.Drawing.Point(20, 20);
            this._dgvPending.MultiSelect = false;
            this._dgvPending.Name = "_dgvPending";
            this._dgvPending.ReadOnly = true;
            this._dgvPending.RowHeadersVisible = false;
            this._dgvPending.RowTemplate.Height = 45;
            this._dgvPending.Size = new System.Drawing.Size(975, 580);
            this._dgvPending.TabIndex = 0;
            this._dgvPending.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvPending.ThemeStyle.AlternatingRowsStyle.Font = null;
            this._dgvPending.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this._dgvPending.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this._dgvPending.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this._dgvPending.ThemeStyle.BackColor = System.Drawing.Color.White;
            this._dgvPending.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvPending.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this._dgvPending.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._dgvPending.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dgvPending.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this._dgvPending.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dgvPending.ThemeStyle.HeaderStyle.Height = 40;
            this._dgvPending.ThemeStyle.ReadOnly = true;
            this._dgvPending.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this._dgvPending.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dgvPending.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dgvPending.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this._dgvPending.ThemeStyle.RowsStyle.Height = 45;
            this._dgvPending.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this._dgvPending.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colP_Id
            // 
            this.colP_Id.DataPropertyName = "RegistrationID";
            this.colP_Id.FillWeight = 30F;
            this.colP_Id.HeaderText = "ID";
            this.colP_Id.Name = "colP_Id";
            this.colP_Id.ReadOnly = true;
            // 
            // colP_Name
            // 
            this.colP_Name.DataPropertyName = "ShopName";
            this.colP_Name.HeaderText = "TÊN SHOP";
            this.colP_Name.Name = "colP_Name";
            this.colP_Name.ReadOnly = true;
            // 
            // colP_Owner
            // 
            this.colP_Owner.DataPropertyName = "OwnerName";
            this.colP_Owner.HeaderText = "CHỦ SỞ HỮU";
            this.colP_Owner.Name = "colP_Owner";
            this.colP_Owner.ReadOnly = true;
            // 
            // colP_Email
            // 
            this.colP_Email.DataPropertyName = "Email";
            this.colP_Email.HeaderText = "EMAIL";
            this.colP_Email.Name = "colP_Email";
            this.colP_Email.ReadOnly = true;
            // 
            // colP_Date
            // 
            this.colP_Date.DataPropertyName = "RequestDate";
            this.colP_Date.HeaderText = "NGÀY GỬI";
            this.colP_Date.Name = "colP_Date";
            this.colP_Date.ReadOnly = true;
            // 
            // colP_Action
            // 
            this.colP_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colP_Action.HeaderText = "XỬ LÝ";
            this.colP_Action.Name = "colP_Action";
            this.colP_Action.ReadOnly = true;
            this.colP_Action.Text = "•••";
            this.colP_Action.UseColumnTextForButtonValue = true;
            // 
            // ShopRequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1066, 710);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopRequestsForm";
            this.Text = "ShopRequestsForm";
            this.Load += new System.EventHandler(this.ShopRequestsForm_Load);
            this._mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvPending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblTitle;
        private Guna.UI2.WinForms.Guna2Panel _mainPanel;
        private Guna.UI2.WinForms.Guna2DataGridView _dgvPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_Date;
        private System.Windows.Forms.DataGridViewButtonColumn colP_Action;
    }
}