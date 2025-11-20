using System;
using System.Linq;
using System.Windows.Forms;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class UsersForm : Form
    {
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;

        public UsersForm()
        {
            InitializeComponent();

            // 1. KHỞI TẠO SERVICE TRƯỚC
            _userService = new UserService();

            // 2. SAU ĐÓ MỚI LOAD DỮ LIỆU
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            try
            {
                // Lấy dữ liệu
                var users = _userService.GetAllUsersForView();

                // Xóa dữ liệu cũ trong container chính (chỉ dùng _userListContainer)
                _userListContainer.Controls.Clear();

                foreach (var user in users)
                {
                    var row = new UcUserRow();
                    row.SetData(user); // Đảm bảo hàm SetData trong UcUserRow nhận đúng kiểu dữ liệu

                    // --- BẮT SỰ KIỆN ---

                    // View
                    row.ViewClicked += (sender, u) => {
                        FormUserDetails frm = new FormUserDetails(u, isEditMode: false);
                        frm.ShowDialog();
                    };

                    // Edit
                    row.EditClicked += (sender, u) => {
                        FormUserDetails frm = new FormUserDetails(u, isEditMode: true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            row.SetData(frm._user);
                            var success = _userService.UpdateUser(frm._user);

                            if (success)
                                MessageBox.Show("Cập nhật user thành công!");
                            else
                                MessageBox.Show("Không thể cập nhật dữ liệu!");
                        }
                    };

                    // Ban
                    row.BanClicked += (sender, u) => {
                        // Console.WriteLine($"Đã cấm user ID: {u.Id}"); 
                        // Lưu ý: Kiểm tra property Id hay UserID trong DTO của bạn
                    };

                    // 3. CHỈ ADD VÀO 1 CONTAINER DUY NHẤT
                    _userListContainer.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
    }
}