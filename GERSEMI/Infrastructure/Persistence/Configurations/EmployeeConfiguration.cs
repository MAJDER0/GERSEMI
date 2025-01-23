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
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id);

            //One Store has many Employees
            builder.HasOne(e => e.Store)
                .WithMany(s => s.Employees)
                .HasForeignKey("store_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(50);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at");

        }
    }
}
