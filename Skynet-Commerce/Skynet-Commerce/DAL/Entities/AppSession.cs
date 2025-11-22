using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.DAL.Entities
{
    public class AppSession
    {
        private static AppSession _instance;

        public static AppSession Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSession();
                return _instance;
            }
        }

        public int AccountID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsLoggedIn => AccountID > 0;

        private AppSession() { }
    }

}
