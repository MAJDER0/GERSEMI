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
    internal class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("coupons");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .HasColumnName("code")
                .HasMaxLength(50);

            builder.Property(c => c.Discount)
                .HasColumnName("discount")
                .HasColumnType("numeric(10,2)");

            builder.Property(c => c.StartDate)
                .HasColumnName("start_date");

            builder.Property(c => c.EndDate)
                .HasColumnName("end_date");

            builder.Property(c => c.UsageLimit)
                .HasColumnName("usage_limit");

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");

            // One Coupon -> Many Coupon Translations
            builder.HasMany(c => c.Translations)
                .WithOne(t => t.Coupon)
                .HasForeignKey("couponId")
                .OnDelete(DeleteBehavior.Restrict); // If you delete a Coupon, all translations are removed
        }
    }
}
