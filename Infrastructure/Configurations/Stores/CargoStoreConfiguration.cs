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
    public class CargoStoreConfiguration : IEntityTypeConfiguration<CargoStore>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoStore> builder)
        {
            builder.HasOne(q => q.Store)
                .WithMany(q => q.CargoStores)
                .HasForeignKey(q => q.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.StoreId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Cargo)
                .WithMany(q => q.CargoStores)
                .HasForeignKey(q => q.CargoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.CargoLocation)
               .WithMany(q => q.CargoStores)
               .HasForeignKey(q => q.CargoLocationId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoLocationId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.ToTable("CargoStores", "STR");
        }
    }
}
