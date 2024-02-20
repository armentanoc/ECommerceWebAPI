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

        public RefundService(IRefundRepository refunds, ISaleService saleService)
        {
            _saleService = saleService;
            _refunds = refunds;
        }
        public bool Add(RefundRequest request)
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

        public bool Update(RefundRequest request)
        {
            throw new NotImplementedException();
        }
        public Refund GetRefundFromRequest(RefundRequest request)
        {
            var saleId = request.SaleId;
            var sale = _saleService.Get(saleId);
            sale.SetId(saleId);

            return new Refund(sale);
        }
    }
}
