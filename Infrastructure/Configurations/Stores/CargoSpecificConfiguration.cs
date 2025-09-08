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
   public class CargoSpecificConfiguration : IEntityTypeConfiguration<CargoSpecific>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoSpecific> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.CargoSpecificCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.CargoSpecificModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Parent)
                .WithMany(q => q.Children)
                .HasForeignKey(q => q.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ParentId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);




            builder.HasOne(q => q.Cargo)
               .WithMany(q => q.CargoSpecifics)
               .HasForeignKey(q => q.CargoId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.HasOne(q => q.Specification)
              .WithMany(q => q.CargoSpecifics)
              .HasForeignKey(q => q.SpecificationId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.SpecificationId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("CargoSpecifics", "STR");
        }
    }
}
