using Skynet_Commerce.BLL.Models.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopDetailForm : Form
    {
        private readonly int _shopId;
        private readonly ShopService _shopService;
        private ShopViewModel _currentShop;

        public ShopDetailForm(int shopId)
        {
            InitializeComponent();

            // Thêm Shadow cho đẹp (Optional)
            new Guna.UI2.WinForms.Guna2ShadowForm(this);

            _shopId = shopId;
            _shopService = new ShopService();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _currentShop = _shopService.GetShopDetail(_shopId);

                if (_currentShop == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                BindToUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void BindToUI()
        {
            _txtShopId.Text = _currentShop.ShopID.ToString();
            _txtShopName.Text = _currentShop.ShopName;
            _txtOwner.Text = _currentShop.OwnerName;

            // Rating & Stock
            decimal rating = _currentShop.RatingAverage ?? 0;
            _lblRating.Text = $"★ {Math.Round(rating, 1)}";
            _lblStock.Text = $"({_currentShop.StockQuantity ?? 0} sản phẩm)";

            // Status Logic
            if (_currentShop.Status == "Active")
            {
                // Đang hoạt động -> Màu xanh
                _badgeStatus.Text = "Đang hoạt động";
                _badgeStatus.FillColor = Color.FromArgb(22, 163, 74); // Green

                // Nút hành động sẽ là "Khóa" (Màu đỏ)
                _btnToggleStatus.Text = "🔒 Khóa cửa hàng";
                _btnToggleStatus.FillColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                // Đang bị khóa -> Màu đỏ
                _badgeStatus.Text = "Đang bị đình chỉ";
                _badgeStatus.FillColor = Color.FromArgb(220, 38, 38); // Red

                // Nút hành động sẽ là "Mở khóa" (Màu xanh)
                _btnToggleStatus.Text = "🔓 Mở lại cửa hàng";
                _btnToggleStatus.FillColor = Color.FromArgb(22, 163, 74);
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnToggleStatus_Click(object sender, EventArgs e)
        {
            string actionName = _currentShop.Status == "Active" ? "khóa" : "mở khóa";

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn {actionName} cửa hàng '{_currentShop.ShopName}' không?",
                "Xác nhận thay đổi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _shopService.ToggleShopStatus(_shopId);
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo");

                    // 1. Tải lại dữ liệu cho chính Form này để cập nhật màu nút/chữ
                    LoadData();

                    // 2. [QUAN TRỌNG] Đánh dấu là đã có thay đổi thành công
                    // Khi form này đóng lại, Form cha sẽ nhận được kết quả OK
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
    }
}