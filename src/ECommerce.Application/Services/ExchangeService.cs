using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchanges;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IProductSaleService _productSaleService;

        public ExchangeService(IExchangeRepository exchanges, IProductService productService, ISaleService saleService, IProductSaleService productSaleService)
        {
            _exchanges = exchanges;
            _productService = productService;
            _saleService = saleService;
            _productSaleService = productSaleService;
        }

        public Exchange Add(ExchangeRequest request)
        {
            var newExchange = GetExchangeFromRequest(request);
            return _exchanges.Add(newExchange);
        }

        public bool Delete(uint id)
        {
            return _exchanges.Delete(id);
        }

        public Exchange Get(uint id)
        {
            return _exchanges.Get(id);
        }

        public IEnumerable<Exchange> GetAll()
        {
            return _exchanges.GetAll();
        }

        public Exchange Update(ExchangeRequest request, uint id)
        {
            throw new NotImplementedException();
        }

        public Exchange GetExchangeFromRequest(ExchangeRequest request)
        {
            var sale = _saleService.Get(id: request.SaleId);
            var oldProducts = _productSaleService.GetAllProductsBySale(request.SaleId);
            var newProducts = new List<Product>();

            if (!sale.IsCancelled)
            {
                foreach (var productRequest in request.ProductIds)
                {
                    var product = _productService.Get(productRequest);
                    _productService.TryDecreasingQuantity(product);
                    newProducts.Add(product);
                }

                foreach (var product in oldProducts)
                {
                    _productService.TryIncreasingQuantity(product);
                }

                _saleService.TryCancellingSale(sale);
            }

            return new Exchange(sale, newProducts);
        }
    }
}
