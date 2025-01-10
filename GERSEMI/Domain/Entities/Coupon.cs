using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coupon
    {
        public int Id { get; private set; }

        public string Code { get; private set; }
        public decimal Discount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int UsageLimit { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Tłumaczenia opisu
        private readonly List<CouponTranslation> _translations = new();
        public IReadOnlyCollection<CouponTranslation> Translations => _translations;

        private Coupon() { }

        public Coupon(string code, decimal discount, DateTime startDate, DateTime endDate, int usageLimit)
        {
            Code = code;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
            UsageLimit = usageLimit;
            IsActive = true;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddTranslation(string languageCode, string? description)
        {
            var existing = _translations.FirstOrDefault(t => t.LanguageCode == languageCode);
            if (existing != null)
            {
                _translations.Remove(existing);
            }

            _translations.Add(new CouponTranslation(this, languageCode, description));
        }
    }
}
