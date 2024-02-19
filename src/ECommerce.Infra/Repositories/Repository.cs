using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _entities = new();
        private uint _nextId = 1;
        public bool Add(T entityToAdd)
        {
            if (!EntityExist(entityToAdd))
            {
                entityToAdd.Id = _nextId++;
                _entities.Add(entityToAdd);
                return true;
            }
            throw new Exception($"Entity {nameof(entityToAdd)} with properties described already exist.");
        }

        public bool Delete(uint id)
        {
            var entityToDelete = Get(id);
            _entities.Remove(entityToDelete);
            return true;
        }

        public T Get(uint id)
        {
            if (_entities.FirstOrDefault(entity => entity.Id == id) is T entityToReturn)
                return entityToReturn;

            throw new Exception($"Entity {nameof(T)} with id {id} doesn't exist.");
        }


        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public bool Update(T newEntity)
        {
            var existingEntity = Get(newEntity.Id);

            if (existingEntity.Equals(newEntity))
                return true;

            throw new Exception($"Updated couldn't be performed in entity {nameof(newEntity)}");
        }

        public bool EntityExist(T entityToAdd)
        {
            return _entities.Any(existingEntity =>
                        existingEntity.GetType().GetProperties()
                            .Where(prop => prop.Name != "Id")
                            .All(prop => object.Equals(
                                prop.GetValue(existingEntity), prop.GetValue(entityToAdd)
                                )));
        }
    }
}
