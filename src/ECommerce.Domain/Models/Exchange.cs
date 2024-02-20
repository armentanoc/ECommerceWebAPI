
using ECommerce.Domain.Utils;

namespace ECommerce.Domain.Models
{
    public class Exchange : BaseEntity
    {
        public DateTime ExchangeDate { get; private set; }
        public Sale OriginalSale { get; private set; }
        public Product NewProduct { get; set; }
        public Exchange(Sale originalSale, Product newProduct)
        {
            ExchangeDate = DateTime.Now;
            if(ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if(ObjectValidator.IsValid(newProduct)) NewProduct = newProduct;
        }

        public Exchange(DateTime exchangeDate, Sale originalSale, Product newProduct)
        {
            if (ObjectValidator.IsDateTimeValid(exchangeDate)) ExchangeDate = exchangeDate;
            if (ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if(ObjectValidator.IsValid(newProduct)) NewProduct = newProduct;
        }
    }
}
