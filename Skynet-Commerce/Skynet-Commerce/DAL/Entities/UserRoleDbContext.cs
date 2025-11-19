using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Commerce.DAL.Entities
{
    public partial class UserRoleDbContext : DbContext
    {
        public UserRoleDbContext()
            : base("name=UserRole")
        {
        }

        public virtual DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
