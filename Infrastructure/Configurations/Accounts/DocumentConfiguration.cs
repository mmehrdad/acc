using Acc.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Configurations.Accounts
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Document>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasOne(q => q.Reference)
                .WithMany(q => q.References)
                .HasForeignKey(q => q.ReferenceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ReferenceId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.FinancialPeriod)
                .WithMany(q => q.Documents)
                .HasForeignKey(q => q.FinancialPeriodId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.FinancialPeriodId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.CostCenter)
               .WithMany(q => q.Documents)
               .HasForeignKey(q => q.CostCenterId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.FinancialPeriodId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Documents", "ACC");
        }
    }
}
