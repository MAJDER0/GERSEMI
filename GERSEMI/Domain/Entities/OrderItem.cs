using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; private set; }

        public Order Order { get; private set; }
        public ProductVariant Variant { get; private set; }

        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private OrderItem() { }

        public OrderItem(Order order, ProductVariant variant, int quantity, decimal unitPrice)
        {
            Order = order;
            Variant = variant;
            Quantity = quantity;
            UnitPrice = unitPrice;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
