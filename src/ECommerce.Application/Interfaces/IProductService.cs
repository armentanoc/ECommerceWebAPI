
using ECommerce.Domain.Models;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService : IService<Product, ProductRequest>
    {
        Product GetProductByRequest(ProductRequest request);
        Product Update(ProductRequest productToUpdate, uint id);
        Product TryIncreasingQuantity(Product product);
        Product TryDecreasingQuantity(Product product);
        IEnumerable<Product> FilterByName(string name);
    }
}
