using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin;
using Skynet_Commerce.DAL;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FormUserDetails : Form
    {
        private readonly UserDetailsService _service;
        private int _userID;
        private UserDetailDTO _userDetail;
        private UserViewModel user;
        private bool v;

        public FormUserDetails(BLL.Models.Admin.UserViewModel user, int userID)
        {
            InitializeComponent();
            _service = new UserDetailsService();
            _userID = userID;
        }

        public FormUserDetails(UserViewModel user, bool v)
        {
            this.user = user;
            this.v = v;
        }

        private void FormUserDetails_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Get comprehensive user details from function
                _userDetail = _service.GetUserDetails(_userID);

                if (_userDetail == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                // Update header
                lblHeader.Text = $"CHI TIẾT NGƯỜI DÙNG - {_userDetail.FullName}";

                // Check fraud warning (Cancel rate > 50%)
                if (_userDetail.TotalOrders >= 5 && _userDetail.CancelledOrders > 0)
                {
                    decimal cancelRate = (decimal)_userDetail.CancelledOrders / _userDetail.TotalOrders;
                    if (cancelRate >= 0.5m)
                    {
                        pnlWarning.Visible = true;
                        lblWarning.Text = $"⚠️ Cảnh báo: Người dùng có tỷ lệ hủy đơn cao ({cancelRate:P0} - {_userDetail.CancelledOrders}/{_userDetail.TotalOrders} đơn)";
                    }
                }

                // Update Ban button
                UpdateBanButton();

                // Load each tab
                LoadBasicInfo();
                LoadActivityStats();
                LoadAddresses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoadBasicInfo()
        {
            pnlBasicInfo.Controls.Clear();

            int yPos = 20;

            // Section: Thông tin tài khoản
            AddSectionLabel(pnlBasicInfo, "THÔNG TIN TÀI KHOẢN", ref yPos);
            AddInfoRow(pnlBasicInfo, "User ID:", _userDetail.UserID.ToString(), ref yPos);
            AddInfoRow(pnlBasicInfo, "Account ID:", _userDetail.AccountID.ToString(), ref yPos);
            AddInfoRow(pnlBasicInfo, "Email:", _userDetail.Email ?? "N/A", ref yPos);
            AddInfoRow(pnlBasicInfo, "Số điện thoại:", _userDetail.Phone ?? "N/A", ref yPos);
            AddInfoRow(pnlBasicInfo, "Ngày tạo:", _userDetail.AccountCreatedAt.ToString("dd/MM/yyyy HH:mm"), ref yPos);
            AddInfoRow(pnlBasicInfo, "Trạng thái:", _userDetail.AccountStatus ? "✓ Hoạt động" : "✖ Đã khóa", ref yPos, 
                _userDetail.AccountStatus ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68));

            yPos += 20;

            // Section: Thông tin cá nhân
            AddSectionLabel(pnlBasicInfo, "THÔNG TIN CÁ NHÂN", ref yPos);
            AddInfoRow(pnlBasicInfo, "Họ tên:", _userDetail.FullName ?? "N/A", ref yPos);
            AddInfoRow(pnlBasicInfo, "Giới tính:", _userDetail.Gender ?? "N/A", ref yPos);
            AddInfoRow(pnlBasicInfo, "Ngày sinh:", _userDetail.DateOfBirth?.ToString("dd/MM/yyyy") ?? "N/A", ref yPos);

            yPos += 20;

            // Section: Vai trò & Shop
            AddSectionLabel(pnlBasicInfo, "VAI TRÒ & CỬA HÀNG", ref yPos);
            AddInfoRow(pnlBasicInfo, "Vai trò:", _userDetail.Roles ?? "Buyer", ref yPos);
            
            if (_userDetail.ShopID.HasValue)
            {
                AddInfoRow(pnlBasicInfo, "Shop ID:", _userDetail.ShopID.ToString(), ref yPos);
                AddInfoRow(pnlBasicInfo, "Tên Shop:", _userDetail.ShopName ?? "N/A", ref yPos);
            }
            else
            {
                AddInfoRow(pnlBasicInfo, "Cửa hàng:", "Chưa có", ref yPos, Color.Gray);
            }
        }

        private void LoadActivityStats()
        {
            pnlActivity.Controls.Clear();

            int yPos = 20;

            // Section: Thống kê đơn hàng
            AddSectionLabel(pnlActivity, "THỐNG KÊ ĐƠN HÀNG", ref yPos);
            AddStatCard(pnlActivity, "Tổng đơn hàng", _userDetail.TotalOrders.ToString(), Color.FromArgb(59, 130, 246), ref yPos);
            AddStatCard(pnlActivity, "Đã giao hàng", _userDetail.DeliveredOrders.ToString(), Color.FromArgb(16, 185, 129), ref yPos);
            AddStatCard(pnlActivity, "Đã hủy", _userDetail.CancelledOrders.ToString(), Color.FromArgb(239, 68, 68), ref yPos);
            
            // Cancel rate calculation
            if (_userDetail.TotalOrders > 0)
            {
                decimal cancelRate = (decimal)_userDetail.CancelledOrders / _userDetail.TotalOrders * 100;
                AddStatCard(pnlActivity, "Tỷ lệ hủy", $"{cancelRate:F1}%", 
                    cancelRate >= 50 ? Color.FromArgb(239, 68, 68) : Color.FromArgb(59, 130, 246), ref yPos);
            }

            yPos += 20;

            // Section: Thống kê chi tiêu
            AddSectionLabel(pnlActivity, "THỐNG KÊ CHI TIÊU & ĐÁNH GIÁ", ref yPos);
            AddStatCard(pnlActivity, "Tổng chi tiêu", _userDetail.TotalSpent.ToString("N0") + " ₫", Color.FromArgb(139, 92, 246), ref yPos);
            AddStatCard(pnlActivity, "Số đánh giá", _userDetail.TotalReviews.ToString(), Color.FromArgb(249, 115, 22), ref yPos);
            AddStatCard(pnlActivity, "Số địa chỉ", _userDetail.TotalAddresses.ToString(), Color.FromArgb(14, 165, 233), ref yPos);
        }

        private void LoadAddresses()
        {
            try
            {
                var addresses = _service.GetUserAddresses(_userDetail.AccountID);

                dgvAddresses.AutoGenerateColumns = false;
                dgvAddresses.Columns.Clear();

                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "AddressID", Width = 50 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người nhận", DataPropertyName = "ReceiverName", Width = 120 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = "ReceiverPhone", Width = 100 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Địa chỉ", DataPropertyName = "AddressLine", Width = 200 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phường/Xã", DataPropertyName = "Ward", Width = 100 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quận/Huyện", DataPropertyName = "District", Width = 100 });
                dgvAddresses.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tỉnh/TP", DataPropertyName = "Province", Width = 100 });
                dgvAddresses.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Mặc định", DataPropertyName = "IsDefault", Width = 80 });

                dgvAddresses.DataSource = addresses;

                // Style header
                dgvAddresses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 50);
                dgvAddresses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvAddresses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                dgvAddresses.CellFormatting += (s, e) =>
                {
                    if (dgvAddresses.Columns[e.ColumnIndex].DataPropertyName == "IsDefault" && e.Value != null)
                    {
                        bool isDefault = (bool)e.Value;
                        e.CellStyle.BackColor = isDefault ? Color.FromArgb(220, 252, 231) : Color.White;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải địa chỉ: " + ex.Message);
            }
        }

        private void UpdateBanButton()
        {
            if (_userDetail.AccountStatus)
            {
                btnBan.Text = "🔒 Khóa TK";
                btnBan.FillColor = Color.FromArgb(239, 68, 68);
            }
            else
            {
                btnBan.Text = "🔓 Mở khóa";
                btnBan.FillColor = Color.FromArgb(16, 185, 129);
            }
        }

        // Helper methods to build UI
        private void AddSectionLabel(Panel panel, string text, ref int yPos)
        {
            var lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 30, 50),
                Location = new Point(20, yPos),
                Size = new Size(650, 25),
                BorderStyle = BorderStyle.None
            };
            panel.Controls.Add(lbl);
            yPos += 35;
        }

        private void AddInfoRow(Panel panel, string label, string value, ref int yPos, Color? valueColor = null)
        {
            var lblLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(20, yPos),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 10F),
                ForeColor = valueColor ?? Color.FromArgb(20, 30, 50),
                Location = new Point(230, yPos),
                Size = new Size(440, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(lblLabel);
            panel.Controls.Add(lblValue);
            yPos += 30;
        }

        private void AddStatCard(Panel panel, string label, string value, Color color, ref int yPos)
        {
            var pnl = new Guna.UI2.WinForms.Guna2Panel
            {
                Location = new Point(20, yPos),
                Size = new Size(650, 60),
                BorderRadius = 8,
                FillColor = Color.FromArgb(245, 245, 245),
                BorderColor = color,
                BorderThickness = 2
            };

            var lblLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(15, 10),
                Size = new Size(620, 20)
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 28),
                Size = new Size(620, 25)
            };

            pnl.Controls.Add(lblLabel);
            pnl.Controls.Add(lblValue);
            panel.Controls.Add(pnl);
            yPos += 70;
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userDetail.AccountStatus)
                {
                    // Ban account
                    var reasonForm = new Form
                    {
                        Text = "Lý do khóa tài khoản",
                        Size = new Size(400, 200),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    var txtReason = new Guna.UI2.WinForms.Guna2TextBox
                    {
                        Location = new Point(20, 20),
                        Size = new Size(340, 80),
                        Multiline = true,
                        PlaceholderText = "Nhập lý do khóa tài khoản..."
                    };

                    var btnOK = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = "Xác nhận",
                        Location = new Point(160, 120),
                        Size = new Size(100, 35),
                        FillColor = Color.FromArgb(239, 68, 68)
                    };

                    var btnCancel = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = "Hủy",
                        Location = new Point(270, 120),
                        Size = new Size(90, 35),
                        FillColor = Color.Gray
                    };

                    btnOK.Click += (s, ev) => { reasonForm.DialogResult = DialogResult.OK; reasonForm.Close(); };
                    btnCancel.Click += (s, ev) => { reasonForm.DialogResult = DialogResult.Cancel; reasonForm.Close(); };

                    reasonForm.Controls.AddRange(new Control[] { txtReason, btnOK, btnCancel });

                    if (reasonForm.ShowDialog() == DialogResult.OK)
                    {
                        string reason = string.IsNullOrWhiteSpace(txtReason.Text) ? "Vi phạm chính sách" : txtReason.Text;
                        
                        bool success = _service.BanAccount(_userDetail.AccountID, AppSession.Instance.AccountID, reason);
                        
                        if (success)
                        {
                            MessageBox.Show("Đã khóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData(); // Refresh
                        }
                        else
                        {
                            MessageBox.Show("Không thể khóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Unban account
                    var confirm = MessageBox.Show($"Bạn có chắc muốn mở khóa tài khoản cho {_userDetail.FullName}?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        bool success = _service.UnbanAccount(_userDetail.AccountID, AppSession.Instance.AccountID);
                        
                        if (success)
                        {
                            MessageBox.Show("Đã mở khóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData(); // Refresh
                        }
                        else
                        {
                            MessageBox.Show("Không thể mở khóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}