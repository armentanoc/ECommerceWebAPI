
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService : IService<Product, ProductRequest>
    {
        public Product GetProductFromRequest(ProductRequest request);
    }
}
