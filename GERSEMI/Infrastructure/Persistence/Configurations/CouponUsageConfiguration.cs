using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class CouponUsageConfiguration : IEntityTypeConfiguration<CouponUsage>
    {
        public void Configure(EntityTypeBuilder<CouponUsage> builder)
        {

        }
    }
}
