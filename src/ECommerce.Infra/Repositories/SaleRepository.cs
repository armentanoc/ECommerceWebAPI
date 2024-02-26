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
            // required by EF
        }

        public override Sale Get(uint id)
        {
            var entityToReturn = _context.Sale
                .Include(s => s.SaleProducts)
                    .ThenInclude(ps => ps.Product)
                .FirstOrDefault(s => s.Id == id);

            if (entityToReturn != null)
            {
                entityToReturn.SetId(id);
                return entityToReturn;
            }

            throw new Exception($"Entity with id {id} doesn't exist.");
        }


        public override IEnumerable<Sale> GetAll()
        {
            return _context.Sale
                .Include(s => s.SaleProducts)
                    .ThenInclude(ps => ps.Product) 
                .ToList();
        }
    }
}
