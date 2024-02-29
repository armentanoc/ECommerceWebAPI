using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Services
{
    public class ProductSaleService : IProductSaleService
    {
        private readonly IProductSaleRepository _repository;

        public ProductSaleService(IProductSaleRepository repository)
        {
            _repository = repository;   
        }
        public ProductSale Get(uint id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<ProductSale> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<object> GetCompleteProductSaleInformation()
        {
            return _repository.GetCompleteProductSaleInformation();
        }

        public ProductSale Add(ProductSaleRequest newEntityRequest)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public ProductSale Update(ProductSaleRequest newEntityRequest, uint id)
        {
            throw new NotImplementedException();
        }
    }
}
