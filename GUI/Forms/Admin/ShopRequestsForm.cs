using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.BLL.Services.Admin; // Đảm bảo namespace đúng service
using Skynet_Commerce.GUI.Forms.Admin;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

            // Xem chi tiết
            var itemDetail = menu.Items.Add("Xem chi tiết");
            itemDetail.ForeColor = Color.FromArgb(59, 130, 246);
            itemDetail.Click += (s, ev) =>
            {
                var detailForm = new ShopRequestDetailForm(item.RegistrationID);
                detailForm.ShowDialog();
            };

            menu.Items.Add(new ToolStripSeparator());

            var itemApprove = menu.Items.Add("✓ Duyệt đăng ký");
            itemApprove.Image = SystemIcons.Shield.ToBitmap(); // Hoặc dùng ImageHelper nếu muốn
            itemApprove.ForeColor = Color.Green;
            itemApprove.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Duyệt cửa hàng '{item.ShopName}'?\n\nTài khoản sẽ được cấp quyền Seller.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Approve shop registration
                        _shopService.ApproveShopRegistration(item.RegistrationID);

                        // Grant Seller role to the account
                        using (var context = new Skynet_Ecommerce.ApplicationDbContext())
                        {
                            var registration = context.ShopRegistrations.Find(item.RegistrationID);
                            if (registration != null)
                            {
                                // Check if user already has Seller role
                                bool hasSellerRole = context.UserRoles.Any(ur => 
                                    ur.AccountID == registration.AccountID && 
                                    ur.RoleName == "Seller");

                                if (!hasSellerRole)
                                {
                                    var newRole = new UserRole
                                    {
                                        AccountID = registration.AccountID,
                                        RoleName = "Seller",
                                        CreatedAt = DateTime.Now
                                    };
                                    context.UserRoles.Add(newRole);
                                    context.SaveChanges();
                                }
                            }
                        }

                        MessageBox.Show("Đã duyệt thành công và cấp quyền Seller!", "Thông báo");
                        LoadPendingShops(); // Refresh lại
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            };

            var itemReject = menu.Items.Add("✖ Từ chối");
            itemReject.ForeColor = Color.Red;
            itemReject.Click += (s, ev) =>
            {
                // Prompt for rejection reason
                using (var reasonForm = new Form())
                {
                    reasonForm.Text = "Lý do từ chối";
                    reasonForm.Size = new Size(450, 250);
                    reasonForm.StartPosition = FormStartPosition.CenterParent;
                    reasonForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    reasonForm.MaximizeBox = false;
                    reasonForm.MinimizeBox = false;

                    var lblPrompt = new Label
                    {
                        Text = "Nhập lý do từ chối đơn đăng ký:",
                        Location = new Point(20, 20),
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                    };

                    var txtReason = new Guna.UI2.WinForms.Guna2TextBox
                    {
                        Location = new Point(20, 50),
                        Size = new Size(390, 100),
                        Multiline = true,
                        PlaceholderText = "Ví dụ: Thông tin CCCD không hợp lệ...",
                        BorderRadius = 8
                    };

                    var btnOK = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = "Xác nhận",
                        Location = new Point(220, 170),
                        Size = new Size(90, 36),
                        FillColor = Color.FromArgb(239, 68, 68),
                        BorderRadius = 8
                    };
                    btnOK.Click += (s2, e2) => { reasonForm.DialogResult = DialogResult.OK; };

                    var btnCancel = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = "Hủy",
                        Location = new Point(320, 170),
                        Size = new Size(90, 36),
                        FillColor = Color.FromArgb(100, 100, 100),
                        BorderRadius = 8
                    };
                    btnCancel.Click += (s2, e2) => { reasonForm.DialogResult = DialogResult.Cancel; };

                    reasonForm.Controls.Add(lblPrompt);
                    reasonForm.Controls.Add(txtReason);
                    reasonForm.Controls.Add(btnOK);
                    reasonForm.Controls.Add(btnCancel);

                    if (reasonForm.ShowDialog() == DialogResult.OK)
                    {
                        string reason = txtReason.Text.Trim();
                        if (string.IsNullOrEmpty(reason))
                        {
                            MessageBox.Show("Vui lòng nhập lý do từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            // Update Description field with rejection reason
                            using (var context = new Skynet_Ecommerce.ApplicationDbContext())
                            {
                                var registration = context.ShopRegistrations.Find(item.RegistrationID);
                                if (registration != null)
                                {
                                    registration.RejectionReason = reason;
                                    context.SaveChanges();
                                }
                            }

                            // Reject the registration
                            _shopService.RejectShopRegistration(item.RegistrationID);
                            MessageBox.Show("Đã từ chối đơn đăng ký.", "Thông báo");
                            LoadPendingShops();
                        }
                        catch (Exception ex) 
                        { 
                            MessageBox.Show("Lỗi: " + ex.Message); 
                        }
                    }
                }
            };

            Rectangle cellRect = _dgvPending.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            menu.Show(_dgvPending, cellRect.Left, cellRect.Bottom);
        }
    }
}