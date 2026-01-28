namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    partial class SellerInfoForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.lblShopID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangeCitizenImage = new Guna.UI2.WinForms.Guna2Button();
            this.pbCitizenImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblCitizenLabel = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.txtShopName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblShopNameLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.btnChangeAvatar = new Guna.UI2.WinForms.Guna2Button();
            this.pbShopAvatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnChangeCover = new Guna.UI2.WinForms.Guna2Button();
            this.pbShopCover = new Guna.UI2.WinForms.Guna2PictureBox();
            this.toggleIsActive = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCitizenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblAccountID);
            this.panelHeader.Controls.Add(this.lblShopID);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1094, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccountID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblAccountID.Location = new System.Drawing.Point(200, 55);
            this.lblAccountID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(107, 20);
            this.lblAccountID.TabIndex = 2;
            this.lblAccountID.Text = "Account ID: ---";
            // 
            // lblShopID
            // 
            this.lblShopID.AutoSize = true;
            this.lblShopID.BackColor = System.Drawing.Color.Transparent;
            this.lblShopID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShopID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblShopID.Location = new System.Drawing.Point(27, 55);
            this.lblShopID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShopID.Name = "lblShopID";
            this.lblShopID.Size = new System.Drawing.Size(87, 20);
            this.lblShopID.TabIndex = 1;
            this.lblShopID.Text = "Shop ID: ---";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(318, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN CỬA HÀNG";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.btnSave);
            this.panelContent.Controls.Add(this.btnCancel);
            this.panelContent.Controls.Add(this.btnEdit);
            this.panelContent.Controls.Add(this.btnChangeCitizenImage);
            this.panelContent.Controls.Add(this.pbCitizenImage);
            this.panelContent.Controls.Add(this.lblCitizenLabel);
            this.panelContent.Controls.Add(this.txtAddress);
            this.panelContent.Controls.Add(this.lblAddressLabel);
            this.panelContent.Controls.Add(this.txtPhone);
            this.panelContent.Controls.Add(this.lblPhoneLabel);
            this.panelContent.Controls.Add(this.txtEmail);
            this.panelContent.Controls.Add(this.lblEmailLabel);
            this.panelContent.Controls.Add(this.txtDescription);
            this.panelContent.Controls.Add(this.lblDescriptionLabel);
            this.panelContent.Controls.Add(this.txtShopName);
            this.panelContent.Controls.Add(this.lblShopNameLabel);
            this.panelContent.Controls.Add(this.lblStatus);
            this.panelContent.Controls.Add(this.toggleIsActive);
            this.panelContent.Controls.Add(this.lblStatusLabel);
            this.panelContent.Controls.Add(this.lblCreatedAt);
            this.panelContent.Controls.Add(this.lblRating);
            this.panelContent.Controls.Add(this.btnChangeAvatar);
            this.panelContent.Controls.Add(this.pbShopAvatar);
            this.panelContent.Controls.Add(this.btnChangeCover);
            this.panelContent.Controls.Add(this.pbShopCover);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.FillColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(0, 86);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelContent.Size = new System.Drawing.Size(1094, 734);
            this.panelContent.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(606, 681);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 52);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(409, 681);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 52);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 6;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(173, 681);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 52);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnChangeCitizenImage
            // 
            this.btnChangeCitizenImage.BorderRadius = 5;
            this.btnChangeCitizenImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeCitizenImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeCitizenImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeCitizenImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeCitizenImage.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnChangeCitizenImage.ForeColor = System.Drawing.Color.White;
            this.btnChangeCitizenImage.Location = new System.Drawing.Point(798, 595);
            this.btnChangeCitizenImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeCitizenImage.Name = "btnChangeCitizenImage";
            this.btnChangeCitizenImage.Size = new System.Drawing.Size(160, 39);
            this.btnChangeCitizenImage.TabIndex = 22;
            this.btnChangeCitizenImage.Text = "Đổi ảnh CCCD";
            this.btnChangeCitizenImage.Visible = false;
            this.btnChangeCitizenImage.Click += new System.EventHandler(this.BtnChangeCitizenImage_Click);
            // 
            // pbCitizenImage
            // 
            this.pbCitizenImage.BorderRadius = 8;
            this.pbCitizenImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pbCitizenImage.ImageRotate = 0F;
            this.pbCitizenImage.Location = new System.Drawing.Point(672, 347);
            this.pbCitizenImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbCitizenImage.Name = "pbCitizenImage";
            this.pbCitizenImage.Size = new System.Drawing.Size(362, 215);
            this.pbCitizenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCitizenImage.TabIndex = 21;
            this.pbCitizenImage.TabStop = false;
            // 
            // lblCitizenLabel
            // 
            this.lblCitizenLabel.AutoSize = true;
            this.lblCitizenLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCitizenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCitizenLabel.Location = new System.Drawing.Point(668, 311);
            this.lblCitizenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCitizenLabel.Name = "lblCitizenLabel";
            this.lblCitizenLabel.Size = new System.Drawing.Size(194, 21);
            this.lblCitizenLabel.TabIndex = 20;
            this.lblCitizenLabel.Text = "Ảnh Căn cước công dân:";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(63, 621);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(601, 44);
            this.txtAddress.TabIndex = 19;
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAddressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddressLabel.Location = new System.Drawing.Point(59, 595);
            this.lblAddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(137, 21);
            this.lblAddressLabel.TabIndex = 18;
            this.lblAddressLabel.Text = "Địa chỉ lấy hàng:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(371, 532);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(216, 44);
            this.txtPhone.TabIndex = 17;
            // 
            // lblPhoneLabel
            // 
            this.lblPhoneLabel.AutoSize = true;
            this.lblPhoneLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhoneLabel.Location = new System.Drawing.Point(367, 506);
            this.lblPhoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneLabel.Name = "lblPhoneLabel";
            this.lblPhoneLabel.Size = new System.Drawing.Size(115, 21);
            this.lblPhoneLabel.TabIndex = 16;
            this.lblPhoneLabel.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(63, 532);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(282, 44);
            this.txtEmail.TabIndex = 15;
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.AutoSize = true;
            this.lblEmailLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmailLabel.Location = new System.Drawing.Point(63, 506);
            this.lblEmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(113, 21);
            this.lblEmailLabel.TabIndex = 14;
            this.lblEmailLabel.Text = "Email liên hệ:";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(63, 429);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(533, 53);
            this.txtDescription.TabIndex = 13;
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescriptionLabel.Location = new System.Drawing.Point(63, 403);
            this.lblDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(133, 21);
            this.lblDescriptionLabel.TabIndex = 12;
            this.lblDescriptionLabel.Text = "Mô tả cửa hàng:";
            // 
            // txtShopName
            // 
            this.txtShopName.BorderRadius = 5;
            this.txtShopName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShopName.DefaultText = "";
            this.txtShopName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtShopName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtShopName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtShopName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtShopName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtShopName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtShopName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtShopName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtShopName.Location = new System.Drawing.Point(63, 337);
            this.txtShopName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.PlaceholderText = "";
            this.txtShopName.ReadOnly = true;
            this.txtShopName.SelectedText = "";
            this.txtShopName.Size = new System.Drawing.Size(533, 44);
            this.txtShopName.TabIndex = 11;
            // 
            // lblShopNameLabel
            // 
            this.lblShopNameLabel.AutoSize = true;
            this.lblShopNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblShopNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShopNameLabel.Location = new System.Drawing.Point(63, 311);
            this.lblShopNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShopNameLabel.Name = "lblShopNameLabel";
            this.lblShopNameLabel.Size = new System.Drawing.Size(116, 21);
            this.lblShopNameLabel.TabIndex = 10;
            this.lblShopNameLabel.Text = "Tên cửa hàng:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(496, 249);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Đang hoạt động";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.Location = new System.Drawing.Point(272, 249);
            this.lblStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(160, 20);
            this.lblStatusLabel.TabIndex = 7;
            this.lblStatusLabel.Text = "Trạng thái hoạt động:";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreatedAt.ForeColor = System.Drawing.Color.Gray;
            this.lblCreatedAt.Location = new System.Drawing.Point(400, 203);
            this.lblCreatedAt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(82, 20);
            this.lblCreatedAt.TabIndex = 6;
            this.lblCreatedAt.Text = "Tạo lúc: ---";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRating.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblRating.Location = new System.Drawing.Point(271, 199);
            this.lblRating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(74, 25);
            this.lblRating.TabIndex = 5;
            this.lblRating.Text = "0.0/5.0";
            // 
            // btnChangeAvatar
            // 
            this.btnChangeAvatar.BorderRadius = 5;
            this.btnChangeAvatar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAvatar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAvatar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeAvatar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnChangeAvatar.ForeColor = System.Drawing.Color.White;
            this.btnChangeAvatar.Location = new System.Drawing.Point(67, 245);
            this.btnChangeAvatar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeAvatar.Name = "btnChangeAvatar";
            this.btnChangeAvatar.Size = new System.Drawing.Size(147, 37);
            this.btnChangeAvatar.TabIndex = 3;
            this.btnChangeAvatar.Text = "Đổi Avatar";
            this.btnChangeAvatar.Visible = false;
            this.btnChangeAvatar.Click += new System.EventHandler(this.BtnChangeAvatar_Click);
            // 
            // pbShopAvatar
            // 
            this.pbShopAvatar.BorderRadius = 75;
            this.pbShopAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShopAvatar.FillColor = System.Drawing.Color.LightGray;
            this.pbShopAvatar.ImageRotate = 0F;
            this.pbShopAvatar.Location = new System.Drawing.Point(71, 66);
            this.pbShopAvatar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbShopAvatar.Name = "pbShopAvatar";
            this.pbShopAvatar.Size = new System.Drawing.Size(165, 158);
            this.pbShopAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShopAvatar.TabIndex = 2;
            this.pbShopAvatar.TabStop = false;
            // 
            // btnChangeCover
            // 
            this.btnChangeCover.BorderRadius = 5;
            this.btnChangeCover.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeCover.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeCover.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeCover.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeCover.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnChangeCover.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangeCover.ForeColor = System.Drawing.Color.White;
            this.btnChangeCover.Location = new System.Drawing.Point(834, 120);
            this.btnChangeCover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeCover.Name = "btnChangeCover";
            this.btnChangeCover.Size = new System.Drawing.Size(160, 43);
            this.btnChangeCover.TabIndex = 1;
            this.btnChangeCover.Text = "Đổi ảnh bìa";
            this.btnChangeCover.Visible = false;
            this.btnChangeCover.Click += new System.EventHandler(this.BtnChangeCover_Click);
            // 
            // pbShopCover
            // 
            this.pbShopCover.BorderRadius = 10;
            this.pbShopCover.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pbShopCover.ImageRotate = 0F;
            this.pbShopCover.Location = new System.Drawing.Point(40, 8);
            this.pbShopCover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbShopCover.Name = "pbShopCover";
            this.pbShopCover.Size = new System.Drawing.Size(954, 155);
            this.pbShopCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShopCover.TabIndex = 0;
            this.pbShopCover.TabStop = false;
            // 
            // toggleIsActive
            // 
            this.toggleIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleIsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.toggleIsActive.Enabled = false;
            this.toggleIsActive.Location = new System.Drawing.Point(672, 199);
            this.toggleIsActive.Margin = new System.Windows.Forms.Padding(4);
            this.toggleIsActive.Name = "toggleIsActive";
            this.toggleIsActive.Size = new System.Drawing.Size(67, 31);
            this.toggleIsActive.TabIndex = 8;
            this.toggleIsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.toggleIsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.toggleIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.toggleIsActive.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // SellerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 820);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SellerInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin Cửa hàng - Skynet";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCitizenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShopCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label lblShopID;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnChangeCitizenImage;
        private Guna.UI2.WinForms.Guna2PictureBox pbCitizenImage;
        private System.Windows.Forms.Label lblCitizenLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblAddressLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblEmailLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtShopName;
        private System.Windows.Forms.Label lblShopNameLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblRating;
        private Guna.UI2.WinForms.Guna2Button btnChangeAvatar;
        private Guna.UI2.WinForms.Guna2PictureBox pbShopAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChangeCover;
        private Guna.UI2.WinForms.Guna2PictureBox pbShopCover;
        private Guna.UI2.WinForms.Guna2ToggleSwitch toggleIsActive;
    }
}