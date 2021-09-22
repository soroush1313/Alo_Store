using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alo_Store.Persistence.FluentConfigs.Users
{
    public class UserInRoleConfig : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.HasKey(ur => new {ur.UserId, ur.RoleId});

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserInRoles)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserInRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
