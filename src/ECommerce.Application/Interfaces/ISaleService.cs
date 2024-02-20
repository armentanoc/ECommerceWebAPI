
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface ISaleService : IService<Sale, SaleRequest>
    {
        public Sale GetSaleFromRequest(SaleRequest request);
    }
}
