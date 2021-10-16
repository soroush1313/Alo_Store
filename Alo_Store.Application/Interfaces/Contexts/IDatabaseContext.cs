using Alo_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alo_Store.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Alo_Store.Application.Interfaces.Contexts
{
    public interface IDatabaseContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Category> Categories { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
             CancellationToken cancellationToken = new CancellationToken());

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
