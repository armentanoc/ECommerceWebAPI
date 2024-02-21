
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface ISaleService : IService<Sale, SaleRequest>
    {
        Sale GetSaleFromRequest(SaleRequest request);
        void TryCancellingSale(Sale sale);
        Sale Update(Sale sale);
    }
}
