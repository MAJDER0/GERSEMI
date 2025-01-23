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
    internal class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.ToTable("product_prices");

            builder.HasKey(pp => pp.Id);

            //Eech price belongsto 1 Product
            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.Prices)
                .HasForeignKey("product_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pp => pp.CurrencyCode)
                .HasColumnName("currency_code")
                .HasMaxLength(3);

            builder.Property(pp => pp.Price)
                .HasColumnName("price")
                .HasColumnType("numeric(10,2)");
        }
    }
}
