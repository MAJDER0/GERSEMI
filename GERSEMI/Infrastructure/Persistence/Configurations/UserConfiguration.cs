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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(1000);

            builder.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasColumnName("phone")
                .HasMaxLength(50);

            builder.Property(u => u.Address)
                .HasColumnName("address")
                .HasMaxLength(255);

            builder.Property(u => u.City)
                .HasColumnName("city")
                .HasMaxLength(255);

            builder.Property(u => u.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(20);

            builder.Property(u => u.Country)
                .HasColumnName("country");

            builder.Property(u => u.IsAdmin)
                .HasColumnName("is_admin");

            builder.Property(u => u.IsEmployee)
                .HasColumnName("is_employee");

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
