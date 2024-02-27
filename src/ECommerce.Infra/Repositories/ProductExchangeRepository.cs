using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class ProductExchangeRepository : Repository<ProductExchange>, IProductExchangeRepository
    {
        public ProductExchangeRepository(AppDbContext context) : base(context)
        {
            // required by EF
        }

        public IEnumerable<object> GetAllExchangeInformation()
        {
            var productExchanges = _context.ProductExchange
                .Include(pe => pe.Product)
                .Include(pe => pe.Exchange)
                    .ThenInclude(e => e.OriginalSale)
                        .ThenInclude(os => os.SaleProducts)
                            .ThenInclude(sp => sp.Product)
                .ToList();

            var groupedProductExchanges = productExchanges
                .GroupBy(pe => pe.ExchangeId)
                .Select(group => new
                {
                    exchangeId = group.Key,
                    exchange = group.First().Exchange, 
                    products = group.Select(pe => pe.Product)
                });
            return groupedProductExchanges.ToList();
        }

    }
}
