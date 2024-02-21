using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository()
        {
            var exchange = new Exchange(SaleRepository.sale2, ProductRepository.product3);
            exchange.OriginalSale.CancelSale();
            Add(exchange);
        }
    }
}
