using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            //required by EF
        }

        public IEnumerable<Product> FilterByName(string name)
        {
            return _context.Set<Product>().AsEnumerable().Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
