using Guna.UI2.WinForms;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages.User
{
    public partial class UcOrderHistory : UserControl
    {
        private FrmMain main;
        private string _currentFilter = "All";
        private bool _isLoading = false;

        public UcOrderHistory(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
            BindEvents();
            LoadData("All");
        }

        public UcOrderHistory() : this(null) { }

        private void BindEvents()
        {
            if (btnTabAll != null) { btnTabAll.Click -= OnTabClick; btnTabAll.Click += OnTabClick; }
            if (btnTabPending != null) { btnTabPending.Click -= OnTabClick; btnTabPending.Click += OnTabClick; }
            if (btnTabShipping != null) { btnTabShipping.Click -= OnTabClick; btnTabShipping.Click += OnTabClick; }
            if (btnTabCompleted != null) { btnTabCompleted.Click -= OnTabClick; btnTabCompleted.Click += OnTabClick; }
            if (btnTabCancelled != null) { btnTabCancelled.Click -= OnTabClick; btnTabCancelled.Click += OnTabClick; }
        }

        private void OnTabClick(object sender, EventArgs e)
        {
            if (_isLoading) return;
            Guna2Button btn = sender as Guna2Button;
            if (btn == null) return;

            ResetTabColors();
            btn.ForeColor = Color.Red;
            btn.CustomBorderColor = Color.Red;

            _currentFilter = "All";
            if (btn == btnTabPending) _currentFilter = "Pending";
            else if (btn == btnTabShipping) _currentFilter = "Shipping";
            else if (btn == btnTabCompleted) _currentFilter = "Completed";
            else if (btn == btnTabCancelled) _currentFilter = "Cancelled";

            LoadData(_currentFilter);
        }

        private void ResetTabColors()
        {
            foreach (Control c in pnlTabs.Controls)
            {
                if (c is Guna2Button btn)
                {
                    btn.ForeColor = Color.Black;
                    btn.CustomBorderColor = Color.Transparent;
                }
            }
        }

        private async void LoadData(string filterStatus)
        {
            if (_isLoading) return;
            _isLoading = true;
            flowPanelOrders.Controls.Clear();

            try
            {
                int accId = AppSession.Instance.AccountID;

                using (var db = new ApplicationDbContext())
                {
                    var query = db.Orders
                        .AsNoTracking()
                        .Include(o => o.Shop)
                        .Include(o => o.UserAddress) // <--- THÊM DÒNG NÀY ĐỂ LẤY ĐỊA CHỈ
                        .Include(o => o.OrderDetails.Select(od => od.Product.ProductImages))
                        .Where(o => o.AccountID == accId);

                    if (filterStatus != "All")
                    {
                        query = query.Where(o => o.Status == filterStatus);
                    }

                    var rawList = await Task.Run(() =>
                        query.OrderByDescending(o => o.CreatedAt).ToList()
                    );

                    var uniqueOrders = rawList
                        .GroupBy(o => o.OrderID)
                        .Select(g => g.First())
                        .ToList();

                    flowPanelOrders.Controls.Clear();

                    if (uniqueOrders.Count == 0)
                    {
                        Label lbl = new Label { Text = "Chưa có đơn hàng nào.", AutoSize = true, Font = new Font("Segoe UI", 12), Padding = new Padding(20) };
                        flowPanelOrders.Controls.Add(lbl);
                    }
                    else
                    {
                        var controlList = new List<Control>();

                        foreach (var item in uniqueOrders)
                        {
                            UcOrderDetail card = new UcOrderDetail();

                            var firstDetail = item.OrderDetails.FirstOrDefault();
                            string productName = "Sản phẩm không tồn tại";
                            string imgUrl = "";
                            decimal price = 0;
                            int qty = 0;

                            if (firstDetail != null && firstDetail.Product != null)
                            {
                                productName = firstDetail.Product.Name;
                                price = firstDetail.UnitPrice ?? 0;
                                qty = firstDetail.Quantity ?? 1;
                                var firstImg = firstDetail.Product.ProductImages.FirstOrDefault();
                                if (firstImg != null) imgUrl = firstImg.ImageURL;
                            }

                            // Lấy chuỗi địa chỉ từ UserAddress
                            string addressStr = "Địa chỉ không xác định";
                            if (item.UserAddress != null)
                            {
                                addressStr = $"{item.UserAddress.AddressLine}, {item.UserAddress.Ward}, {item.UserAddress.District}, {item.UserAddress.Province}";
                            }

                            card.SetData(
                                item.OrderID, item.CreatedAt, item.Shop?.ShopName ?? "Shop ẩn danh",
                                item.Status, item.TotalAmount ?? 0, productName,
                                item.OrderDetails.Count, imgUrl, price, qty,
                                addressStr // <--- Truyền địa chỉ xuống đây
                            );

                            card.Width = flowPanelOrders.Width - 25;

                            card.ButtonCancelClicked += HandleCancelOrder;
                            card.ButtonReceiveClicked += HandleReceiveOrder;
                            card.ButtonBuyAgainClicked += HandleBuyAgain;

                            controlList.Add(card);
                        }

                        flowPanelOrders.Controls.AddRange(controlList.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        // --- LOGIC NÚT BẤM (Giữ nguyên) ---
        private async void HandleCancelOrder(object sender, int orderId)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var order = await db.Orders.FindAsync(orderId);
                    if (order != null && order.Status == "Pending")
                    {
                        order.Status = "Cancelled";
                        await db.SaveChangesAsync();
                        MessageBox.Show("Đã hủy đơn!");
                        LoadData(_currentFilter);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void HandleReceiveOrder(object sender, int orderId)
        {
            if (MessageBox.Show("Xác nhận đã nhận hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var order = await db.Orders.FindAsync(orderId);
                    if (order != null && order.Status == "Shipping")
                    {
                        order.Status = "Completed";
                        await db.SaveChangesAsync();
                        MessageBox.Show("Cảm ơn bạn đã mua hàng!");
                        LoadData(_currentFilter);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void HandleBuyAgain(object sender, int orderId)
        {
            MessageBox.Show("Chức năng mua lại đang phát triển.");
        }
    }
}