using Alo_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Application.Interfaces.Contexts;
using Alo_Store.Persistence.FluentConfigs.Users;

namespace Alo_Store.Persistence.Contexts
{
    public class DatabaseContext:DbContext,IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserInRoleConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
