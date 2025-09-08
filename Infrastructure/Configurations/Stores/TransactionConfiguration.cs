using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Stores;


namespace Acc.Infrastructure.Configurations.Transactions
{
   public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.HasOne(q => q.Creator)
                .WithMany(q => q.TransactionCreators)
                .HasForeignKey(q => q.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatorId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.Modifier)
                .WithMany(q => q.TransactionModifiers)
                .HasForeignKey(q => q.ModifierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ModifierId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.HasOne(q => q.CargoRequest)
                .WithMany(q => q.Transactions)
                .HasForeignKey(q => q.CargoRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CargoRequestId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);


            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Transactions", "STR");
        }
    }
}
