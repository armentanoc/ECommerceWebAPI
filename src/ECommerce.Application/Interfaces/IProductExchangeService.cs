
using ECommerce.Domain.Models;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Interfaces
{
    public interface IProductExchangeService : IService<ProductExchange, ProductExchangeRequest>
    {
        public IEnumerable<object> GetAllExchangeInformation();
    }
}
