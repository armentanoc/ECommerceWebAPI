
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class ExchangeRequest : Request
    {
        [Required]
        public uint SaleId { get; private set; }
        [Required]
        public uint ProductId { get; private set; }
        public ExchangeRequest(uint saleId, uint productId) 
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}
