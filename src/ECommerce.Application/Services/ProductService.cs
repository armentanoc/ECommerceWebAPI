using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _products;

        public ProductService(IProductRepository products)
        {
            _products = products;   
        }
        public Product Add(ProductRequest request)
        {
            var newProduct = GetProductByRequest(request);
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

        public Product Update(ProductRequest request, uint id)
        {
            var newProduct = GetProductByRequest(request);
            newProduct.SetId(id);
            return _products.Update(newProduct);
        }

        public Product Update(Product product)
        {
            return _products.Update(product);
        }
        public Product GetProductByRequest(ProductRequest request)
        {
            return new Product(request.Name, request.Description, request.Price, request.Quantity);
        }

        public Product TryIncreasingQuantity(Product product)
        {
            product.IncreaseQuantity();
            Update(product);
            return product;
        }

        public Product TryDecreasingQuantity(Product product)
        {
            product.DecreaseQuantity();
            Update(product);
            return product;
        }

        public IEnumerable<Product> FilterByName(string name)
        {
            return _products.FilterByName(name);
        }
    }
}
