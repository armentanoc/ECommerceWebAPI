
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels.Requests
{
    public class SaleRequest : Request
    {
        [Required(ErrorMessage = "O Id do produto é obrigatório.")]
        public uint[] ProductIds { get; init; }

        public SaleRequest(uint[] productIds)
        {
            ProductIds = productIds;
        }
    }
}
