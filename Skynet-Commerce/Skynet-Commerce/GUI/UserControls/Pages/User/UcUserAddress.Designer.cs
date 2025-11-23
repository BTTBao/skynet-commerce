namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    partial class UcUserAddress
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.flowPanelAddresses = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAddAddress = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtAddressLine = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtWard = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDistrict = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProvince = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlAddAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.ColumnCount = 1;
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContainer.Controls.Add(this.pnlHeader, 0, 0);
            this.pnlContainer.Controls.Add(this.flowPanelAddresses, 0, 1);
            this.pnlContainer.Controls.Add(this.pnlAddAddress, 0, 2);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RowCount = 3;
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.pnlContainer.Size = new System.Drawing.Size(1000, 700);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(994, 54);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.Location = new System.Drawing.Point(150, 10);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(147, 37);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "Sổ Địa Chỉ";
            // 
            // flowPanelAddresses
            // 
            this.flowPanelAddresses.AutoScroll = true;
            this.flowPanelAddresses.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelAddresses.Location = new System.Drawing.Point(3, 63);
            this.flowPanelAddresses.Name = "flowPanelAddresses";
            this.flowPanelAddresses.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelAddresses.Size = new System.Drawing.Size(994, 354);
            this.flowPanelAddresses.TabIndex = 0;
            // 
            // pnlAddAddress
            // 
            this.pnlAddAddress.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddAddress.BorderRadius = 10;
            this.pnlAddAddress.Controls.Add(this.btnBack);
            this.pnlAddAddress.Controls.Add(this.lblAddTitle);
            this.pnlAddAddress.Controls.Add(this.btnAdd);
            this.pnlAddAddress.Controls.Add(this.txtAddressLine);
            this.pnlAddAddress.Controls.Add(this.txtWard);
            this.pnlAddAddress.Controls.Add(this.txtDistrict);
            this.pnlAddAddress.Controls.Add(this.txtProvince);
            this.pnlAddAddress.Controls.Add(this.txtPhone);
            this.pnlAddAddress.Controls.Add(this.txtName);
            this.pnlAddAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddAddress.FillColor = System.Drawing.Color.White;
            this.pnlAddAddress.Location = new System.Drawing.Point(3, 423);
            this.pnlAddAddress.Name = "pnlAddAddress";
            this.pnlAddAddress.ShadowDecoration.Enabled = true;
            this.pnlAddAddress.Size = new System.Drawing.Size(994, 274);
            this.pnlAddAddress.TabIndex = 1;
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAddTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(178, 28);
            this.lblAddTitle.TabIndex = 7;
            this.lblAddTitle.Text = "Thêm địa chỉ mới";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.FillColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(25, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Lưu địa chỉ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAddressLine
            // 
            this.txtAddressLine.BorderRadius = 5;
            this.txtAddressLine.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressLine.DefaultText = "";
            this.txtAddressLine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddressLine.Location = new System.Drawing.Point(25, 160);
            this.txtAddressLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddressLine.Name = "txtAddressLine";
            this.txtAddressLine.PlaceholderText = "Địa chỉ cụ thể (Số nhà, tên đường...)";
            this.txtAddressLine.SelectedText = "";
            this.txtAddressLine.Size = new System.Drawing.Size(630, 40);
            this.txtAddressLine.TabIndex = 5;
            // 
            // txtWard
            // 
            this.txtWard.BorderRadius = 5;
            this.txtWard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWard.DefaultText = "";
            this.txtWard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWard.Location = new System.Drawing.Point(455, 110);
            this.txtWard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWard.Name = "txtWard";
            this.txtWard.PlaceholderText = "Phường / Xã";
            this.txtWard.SelectedText = "";
            this.txtWard.Size = new System.Drawing.Size(200, 40);
            this.txtWard.TabIndex = 4;
            // 
            // txtDistrict
            // 
            this.txtDistrict.BorderRadius = 5;
            this.txtDistrict.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistrict.DefaultText = "";
            this.txtDistrict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDistrict.Location = new System.Drawing.Point(240, 110);
            this.txtDistrict.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.PlaceholderText = "Quận / Huyện";
            this.txtDistrict.SelectedText = "";
            this.txtDistrict.Size = new System.Drawing.Size(200, 40);
            this.txtDistrict.TabIndex = 3;
            // 
            // txtProvince
            // 
            this.txtProvince.BorderRadius = 5;
            this.txtProvince.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProvince.DefaultText = "";
            this.txtProvince.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProvince.Location = new System.Drawing.Point(25, 110);
            this.txtProvince.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.PlaceholderText = "Tỉnh / Thành phố";
            this.txtProvince.SelectedText = "";
            this.txtProvince.Size = new System.Drawing.Size(200, 40);
            this.txtProvince.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(340, 60);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Số điện thoại";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(300, 40);
            this.txtPhone.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(25, 60);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Họ tên người nhận";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(300, 40);
            this.txtName.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 5;
            this.btnBack.FillColor = System.Drawing.Color.Black;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(211, 210);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Quay lại";
            // 
            // UcUserAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "UcUserAddress";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAddAddress.ResumeLayout(false);
            this.pnlAddAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlContainer;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.FlowLayoutPanel flowPanelAddresses;
        private Guna.UI2.WinForms.Guna2Panel pnlAddAddress;
        private System.Windows.Forms.Label lblAddTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtProvince;
        private Guna.UI2.WinForms.Guna2TextBox txtDistrict;
        private Guna.UI2.WinForms.Guna2TextBox txtWard;
        private Guna.UI2.WinForms.Guna2TextBox txtAddressLine;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}