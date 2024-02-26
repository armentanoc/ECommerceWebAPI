
using ECommerce.Domain.Utils;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Models
{
    public class Exchange : BaseEntity
    {
        public DateTime ExchangeDate { get; private set; }
        public Sale OriginalSale { get; private set; }
        public decimal PriceDifference { get; private set; }

        [JsonIgnore]
        public List<ProductExchange> ProductExchanges { get; set; } = new();

        public Exchange()
        {
            // required by EF
        }

        public Exchange(Sale originalSale, List<Product> newProducts)
        {
            ExchangeDate = DateTime.Now;
            if (ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if (ObjectValidator.IsValid(newProducts))
            {
                ProductExchanges = newProducts.Select(product => new ProductExchange { Product = product, Exchange = this }).ToList();
                CalculatePriceDifference();
            }
        }

        public Exchange(DateTime exchangeDate, Sale originalSale, List<Product> newProducts)
        {
            if (ObjectValidator.IsDateTimeValid(exchangeDate)) ExchangeDate = exchangeDate;
            if (ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if (ObjectValidator.IsValid(newProducts))
            {
                ProductExchanges = newProducts.Select(product => new ProductExchange { Product = product, Exchange = this }).ToList();
                CalculatePriceDifference();
            }
        }

        private void CalculatePriceDifference()
        {
            PriceDifference = ProductExchanges.Sum(pe => pe.Product.Price) - OriginalSale.Amount;
        }
    }
}
