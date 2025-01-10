using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CouponTranslation
    {
        public int Id { get; set; }

        public int CouponId { get; set; }
        public string LanguageCode { get; set; } = null!;

        // Pola tłumaczone
        public string? Description { get; set; }

        // Nawigacja
        public virtual Coupon Coupon { get; set; } = null!;
    }
}
