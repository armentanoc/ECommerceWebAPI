
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class SaleRequest : Request
    {
        [Required]
        public uint ProductId { get; private set; }

        public SaleRequest(uint productId)
        {
            ProductId = productId;
        }
    }
}
