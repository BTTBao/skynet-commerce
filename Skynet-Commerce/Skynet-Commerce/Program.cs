

using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.GUI.Forms;
using System;
using System.Windows.Forms;
namespace Skynet_Commerce
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
            Application.Run(new FrmMain()); // của bảo ở đây nhé
            //Application.Run(new SellerLayout(1));

            //Application.Run(new FrmMain());
        }

    }
}
