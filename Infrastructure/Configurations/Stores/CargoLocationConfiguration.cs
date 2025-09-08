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
   public class CargoLocationConfiguration : IEntityTypeConfiguration<CargoLocation>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoLocation> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.CargoLocationCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.CargoLocationModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Store)
                .WithMany(q => q.CargoLocations)
                .HasForeignKey(q => q.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.StoreId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);



            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("CargoLocations", "STR");
        }
    }
}
