
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(uint id);
        bool Add(ProductRequest newProduct);
        bool Update(ProductRequest newProduct);
        bool Delete(uint id);
    }
}
