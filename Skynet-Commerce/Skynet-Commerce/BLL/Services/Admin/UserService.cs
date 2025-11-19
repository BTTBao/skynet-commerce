using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using Skynet_Commerce.DAL.Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class UserService
    {
        private readonly UserRepository _repoUser;
        private readonly AccountRepository _repoAccount;
        private readonly ApplicationDbContext _context;

        public UserService()
        {
            _repoUser = new UserRepository();
            _repoAccount = new AccountRepository();
            _context = new ApplicationDbContext();
        }
        public List<UserViewModel> GetAllUsersForView()
        {
            var users = _repoUser.GetAll();
            var viewModels = new List<UserViewModel>();

            foreach(var s in users)
            {
                if (s.AccountID == null)
                    return null;

                var account = _repoAccount.GetByAccountId(s.AccountID.Value);
                var role = _context.UserRoles.FirstOrDefault(x => x.AccountID == s.AccountID);

                viewModels.Add(new UserViewModel
                {
                    UserID = s.UserID,
                    FullName = s.FullName,
                    Email = account.Email,
                    Phone = account.Phone,
                    RoleName = role.RoleName,
                    Status = account.IsActive == true ? "Active" : "Banned"
                });
            }
            return viewModels;
        }
    }
}
