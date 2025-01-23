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
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("stores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.Property(s => s.City)
                .HasColumnName("city")
                .HasMaxLength(100);

            builder.Property(s => s.Street)
                .HasColumnName("street")
                .HasMaxLength(255);

            builder.Property(s => s.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(s => s.UpdatedAt)
                .HasColumnName("updated_at");

            //One Store -> many Employees
            builder.HasMany(s => s.Employees)
                .WithOne(e => e.Store)
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.SetNull);  //If you delete a store, employees remain but store_id = null

            builder.HasMany(s => s.Orders)
                .WithOne(o => o.Store)
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
