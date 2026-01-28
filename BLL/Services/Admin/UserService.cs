using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService()
        {
            _context = new ApplicationDbContext();
        }
        // Cập nhật hàm này nhận tham số keyword và role
        public List<UserViewModel> GetAllUsersForView(string keyword = "", string role = "All Roles",
            DateTime? fromDate = null, DateTime? toDate = null)
        {
            // 1. Khởi tạo query cơ bản
            var query = _context.Users
                .Include("Account")
                .Include("Account.UserRoles")
                .AsQueryable();

            // 2. Lọc theo Role (nếu không phải "All Roles")
            if (!string.IsNullOrEmpty(role) && role != "All Roles")
            {
                // Lọc những user có Account chứa RoleName tương ứng
                query = query.Where(u => u.Account.UserRoles.Any(r => r.RoleName == role));
            }

            // 3. Lọc theo Keyword (Tên, Email hoặc Phone)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(u =>
                    u.FullName.Contains(keyword) ||
                    u.Account.Email.Contains(keyword) ||
                    u.Account.Phone.Contains(keyword)
                );
            }
            
            // 4. Lọc theo khoảng thời gian đăng ký
            if (fromDate.HasValue)
            {
                query = query.Where(u => u.Account.CreatedAt >= fromDate.Value);
            }
            
            if (toDate.HasValue)
            {
                query = query.Where(u => u.Account.CreatedAt <= toDate.Value);
            }

            // 4. Select ra ViewModel (Projection)
            var result = query.Select(u => new UserViewModel
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
