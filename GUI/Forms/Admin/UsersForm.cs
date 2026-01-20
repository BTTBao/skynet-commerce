using OfficeOpenXml;
using OfficeOpenXml.Style;
using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Ecommerce.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class UsersForm : Form
    {
        private readonly UserService _userService;
        private bool _isLoading = false;

        //phân trang
        private PaginationHelper _paginationHelper;
        private List<UserViewModel> _allUsersCache = new List<UserViewModel>(); // Vẫn giữ Cache để cắt dữ liệu
        
        public class RoleOption
        {
            public string DisplayName { get; set; }
            public string Value { get; set; }
        }

        public UsersForm()
        {
            InitializeComponent(); // _dgvUsers đã được tạo ở đây

            _userService = new UserService();

            SetupRoleFilter();
            SetupButtonIcons();

            // Đăng ký sự kiện thay đổi con trỏ chuột (Cursor)
            _dgvUsers.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvUsers.Cursor = Cursors.Hand; };
            _dgvUsers.CellMouseLeave += (s, e) => { _dgvUsers.Cursor = Cursors.Default; };

            // phân trang
            _paginationHelper = new PaginationHelper(
                _pnlPagination,     // Panel chứa nút 1 2 3
                _cboPageSelect,     // ComboBox chọn trang
                _lblTotalPageText,  // Label "of 10"
                (page) => RenderUserGrid(), // Callback: Khi đổi trang thì vẽ lại Grid
                pageSize: 10        // Số dòng mỗi trang
            );
        }

        // --- XỬ LÝ MÀU SẮC THÔNG MINH ---
        private void _dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvUsers.Columns[e.ColumnIndex].Name == "colStatus")
            {
                string status = e.Value?.ToString();
                if (status == "Active")
                {
                    e.Value = "● Hoạt động";
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129); // Green-500
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "● Đã Khoá";
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); // Red-500
                }
            }

            if (_dgvUsers.Columns[e.ColumnIndex].Name == "colRole")
            {
                string role = e.Value?.ToString();
                if (role == "Admin")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(124, 58, 237); // Violet
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (role == "Seller")
                {
                    e.Value = "Người bán";
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Blue
                }
                else
                {
                    e.Value = "Người mua";
                    e.CellStyle.ForeColor = Color.FromArgb(107, 114, 128); // Gray
                }
            }
        }

        #region --- XỬ LÝ SỰ KIỆN CLICK ---
        private void _btnView_Click(object sender, EventArgs e)
        {
            if (_dgvUsers.SelectedRows.Count == 0) return;
            var user = _dgvUsers.SelectedRows[0].DataBoundItem as UserViewModel;

            if (user != null)
            {
                new FormUserDetails(user, false).ShowDialog();
            }
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            if (_dgvUsers.SelectedRows.Count == 0) return;
            var user = _dgvUsers.SelectedRows[0].DataBoundItem as UserViewModel;

            if (user != null)
            {
                FormUserDetails frm = new FormUserDetails(user, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (_userService.UpdateUser(frm._user))
                    {
                        MessageBox.Show("Đã cập nhật!");
                        _ = LoadUserDataAsync(); // Load lại dữ liệu để cập nhật bảng
                    }
                }
            }
        }

        private void _btnBan_Click(object sender, EventArgs e)
        {
            if (_dgvUsers.SelectedRows.Count == 0) return;
            var user = _dgvUsers.SelectedRows[0].DataBoundItem as UserViewModel;

            if (user != null)
            {
                string actionText = user.Status == "Active" ? "Khoá tài khoản" : "Mở khoá tài khoản";
                var confirm = MessageBox.Show($"Bạn muốn {actionText.ToLower()} {user.FullName}?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Đảo trạng thái
                    user.Status = user.Status == "Active" ? "Banned" : "Active";

                    // TODO: Gọi Service để lưu xuống DB (Ví dụ: _userService.ChangeStatus(user.Id, user.Status))
                    // Hiện tại code cũ bạn chỉ refresh grid, ở đây tôi giả lập update UI
                    _dgvUsers.Refresh();

                    // Cập nhật lại nút Ban ngay lập tức
                    _dgvUsers_SelectionChanged(null, null);
                }
            }
        }

        private void _btnExportExcel_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu hiện tại từ GridView
            var userList = _dgvUsers.DataSource as List<UserViewModel>;
            if (userList == null || userList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"DanhSachNguoiDung_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportDataToExcel(userList, sfd.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
        
        private void ExportDataToExcel(List<UserViewModel> data, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                // Tạo Sheet mới
                var worksheet = package.Workbook.Worksheets.Add("Users");

                // --- 1. TẠO HEADER ---
                string[] headers = { "Họ và Tên", "Email", "Số điện thoại", "Vai trò", "Trạng thái" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];

                    // Style cho Header
                    var cell = worksheet.Cells[1, i + 1];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(100, 88, 255)); // Màu tím giống Grid
                    cell.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // --- 2. ĐỔ DỮ LIỆU ---
                int row = 2;
                foreach (var user in data)
                {
                    worksheet.Cells[row, 1].Value = user.FullName;
                    worksheet.Cells[row, 2].Value = user.Email;
                    worksheet.Cells[row, 3].Value = user.Phone;

                    // Format lại Vai trò cho đẹp (Giống logic hiển thị trên Grid)
                    string roleDisplay = user.RoleName;
                    if (user.RoleName == "Seller") roleDisplay = "Người bán";
                    else if (user.RoleName == "Buyer") roleDisplay = "Người mua";
                    worksheet.Cells[row, 4].Value = roleDisplay;

                    // Format lại Trạng thái
                    string statusDisplay = user.Status == "Active" ? "Hoạt động" : "Đã khoá";
                    worksheet.Cells[row, 5].Value = statusDisplay;

                    // Tô màu đỏ nếu bị khoá
                    if (user.Status != "Active")
                    {
                        worksheet.Cells[row, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    }

                    row++;
                }

                // --- 3. FORMAT CHUNG ---
                worksheet.Cells.AutoFitColumns(); // Tự động giãn cột

                // Lưu file
                FileInfo fi = new FileInfo(filePath);
                package.SaveAs(fi);
            }
        }

        #region Thiết lập giao diện và tải dữ liệu
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
            _comboRole.DisplayMember = "DisplayName";
            _comboRole.ValueMember = "Value";

            _comboRole.StartIndex = 0;
            _comboRole.SelectedIndexChanged += _comboRole_SelectedIndexChanged;
        }

        private void SetupButtonIcons()
        {
            // 1. URL của các Icon (Tôi chọn các icon phù hợp từ Flaticon tương tự Dashboard)
            string urlView = "https://cdn-icons-png.flaticon.com/128/709/709612.png"; // Icon con mắt
            string urlEdit = "https://cdn-icons-png.flaticon.com/128/2356/2356780.png"; // Icon cây bút
            string urlBan = "https://cdn-icons-png.flaticon.com/128/483/483408.png"; // Icon ổ khoá
            string urlExcel = "https://cdn-icons-png.flaticon.com/128/732/732089.png"; // Icon Excel

            // 2. Tải và gán ảnh
            _btnView.Image = ImageHelper.LoadFromUrl(urlView);
            _btnEdit.Image = ImageHelper.LoadFromUrl(urlEdit);
            _btnBan.Image = ImageHelper.LoadFromUrl(urlBan);
            _btnExportExcel.Image = ImageHelper.LoadFromUrl(urlExcel);

            // 3. Đổi màu ảnh sang trắng (vì nền nút đang là màu đậm)
            _btnView.Image = ImageHelper.Recolor(_btnView.Image, Color.White);
            _btnEdit.Image = ImageHelper.Recolor(_btnEdit.Image, Color.White);
            _btnBan.Image = ImageHelper.Recolor(_btnBan.Image, Color.White);
            _btnExportExcel.Image = ImageHelper.Recolor(_btnExportExcel.Image, Color.White);

            // 4. Cấu hình kích thước và vị trí Icon (để icon nằm đẹp bên trái text)
            ConfigureButtonIcon(_btnView);
            ConfigureButtonIcon(_btnEdit);
            ConfigureButtonIcon(_btnBan);
            ConfigureButtonIcon(_btnExportExcel);
        }
        
        private void ConfigureButtonIcon(Guna.UI2.WinForms.Guna2Button btn)
        {
            btn.ImageSize = new Size(18, 18); // Kích thước icon
            btn.ImageOffset = new Point(5, 0); // Cách lề trái một chút
            btn.TextOffset = new Point(10, 0);
        }

        #endregion

        private async void _comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
        }

        private async void _txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await LoadUserDataAsync();
            }
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
        }

        // Xử lý khi người dùng tự gõ số trang và nhấn Enter
      
        private async Task LoadUserDataAsync()
        {
            if (_isLoading) return;
            _isLoading = true;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string keyword = _txtSearch.Text.Trim();
                string role = _comboRole.SelectedValue != null ? _comboRole.SelectedValue.ToString() : "All Roles";
                List<UserViewModel> users = await Task.Run(() =>
                {
                    return _userService.GetAllUsersForView(keyword, role);
                });
                // Lưu vào Cache và tính tổng số trang
                _allUsersCache = users;

                _paginationHelper.SetTotalRecords(users.Count);
                _paginationHelper.SetPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
                Cursor.Current = Cursors.Default;
            }
        }

        // [HÀM MỚI] Hàm callback chỉ làm nhiệm vụ cắt dữ liệu từ Cache ra hiển thị
        private void RenderUserGrid()
        {
            int page = _paginationHelper.CurrentPage;
            int size = _paginationHelper.PageSize;

            // Cắt dữ liệu (Client-side pagination)
            var pagedData = _allUsersCache
                            .Skip((page - 1) * size)
                            .Take(size)
                            .ToList();

            _dgvUsers.AutoGenerateColumns = false;
            _dgvUsers.DataSource = pagedData;
        }

        private void _dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = _dgvUsers.SelectedRows.Count > 0;

            _btnView.Enabled = hasSelection;
            _btnEdit.Enabled = hasSelection;
            _btnBan.Enabled = hasSelection;

            // Nếu có chọn, cập nhật text nút Ban cho đúng trạng thái (Khoá hay Mở khoá)
            if (hasSelection)
            {
                var user = _dgvUsers.SelectedRows[0].DataBoundItem as UserViewModel;
                if (user != null)
                {
                    if (user.Status == "Active")
                    {
                        _btnBan.Text = "Khoá";
                        _btnBan.FillColor = Color.FromArgb(239, 68, 68); // Đỏ
                    }
                    else
                    {
                        _btnBan.Text = "Mở khoá";
                        _btnBan.FillColor = Color.FromArgb(16, 185, 129); // Xanh lá
                    }
                }
            }
            else
            {
                _btnBan.Text = "Khoá";
                _btnBan.FillColor = Color.FromArgb(239, 68, 68);
            }
        }
    }
}