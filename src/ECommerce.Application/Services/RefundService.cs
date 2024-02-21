using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels;

namespace ECommerce.Application.Services
{
    public class RefundService : IRefundService
    {
        private readonly IRefundRepository _refunds;
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;

        public RefundService(IRefundRepository refunds, ISaleService saleService, IProductService productService)
        {
            _saleService = saleService;
            _productService = productService;
            _refunds = refunds;
        }
        public Refund Add(RefundRequest request)
        {
            var newRefund = GetRefundFromRequest(request);
            return _refunds.Add(newRefund);
        }

        public bool Delete(uint id)
        {
            return _refunds.Delete(id);
        }

        public Refund Get(uint id)
        {
            return _refunds.Get(id);
        }

        public IEnumerable<Refund> GetAll()
        {
            return _refunds.GetAll();
        }

        public Refund Update(RefundRequest request)
        {
            throw new NotImplementedException();
        }
        public Refund GetRefundFromRequest(RefundRequest request)
        {
            var sale = _saleService.Get(id: request.SaleId);
            _saleService.TryCancellingSale(sale);
            _productService.TryIncreasingQuantity(product: sale.SoldProduct);
            return new Refund(sale);
        }
    }
}
