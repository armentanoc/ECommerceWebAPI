using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class RefundRepository : Repository<Refund>, IRefundRepository
    {
        public RefundRepository()
        {
            Add(new Refund(SaleRepository.sale1));
        }
    }
}
