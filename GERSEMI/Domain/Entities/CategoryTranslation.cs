using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryTranslation
    {
        public int Id { get; private set; }

        // Język (np. "pl", "en")
        public string LanguageCode { get; private set; }
        public string Name { get; private set; }

        // Relacja do głównej encji
        public Category Category { get; private set; }

        private CategoryTranslation() { }

        public CategoryTranslation(Category category, string languageCode, string name)
        {
            Category = category;
            LanguageCode = languageCode;
            Name = name;
        }
    }
}
