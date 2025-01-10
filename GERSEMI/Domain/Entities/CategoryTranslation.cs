using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CouponTranslation
    {
        public int Id { get; private set; }

        // Kod języka
        public string LanguageCode { get; private set; }

        // Przetłumaczony opis
        public string? Description { get; private set; }

        public Coupon Coupon { get; private set; }

        private CouponTranslation() { }

        public CouponTranslation(Coupon coupon, string languageCode, string? description)
        {
            Coupon = coupon;
            LanguageCode = languageCode;
            Description = description;
        }
    }
}
