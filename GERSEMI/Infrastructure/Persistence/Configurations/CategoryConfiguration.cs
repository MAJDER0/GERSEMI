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
            builder.ToTable("categories");

            builder.HasKey(c => c.Id);

            // Self-referencing relationship
            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey("parent_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
