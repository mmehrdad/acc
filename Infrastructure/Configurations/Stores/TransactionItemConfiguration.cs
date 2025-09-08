using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Stores;

namespace Acc.Infrastructure.Configurations.TransactionItems
{
    public class TransactionItemConfiguration : IEntityTypeConfiguration<TransactionItem>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {

            builder.HasOne(q => q.Creator)
                .WithMany(q => q.TransactionItemCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.TransactionItemModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Transaction)
                .WithMany(q => q.TransactionItems)
                .HasForeignKey(q => q.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.TransactionId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("TransactionItems", "STR");
        }
    }
}
