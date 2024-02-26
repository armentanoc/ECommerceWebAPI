using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

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

        public Refund GetRefundFromRequest(RefundRequest request)
        {
            var sale = _saleService.Get(id: request.SaleId);

            if (sale != null && !sale.IsCancelled)
            {
                foreach (var product in sale.SaleProducts.ConvertAll(ps => ps.Product))
                    _productService.TryIncreasingQuantity(product);

                _saleService.TryCancellingSale(sale);
                return new Refund(sale);
            }
            else
            {
                return null;
            }
        }

        public Refund Update(RefundRequest newEntityRequest, uint id)
        {
            throw new NotImplementedException();
        }
    }
}
