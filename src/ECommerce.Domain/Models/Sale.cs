
using ECommerce.Domain.Utils;

namespace ECommerce.Domain.Models
{
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; private set; }
        public decimal Amount { get; private set; }
        public Product SoldProduct { get; private set; }
        public bool IsCancelled { get; private set; }

        public Sale()
        {
            // required by EF
        }

        public Sale(Product soldProduct)
        {
            IsCancelled = false;
            SaleDate = DateTime.Now;
            if(ObjectValidator.IsValid(soldProduct)) SoldProduct = soldProduct;
            if(PrimaryValidator.IsValid(soldProduct.Price)) Amount = soldProduct.Price;
        }
        public Sale(DateTime saleDate, Product soldProduct)
        {
            if(ObjectValidator.IsDateTimeValid(saleDate)) SaleDate = saleDate;
            if(ObjectValidator.IsValid(soldProduct)) SoldProduct = soldProduct;
            if(PrimaryValidator.IsValid(soldProduct.Price)) Amount = soldProduct.Price;
        }

        public void CancelSale()
        {
            IsCancelled = true;
        }
    }
}
