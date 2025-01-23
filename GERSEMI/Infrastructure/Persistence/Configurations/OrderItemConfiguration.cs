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
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_items");

            builder.HasKey(oi => oi.Id);

            //each OrderItem references one Order
            //The Order has many OrderItems (o => o.OrderItems)
            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey("order_id")
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(oi => oi.Variant)
                .WithMany()
                .HasForeignKey("variant_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(oi => oi.Quantity)
                .HasColumnName("quantity");

            builder.Property(oi => oi.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10,2)");

            builder.Property(oi => oi.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(oi => oi.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
