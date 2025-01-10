using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductPrice
    {
        public int Id { get; private set; }

        public string CurrencyCode { get; private set; }
        public decimal Price { get; private set; }

        public Product Product { get; private set; }

        private ProductPrice() { }

        public ProductPrice(Product product, string currencyCode, decimal price)
        {
            Product = product;
            CurrencyCode = currencyCode;
            Price = price;
        }
    }
}
