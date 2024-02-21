
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService : IService<Product, ProductRequest>
    {
        Product GetProductByRequest(ProductRequest request);
        Product Update(Product productToUpdate);
        Product TryIncreasingQuantity(Product product);
        Product TryDecreasingQuantity(Product product);
    }
}
