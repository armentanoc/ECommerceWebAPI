using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context)
        {
            //required by EF
        }

        public override Sale Get(uint id)
        {
            if (_context.Sale
                    .Include(sale => sale.SoldProduct)
                    .FirstOrDefault(entity => entity.Id == id) is Sale entityToReturn)
            {
                entityToReturn.SetId(id);
                _context.SaveChangesAsync();
                return entityToReturn;
            }

            throw new Exception($"Entity {nameof(entityToReturn)} with id {id} doesn't exist.");
        }

        public override IEnumerable<Sale> GetAll()
        {
            return _context.Sale.Include(s => s.SoldProduct).ToList();
        }
    }
}
