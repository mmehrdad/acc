using Acc.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Stores;

namespace Acc.Infrastructure.Configurations.Stores
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Stores", "STR");
        }
    }
}
