using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        internal static Product product1 = new Product("Camisa Nike", "Tamanho G", 99.45m, 4);
        internal static Product product2 = new Product("Short Adidas", "Tamanho M", 89.50m, 3);
        internal static Product product3 = new Product("Calça Oxer", "Tamanho P", 69.99m, 2);
        public ProductRepository()
        {
            product1.SetId(1);
            product2.SetId(2);
            product3.SetId(3);

            Add(product1);
            Add(product2);
            Add(product3);
        }
    }
}
