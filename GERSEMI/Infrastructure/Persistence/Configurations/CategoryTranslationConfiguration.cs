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
    internal class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder) 
        {
            
            builder.ToTable("category_translations");

            builder.HasKey(t => t.Id);

            // each CategoryTranslation belongs to exactly one Category
            builder.HasOne(ct => ct.Category)
                .WithMany(ct => ct.Translations)
                .HasForeignKey("category_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ct => ct.LanguageCode)
                .HasColumnName("language_code")
                .HasMaxLength(5);

            builder.Property(ct => ct.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

        }
    }
}
