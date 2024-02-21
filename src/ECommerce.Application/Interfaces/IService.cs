
using ECommerce.Domain.Models;
using ECommerce.ViewModels;

namespace ECommerce.Application.Interfaces
{
    public interface IService<TEntity, TRequest> 
        where TEntity : BaseEntity 
        where TRequest : Request
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(uint id);
        TEntity Add(TRequest newEntityRequest);
        TEntity Update(TRequest newEntityRequest);
        bool Delete(uint id);
    }
}
