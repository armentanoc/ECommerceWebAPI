
using ECommerce.Domain.Models;
using ECommerce.ViewModels.Requests;

namespace ECommerce.Application.Interfaces
{
    public interface IService<TEntity, TRequest> 
        where TEntity : BaseEntity 
        where TRequest : Request
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(uint id);
        TEntity Add(TRequest newEntityRequest);
        TEntity Update(TRequest newEntityRequest, uint id);
        bool Delete(uint id);
    }
}
