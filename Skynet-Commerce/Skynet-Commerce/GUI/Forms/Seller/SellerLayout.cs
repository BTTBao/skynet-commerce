using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class SellerLayout : Form
    {
        // Khai báo biến để giữ nút đang hoạt động (Optional, but good practice)
        private Button currentActiveButton = null;

        public SellerLayout()
        {
            InitializeComponent();
            // Đặt màu nền ban đầu cho tất cả các nút (Sử dụng màu White hoặc BackColor mặc định của sidebar)
            btnOverview.BackColor = Color.White;
            btnProducts.BackColor = Color.White;
            btnOrders.BackColor = Color.White;
            btnSettings.BackColor = Color.White;

            // Highlight menu ban đầu (Tổng quan)
            HighlightMenu(btnOverview);
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
                    //newContent = new Label() { Text = "Tổng quan shop", Font = new Font("Segoe UI", 16), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                    titleText = "Kênh người bán - Tổng quan";
                    break;

                case "btnProducts":
                    // *** THAY ĐỔI QUAN TRỌNG: Gọi new ucProduct() ***
                    newContent = new ucProduct();
                    titleText = "Kênh người bán - Quản lý sản phẩm";
                    break;

                case "btnOrders":
                    // Thay thế bằng new ucOrders() thực tế nếu có
                    newContent = new ucOrder();
                    titleText = "Kênh người bán - Quản lý đơn hàng";
                    break;

                case "btnSettings":
                    // Thay thế bằng new ucSettings() thực tế nếu có
                    newContent = new ucShopSetting();
                    titleText = "Kênh người bán - Cài đặt shop";
                    break;

                default:
                    return;
            }

            // Gán title label (Giả định titleLabel tồn tại trong SellerLayout.Designer.cs)
            this.titleLabel.Text = titleText;

            // Cấu hình và thêm UserControl vào Panel
            if (newContent != null)
            {
                newContent.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(newContent);
            }
        }

        // --- Event Handlers ---

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
    }
}