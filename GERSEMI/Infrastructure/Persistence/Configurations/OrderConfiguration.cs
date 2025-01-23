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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Coupon)
                .WithMany()
                .HasForeignKey("coupon_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Store)
                .WithMany(s => s.Orders)
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey("employee_id")
                .OnDelete(DeleteBehavior.SetNull); //if an employee is deleted, order still remains but employee_id goes null

           builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey("order_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.TotalAmount)
                 .HasColumnName("total_amount")
                 .HasColumnType("numeric(10,2)");

            builder.Property(o => o.Status)
                .HasColumnName("status")
                .HasMaxLength(50);

            builder.Property(o => o.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(o => o.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
