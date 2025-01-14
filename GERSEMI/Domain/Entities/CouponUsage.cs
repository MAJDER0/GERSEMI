using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CouponUsage
    {
        public int Id { get; private set; }

        // Może być null, jeśli gość nie ma konta
        public User? User { get; private set; }

        // Kupon wykorzystany
        public Coupon Coupon { get; private set; }

        // Zamówienie, w którym użyto kupon
        public Order? Order { get; private set; }

        public DateTime UsedAt { get; private set; }

        // Identyfikator gościa (np. cookies / session)
        public Guid? GuestIdentifier { get; private set; }

        private CouponUsage() { }

        public CouponUsage(Coupon coupon, User? user, Order? order, Guid? guestIdentifier)
        {
            Coupon = coupon;
            User = user;
            Order = order;
            GuestIdentifier = guestIdentifier;
            UsedAt = DateTime.UtcNow;
        }
    }
}
