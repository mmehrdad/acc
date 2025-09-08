using Acc.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Configurations.Identities
{
   public class RoleModulePermissionConfiguration : IEntityTypeConfiguration<RoleModulePermission>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<RoleModulePermission> builder)
        {


            builder.HasOne(q => q.Creator)
                .WithMany(q => q.RoleModulePermissionCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.RoleModulePermissionModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.RoleModule)
                .WithMany(q => q.RoleModulePermissions)
                .HasForeignKey(q => q.RoleModuleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.RoleModuleId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Permission)
                .WithMany(q => q.RoleModulePermissions)
                .HasForeignKey(q => q.PermissionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.PermissionId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);



            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("RoleModulePermissions", "IDN");
        }
    }
}
