
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels.Requests
{
    public class ExchangeRequest : Request
    {
        [Required(ErrorMessage = "O id da venda é obrigatório.")]
        public uint SaleId { get; init; }
        [Required(ErrorMessage = "O id do produto é obrigatório.")]
        public uint[] ProductIds { get; init; }
        public ExchangeRequest(uint saleId, uint[] productIds)
        {
            SaleId = saleId;
            ProductIds = productIds;
        }
    }
}
