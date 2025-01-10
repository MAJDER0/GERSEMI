using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }

        // Użytkownik, który złożył zamówienie
        public User User { get; private set; }

        // Kupon użyty w tym zamówieniu (opcjonalnie)
        public Coupon? Coupon { get; private set; }

        // Sklep i pracownik, jeśli zamówienie dotyczy np. odbioru w sklepie stacjonarnym
        public Store? Store { get; private set; }
        public Employee? Employee { get; private set; }

        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Pozycje w zamówieniu
        private readonly List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private Order() { }

        public Order(User user, decimal totalAmount, string status)
        {
            User = user;
            TotalAmount = totalAmount;
            Status = status;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AssignCoupon(Coupon coupon)
        {
            Coupon = coupon;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
