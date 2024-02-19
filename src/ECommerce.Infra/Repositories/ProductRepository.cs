using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository()
        {
            Add(new Product("Camisa Nike", "Tamanho G", 99.45m));
            Add(new Product("Short Adidas", "Tamanho M", 89.50m));
            Add(new Product("Calça Oxer", "Tamanho P", 69.99m));
        }
    }
}
