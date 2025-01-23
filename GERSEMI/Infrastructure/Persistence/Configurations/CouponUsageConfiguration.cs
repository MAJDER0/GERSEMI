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
            builder.ToTable("coupon_usages");

            builder.HasKey(cu => cu.Id);

            //One Coupon -> Many CouponUsage
            //Each usage references a single coupon

            builder.HasOne(cu => cu.Coupon)
                .WithMany()
                    .HasForeignKey("coupon_id")
                        .OnDelete(DeleteBehavior.Cascade);

            //One User can have many CouponUsages
            builder.HasOne(cu => cu.User)
                .WithMany()
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.SetNull); // SetNull because the user may be removed

            builder.HasOne(cu => cu.Order)
                .WithMany()
                .HasForeignKey("order_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(cu => cu.UsedAt)
                .HasColumnName("used_at");

            builder.Property(cu => cu.GuestIdentifier)
                .HasColumnName("guest_identifier");
        }
    }
}
