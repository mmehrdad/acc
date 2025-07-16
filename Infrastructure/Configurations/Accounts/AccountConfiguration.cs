using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Core.Entities.Accounts;

namespace Acc.Infrastructure.Configurations.Accounts
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(q => q.Parent)
                .WithMany(q => q.ChildAccounts)
                .HasForeignKey(q => q.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.ParentId).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("Accounts", "ACC");
        }
    }
}
