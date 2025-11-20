using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.DAL.Repositories.Admin
{
    public class AccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }
        public Account GetByAccountId(int id)
        {
            return _context.Accounts.Find(id);
        }
    }
}
