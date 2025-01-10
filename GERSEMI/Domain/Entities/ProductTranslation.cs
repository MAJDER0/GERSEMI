using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductTranslation
    {
        public int Id { get; private set; }

        public string LanguageCode { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Product Product { get; private set; }

        private ProductTranslation() { }

        public ProductTranslation(Product product, string languageCode, string name, string? description)
        {
            Product = product;
            LanguageCode = languageCode;
            Name = name;
            Description = description;
        }
    }
}
