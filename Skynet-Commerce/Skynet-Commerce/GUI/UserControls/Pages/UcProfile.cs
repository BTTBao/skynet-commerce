using Skynet_Commerce.GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls.Pages
{
    public partial class UcProfile : UserControl
    {
        private FrmMain main;
        public UcProfile(FrmMain main)
        {
            this.main = main;
            InitializeComponent();
        }
    }
}
