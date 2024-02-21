using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repositories
{
    public class RefundRepository : Repository<Refund>, IRefundRepository
    {
        public RefundRepository(AppDbContext context) : base(context)
        {
            //required by EF
        }

        public override Refund Get(uint id)
        {
            if (_context.Refund
                    .Include(r => r.OriginalSale)
                        .ThenInclude(r => r.SoldProduct)
                    .FirstOrDefault(entity => entity.Id == id) is Refund entityToReturn)
            {
                entityToReturn.SetId(id);
                _context.SaveChangesAsync();
                return entityToReturn;
            }

            throw new Exception($"Entity {nameof(entityToReturn)} with id {id} doesn't exist.");
        }

        public override IEnumerable<Refund> GetAll()
        {
            return _context.Refund
                .Include(r => r.OriginalSale)
                    .ThenInclude(r => r.SoldProduct)
                .ToList();
        }
    }
}
