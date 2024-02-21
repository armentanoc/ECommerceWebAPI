
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IRefundService : IService<Refund, RefundRequest>
    {
        Refund GetRefundFromRequest(RefundRequest request);
    }
}
