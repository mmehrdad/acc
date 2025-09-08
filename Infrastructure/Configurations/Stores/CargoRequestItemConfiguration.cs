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
    class CargoRequestItemItemConfiguration : IEntityTypeConfiguration<CargoRequestItem>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoRequestItem> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.CargoRequestItemCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.CargoRequestItemModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);




            builder.HasOne(q => q.Cargo)
                .WithMany(q => q.CargoRequestItems)
                .HasForeignKey(q => q.CargoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.CargoRequest)
                .WithMany(q => q.CargoRequestItems)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoRequestId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);



            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("CargoRequestItems", "STR");
        }
    }
}
