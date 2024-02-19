
using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(uint id);
        bool Add(Product newProduct);
        bool Update(Product newProduct);
        bool Delete(uint id);
    }
}
