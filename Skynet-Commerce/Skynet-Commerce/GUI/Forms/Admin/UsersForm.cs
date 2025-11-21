using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class UsersForm : Form
    {
        private readonly UserService _userService;
        private bool _isLoading = false;

        public class RoleOption
        {
            public string DisplayName { get; set; } // Tên hiển thị (Tiếng Việt)
            public string Value { get; set; }       // Giá trị logic (Tiếng Anh)
        }

        public UsersForm()
        {
            InitializeComponent();

            // KHỞI TẠO SERVICE TRƯỚC
            _userService = new UserService();

            SetupRoleFilter();
        }

        private void SetupRoleFilter()
        {
            _comboRole.SelectedIndexChanged -= _comboRole_SelectedIndexChanged;
            var roleList = new List<RoleOption>()
            {
                new RoleOption { DisplayName = "Tất cả vai trò", Value = "All Roles" },
                new RoleOption { DisplayName = "Người mua",      Value = "Buyer" },
                new RoleOption { DisplayName = "Người bán",      Value = "Seller" },
                new RoleOption { DisplayName = "Quản trị viên",  Value = "Admin" }
            };

            _comboRole.DataSource = roleList;
            _comboRole.DisplayMember = "DisplayName"; // Hiển thị cái này
            _comboRole.ValueMember = "Value";         // Lấy giá trị cái này

            _comboRole.StartIndex = 0; // Chọn mặc định dòng đầu

            _comboRole.SelectedIndexChanged += _comboRole_SelectedIndexChanged;
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            // Mặc định chọn "All Roles"
            await LoadUserDataAsync();
        }

        private async Task LoadUserDataAsync()
        {
            if (_isLoading) return;
            _isLoading = true;
            Cursor.Current = Cursors.WaitCursor; // Hiển thị con trỏ xoay

            try
            {
                // 1. Lấy tham số từ giao diện
                string keyword = _txtSearch.Text.Trim();
                // Xử lý null cho ComboBox để tránh lỗi
                string role = _comboRole.SelectedValue != null
                              ? _comboRole.SelectedValue.ToString()
                              : "All Roles";

                // 2. Gọi Service ở Background Thread
                List<UserViewModel> users = await Task.Run(() =>
                {
                    return _userService.GetAllUsersForView(keyword, role);
                });

                // 3. Cập nhật UI (Trên Main Thread)
                _userListContainer.SuspendLayout(); // Tạm dừng vẽ để tối ưu
                _userListContainer.Controls.Clear();

                if (users.Count == 0)
                {
                    // Hiển thị thông báo nếu không tìm thấy
                    Label lblEmpty = new Label
                    {
                        Text = "Không tìm thấy kết quả nào.",
                        AutoSize = true,
                        Padding = new Padding(20),
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        ForeColor = Color.Gray
                    };
                    _userListContainer.Controls.Add(lblEmpty);
                }
                else
                {
                    foreach (var user in users)
                    {
                        var row = new UcUserRow();
                        row.SetData(user);

                        // Gán lại các sự kiện click
                        row.ViewClicked += Row_ViewClicked;
                        row.EditClicked += Row_EditClicked;
                        row.BanClicked += Row_BanClicked;

                        _userListContainer.Controls.Add(row);
                    }
                }
                _userListContainer.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private async void _comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_userService != null)
                await LoadUserDataAsync();
        }

        private void Row_ViewClicked(object sender, UserViewModel u)
        {
            FormUserDetails frm = new FormUserDetails(u, isEditMode: false);
            frm.ShowDialog();
        }

        private void Row_EditClicked(object sender, UserViewModel u)
        {
            FormUserDetails frm = new FormUserDetails(u, isEditMode: true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Cập nhật database
                bool success = _userService.UpdateUser(frm._user);
                if (success)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    // Load lại dữ liệu để cập nhật dòng vừa sửa
                    // (Hoặc tối ưu hơn: chỉ gọi row.SetData(frm._user) nếu không muốn reload db)
                    _ = LoadUserDataAsync();
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật!");
                }
            }
        }

        private void Row_BanClicked(object sender, UserViewModel u)
        {
            // Logic ban đã nằm trong UcUserRow, nhưng nếu muốn reload lại list 
            // để đảm bảo đồng bộ hoàn toàn thì gọi lại load:
            // _ = LoadUserDataAsync();
        }

        private async void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng "ding" của Windows
                await LoadUserDataAsync();
            }
        }
    }
}