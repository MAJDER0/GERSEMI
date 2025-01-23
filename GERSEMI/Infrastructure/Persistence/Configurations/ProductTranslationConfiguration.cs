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
    internal class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("product_translations");

            builder.HasKey(pt => pt.Id);

            //Each translation belongs to 1 product
            builder.HasOne(pt=>pt.Product)
                .WithMany(p => p.Translations)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pt => pt.LanguageCode)
                .HasColumnName("language_code")
                .HasMaxLength(5);

            builder.Property(pt => pt.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

            builder.Property(pt => pt.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);
        }
    }
}
