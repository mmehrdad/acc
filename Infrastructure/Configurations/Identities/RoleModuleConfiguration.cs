using Acc.Core.Entities.Stores;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Identity;

namespace Acc.Infrastructure.Configurations.Identities
{
   public class RoleModuleConfiguration : IEntityTypeConfiguration<RoleModule>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<RoleModule> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.RoleModuleCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.RoleModuleModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Module)
                .WithMany(q => q.RoleModules)
                .HasForeignKey(q => q.ModuleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModuleId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Role)
                .WithMany(q => q.RoleModules)
                .HasForeignKey(q => q.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.RoleId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);



            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("RoleModules", "IDN");
        }
    }
}
