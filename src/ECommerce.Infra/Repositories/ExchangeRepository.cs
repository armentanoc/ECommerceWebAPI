using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository()
        {
            Add(new Exchange(SaleRepository.sale2, ProductRepository.product3));
        }
    }
}
