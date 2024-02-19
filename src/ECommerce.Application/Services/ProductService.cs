using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _products;

        public ProductService(IProductRepository products)
        {
            _products = products;   
        }
        public bool Add(ProductRequest request)
        {
            var newProduct = GetProductFromRequest(request);
            return _products.Add(newProduct);
        }

        public bool Delete(uint id)
        {
            return _products.Delete(id);
        }

        public Product Get(uint id)
        {
            return _products.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.GetAll();
        }

        public bool Update(ProductRequest request)
        {
            var newProduct = GetProductFromRequest(request);
            return _products.Update(newProduct);
        }
        public Product GetProductFromRequest(ProductRequest request)
        {
            return new Product(request.Name, request.Description, request.Price);
        }
    }
}
