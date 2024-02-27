using ECommerce.Application.Interfaces;
using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Services
{
    public class ProductExchangeService : IProductExchangeService
    {
        private readonly IProductExchangeRepository _repository;

        public ProductExchangeService(IProductExchangeRepository repository)
        {
            _repository = repository;   
        }

        public ProductExchange Get(uint id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<ProductExchange> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<object> GetAllExchangeInformation()
        {
            return _repository.GetAllExchangeInformation();
        }

        public ProductExchange Add(ProductExchangeRequest newEntityRequest)
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public ProductExchange Update(ProductExchangeRequest newEntityRequest, uint id)
        {
            throw new NotImplementedException();
        }
    }
}
