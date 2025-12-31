using Skynet_Ecommerce;

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
