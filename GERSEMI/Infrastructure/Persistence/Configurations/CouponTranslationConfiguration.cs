using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class CouponTranslationConfiguration : IEntityTypeConfiguration<CouponTranslation>
    {
        public void Configure(EntityTypeBuilder<CouponTranslation> builder)
        {
            builder.ToTable("coupon_translations");

            builder.HasKey(ct => ct.Id);

            //Many Translations -> One Coupon
            builder.HasOne(ct => ct.Coupon)
                .WithMany(c => c.Translations)
                .HasForeignKey("coupon_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ct => ct.LanguageCode)
                .HasColumnName("language_code")
                .HasMaxLength(5); //for instance: en, pl etc

            builder.Property(ct => ct.Description)
                .HasColumnName("description")
                .HasMaxLength(1000); //or text

        }
    }
}
