using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerInfoForm : Form
    {
        private Guna2Panel panelHeader, panelContent;
        private Label lblTitle;
        private Guna2PictureBox pbShopLogo;
        private Guna2TextBox txtShopName, txtDescription, txtEmail, txtPhone, txtAddress, txtReturnPolicy, txtShippingPolicy;
        private Label lblRating, lblFollowers;
        private Guna2Button btnEdit, btnSave, btnChangeLogo;
        private Guna2RatingStar ratingStar;


        private void LoadDummyData()
        {
            txtShopName.Text = "Skynet Official Store";
            txtDescription.Text = "Chuyên cung cấp linh kiện công nghệ hàng đầu Việt Nam.";
            txtEmail.Text = "support@skynet.com";
            txtPhone.Text = "0123.456.789";
            txtAddress.Text = "Khu Công Nghệ Cao, Quận 9, TP. HCM";
            txtReturnPolicy.Text = "Đổi trả miễn phí trong vòng 7 ngày nếu có lỗi từ nhà sản xuất.";
            txtShippingPolicy.Text = "Miễn phí vận chuyển cho đơn hàng từ 500k.";
            lblRating.Text = "4.9/5.0";
            lblFollowers.Text = "12.5k Người theo dõi";
            ratingStar.Value = 4.8F;
        }

        private void SetFieldsEditable(bool editable)
        {
            txtShopName.ReadOnly = txtDescription.ReadOnly = txtEmail.ReadOnly =
            txtPhone.ReadOnly = txtAddress.ReadOnly = txtReturnPolicy.ReadOnly =
            txtShippingPolicy.ReadOnly = !editable;

            btnChangeLogo.Visible = editable;
            btnSave.Enabled = editable;

            Color activeColor = editable ? Color.White : Color.FromArgb(245, 245, 245);
            txtShopName.FillColor = txtDescription.FillColor = txtEmail.FillColor =
            txtPhone.FillColor = txtAddress.FillColor = txtReturnPolicy.FillColor =
            txtShippingPolicy.FillColor = activeColor;
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Guna2Panel();
            this.panelContent = new Guna2Panel();
            this.lblTitle = new Label();

            // Header
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.FillColor = Color.FromArgb(31, 30, 68);
            this.panelHeader.Height = 60;
            this.lblTitle.Text = "THÔNG TIN CỬA HÀNG";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.AutoSize = true;
            this.panelHeader.Controls.Add(lblTitle);

            // Content Container
            this.panelContent.Dock = DockStyle.Fill;
            this.panelContent.FillColor = Color.White;
            this.panelContent.AutoScroll = true;

            // 1. KHU VỰC LOGO & CHỈ SỐ (Bên trái)
            pbShopLogo = new Guna2PictureBox();
            pbShopLogo.Size = new Size(130, 130);
            pbShopLogo.Location = new Point(40, 30);
            pbShopLogo.BorderRadius = 65;
            pbShopLogo.FillColor = Color.LightGray;
            pbShopLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.panelContent.Controls.Add(pbShopLogo);

            btnChangeLogo = new Guna2Button { Text = "Đổi Logo", Size = new Size(100, 30), Location = new Point(55, 170), BorderRadius = 5 };
            this.panelContent.Controls.Add(btnChangeLogo);

            ratingStar = new Guna2RatingStar { Location = new Point(45, 220), Size = new Size(120, 25), ReadOnly = true };
            this.panelContent.Controls.Add(ratingStar);

            lblRating = new Label { Location = new Point(45, 250), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.OrangeRed };
            lblFollowers = new Label { Location = new Point(45, 275), AutoSize = true, Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray };
            this.panelContent.Controls.Add(lblRating);
            this.panelContent.Controls.Add(lblFollowers);

            // 2. KHU VỰC NHẬP LIỆU (Bên phải)
            int startX = 220;
            txtShopName = CreateField("Tên hiển thị Shop:", startX, 30, 500);
            txtDescription = CreateField("Mô tả ngắn:", startX, 100, 500);
            txtDescription.Multiline = true;
            txtDescription.Height = 60;

            txtEmail = CreateField("Email liên hệ:", startX, 190, 240);
            txtPhone = CreateField("Số điện thoại:", startX + 260, 190, 240);

            txtAddress = CreateField("Địa chỉ lấy hàng:", startX, 260, 500);

            // CHÍNH SÁCH
            txtReturnPolicy = CreateField("Chính sách đổi trả:", startX, 330, 500);
            txtReturnPolicy.Multiline = true;
            txtReturnPolicy.Height = 50;

            txtShippingPolicy = CreateField("Chính sách vận chuyển:", startX, 410, 500);
            txtShippingPolicy.Multiline = true;
            txtShippingPolicy.Height = 50;

            // 3. NÚT BẤM
            btnEdit = new Guna2Button { Text = "Chỉnh sửa", Location = new Point(480, 500), Size = new Size(110, 40), FillColor = Color.FromArgb(31, 30, 68), BorderRadius = 5 };
            btnEdit.Click += (s, e) => SetFieldsEditable(true);

            btnSave = new Guna2Button { Text = "Lưu thay đổi", Location = new Point(610, 500), Size = new Size(110, 40), FillColor = Color.MediumSeaGreen, BorderRadius = 5 };
            btnSave.Click += btnSave_Click;

            this.panelContent.Controls.Add(btnEdit);
            this.panelContent.Controls.Add(btnSave);

            // Form Main Settings
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(panelContent);
            this.Controls.Add(panelHeader);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ Shop - Skynet";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu đã được lưu hệ thống!", "Thành công");
            SetFieldsEditable(false);
        }

        // Hàm helper tối ưu nhất để tránh lỗi "Not found"
        private Guna2TextBox CreateField(string labelText, int x, int y, int width)
        {
            Label lbl = new Label { Text = labelText, Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64) };
            this.panelContent.Controls.Add(lbl);

            Guna2TextBox txt = new Guna2TextBox { Location = new Point(x, y + 20), Size = new Size(width, 36), BorderRadius = 5, Font = new Font("Segoe UI", 9F) };
            this.panelContent.Controls.Add(txt);
            return txt;
        }
    }
}