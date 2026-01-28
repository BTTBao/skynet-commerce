using System;
using System.Windows.Forms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerMainForm : Form
    {
        private int shopID;
        public SellerMainForm(int shopId)
        {
            InitializeComponent();
            shopID = shopId;

            // Gán sự kiện cho các nút sidebar
            btnDashboard.Click += BtnDashboard_Click;
            btnProduct.Click += BtnProduct_Click;
            btnOrder.Click += BtnOrder_Click;
            btnVoucher.Click += BtnVoucher_Click;
            btnShopInfo.Click += BtnShopInfo_Click;
            btnLogout.Click += BtnLogout_Click;

            // Mặc định load Dashboard
            LoadChildForm(new SellerDashboardForm(shopId));
        }

        private void LoadChildForm(Form childForm)
        {
            // Xóa form cũ trong panel
            panelContainer.Controls.Clear();

            childForm.TopLevel = false; // bắt buộc để nhúng vào panel
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.Show();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            LoadChildForm(new SellerDashboardForm(shopID));
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            LoadChildForm(new SellerProductForm(shopID));
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            LoadChildForm(new SellerOrderForm(shopID));
        }

        private void BtnVoucher_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnShopInfo_Click(object sender, EventArgs e)
        {
            LoadChildForm(new SellerInfoForm(shopID));
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                new Login.LoginForm().Show();
            }
        }
    }
}
