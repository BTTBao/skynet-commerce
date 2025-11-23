using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.DAL.Repositories.Admin
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }
    }
}
