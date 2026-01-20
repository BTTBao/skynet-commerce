using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin; // Đảm bảo namespace đúng service
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopRequestsForm : Form
    {
        private readonly ShopService _shopService;

        public ShopRequestsForm()
        {
            InitializeComponent();
            _shopService = new ShopService();

            // Setup Grid UI
            _dgvPending.CellMouseEnter += (s, e) => { if (e.RowIndex >= 0) _dgvPending.Cursor = Cursors.Hand; };
            _dgvPending.CellMouseLeave += (s, e) => { _dgvPending.Cursor = Cursors.Default; };
            _dgvPending.CellContentClick += _dgvPending_CellContentClick;
        }

        private void ShopRequestsForm_Load(object sender, EventArgs e)
        {
            LoadPendingShops();
        }

        private void LoadPendingShops()
        {
            List<PendingShopViewModel> pendingList = _shopService.GetPendingRegistrations();
            _dgvPending.AutoGenerateColumns = false;
            _dgvPending.DataSource = pendingList;
        }

        private void _dgvPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgvPending.Columns[e.ColumnIndex].Name != "colP_Action") return;

            var item = _dgvPending.Rows[e.RowIndex].DataBoundItem as PendingShopViewModel;
            if (item == null) return;

            ContextMenuStrip menu = new ContextMenuStrip();

            var itemApprove = menu.Items.Add("Duyệt đăng ký");
            itemApprove.Image = SystemIcons.Shield.ToBitmap(); // Hoặc dùng ImageHelper nếu muốn
            itemApprove.ForeColor = Color.Green;
            itemApprove.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Duyệt cửa hàng '{item.ShopName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _shopService.ApproveShopRegistration(item.RegistrationID);
                        MessageBox.Show("Đã duyệt thành công!", "Thông báo");
                        LoadPendingShops(); // Refresh lại
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            };

            var itemReject = menu.Items.Add("Từ chối");
            itemReject.ForeColor = Color.Red;
            itemReject.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Từ chối đơn đăng ký này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _shopService.RejectShopRegistration(item.RegistrationID);
                        MessageBox.Show("Đã từ chối.");
                        LoadPendingShops();
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            };

            Rectangle cellRect = _dgvPending.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvPending, cellRect.Left, cellRect.Bottom);
        }
    }
}