using Skynet_Commerce.BLL.Models.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcUserRow : UserControl
    {
        // 1. Lưu trữ dữ liệu của dòng hiện tại
        private UserViewModel _currentUser;

        // 2. Định nghĩa các sự kiện (Event) để Form cha đăng ký lắng nghe
        public event EventHandler<UserViewModel> ViewClicked;
        public event EventHandler<UserViewModel> EditClicked;
        public event EventHandler<UserViewModel> BanClicked;
        public UcUserRow()
        {
            InitializeComponent();
            // Tạo đường kẻ mờ dưới mỗi hàng
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };

            // 3. Gán sự kiện Click cho các nút
            _btnView.Click += (s, e) => ViewClicked?.Invoke(this, _currentUser);
            _btnEdit.Click += (s, e) => EditClicked?.Invoke(this, _currentUser);
            _btnBan.Click += _btnBan_Click;
        }

        public void SetData(UserViewModel user)
        {
            _lblId.Text = user.UserID.ToString();
            _lblName.Text = user.FullName;
            _lblEmail.Text = user.Email;
            _lblPhone.Text = user.Phone;

            _currentUser = user;

            UpdateRoleUI(user.RoleName);
            UpdateStatusUI(user.Status);
        }
        // Tách hàm UI Role cho gọn
        private void UpdateRoleUI(string role)
        {
            _btnRole.Text = role;
            if (role == "Admin")
            {
                _btnRole.FillColor = Color.FromArgb(79, 70, 229);
                _btnRole.ForeColor = Color.White;
            }
            else if (role == "Seller")
            {
                _btnRole.FillColor = Color.White;
                _btnRole.BorderThickness = 1;
                _btnRole.BorderColor = Color.LightGray;
                _btnRole.ForeColor = Color.Black;
            }
            else // Buyer
            {
                _btnRole.FillColor = Color.FromArgb(243, 244, 246);
                _btnRole.ForeColor = Color.Black;
            }
        }

        // Tách hàm UI Status cho gọn
        private void UpdateStatusUI(string status)
        {
            _btnStatus.Text = status;
            if (status == "Active")
            {
                _btnStatus.FillColor = Color.FromArgb(79, 70, 229);
            }
            else // Banned
            {
                _btnStatus.FillColor = Color.FromArgb(220, 38, 38);
            }
        }
        // 4. Xử lý logic nút BAN ngay tại đây
        private void _btnBan_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Lỗi: Dữ liệu người dùng bị trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại ngay, không chạy tiếp dòng 81 gây lỗi
            }
            // Xác nhận trước khi Ban
            var result = MessageBox.Show($"Bạn có chắc muốn cấm user {_currentUser.FullName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Cập nhật dữ liệu logic
                _currentUser.Status = "Banned";

                // Cập nhật giao diện ngay lập tức
                UpdateStatusUI("Banned");

                // Gửi sự kiện ra ngoài (nếu cần cập nhật Database)
                BanClicked?.Invoke(this, _currentUser);
            }
        }
    
    }
}