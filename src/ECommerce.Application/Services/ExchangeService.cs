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
        public bool Add(ExchangeRequest request)
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

        public bool Update(ExchangeRequest request)
        {
            throw new NotImplementedException();
        }
        public Exchange GetExchangeFromRequest(ExchangeRequest request)
        {
            var saleId = request.SaleId;
            var sale = _saleService.Get(saleId);
            sale.SetId(saleId);

            var productId = request.ProductId;
            var newProduct = _productService.Get(productId);
            newProduct.SetId(productId);

            return new Exchange(sale, newProduct);
        }
    }
}
