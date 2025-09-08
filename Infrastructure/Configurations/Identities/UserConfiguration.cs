
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Identity;
using Acc.Infrastructure.Configurations;

namespace Acc.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedNever()
               .IsFixedLength(true).HasColumnType("char(18)")
               .HasMaxLength(18);
            builder.ToTable("AspUsers", "IDN");

        }
    }
}
