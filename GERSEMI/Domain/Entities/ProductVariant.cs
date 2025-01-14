using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductVariant
    {
        public int Id { get; private set; }

        public string Color { get; private set; }
        public string Size { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string SKU { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Product Product { get; private set; }

        private ProductVariant() { }

        public ProductVariant(
            Product product,
            string color,
            string size,
            decimal price,
            int stock,
            string sku)
        {
            Product = product;
            Color = color;
            Size = size;
            Price = price;
            Stock = stock;
            SKU = sku;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
