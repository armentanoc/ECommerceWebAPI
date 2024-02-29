
using ECommerce.Domain.Models;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Interfaces
{
    public interface IProductSaleService : IService<ProductSale, ProductSaleRequest>
    {
        public IEnumerable<Product> GetAllProductsBySale(uint saleId);
        public IEnumerable<object> GetCompleteProductSaleInformation();
    }
}
