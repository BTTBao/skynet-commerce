using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcUserAddress : UserControl
    {
        private FrmMain main;

        // Cập nhật Constructor nhận FrmMain
        public UcUserAddress(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
            LoadAddresses();
            btnBack.Click += btnBack_Click;
        }

        // --- SỰ KIỆN NÚT QUAY LẠI ---
        private void btnBack_Click(object sender, EventArgs e)
        {
            main.LoadPage("Profile");
        }

        private async void LoadAddresses()
        {
            flowPanelAddresses.Controls.Clear();

            try
            {
                int accId = AppSession.Instance.AccountID;
                using (var db = new ApplicationDbContext())
                {
                    var list = await Task.Run(() => db.UserAddresses
                        .Where(a => a.AccountID == accId)
                        .OrderByDescending(a => a.IsDefault) // Mặc định lên đầu
                        .ThenByDescending(a => a.AddressID)
                        .ToList());

                    if (list.Count == 0)
                    {
                        Label lblEmpty = new Label { Text = "Bạn chưa có địa chỉ nào.", AutoSize = true, Padding = new Padding(20) };
                        flowPanelAddresses.Controls.Add(lblEmpty);
                        return;
                    }

                    foreach (var item in list)
                    {
                        flowPanelAddresses.Controls.Add(CreateAddressItem(item));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải địa chỉ: " + ex.Message);
            }
        }

        private Control CreateAddressItem(UserAddress addr)
        {
            Guna.UI2.WinForms.Guna2Panel pnlItem = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(950, 100),
                FillColor = Color.White,
                BorderRadius = 10,
                Margin = new Padding(5, 5, 5, 10),
                ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 0, 5, 5) }
            };

            Label lblInfo = new Label
            {
                Text = $"{addr.ReceiverFullName} | {addr.ReceiverPhone}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblDetail = new Label
            {
                Text = $"{addr.AddressLine}, {addr.Ward}, {addr.District}, {addr.Province}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(20, 45),
                AutoSize = true
            };

            if (addr.IsDefault == true)
            {
                Guna.UI2.WinForms.Guna2Button btnBadge = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "Mặc định",
                    FillColor = Color.Red,
                    ForeColor = Color.White,
                    BorderRadius = 5,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    Size = new Size(80, 25),
                    Location = new Point(20, 70),
                    Enabled = false
                };
                pnlItem.Controls.Add(btnBadge);
            }
            else
            {
                Guna.UI2.WinForms.Guna2Button btnSetDefault = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "Thiết lập mặc định",
                    FillColor = Color.White,
                    BorderColor = Color.Black,
                    BorderThickness = 1,
                    ForeColor = Color.Black,
                    BorderRadius = 5,
                    Size = new Size(140, 30),
                    Location = new Point(20, 65),
                    Cursor = Cursors.Hand
                };
                btnSetDefault.Click += (s, e) => SetDefaultAddress(addr.AddressID);
                pnlItem.Controls.Add(btnSetDefault);

                Guna.UI2.WinForms.Guna2Button btnDelete = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "Xóa",
                    FillColor = Color.Transparent,
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 9, FontStyle.Underline),
                    Size = new Size(60, 30),
                    Location = new Point(170, 65),
                    Cursor = Cursors.Hand
                };
                btnDelete.Click += (s, e) => DeleteAddress(addr.AddressID);
                pnlItem.Controls.Add(btnDelete);
            }

            pnlItem.Controls.Add(lblInfo);
            pnlItem.Controls.Add(lblDetail);

            return pnlItem;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtProvince.Text) || string.IsNullOrEmpty(txtAddressLine.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int accId = AppSession.Instance.AccountID;
                    int count = db.UserAddresses.Count(a => a.AccountID == accId);
                    if (count >= 5)
                    {
                        MessageBox.Show("Bạn chỉ được lưu tối đa 5 địa chỉ!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool isFirst = count == 0;
                    var newAddr = new UserAddress
                    {
                        AccountID = accId,
                        ReceiverFullName = txtName.Text.Trim(),
                        ReceiverPhone = txtPhone.Text.Trim(),
                        Province = txtProvince.Text.Trim(),
                        District = txtDistrict.Text.Trim(),
                        Ward = txtWard.Text.Trim(),
                        AddressLine = txtAddressLine.Text.Trim(),
                        IsDefault = isFirst,
                        AddressName = "Nhà riêng"
                    };

                    db.UserAddresses.Add(newAddr);
                    await db.SaveChangesAsync();

                    MessageBox.Show("Thêm địa chỉ thành công!");
                    ClearForm();
                    LoadAddresses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void SetDefaultAddress(int addressId)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    int accId = AppSession.Instance.AccountID;
                    var oldDefault = db.UserAddresses.FirstOrDefault(a => a.AccountID == accId && a.IsDefault == true);
                    if (oldDefault != null) oldDefault.IsDefault = false;

                    var newDefault = db.UserAddresses.Find(addressId);
                    if (newDefault != null) newDefault.IsDefault = true;

                    await db.SaveChangesAsync();
                    LoadAddresses();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void DeleteAddress(int addressId)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa địa chỉ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var addr = db.UserAddresses.Find(addressId);
                    if (addr != null)
                    {
                        db.UserAddresses.Remove(addr);
                        await db.SaveChangesAsync();
                        LoadAddresses();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

        private void ClearForm()
        {
            txtName.Clear(); txtPhone.Clear(); txtProvince.Clear();
            txtDistrict.Clear(); txtWard.Clear(); txtAddressLine.Clear();
        }
    }
}