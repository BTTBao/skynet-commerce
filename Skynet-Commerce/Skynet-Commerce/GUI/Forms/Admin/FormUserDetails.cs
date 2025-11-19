using Skynet_Commerce.BLL.Models.Admin;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FormUserDetails : Form
    {
        private UserViewModel _user;
        private bool _isEditMode;

        // Constructor nhận vào User và chế độ (View hay Edit)
        public FormUserDetails(UserViewModel user, bool isEditMode)
        {
            InitializeComponent();
            _user = user;
            _isEditMode = isEditMode;

            LoadStaticData(); // Nạp dữ liệu tĩnh cho ComboBox
            LoadUserData();   // Đổ dữ liệu User lên Form
            SetupFormMode();  // Cấu hình giao diện theo Mode
        }

        private void LoadStaticData()
        {
            if (cboRole != null && cboRole.Items.Count == 0)
            {
                cboRole.Items.AddRange(new string[] { "Admin", "Seller", "Buyer" });
            }

            if (cboStatus != null && cboStatus.Items.Count == 0)
            {
                cboStatus.Items.AddRange(new string[] { "Active", "Banned" });
            }
        }

        private void LoadUserData()
        {
            // 1. KIỂM TRA AN TOÀN (Tránh crash nếu user null)
            if (_user == null) return;

            // 2. KIỂM TRA CONTROL (Tránh crash nếu Designer lỗi)
            if (txtId == null || txtName == null)
            {
                MessageBox.Show("Lỗi giao diện: Control chưa được khởi tạo. Kiểm tra lại file Designer.cs", "Lỗi nghiêm trọng");
                return;
            }
            // 3. GÁN DỮ LIỆU
            // Lưu ý: Kiểm tra tên property chính xác trong UserViewModel (Id hay UserID?)
            txtId.Text = _user.UserID.ToString(); 
            txtName.Text = _user.FullName ?? "";  
            txtEmail.Text = _user.Email ?? "";
            txtPhone.Text = _user.Phone ?? ""; 

            // Xử lý ComboBox an toàn
            if (_user.RoleName != null && cboRole.Items.Contains(_user.RoleName))
                cboRole.SelectedItem = _user.RoleName;
            else
                cboRole.StartIndex = 0; // Mặc định nếu không tìm thấy

            if (_user.Status != null && cboStatus.Items.Contains(_user.Status))
                cboStatus.SelectedItem = _user.Status;
        }

        private void SetupFormMode()
        {
            if (_isEditMode)
            {
                this.Text = "Edit User Details";
                btnSave.Visible = true;

                // Cho phép chỉnh sửa
                txtName.Enabled = true;
                cboRole.Enabled = true;
                cboStatus.Enabled = true;
                // ID và Email thường không cho sửa
                txtId.Enabled = false;
                txtEmail.Enabled = false;
            }
            else // View Mode
            {
                this.Text = "User Details";
                btnSave.Visible = false; // Ẩn nút lưu

                // Khóa toàn bộ control, chỉ cho xem
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                cboRole.Enabled = false;
                cboStatus.Enabled = false;
                txtId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user == null) return;

            // Validate dữ liệu cơ bản (Ví dụ: không được để trống tên)
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("Tên người dùng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại object _user từ giao diện
            _user.FullName = txtName.Text.Trim();
            _user.Phone = txtPhone.Text.Trim();

            if (cboRole.SelectedItem != null)
                _user.RoleName = cboRole.SelectedItem.ToString();

            if (cboStatus.SelectedItem != null)
                _user.Status = cboStatus.SelectedItem.ToString();

            // Thông báo và đóng form
            MessageBox.Show("Đã lưu thông tin tạm thời (Cần Save xuống DB).", "Thông báo");

            this.DialogResult = DialogResult.OK; // Báo cho form cha biết là đã bấm Save
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}