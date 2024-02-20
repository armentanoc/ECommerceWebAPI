
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IRefundService : IService<Refund, RefundRequest>
    {
        public Refund GetRefundFromRequest(RefundRequest request);
    }
}
