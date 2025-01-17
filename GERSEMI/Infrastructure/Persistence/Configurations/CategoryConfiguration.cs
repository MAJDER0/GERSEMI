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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey("Parent_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreatedAt)
                .HasColumnName("Created_At");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("Updated_At");
        }
    }
}
