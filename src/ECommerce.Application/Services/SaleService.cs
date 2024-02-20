using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels;

namespace ECommerce.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _sales;
        private readonly IProductService _productService;

        public SaleService(ISaleRepository sales, IProductService productService)
        {
            _productService = productService;
            _sales = sales;   
        }
        public bool Add(SaleRequest request)
        {
            var newSale = GetSaleFromRequest(request);
            return _sales.Add(newSale);
        }

        public bool Delete(uint id)
        {
            return _sales.Delete(id);
        }

        public Sale Get(uint id)
        {
            return _sales.Get(id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _sales.GetAll();
        }

        public bool Update(SaleRequest request)
        {
            throw new NotImplementedException();
        }
        public Sale GetSaleFromRequest(SaleRequest request)
        {
            var productId = request.ProductId;
            var product = _productService.Get(productId);
            product.SetId(productId);

            return new Sale(product);
        }
    }
}
