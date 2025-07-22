using Acc.Core.Entities.Stores;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Configurations.Stores
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Cargoes", "STR");
        }
    }
}
