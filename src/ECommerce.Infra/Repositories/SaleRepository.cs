using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public static Sale sale1 = new Sale(ProductRepository.product1);
        public static Sale sale2 = new Sale(ProductRepository.product2);
        public SaleRepository()
        {
            sale1.SetId(1);
            sale2.SetId(2);

            Add(sale1);
            Add(sale2);
        }
    }
}
