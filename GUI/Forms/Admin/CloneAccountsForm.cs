using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Skynet_Ecommerce.BLL.Services.Admin;
using Skynet_Commerce.DAL.Entities;

namespace Skynet_Commerce.GUI.Forms.Admin
{
    public partial class CloneAccountsForm : Form
    {
        private SettlementService _service;
        private List<CloneAccountDTO> _currentData;

        public CloneAccountsForm()
        {
            InitializeComponent();
            _service = new SettlementService();
            _currentData = new List<CloneAccountDTO>();
        }

        private void CloneAccountsForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCloneAccounts();
        }

        private void SetupDataGridView()
        {
            dgvCloneAccounts.Columns.Clear();
            dgvCloneAccounts.AutoGenerateColumns = false;

            // ReceiverPhone
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReceiverPhone",
                HeaderText = "SĐT người nhận",
                Name = "colReceiverPhone",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(239, 68, 68)
                }
            });

            // AccountCount
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AccountCount",
                HeaderText = "Số TK trùng",
                Name = "colAccountCount",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(239, 68, 68)
                }
            });

            // AccountID
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AccountID",
                HeaderText = "ID TK",
                Name = "colAccountID",
                Width = 60
            });

            // FullName
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ tên",
                Name = "colFullName",
                Width = 180
            });

            // Email
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "colEmail",
                Width = 200
            });

            // TotalOrders
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalOrders",
                HeaderText = "Tổng đơn",
                Name = "colTotalOrders",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(59, 130, 246)
                }
            });

            // CancelledOrders
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CancelledOrders",
                HeaderText = "Đơn hủy",
                Name = "colCancelledOrders",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(239, 68, 68)
                }
            });

            // IsActive (Status)
            dgvCloneAccounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Trạng thái",
                Name = "colIsActive",
                Width = 110
            });

            // Ban Button
            var btnBan = new DataGridViewButtonColumn
            {
                HeaderText = "Hành động",
                Name = "colBan",
                Text = "🔒 Khóa",
                UseColumnTextForButtonValue = false,
                Width = 100
            };
            dgvCloneAccounts.Columns.Add(btnBan);

            dgvCloneAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCloneAccounts.CellFormatting += dgvCloneAccounts_CellFormatting;
        }

        private void LoadCloneAccounts()
        {
            _currentData = _service.GetCloneAccounts();
            dgvCloneAccounts.DataSource = _currentData;
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            lblTotalAccounts.Text = $"Tổng tài khoản: {_currentData.Count}";
            
            int uniquePhones = _currentData.Select(x => x.ReceiverPhone).Distinct().Count();
            lblTotalPhones.Text = $"SĐT trùng lặp: {uniquePhones}";
        }

        private void dgvCloneAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCloneAccounts.Columns[e.ColumnIndex].Name == "colIsActive")
            {
                if (e.Value is bool isActive)
                {
                    e.Value = isActive ? "✅ Hoạt động" : "🔒 Đã khóa";
                    e.CellStyle.ForeColor = isActive ? Color.FromArgb(0, 150, 136) : Color.FromArgb(239, 68, 68);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }

            if (dgvCloneAccounts.Columns[e.ColumnIndex].Name == "colBan")
            {
                var row = dgvCloneAccounts.Rows[e.RowIndex];
                if (row.DataBoundItem is CloneAccountDTO item)
                {
                    if (!item.IsActive)
                    {
                        e.Value = "✔️ Đã khóa";
                    }
                    else
                    {
                        e.Value = "🔒 Khóa";
                    }
                }
            }
        }

        private void dgvCloneAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCloneAccounts.Columns[e.ColumnIndex].Name == "colBan")
            {
                var item = _currentData[e.RowIndex];

                if (!item.IsActive)
                {
                    MessageBox.Show("Tài khoản này đã bị khóa trước đó.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc muốn KHÓA tài khoản?\n\n" +
                    $"ID: {item.AccountID}\n" +
                    $"Họ tên: {item.FullName}\n" +
                    $"Email: {item.Email}\n" +
                    $"SĐT nhận: {item.ReceiverPhone}\n\n" +
                    $"⚠️ Hành động này sẽ vô hiệu hóa tài khoản và gửi thông báo cho người dùng!",
                    "Xác nhận khóa tài khoản",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        string reason = $"Phát hiện sử dụng SĐT người nhận trùng lặp ({item.ReceiverPhone}) với {item.AccountCount} tài khoản khác - Nghi ngờ gian lận tạo clone account";
                        
                        int adminId = AppSession.Instance.AccountID;
                        bool success = _service.BanAccount(item.AccountID, adminId, reason);

                        if (success)
                        {
                            MessageBox.Show("Đã khóa tài khoản thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCloneAccounts(); // Reload data
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi khóa tài khoản: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCloneAccounts();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
