
namespace ECommerce.Domain.Models
{ 
    public class ProductExchange : BaseEntity
    {
        public uint ProductId { get; set; }
        public Product Product { get; set; }
        public uint ExchangeId { get; set; }
        public Exchange Exchange { get; set; }

        public ProductExchange()
        {
            // required by EF
        }
    }

}