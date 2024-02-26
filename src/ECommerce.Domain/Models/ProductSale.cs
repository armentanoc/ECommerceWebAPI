
namespace ECommerce.Domain.Models
{
    public class ProductSale : BaseEntity
    {
        public uint SaleId { get; set; }
        public Sale Sale { get; set; }
        public uint ProductId { get; set; }
        public Product Product { get; set; }

        public ProductSale()
        {
            // required by EF
        }
    }
}