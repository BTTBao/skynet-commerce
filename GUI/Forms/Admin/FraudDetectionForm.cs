using Skynet_Commerce.BLL.Services.Admin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class FraudDetectionForm : Form
    {
        private readonly FraudDetectionService _service;

        // State variables
        private int _selectedUserId = -1;
        private string _selectedUserName = "";

        private int _selectedShopId = -1;
        private string _selectedShopName = "";

        public FraudDetectionForm()
        {
            InitializeComponent();
            _service = new FraudDetectionService();

            // Form Load
            this.Load += FraudDetectionForm_Load;

            // Events Tab 1 (User)
            this.btnFilter.Click += BtnFilter_Click;
            this.gridUsers.CellClick += GridUsers_CellClick;
            this.gridUsers.CellFormatting += GridUsers_CellFormatting;
            this.btnLockAccount.Click += BtnLockAccount_Click;

            // Events Tab 2 (Shop)
            this.gridShops.CellClick += GridShops_CellClick;
            this.btnLockShop.Click += BtnLockShop_Click;
        }

        private void FraudDetectionForm_Load(object sender, EventArgs e)
        {
            LoadUserRisks();
            LoadShopRisks();
            LoadCloneRisks();
        }

        // ==========================================
        // TAB 1: USER RISK LOGIC
        // ==========================================
        private void BtnFilter_Click(object sender, EventArgs e) => LoadUserRisks();

        private void LoadUserRisks()
        {
            try
            {
                double minRate = 50;
                if (cboRiskLevel.SelectedIndex == 0) minRate = 30;
                if (cboRiskLevel.SelectedIndex == 2) minRate = 70;

                gridUsers.DataSource = _service.GetHighRiskUsers(5, minRate);

                if (gridUsers.Columns["UserID"] != null) gridUsers.Columns["UserID"].HeaderText = "ID";
                if (gridUsers.Columns["FullName"] != null) gridUsers.Columns["FullName"].HeaderText = "Họ Tên";
                if (gridUsers.Columns["Phone"] != null) gridUsers.Columns["Phone"].HeaderText = "SĐT";
                if (gridUsers.Columns["TotalOrders"] != null) gridUsers.Columns["TotalOrders"].HeaderText = "Tổng Đơn";
                if (gridUsers.Columns["CancelledOrders"] != null) gridUsers.Columns["CancelledOrders"].HeaderText = "Đơn Hủy";
                if (gridUsers.Columns["CancelRate"] != null)
                {
                    gridUsers.Columns["CancelRate"].HeaderText = "Tỷ lệ Hủy (%)";
                    gridUsers.Columns["CancelRate"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải User: " + ex.Message);
            }
        }

        private void GridUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridUsers.Columns[e.ColumnIndex].Name == "CancelRate")
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out double rate))
                {
                    if (rate >= 80)
                    {
                        e.CellStyle.BackColor = Color.MistyRose;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                    else if (rate >= 50)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void GridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridUsers.Rows[e.RowIndex];
                _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
                _selectedUserName = row.Cells["FullName"].Value?.ToString();
                var rate = row.Cells["CancelRate"].Value?.ToString();

                lblSelectedUser.Text = $"User: {_selectedUserName} (ID: {_selectedUserId}) - Tỷ lệ: {rate}%";
                lblSelectedUser.ForeColor = Color.Black;
                btnLockAccount.Enabled = true;
            }
        }

        private void BtnLockAccount_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == -1) return;
            if (MessageBox.Show($"Khóa tài khoản '{_selectedUserName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_service.LockAccount(_selectedUserId))
                {
                    MessageBox.Show("Đã khóa thành công.");
                    LoadUserRisks();
                    btnLockAccount.Enabled = false;
                    _selectedUserId = -1;
                    lblSelectedUser.Text = "Chọn User để xử lý...";
                }
                else MessageBox.Show("Lỗi khi khóa.");
            }
        }

        // ==========================================
        // TAB 2: SHOP RISK LOGIC
        // ==========================================
        private void LoadShopRisks()
        {
            try
            {
                gridShops.DataSource = _service.GetShopSpammers();

                if (gridShops.Columns["ShopID"] != null) gridShops.Columns["ShopID"].HeaderText = "Mã Shop";
                if (gridShops.Columns["ShopName"] != null) gridShops.Columns["ShopName"].HeaderText = "Tên Shop";
                if (gridShops.Columns["ReviewerID"] != null) gridShops.Columns["ReviewerID"].HeaderText = "User Buff";
                if (gridShops.Columns["ReviewCount"] != null) gridShops.Columns["ReviewCount"].HeaderText = "Số Review";
                if (gridShops.Columns["TimeSpanMinutes"] != null) gridShops.Columns["TimeSpanMinutes"].HeaderText = "Trong (phút)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Shop: " + ex.Message);
            }
        }

        private void GridShops_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = gridShops.Rows[e.RowIndex];
                _selectedShopId = Convert.ToInt32(row.Cells["ShopID"].Value);
                _selectedShopName = row.Cells["ShopName"].Value?.ToString();

                lblSelectedShop.Text = $"Shop: {_selectedShopName} (ID: {_selectedShopId})";
                btnLockShop.Enabled = true;
            }
        }

        private void BtnLockShop_Click(object sender, EventArgs e)
        {
            if (_selectedShopId == -1) return;
            if (MessageBox.Show($"Khóa Shop '{_selectedShopName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_service.LockShop(_selectedShopId))
                {
                    MessageBox.Show("Đã khóa Shop thành công.");
                    LoadShopRisks();
                    btnLockShop.Enabled = false;
                    _selectedShopId = -1;
                    lblSelectedShop.Text = "Chọn Shop để xử lý...";
                }
                else MessageBox.Show("Lỗi khi khóa Shop.");
            }
        }

        // ==========================================
        // TAB 3: CLONE RISK LOGIC
        // ==========================================
        private void LoadCloneRisks()
        {
            try
            {
                gridClones.DataSource = _service.GetCloneAccounts();

                if (gridClones.Columns["ReceiverPhone"] != null) gridClones.Columns["ReceiverPhone"].HeaderText = "SĐT Trùng";
                if (gridClones.Columns["LinkedAccountsCount"] != null) gridClones.Columns["LinkedAccountsCount"].HeaderText = "Số Acc liên kết";
                if (gridClones.Columns["AccountIDs"] != null) gridClones.Columns["AccountIDs"].HeaderText = "Danh sách ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Clone: " + ex.Message);
            }
        }
    }
}