using ECommerce.Domain.Models;

namespace ECommerce.Infra.Interfaces
{
    public interface IProductExchangeRepository : IRepository<ProductExchange>
    {
        public IEnumerable<object> GetAllExchangeInformation();
    }
}
