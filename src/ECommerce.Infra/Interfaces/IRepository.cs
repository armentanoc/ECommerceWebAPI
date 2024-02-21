

using ECommerce.Domain.Models;

namespace ECommerce.Infra.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();
        public T Get(uint id);
        public T Add(T newEntity);
        public T Update(T newEntity);
        public bool Delete(uint id);
        public bool EntityExist(T newEntity);
    }
}
