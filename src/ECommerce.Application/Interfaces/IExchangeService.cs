
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IExchangeService : IService<Exchange, ExchangeRequest>
    {
        public Exchange GetExchangeFromRequest(ExchangeRequest request);
    }
}
