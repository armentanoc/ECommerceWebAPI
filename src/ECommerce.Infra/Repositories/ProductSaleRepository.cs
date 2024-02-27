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

        public IEnumerable<object> GetCompleteProductSaleInformation()
        {
            var productSales = _context.ProductSale
                .Include(ps => ps.Product)
                .Include(ps => ps.Sale)
                .ToList();

            var groupedProductSales = productSales
                .GroupBy(ps => ps.SaleId)
                .Select(group => new
                {
                    saleId = group.Key,
                    sale = group.First().Sale, 
                    products = group.Select(ps => ps.Product)
                });

            return groupedProductSales.ToList();
        }

    }
}
