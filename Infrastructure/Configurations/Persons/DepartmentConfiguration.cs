using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Persons;

namespace Acc.Infrastructure.Configurations.Persons
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasOne(q => q.Creator)
                .WithMany(q => q.DepartmentCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.DepartmentModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Departments", "PRS");
        }
    }
}
