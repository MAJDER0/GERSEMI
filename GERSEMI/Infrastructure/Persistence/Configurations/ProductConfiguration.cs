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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BasePrice)
                .HasColumnName("best_price")
                .HasColumnType("numeric(10,2)");

            builder.Property(p => p.ImageUrl)
                .HasColumnName("image_url")
                .HasMaxLength(255);

            builder.Property(p => p.IsActive)
                .HasColumnName("is_active");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at");

            //Product -> ProductTranslation
            builder.HasMany(p => p.Translations)
                .WithOne(t => t.Product)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);

            // Product -> ProductPrice
            builder.HasMany(p => p.Prices)
                .WithOne(pp => pp.Product)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);

            //Product -> ProductVariant
            builder.HasMany(p => p.Variants)
                .WithOne(v => v.Product)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
