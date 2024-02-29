using ECommerce.Domain.Models;

namespace ECommerce.Infra.Interfaces
{
    public interface IProductSaleRepository : IRepository<ProductSale>
    {
        public IEnumerable<Product> GetAllProductsBySale(uint saleId);
        public IEnumerable<object> GetCompleteProductSaleInformation();
    }
}
