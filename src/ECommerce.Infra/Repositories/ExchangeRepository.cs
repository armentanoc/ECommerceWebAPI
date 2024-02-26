using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Infra.Repositories
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(AppDbContext context) : base(context)
        {
            // required by EF
        }

        public override Exchange Get(uint id)
        {
            var entityToReturn = _context.Exchange
                .Include(e => e.OriginalSale)
                    .ThenInclude(s => s.SaleProducts)
                        .ThenInclude(ps => ps.Product) 
                .Include(e => e.ProductExchanges)
                    .ThenInclude(pe => pe.Product) 
                .FirstOrDefault(e => e.Id == id);

            if (entityToReturn != null)
            {
                entityToReturn.SetId(id);
                return entityToReturn;
            }

            throw new Exception($"Entity with id {id} doesn't exist.");
        }

        public override IEnumerable<Exchange> GetAll()
        {
            return _context.Exchange
                .Include(e => e.OriginalSale)
                    .ThenInclude(s => s.SaleProducts)
                        .ThenInclude(ps => ps.Product) 
                .Include(e => e.ProductExchanges)
                    .ThenInclude(pe => pe.Product) 
                .ToList();
        }
    }
}
