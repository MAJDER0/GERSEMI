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
    internal class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            //Table name
            builder.ToTable("product_variants");

            //Primary Key
            builder.HasKey(pv => pv.Id);

            // Each ProductVariant has exactly one Product (pv.Product)
            // and each Product can have many ProductVariants (p.Variants).
            
            builder.HasOne(pv => pv.Product)
                .WithMany(pv => pv.Variants)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pv => pv.Color)
                .HasColumnName("color")
                .HasMaxLength(50);

            builder.Property(pv => pv.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(10,2)");

            builder.Property(pv => pv.Stock)
                .HasColumnName("stock");

            builder.Property(pv => pv.SKU)
                .HasColumnName("sku")
                .HasMaxLength(100);

            builder.Property(pv => pv.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(pv => pv.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
