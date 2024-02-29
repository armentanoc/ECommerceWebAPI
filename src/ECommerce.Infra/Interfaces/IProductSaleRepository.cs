using ECommerce.Domain.Models;

namespace ECommerce.Infra.Interfaces
{
    public interface IProductSaleRepository : IRepository<ProductSale>
    {
        public IEnumerable<object> GetCompleteProductSaleInformation();
    }
}
