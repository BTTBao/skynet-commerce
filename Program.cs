using Skynet_Ecommerce.BLL.Services.Auth;
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
            Form startupForm = AuthService.GetStartupForm();

            if (startupForm != null)
            {
                Application.Run(startupForm);
            }
        }
    }
}
