using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class RefundRepository : Repository<Refund>, IRefundRepository
    {
        public RefundRepository()
        {
            var refund = new Refund(SaleRepository.sale1);
            refund.OriginalSale.CancelSale();
            Add(refund);
        }
    }
}
