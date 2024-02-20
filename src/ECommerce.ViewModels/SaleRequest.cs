
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class SaleRequest : Request
    {
        [Required(ErrorMessage = "O Id do produto é obrigatório.")]
        public uint ProductId { get; init; }

        public SaleRequest(uint productId)
        {
            ProductId = productId;
        }
    }
}
