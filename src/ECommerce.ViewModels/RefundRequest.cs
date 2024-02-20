
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class RefundRequest : Request
    {
        [Required(ErrorMessage = "O Id da venda é obrigatório.")]
        public uint SaleId { get; init; }

        public RefundRequest(uint saleId)
        {
            SaleId = saleId;
        }
    }
}
