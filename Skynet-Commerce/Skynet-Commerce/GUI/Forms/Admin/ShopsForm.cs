using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopsForm : Form
    {
        private readonly ShopService _shopService;
        public ShopsForm()
        {
            InitializeComponent();
            _shopService = new ShopService();
            LoadPendingShops();
            LoadActiveShops();
        }

        private void LoadPendingShops()
        {
            _pendingContainer.Controls.Clear();

            // 1. Gọi Service lấy danh sách từ bảng ShopRegistration
            List<PendingShopViewModel> pendingList = _shopService.GetPendingRegistrations();

            if (pendingList.Count == 0)
            {
                // Ẩn card Pending
                _cardPending.Visible = false;

                // Kéo cardAllShops lên vị trí của pending
                _cardAllShops.Location = _cardPending.Location;

                // Tăng chiều cao cho cardAllShops nếu muốn
                _cardAllShops.Height += _cardPending.Height;
                _activeContainer.Height += _cardPending.Height;
                return;
            }

            // Nếu có pending thì hiển thị bình thường
            _cardPending.Visible = true;
            // 2. Duyệt và hiển thị lên giao diện
            foreach (var item in pendingList)
            {
                var row = new UcPendingShopRow();

                string displayId = item.RegistrationID.ToString();
                string dateStr = item.RequestDate.ToString("dd/MM/yyyy");

                // Truyền dữ liệu vào UserControl
                // Lưu ý: Bạn nên truyền cả item.RegistrationID gốc vào một biến ẩn trong UC để dùng cho nút Duyệt/Từ chối sau này
                row.SetData(displayId, item.ShopName, item.OwnerName, item.Email, dateStr);

                // Gắn Tag để sau này dễ lấy ID khi click nút
                row.Tag = item.RegistrationID;

                _pendingContainer.Controls.Add(row);
            }
        }
        private void LoadActiveShops()
        {
            List<ShopViewModel> shops = _shopService.GetShops();

            _activeContainer.Controls.Clear();
            foreach (var shop in shops)
            {
                var row = new UcActiveShopRow();
                row.SetData(shop);
                _activeContainer.Controls.Add(row);
            }
        }

    }
}