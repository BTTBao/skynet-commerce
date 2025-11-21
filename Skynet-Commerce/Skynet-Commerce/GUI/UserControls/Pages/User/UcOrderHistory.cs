using Guna.UI2.WinForms;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcOrderHistory : UserControl
    {
        public UcOrderHistory()
        {
            InitializeComponent();
            LoadData("Tất cả"); // Mặc định load hết
        }

        // Sự kiện khi bấm vào các Tab
        private void OnTabClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            LoadData(btn.Text);
        }

        // Hàm load dữ liệu giả lập
        private void LoadData(string filterStatus)
        {
            flowPanelOrders.Controls.Clear(); // Xóa danh sách cũ

            // Tạo dữ liệu giả để test
            var orders = new[]
            {
                new { Id = "DH112233", Status = "Hoàn thành", Name = "Tai nghe Bluetooth Sony", Price = "2.500.000đ", Total = "2.500.000đ" },
                new { Id = "DH112234", Status = "Đang giao", Name = "Bàn phím cơ Keychron", Price = "1.800.000đ", Total = "1.830.000đ" },
                new { Id = "DH112235", Status = "Chờ xác nhận", Name = "Chuột Logitech G Pro", Price = "2.900.000đ", Total = "2.900.000đ" },
                new { Id = "DH112236", Status = "Đã hủy", Name = "Lót chuột Gaming", Price = "300.000đ", Total = "300.000đ" },
                new { Id = "DH112237", Status = "Hoàn thành", Name = "Áo thun Local Brand", Price = "350.000đ", Total = "380.000đ" }
            };

            foreach (var item in orders)
            {
                // Logic lọc: Nếu chọn "Tất cả" thì lấy hết, ngược lại thì phải đúng trạng thái
                if (filterStatus != "Tất cả" && item.Status != filterStatus) continue;

                // Tạo thẻ đơn hàng con (UcOrderDetail)
                UcOrderDetail card = new UcOrderDetail();

                // Đổ dữ liệu vào thẻ con
                card.SetData(
                    item.Id,
                    "2025-11-22",
                    "Tech Store Official",
                    item.Name,
                    "Mặc định",
                    1,
                    item.Price,
                    item.Total,
                    null, // Nếu có ảnh thì truyền vào đây
                    item.Status
                );

                // Chỉnh kích thước thẻ con cho đẹp
                card.Width = flowPanelOrders.Width - 25; // Trừ thanh cuộn
                card.Margin = new Padding(0, 0, 0, 10); // Cách nhau 1 chút

                // Thêm vào panel
                flowPanelOrders.Controls.Add(card);
            }
        }
    }
}