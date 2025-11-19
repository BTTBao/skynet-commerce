using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Commerce.DAL.Entities
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("name=User")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
