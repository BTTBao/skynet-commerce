using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcPendingShopRow : UserControl
    {
        // 1. Định nghĩa Event
        public event EventHandler OnApproveClicked;
        public event EventHandler OnRejectClicked;

        // Biến lưu ID để xử lý
        public int RegistrationID { get; private set; }

        public UcPendingShopRow()
        {
            InitializeComponent();
            // Kẻ đường line mờ dưới đáy
            this.Paint += (s, e) => {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), 0, this.Height - 1, this.Width, this.Height - 1);
            };

            // 2. Gắn sự kiện click cho nút nội bộ
            _btnApprove.Click += (s, e) => OnApproveClicked?.Invoke(this, EventArgs.Empty);
            _btnReject.Click += (s, e) => OnRejectClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(int id, string name, string owner, string email, string date)
        {
            this.RegistrationID = id;
            _lblId.Text = id.ToString();
            _lblName.Text = name;
            _lblOwner.Text = owner;
            _lblEmail.Text = email;
            _lblDate.Text = date;
        }
    }
}