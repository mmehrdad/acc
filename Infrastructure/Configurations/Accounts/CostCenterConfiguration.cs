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
    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>, IDbModelConfiguration
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            

            builder.Property(m => m.Id).ValueGeneratedNever()
                .IsFixedLength(true).HasColumnType("char(18)")
                .HasMaxLength(18);
            builder.ToTable("CostCenters", "ACC");
        }
    }
}
