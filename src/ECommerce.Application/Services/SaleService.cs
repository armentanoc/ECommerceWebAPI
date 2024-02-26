using ECommerce.Application.Interfaces;
using ECommerce.Application.CustomExceptions;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

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
        public Sale Add(SaleRequest request)
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

        public Sale Update(Sale sale)
        {
            return _sales.Update(sale);
        }

        public Sale GetSaleFromRequest(SaleRequest request)
        {
            var products = new List<Product>();

            foreach (var productId in request.ProductIds)
            {
                var product = _productService.Get(productId);
                _productService.TryDecreasingQuantity(product); 
                products.Add(product);
            }

            return new Sale(products);
        }

        public void TryCancellingSale(Sale sale)
        {
            if (sale.IsCancelled)
                throw new SaleIsAlreadyCancelledException();
            else
                sale.CancelSale();
                Update(sale);
        }

        public Sale Update(SaleRequest newEntityRequest)
        {
            throw new NotImplementedException();
        }

        public Sale Update(SaleRequest newEntityRequest, uint id)
        {
            throw new NotImplementedException();
        }
    }
}
