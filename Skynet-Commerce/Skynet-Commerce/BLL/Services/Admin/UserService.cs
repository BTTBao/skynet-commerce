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
        private readonly ApplicationDbContext _context;

        public UserService()
        {
            _context = new ApplicationDbContext();
        }
        public List<UserViewModel> GetAllUsersForView()
        {
            var result = _context.Users
                .Include("Account")
                .Include("Account.UserRoles")
                .Select(u => new UserViewModel
                {
                    UserID = u.UserID,
                    AccountID = u.Account.AccountID,
                    FullName = u.FullName,
                    Email = u.Account.Email,
                    Phone = u.Account.Phone,
                    RoleName = u.Account.UserRoles.FirstOrDefault().RoleName,
                    Status = u.Account.IsActive == true ? "Active" : "Banned"
                })
                .ToList();

            return result;
        }
        public bool UpdateUser(UserViewModel vm)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == vm.UserID);
            if (user == null) return false;

            var account = _context.Accounts.FirstOrDefault(x => x.AccountID == user.AccountID);
            if (account == null) return false;

            // Update User table
            user.FullName = vm.FullName;

            // Update Account table
            account.Email = vm.Email;
            account.Phone = vm.Phone;
            account.IsActive = vm.Status == "Active";

            // Update Role
            var role = _context.UserRoles.FirstOrDefault(x => x.AccountID == account.AccountID);
            if (role != null)
                role.RoleName = vm.RoleName;

            _context.SaveChanges();
            return true;
        }

    }
}
