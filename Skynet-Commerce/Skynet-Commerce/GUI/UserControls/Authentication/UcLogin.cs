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
    public partial class UcLogin : UserControl
    {
        private Authentication main;
        public UcLogin(Authentication main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        public void ShowRegister()
        {
            UcRegister regis = new UcRegister(main);
            regis.Dock = DockStyle.Fill;
            main.ShowControl(regis);
        }
        private void btnRegis_Click(object sender, EventArgs e)
        {
            ShowRegister();
        }
    }
}
