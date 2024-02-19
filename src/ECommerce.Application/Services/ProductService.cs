using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _products;

        public ProductService(IProductRepository products)
        {
            _products = products;   
        }
        public bool Add(Product newProduct)
        {
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

        public bool Update(Product newProduct)
        {
            return _products.Update(newProduct);
        }

        bool IProductService.Delete(uint id)
        {
            throw new NotImplementedException();
        }

        bool IProductService.Update(Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
