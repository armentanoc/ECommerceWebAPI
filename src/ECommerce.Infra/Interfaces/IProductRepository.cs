using ECommerce.Domain.Models;

namespace ECommerce.Infra.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> FilterByName(string name);
    }
}
