using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Skynet_Ecommerce.GUI.Forms.Seller
{
    public partial class SellerOrderForm : Form
    {
        private Guna2Panel panelHeader;
        private Label lblTitle;
        private Guna2Panel panelControls;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cmbStatusFilter;
        private Guna2DataGridView dgvOrders;
        private Guna2Panel panelPagination;
        private Guna2Button btnPrevPage;
        private Guna2Button btnNextPage;
        private Label lblPageInfo;



        private void InitializeComponent()
        {
            this.panelHeader = new Guna2Panel();
            this.lblTitle = new Label();
            this.panelControls = new Guna2Panel();
            this.txtSearch = new Guna2TextBox();
            this.cmbStatusFilter = new Guna2ComboBox();
            this.dgvOrders = new Guna2DataGridView();
            this.panelPagination = new Guna2Panel();
            this.btnPrevPage = new Guna2Button();
            this.btnNextPage = new Guna2Button();
            this.lblPageInfo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelPagination.SuspendLayout();
            this.SuspendLayout();

            // ======================
            // Panel Header
            // ======================
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.FillColor = Color.FromArgb(31, 30, 68);
            this.panelHeader.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "Quản lý Đơn hàng";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 15);

            // ======================
            // Panel Controls (Search + Filter)
            // ======================
            this.panelControls.Dock = DockStyle.Top;
            this.panelControls.Height = 60;
            this.panelControls.FillColor = Color.Transparent;
            this.panelControls.Padding = new Padding(20, 10, 20, 10);
            this.panelControls.Controls.Add(this.txtSearch);
            this.panelControls.Controls.Add(this.cmbStatusFilter);

            // Search box
            this.txtSearch.PlaceholderText = "Tìm kiếm đơn hàng...";
            this.txtSearch.Size = new Size(300, 40);
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Location = new Point(0, 10);

            // Status filter
            this.cmbStatusFilter.Size = new Size(180, 40);
            this.cmbStatusFilter.Location = new Point(320, 10);
            this.cmbStatusFilter.BorderRadius = 10;
            this.cmbStatusFilter.Items.AddRange(new string[]
            {
                "Tất cả", "Chờ xác nhận", "Xác nhận", "Đang chuẩn bị", "Đang giao", "Hoàn thành", "Hủy"
            });
            this.cmbStatusFilter.SelectedIndex = 0;
            this.cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;

            // ======================
            // DataGridView Orders
            // ======================
            this.dgvOrders.Dock = DockStyle.Fill;
            this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = Color.White;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            this.dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvOrders.RowTemplate.Height = 40;
            this.dgvOrders.GridColor = Color.LightGray;
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Các cột dữ liệu
            this.dgvOrders.Columns.Add("Id", "ID");
            this.dgvOrders.Columns.Add("Customer", "Khách hàng");
            this.dgvOrders.Columns.Add("Date", "Ngày đặt");
            this.dgvOrders.Columns.Add("Total", "Tổng tiền");
            this.dgvOrders.Columns.Add("Status", "Trạng thái");

            // Nút Cập nhật đơn
            var updateBtn = new DataGridViewImageColumn();
            updateBtn.HeaderText = "";
            updateBtn.Image = Properties.Resources.LOGO; // icon cập nhật
            updateBtn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            updateBtn.Width = 40;
            this.dgvOrders.Columns.Add(updateBtn);

            // Nút Xem chi tiết
            var viewBtn = new DataGridViewImageColumn();
            viewBtn.HeaderText = "";
            viewBtn.Image = Properties.Resources.LOGO; // icon xem chi tiết
            viewBtn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            viewBtn.Width = 40;
            this.dgvOrders.Columns.Add(viewBtn);

            this.dgvOrders.CellClick += DgvOrders_CellClick;

            // ======================
            // Panel Pagination
            // ======================
            this.panelPagination.Dock = DockStyle.Bottom;
            this.panelPagination.Height = 50;
            this.panelPagination.FillColor = Color.Transparent;
            this.panelPagination.Controls.Add(this.btnPrevPage);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNextPage);

            this.btnPrevPage.Text = "<";
            this.btnPrevPage.Size = new Size(40, 30);
            this.btnPrevPage.Location = new Point(300, 10);
            this.btnPrevPage.Click += BtnPrevPage_Click;

            this.btnNextPage.Text = ">";
            this.btnNextPage.Size = new Size(40, 30);
            this.btnNextPage.Location = new Point(380, 10);
            this.btnNextPage.Click += BtnNextPage_Click;

            this.lblPageInfo.Text = "1 / 10";
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new Point(350, 15);
            this.lblPageInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // ======================
            // SellerOrderForm
            // ======================
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelHeader);
            this.Text = "Quản lý đơn hàng";
            this.StartPosition = FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.ResumeLayout(false);
        }

        // ======================
        // Demo Data & Logic
        // ======================
        private void LoadDemoOrders()
        {
            dgvOrders.Rows.Clear();
            dgvOrders.Rows.Add("1", "Nguyen Van A", "2026-01-17", "500,000", "Chờ xác nhận");
            dgvOrders.Rows.Add("2", "Tran Thi B", "2026-01-16", "1,200,000", "Đang chuẩn bị");
            dgvOrders.Rows.Add("3", "Le Van C", "2026-01-15", "800,000", "Đang giao");
            dgvOrders.Rows.Add("4", "Pham Thi D", "2026-01-14", "2,000,000", "Hoàn thành");
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Lọc theo trạng thái: " + cmbStatusFilter.SelectedItem);
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang trước");
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang sau");
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var status = dgvOrders.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            // Cột cập nhật
            if (e.ColumnIndex == dgvOrders.Columns.Count - 2)
            {
                if (status == "Hoàn thành" || status == "Đã giao" || status == "Hủy")
                {
                    MessageBox.Show("Không thể cập nhật trạng thái đơn này!");
                    return;
                }

                // Tuần tự cập nhật trạng thái
                string newStatus = status;

                switch (status)
                {
                    case "Chờ xác nhận":
                        newStatus = "Xác nhận";
                        break;
                    case "Xác nhận":
                        newStatus = "Đang chuẩn bị";
                        break;
                    case "Đang chuẩn bị":
                        newStatus = "Đang giao";
                        break;
                    case "Đang giao":
                        newStatus = "Hoàn thành";
                        break;
                    default:
                        newStatus = status;
                        break;
                }

                dgvOrders.Rows[e.RowIndex].Cells["Status"].Value = newStatus;
                MessageBox.Show($"Đơn {dgvOrders.Rows[e.RowIndex].Cells["Id"].Value} cập nhật: {newStatus}");
            }

            // Cột xem chi tiết
            if (e.ColumnIndex == dgvOrders.Columns.Count - 1)
            {
                MessageBox.Show("Xem chi tiết đơn: " + dgvOrders.Rows[e.RowIndex].Cells["Id"].Value);
            }
        }
    }
}
