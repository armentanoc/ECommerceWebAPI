
using ECommerce.Domain.Models;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Interfaces
{
    public interface IExchangeService : IService<Exchange, ExchangeRequest>
    {
        Exchange GetExchangeFromRequest(ExchangeRequest request);
    }
}
