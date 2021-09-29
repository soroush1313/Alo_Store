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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.FullName).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasQueryFilter(u => !u.IsRemoved);
        }
    }
}
