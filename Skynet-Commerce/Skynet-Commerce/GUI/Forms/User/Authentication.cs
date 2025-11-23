using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        public void ShowControl(UserControl control)
        {
            panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
            control.Show();
        }

        public void ShowLogin()
        {
            this.Show();
            ShowControl(new UcLogin(this));
        }
    }
}
