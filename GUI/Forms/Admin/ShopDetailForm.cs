using Guna.UI2.WinForms;
using Skynet_Commerce.BLL.Models.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopDetailForm : Form
    {
        private int _shopId;
        private ShopService _service;
        private ShopFullDetailViewModel _viewModel;

        public ShopDetailForm(int shopId)
        {
            InitializeComponent(); // Lúc này sẽ gọi hàm trong file Designer
            _shopId = shopId;
            _service = new ShopService();

            // Cấu hình thêm cho Grid (nếu Designer chưa đủ)
            SetupGridColumns();
        }

        private void SetupGridColumns()
        {
            // Định nghĩa cột cho Grid Products
            _gridProducts.AutoGenerateColumns = false;
            if (_gridProducts.Columns.Count == 0)
            {
                _gridProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductID", HeaderText = "ID" });
                _gridProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên Sản Phẩm" });
                _gridProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Giá", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                _gridProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Kho" });
                _gridProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sold", HeaderText = "Đã Bán" });
            }

            // Định nghĩa cột cho Grid Orders
            _gridOrders.AutoGenerateColumns = false;
            if (_gridOrders.Columns.Count == 0)
            {
                _gridOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderID", HeaderText = "Mã Đơn" });
                _gridOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Tổng tiền", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
                _gridOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái" });
                _gridOrders.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "Ngày đặt" });
            }
        }

        private void ShopDetailForm_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện Load ở Designer hoặc gọi trực tiếp ở đây cũng được
            LoadData();
        }

        // Cần override OnLoad để chắc chắn chạy LoadData nếu Designer quên bind event
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _viewModel = _service.GetShopFullDetail(_shopId);
                if (_viewModel == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu shop!");
                    this.Close();
                    return;
                }

                // Bind Data Tab 1: Info
                _txtName.Text = _viewModel.ShopName;
                _txtDesc.Text = _viewModel.Description;
                _txtOwner.Text = _viewModel.OwnerName;
                _txtEmail.Text = _viewModel.Email;
                _txtPhone.Text = _viewModel.Phone ?? "N/A";

                // Status Badge & Button Color
                bool isActive = _viewModel.Status == "Active";
                _lblStatus.Text = isActive ? "● ĐANG HOẠT ĐỘNG" : "● BỊ ĐÌNH CHỈ";
                _lblStatus.ForeColor = isActive ? Color.Green : Color.Red;

                _btnBan.Text = isActive ? "Đình chỉ" : "Mở khoá";
                _btnBan.FillColor = isActive ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129); // Đỏ hoặc Xanh

                // Bind Data Tab 1: Stats Cards
                _lblRevenueVal.Text = string.Format("{0:N0} đ", _viewModel.TotalRevenue);
                _lblTotalOrderVal.Text = _viewModel.TotalOrders.ToString();
                _lblRatingVal.Text = $"{_viewModel.Rating:F1} ★";

                // Bind Data Tab 2 & 3
                _gridProducts.DataSource = _viewModel.TopProducts;
                _gridOrders.DataSource = _viewModel.RecentOrders;

                // Load Avatar nếu có URL (Giả định có thư viện hỗ trợ hoặc dùng PictureBox chuẩn)
                if (!string.IsNullOrEmpty(_viewModel.AvatarURL))
                {
                    // _picAvatar.LoadAsync(_viewModel.AvatarURL); // Uncomment nếu muốn load ảnh mạng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _service.UpdateShopBasicInfo(_shopId, _txtName.Text.Trim(), _txtDesc.Text.Trim());
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void _btnBan_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thay đổi trạng thái hoạt động của shop này?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _service.ToggleShopStatus(_shopId);
                    LoadData(); // Reload lại để cập nhật UI
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
    }
}