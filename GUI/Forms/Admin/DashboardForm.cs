using Guna.UI2.WinForms;
using Skynet_Commerce.DAL.Entities;
using Skynet_Ecommerce.BLL.Helpers;
using Skynet_Ecommerce.GUI.Forms.Login;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Skynet_Commerce.GUI.Forms;
using Skynet_Commerce.GUI.Forms.Admin;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            guna2PictureBox1.LoadAsync("https://cdn-icons-png.flaticon.com/128/1533/1533565.png");
            CreateSidebarItems();

            LoadPage(new DashboardOverviewForm());
        }

        private void LoadPage(Form childForm)
        {
            _mainPanel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(childForm);
            _mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private class MenuItemModel
        {
            public string Key { get; set; }
            public string Title { get; set; }
            public string IconUrl { get; set; }
            public List<MenuItemModel> SubItems { get; set; } = new List<MenuItemModel>();
        }

        private void CreateSidebarItems()
        {
            // --- CẤU HÌNH DATA MENU ---
            var menuData = new List<MenuItemModel>
            {
                new MenuItemModel { Key = "Dashboard", Title = "Tổng quan", IconUrl = "https://cdn-icons-png.flaticon.com/128/12255/12255013.png" },
                new MenuItemModel { Key = "Users", Title = "Người dùng", IconUrl = "https://cdn-icons-png.flaticon.com/128/33/33308.png" },
        
                // [QUAN TRỌNG] Item Cửa hàng có SubItems
                new MenuItemModel
                {
                    Key = "ShopsParent",
                    Title = "Cửa hàng                    ▼",
                    IconUrl = "https://cdn-icons-png.flaticon.com/128/8610/8610577.png",
                    SubItems = new List<MenuItemModel>
                    {
                        new MenuItemModel { Key = "ShopRequests", Title = "Duyệt cửa hàng", IconUrl = "https://cdn-icons-png.flaticon.com/128/157/157977.png" }, 
                        new MenuItemModel { Key = "ShopList", Title = "Tất cả cửa hàng", IconUrl = "https://cdn-icons-png.flaticon.com/128/443/443635.png" }
                    }
                },

                new MenuItemModel { Key = "Products", Title = "Sản phẩm", IconUrl = "https://cdn-icons-png.flaticon.com/128/10608/10608766.png" },
                new MenuItemModel { Key = "Orders", Title = "Đơn hàng", IconUrl = "https://cdn-icons-png.flaticon.com/128/10161/10161680.png" },
                
                // [MỚI] Item Tài chính có SubItems
                new MenuItemModel
                {
                    Key = "FinanceParent",
                    Title = "Tài chính                    ▼",
                    IconUrl = "https://cdn-icons-png.flaticon.com/128/2489/2489756.png",
                    SubItems = new List<MenuItemModel>
                    {
                        new MenuItemModel { Key = "Settlement", Title = "Đối soát công nợ", IconUrl = "https://cdn-icons-png.flaticon.com/128/3135/3135706.png" },
                        new MenuItemModel { Key = "PaymentHistory", Title = "Lịch sử thanh toán", IconUrl = "https://cdn-icons-png.flaticon.com/128/2331/2331966.png" }
                    }
                },
                
                new MenuItemModel { Key = "Categories", Title = "Danh mục", IconUrl = "https://cdn-icons-png.flaticon.com/128/12916/12916359.png" },
                new MenuItemModel { Key = "FraudDetection", Title = "Quản lý rủi ro", IconUrl = "https://cdn-icons-png.flaticon.com/128/4501/4501286.png" },
                new MenuItemModel { Key = "Logout", Title = "Đăng xuất", IconUrl = "https://cdn-icons-png.flaticon.com/128/4400/4400629.png" }
            };

            int yPos = 80; // Vị trí Y bắt đầu
            int btnHeight = 45;
            int gap = 5;

            // --- VÒNG LẶP TẠO MENU ---
            foreach (var item in menuData)
            {
                // 1. Tạo Nút Cha
                Guna2Button btnParent = CreateMenuButton(item.Title, item.IconUrl, item.Key, false);
                btnParent.Location = new Point(10, yPos);

                // Xử lý riêng cho Logout
                if (item.Key == "Logout")
                {
                    btnParent.Dock = DockStyle.Bottom;
                    btnParent.Margin = new Padding(10, 0, 30, 10);
                    btnParent.FillColor = Color.Transparent;
                    btnParent.ForeColor = Color.Red;
                    btnParent.Image = ImageHelper.Recolor(btnParent.Image, Color.Red);
                    btnParent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
                    _sidebar.Controls.Add(btnParent);
                    continue; // Logout nằm dưới cùng, không tính yPos tiếp
                }

                _sidebar.Controls.Add(btnParent);
                yPos += btnHeight + gap;

                // 2. Nếu có SubItems -> Tạo Panel con chứa các nút con
                if (item.SubItems.Count > 0)
                {
                    // Panel chứa sub-menu
                    Panel pnlSub = new Panel();
                    pnlSub.Width = 230;
                    pnlSub.Height = item.SubItems.Count * (40 + 5); // Chiều cao = số item con * (cao + gap)
                    pnlSub.Location = new Point(10, yPos);
                    pnlSub.BackColor = Color.Transparent;
                    pnlSub.Visible = false; // Mặc định ẩn
                    pnlSub.Tag = "SubPanel_" + item.Key; // Tag để tìm kiếm nếu cần

                    int subY = 0;
                    foreach (var sub in item.SubItems)
                    {
                        Guna2Button btnSub = CreateMenuButton(sub.Title, sub.IconUrl, sub.Key, true); // true = isSubItem
                        btnSub.Location = new Point(0, subY); // Vị trí tương đối trong Panel
                        btnSub.Size = new Size(230, 40); // Nhỏ hơn xíu

                        pnlSub.Controls.Add(btnSub);
                        subY += 45;
                    }

                    _sidebar.Controls.Add(pnlSub);

                    // Sự kiện Click cha -> Toggle Panel con
                    btnParent.Click += (s, e) =>
                    {
                        pnlSub.Visible = !pnlSub.Visible;
                        // Nếu muốn đẹp hơn: Thay đổi icon mũi tên ở đây
                        RearrangeSidebarItems(); // Hàm sắp xếp lại vị trí các nút bên dưới
                    };

                    // Mặc định tăng yPos ảo để chừa chỗ nếu nó mở (hoặc không, ở đây ta dùng hàm Rearrange)
                    // Ta set Tag cho btnParent biết nó có panel con nào
                    btnParent.Tag = pnlSub;
                }
            }
        }

        // 3. Hàm tạo Button chung (để code gọn hơn)
        private Guna2Button CreateMenuButton(string text, string iconUrl, string key, bool isSubItem)
        {
            Guna2Button btn = new Guna2Button();
            btn.Text = text;
            btn.FillColor = Color.Transparent;
            btn.ForeColor = isSubItem ? Color.LightGray : Color.White; // Sub item màu nhạt hơn
            btn.Font = new Font("Segoe UI", isSubItem ? 9 : 10, isSubItem ? FontStyle.Regular : FontStyle.Bold); // Sub item chữ nhỏ hơn

            // Icon
            if (!string.IsNullOrEmpty(iconUrl))
            {
                Image rawIcon = ImageHelper.LoadFromUrl(iconUrl);
                btn.Image = ImageHelper.Recolor(rawIcon, isSubItem ? Color.LightGray : Color.White);
                btn.ImageSize = new Size(20, 20);
                btn.ImageAlign = HorizontalAlignment.Left;
                btn.ImageOffset = new Point(isSubItem ? 25 : 10, 0); // Sub item icon thụt vào sâu hơn
                btn.TextOffset = new Point(30, 0);
                btn.TextAlign = HorizontalAlignment.Center;
            }
            else if (isSubItem)
            {
                // Nếu sub item không có icon, ta để Text thụt vào
                btn.TextOffset = new Point(40, 0);
                btn.TextAlign = HorizontalAlignment.Left;
            }

            if (!isSubItem && !string.IsNullOrEmpty(iconUrl)) btn.TextOffset = new Point(20, 0);
            else if (!isSubItem) btn.TextOffset = new Point(10, 0);

            btn.TextAlign = HorizontalAlignment.Left;
            btn.Size = new Size(230, 45);
            btn.BorderRadius = 8;
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn.BackColor = Color.Transparent;

            // Checked State
            btn.CheckedState.FillColor = Color.DimGray;
            btn.CheckedState.ForeColor = Color.White;

            // Gán Tag là Key để xử lý click
            // Lưu ý: Với nút cha có sub-menu, ta sẽ gán Tag là Panel ở vòng lặp trên, 
            // nên ở đây ta tạm gán Key vào Name hoặc một property khác nếu cần. 
            // Tuy nhiên, logic Sidebar_Click bên dưới dùng Tag, nên ta cứ gán key vào Tag trước.
            // Logic vòng lặp trên sẽ override Tag của Parent Button sau.
            btn.Tag = key;

            // Chỉ gán sự kiện chuyển trang cho SubItems hoặc ParentItems không có con
            if (key != "ShopsParent" && key != "FinanceParent")
            {
                btn.Click += Sidebar_Click;
            }

            return btn;
        }

        // 4. Hàm sắp xếp lại vị trí (Accordion effect)
        // Khi mở/đóng menu con, các nút bên dưới phải chạy lên/xuống
        private void RearrangeSidebarItems()
        {
            int yPos = 80;
            int gap = 5;

            foreach (Control ctrl in _sidebar.Controls)
            {
                // Bỏ qua Logo, Logout (vì Logout dock Bottom), và các control không liên quan
                if (ctrl is Guna2PictureBox) continue;
                if (ctrl is Guna2Button btn && btn.Dock == DockStyle.Bottom) continue;

                // Nếu là Button (Parent)
                if (ctrl is Guna2Button parentBtn && !(parentBtn.Tag is string)) // Tag không phải string -> Tag là Panel (logic ở bước 2)
                {
                    parentBtn.Location = new Point(10, yPos);
                    yPos += parentBtn.Height + gap;

                    // Check xem Panel con của nó có hiện không
                    if (parentBtn.Tag is Panel childPnl)
                    {
                        childPnl.Location = new Point(10, yPos);
                        if (childPnl.Visible)
                        {
                            yPos += childPnl.Height + gap;
                        }
                    }
                }
                // Nếu là Button thường (Key string) và KHÔNG nằm trong Panel con
                else if (ctrl is Guna2Button simpleBtn && simpleBtn.Parent == _sidebar)
                {
                    simpleBtn.Location = new Point(10, yPos);
                    yPos += simpleBtn.Height + gap;
                }
                // Nếu là Panel (Sub menu container)
                else if (ctrl is Panel pnl && pnl.Parent == _sidebar)
                {
                    // Panel vị trí đã được set theo Parent Button ở trên, nên ta không set ở đây
                    // hoặc ta có thể handle logic ở đây cũng được. 
                    // Tuy nhiên cách dễ nhất là handle theo cặp Parent-Child ở block "if parentBtn" phía trên.
                }
            }
        }
        private void Sidebar_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn == null) return;

            string menuName = btn.Tag?.ToString() ?? "";

            switch (menuName)
            {
                case "Dashboard": LoadPage(new DashboardOverviewForm()); break;
                case "Users": LoadPage(new UsersForm()); break;

                // --- HAI MỤC CỬAHÀNG ---
                case "ShopRequests": LoadPage(new ShopRequestsForm()); break; // Form Duyệt
                case "ShopList": LoadPage(new ShopsForm()); break;         // Form Danh sách

                case "Products": LoadPage(new ProductsForm()); break;
                case "Orders": LoadPage(new OrdersForm()); break;
                
                // --- MỤC TÀI CHÍNH ---
                case "Settlement": LoadPage(new SettlementForm()); break; // Form Đối soát
                case "PaymentHistory": LoadPage(new PaymentHistoryForm()); break; // Form Lịch sử thanh toán
                // -------------------
                
                case "Categories": LoadPage(new CategoriesForm()); break;
                case "FraudDetection": LoadPage(new FraudDetectionForm()); break;

                case "Logout":
                    if (MessageBox.Show("Bạn có chắc muốn đăng xuất khỏi trang Quản trị?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // 1. Xóa Session
                        AppSession.Instance.Clear();

                        // 2. Xóa Ghi nhớ trong Settings (QUAN TRỌNG)
                        Skynet_Ecommerce.Properties.Settings.Default.IsRemembered = false;
                        Skynet_Ecommerce.Properties.Settings.Default.RememberUser = "";
                        Skynet_Ecommerce.Properties.Settings.Default.RememberPass = "";
                        Skynet_Ecommerce.Properties.Settings.Default.Save();

                        // 3. Đóng form hiện tại và mở lại Login
                        this.Hide();
                        LoginForm login = new LoginForm();
                        login.ShowDialog();
                        this.Close();
                    }
                    break;
                default: break;
            }
        }
    }
}