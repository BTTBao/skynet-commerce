using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.Forms.User
{
    public partial class UcRegister : UserControl
    {
        private Authentication main;
        public UcRegister(Authentication main)
        {
            this.main = main;
            InitializeComponent();
        }
        private void ShowLogin()
        {
            if (main != null)
            {
                UcLogin login = new UcLogin(main);
                main.ShowControl(login);

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }
    }
}
