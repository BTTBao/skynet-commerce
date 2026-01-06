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

            if (_dgvUsers.Columns[e.ColumnIndex].Name == "colAction")
            {
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                e.CellStyle.SelectionForeColor = Color.Black;
            }
        }

        // --- XỬ LÝ SỰ KIỆN CLICK ---
        private void _dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgvUsers.Columns[e.ColumnIndex].Name != "colAction") return;

            var user = _dgvUsers.Rows[e.RowIndex].DataBoundItem as UserViewModel;
            if (user == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            var itemInfo = menu.Items.Add("Xem chi tiết");
            itemInfo.Image = SystemIcons.Information.ToBitmap();
            itemInfo.Click += (s, ev) => {
                new FormUserDetails(user, false).ShowDialog();
            };

            var itemEdit = menu.Items.Add("Chỉnh sửa");
            itemEdit.Click += (s, ev) => {
                FormUserDetails frm = new FormUserDetails(user, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (_userService.UpdateUser(frm._user))
                    {
                        MessageBox.Show("Đã cập nhật!");
                        _ = LoadUserDataAsync();
                    }
                }
            };

            string banText = user.Status == "Active" ? "Khoá tài khoản" : "Mở khoá";
            var itemBan = menu.Items.Add(banText);
            itemBan.ForeColor = user.Status == "Active" ? Color.Red : Color.Green;
            itemBan.Click += (s, ev) => {
                var confirm = MessageBox.Show($"Bạn muốn {banText.ToLower()} {user.FullName}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    user.Status = user.Status == "Active" ? "Banned" : "Active";
                    _dgvUsers.Refresh();
                }
            };

            Rectangle cellRect = _dgvUsers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvUsers, cellRect.Left, cellRect.Bottom);
        }

        #region Xuất excel
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

        #endregion
        
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
    }
}