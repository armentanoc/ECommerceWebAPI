using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class ProductSaleRepository : Repository<ProductSale>, IProductSaleRepository
    {
        public ProductSaleRepository(AppDbContext context) : base(context)
        {
            // required by EF
        }

        public override IEnumerable<ProductSale> GetAll()
        {
            var productSales = _context.ProductSale
                .Include(ps => ps.Product)
                .Include(ps => ps.Sale)
                .ToList();

            var distinctSaleIds = productSales
                .Select(ps => ps.SaleId)
                .Distinct();

            var groupedProductSales = distinctSaleIds
                .SelectMany(saleId => productSales
                    .Where(ps => ps.SaleId == saleId)
                );

            return groupedProductSales.ToList();
        }

    }
}
