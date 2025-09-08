using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Stores;

namespace Acc.Infrastructure.Configurations.Specifications
{
   public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {

            builder.HasOne(q => q.Creator)
                .WithMany(q => q.SpecificationCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.SpecificationModifiers)
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


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Specifications", "STR");
        }
    }
}
