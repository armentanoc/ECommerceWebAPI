
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class ExchangeRequest : Request
    {
        [Required(ErrorMessage = "O id da venda é obrigatório.")]
        public uint SaleId { get; init; }
        [Required(ErrorMessage = "O id do produto é obrigatório.")]
        public uint ProductId { get; init; }
        public ExchangeRequest(uint saleId, uint productId) 
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}
