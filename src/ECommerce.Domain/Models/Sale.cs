
using ECommerce.Domain.Utils;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Models
{
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; private set; }
        public decimal Amount { get; private set; }
        public bool IsCancelled { get; private set; }

        [JsonIgnore]
        public List<ProductSale> SaleProducts { get; set; } = new();

        public Sale()
        {
            // required by EF
        }

        public Sale(List<Product> soldProducts)
        {
            IsCancelled = false;
            SaleDate = DateTime.Now;
            AddProducts(soldProducts);
        }

        public void AddProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                if (ObjectValidator.IsValid(product))
                {
                    var productSale = new ProductSale { Product = product, Sale = this };
                    SaleProducts.Add(productSale);
                }

                if (PrimaryValidator.IsValid(product.Price)) Amount += product.Price;
            }
        }

        public void CancelSale()
        {
            IsCancelled = true;
        }
    }
}
