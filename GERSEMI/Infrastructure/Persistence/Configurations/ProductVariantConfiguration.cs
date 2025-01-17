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
            builder.ToTable("Product_Variants");

            //Primary Key
            builder.HasKey(pv => pv.Id);

            // Each ProductVariant has exactly one Product (pv.Product)
            // and each Product can have many ProductVariants (p.Variants).
            
            builder.HasOne(pv => pv.Product)
                .WithMany(pv => pv.Variants)
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pv => pv.Color)
                .HasColumnName("Color")
                .HasMaxLength(50);

            builder.Property(pv => pv.Color)
                .HasColumnName("Price")
                .HasColumnType("numeric(10,2)");

            builder.Property(pv => pv.Stock)
                .HasColumnName("Stock");

            builder.Property(pv => pv.SKU)
                .HasColumnName("SKU")
                .HasMaxLength(100);

            builder.Property(pv => pv.CreatedAt)
                .HasColumnName("Created_At");

            builder.Property(pv => pv.UpdatedAt)
                .HasColumnName("Updated_At");
        }
    }
}
