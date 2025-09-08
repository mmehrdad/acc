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
   public class CargoRequestConfiguration : IEntityTypeConfiguration<CargoRequest>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CargoRequest> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.CargoRequestCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.CargoRequestModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Approver)
                .WithMany(q => q.CargoRequestApprovers)
                .HasForeignKey(q => q.ApproverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ApproverId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);




            builder.HasOne(q => q.Requester)
               .WithMany(q => q.CargoRequests)
               .HasForeignKey(q => q.RequesterId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.RequesterId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.HasOne(q => q.Department)
              .WithMany(q => q.CargoRequests)
              .HasForeignKey(q => q.RequesterId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.RequesterId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("CargoRequests", "STR");
        }
    }
}
