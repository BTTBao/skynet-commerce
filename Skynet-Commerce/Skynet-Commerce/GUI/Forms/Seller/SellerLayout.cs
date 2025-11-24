using Skynet_Commerce.BLL.Helpers;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.UserControls.Components.UCSeller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce
{
    public partial class SellerLayout : Form
    {
        // Khai báo biến để giữ nút đang hoạt động (Optional, but good practice)
        private Button currentActiveButton = null;
        private int shopId;

        public SellerLayout(int shopid)
        {
            InitializeComponent();
            // Đặt màu nền ban đầu cho tất cả các nút (Sử dụng màu White hoặc BackColor mặc định của sidebar)
            btnOverview.BackColor = Color.White;
            btnProducts.BackColor = Color.White;
            btnOrders.BackColor = Color.White;
            btnSettings.BackColor = Color.White;

            this.shopId = shopid;

            // Highlight menu ban đầu (Tổng quan)
            HighlightMenu(btnOverview);
            btnLogout.Click += BtnLogout_Click;
        }

        private void HighlightMenu(Button btn)
        {
            // --- 1. Reset màu nút trước đó ---
            if (currentActiveButton != null)
            {
                // Reset màu về màu nền mặc định (White)
                currentActiveButton.BackColor = Color.White;
            }

            // --- 2. Đặt màu cho nút hiện tại (Active) ---
            // Nút được chọn -> cam
            btn.BackColor = Color.Orange;
            currentActiveButton = btn; // Cập nhật nút đang hoạt động

            // --- 3. Gọi nội dung tương ứng ---
            LoadContent(btn.Name);
        }

        private void LoadContent(string menuName)
        {
            // Xóa các controls cũ trong panel
            contentPanel.Controls.Clear();
            UserControl newContent = null;
            string titleText = "";

            // Dựa vào tên nút để quyết định nội dung nào sẽ được tải
            switch (menuName)
            {
                case "btnOverview":
                    // Thay thế bằng new ucOverview() thực tế nếu có
                    newContent = new ucSellerDashboard(shopId);
                    titleText = "Kênh người bán";
                    break;

                case "btnProducts":
                    // *** THAY ĐỔI QUAN TRỌNG: Gọi new ucProduct() ***
                    newContent = new ucProduct(shopId);
                    titleText = "Kênh người bán";
                    break;

                case "btnOrders":
                    // Thay thế bằng new ucOrders() thực tế nếu có
                    newContent = new ucOrder(shopId);
                    titleText = "Kênh người bán";
                    break;

                case "btnSettings":
                    // Thay thế bằng new ucSettings() thực tế nếu có
                    newContent = new ucShopSetting(shopId);
                    titleText = "Kênh người bán";
                    break;

                default:
                    return;
            }

            this.titleLabel.Text = titleText;
            if (newContent != null)
            {
                newContent.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(newContent);
            }
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnOverview);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnProducts);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnOrders);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HighlightMenu(btnSettings);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 1. Xóa Session
                AppSession.Instance.Clear();

                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2. [QUAN TRỌNG] Mở lại Form Main
                // Tạo một instance mới của FrmMain để đảm bảo UI/state được làm mới
                FrmMain newMainForm = new FrmMain();
                newMainForm.Show();

                // 3. Đóng Form SellerLayout hiện tại
                // Điều này sẽ ngắt Application.Exit() trigger từ UcLogin
                this.Close();
            }
        }
    }
}