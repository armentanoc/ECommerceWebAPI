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

        public override IEnumerable<ProductExchange> GetAll()
        {
            return _context.ProductExchange
                .Include(ps => ps.Product)
                .Include(ps => ps.Exchange)
                    .ThenInclude(ps => ps.OriginalSale)
                        .ThenInclude(s => s.SaleProducts)
                            .ThenInclude(ps => ps.Product)
                .ToList();
        }
    }
}
