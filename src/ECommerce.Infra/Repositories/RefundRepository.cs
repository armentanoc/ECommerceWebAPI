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
            // required by EF
        }

        public override Refund Get(uint id)
        {
            var entityToReturn = _context.Refund
                .Include(r => r.OriginalSale)
                    .ThenInclude(s => s.SaleProducts)
                        .ThenInclude(ps => ps.Product) 
                .FirstOrDefault(r => r.Id == id);

            if (entityToReturn != null)
            {
                entityToReturn.SetId(id);
                return entityToReturn;
            }

            throw new Exception($"Entity with id {id} doesn't exist.");
        }

        public override IEnumerable<Refund> GetAll()
        {
            return _context.Refund
                .Include(r => r.OriginalSale)
                    .ThenInclude(s => s.SaleProducts)
                        .ThenInclude(ps => ps.Product) 
                .ToList();
        }
    }
}
