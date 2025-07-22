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
    public class CargoFactorConfiguration : IEntityTypeConfiguration<CargoFactor>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoFactor> builder)
        {
            builder.HasOne(q => q.Cargo)
                .WithMany(q => q.CargoFactors)
                .HasForeignKey(q => q.CargoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Factor)
                .WithMany(q => q.CargoFactors)
                .HasForeignKey(q => q.FactorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.FactorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.ToTable("CargoFactors", "STR");
        }
    }
}
