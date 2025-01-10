using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        // Bazowa cena (np. PLN, jeśli tak przyjmujesz)
        public decimal BasePrice { get; private set; }

        public string? ImageUrl { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Tłumaczenia
        private readonly List<ProductTranslation> _translations = new();
        public IReadOnlyCollection<ProductTranslation> Translations => _translations;

        // Ceny w innych walutach
        private readonly List<ProductPrice> _prices = new();
        public IReadOnlyCollection<ProductPrice> Prices => _prices;

        // Warianty (kolor, rozmiar, itp.)
        private readonly List<ProductVariant> _variants = new();
        public IReadOnlyCollection<ProductVariant> Variants => _variants;

        private Product() { }

        public Product(decimal basePrice, bool isActive, string? imageUrl)
        {
            BasePrice = basePrice;
            IsActive = isActive;
            ImageUrl = imageUrl;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddTranslation(string languageCode, string name, string? description)
        {
            var existing = _translations.FirstOrDefault(t => t.LanguageCode == languageCode);
            if (existing != null)
            {
                _translations.Remove(existing);
            }
            _translations.Add(new ProductTranslation(this, languageCode, name, description));
        }

        public void AddPrice(string currencyCode, decimal price)
        {
            var existing = _prices.FirstOrDefault(p => p.CurrencyCode == currencyCode);
            if (existing != null)
            {
                _prices.Remove(existing);
            }
            _prices.Add(new ProductPrice(this, currencyCode, price));
        }

        public void AddVariant(string color, string size, decimal price, int stock, string sku)
        {
            var variant = new ProductVariant(this, color, size, price, stock, sku);
            _variants.Add(variant);
        }
    }

}
