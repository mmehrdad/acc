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
    public class DocumentDetailConfiguration : IEntityTypeConfiguration<DocumentDetail>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<DocumentDetail> builder)
        {
            builder.HasOne(q => q.Document)
                .WithMany(q => q.DocumentDetails)
                .HasForeignKey(q => q.DocumentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.DocumentId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Account)
                .WithMany(q => q.DocumentDetails)
                .HasForeignKey(q => q.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.AccountId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Reference)
                .WithMany(q => q.References)
                .HasForeignKey(q => q.ReferenceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ReferenceId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("DocumentDetails", "ACC");
        }
    }
}
