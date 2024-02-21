using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(AppDbContext context) : base(context)
        {
            //required by EF
        }

        public override Exchange Get(uint id)
        {
            if (_context.Exchange
                    .Include(e => e.OriginalSale)
                        .ThenInclude(e => e.SoldProduct)
                    .Include(e => e.NewProduct)
                    .FirstOrDefault(entity => entity.Id == id) is Exchange entityToReturn)
            {
                entityToReturn.SetId(id);
                _context.SaveChangesAsync();
                return entityToReturn;
            }

            throw new Exception($"Entity {nameof(entityToReturn)} with id {id} doesn't exist.");
        }

        public override IEnumerable<Exchange> GetAll()
        {
            return _context.Exchange
                .Include(e => e.OriginalSale)
                    .ThenInclude(e => e.SoldProduct)
                .Include(e => e.NewProduct)
                .ToList();
        }
    }
}
