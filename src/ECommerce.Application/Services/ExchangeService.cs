using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels;

namespace ECommerce.Application.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchanges;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;

        public ExchangeService(IExchangeRepository exchanges, IProductService productService, ISaleService saleService)
        {
            _exchanges = exchanges;
            _productService = productService;
            _saleService = saleService;
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

        public Exchange Update(ExchangeRequest request)
        {
            throw new NotImplementedException();
        }
        public Exchange GetExchangeFromRequest(ExchangeRequest request)
        {
            var sale = _saleService.Get(id: request.SaleId);
            _saleService.TryCancellingSale(sale);

            var oldProduct = sale.SoldProduct;
            var newProduct = _productService.Get(id: request.ProductId);

            _productService.TryDecreasingQuantity(newProduct);
            _productService.TryIncreasingQuantity(oldProduct);

            return new Exchange(sale, newProduct);
        }
    }
}
