using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Common.Roles;
using Alo_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alo_Store.Persistence.FluentConfigs.Users
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired();
            builder.HasQueryFilter(r => !r.IsRemoved);
            builder.HasData(new Role {Id = 1, Name = nameof(UserRoles.Admin)});
            builder.HasData(new Role {Id = 2, Name = nameof(UserRoles.Operator)});
            builder.HasData(new Role {Id = 3, Name = nameof(UserRoles.Customer)});
        }
    }
}
