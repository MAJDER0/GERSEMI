using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }

        // Relacja do „rodzica” w drzewie kategorii
        public Category? Parent { get; private set; }

        // Podkategorie
        private readonly List<Category> _children = new();
        public IReadOnlyCollection<Category> Children => _children;

        // Tłumaczenia (np. nazwy) w różnych językach
        private readonly List<CategoryTranslation> _translations = new();
        public IReadOnlyCollection<CategoryTranslation> Translations => _translations;

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Konstruktor bezparametrowy dla ORM
        private Category() { }

        // Konstruktor dla logiki domenowej (jeśli chcemy inicjalizować obiekt w określony sposób)
        public Category(Category? parent)
        {
            Parent = parent;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Przykładowe metody domenowe
        public void AddChild(Category child)
        {
            _children.Add(child);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddTranslation(string languageCode, string name)
        {
            // Usuwamy istniejące tłumaczenie w tym języku, aby dodać nowe
            var existing = _translations.FirstOrDefault(t => t.LanguageCode == languageCode);
            if (existing != null)
            {
                _translations.Remove(existing);
            }

            _translations.Add(new CategoryTranslation(this, languageCode, name));
            UpdatedAt = DateTime.UtcNow;
        }
    }

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
