
using ECommerce.Domain.Utils;

namespace ECommerce.Domain.Models
{
    public class Refund : BaseEntity
    {
        public DateTime RefundDate { get; set; }
        public Sale OriginalSale { get; set; }
        public decimal RefundAmount { get; set; }

        public Refund(Sale originalSale)
        {
            decimal amount = originalSale.Amount;

            RefundDate = DateTime.Now;
            if(ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if (PrimaryValidator.IsValid(amount)) RefundAmount = amount;
        }
        public Refund(DateTime refundDate, Sale originalSale)
        {
            decimal amount = originalSale.Amount;
            if (ObjectValidator.IsDateTimeValid(refundDate)) RefundDate = refundDate;
            if (ObjectValidator.IsValid(originalSale)) OriginalSale = originalSale;
            if (PrimaryValidator.IsValid(amount)) RefundAmount = amount;
        }
    }
}
