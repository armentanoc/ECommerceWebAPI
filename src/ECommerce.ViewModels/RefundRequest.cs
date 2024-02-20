
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class RefundRequest : Request
    {
        [Required]
        public uint SaleId { get; private set; }

        public RefundRequest(uint saleId)
        {
            SaleId = saleId;
        }
    }
}
