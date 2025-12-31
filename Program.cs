using Skynet_Commerce.GUI.Forms;
using Skynet_Ecommerce.GUI.Forms.Admin;
using System;
using System.Windows.Forms;

namespace Skynet_Ecommerce
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm());
        }
    }
}
