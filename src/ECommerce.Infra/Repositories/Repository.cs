using ECommerce.Domain.Models;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _entities = new();
        private uint _nextId = 1;
        private string _specificEntity = typeof(T).Name;
        public T Add(T entityToAdd)
        {
            if (!EntityExist(entityToAdd))
            {
                entityToAdd.Id = _nextId++;
                _entities.Add(entityToAdd);
                return entityToAdd;
            }
            throw new Exception($"Entity {_specificEntity} with properties described already exist.");
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
            {
                entityToReturn.SetId(id);
                return entityToReturn;
            }

            throw new Exception($"Entity {_specificEntity} with id {id} doesn't exist.");
        }


        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T Update(T newEntity)
        {
            var existingEntity = Get(newEntity.Id);

            foreach (var prop in typeof(T).GetProperties().Where(prop => prop.Name != "Id"))
            {
                var newValue = prop.GetValue(newEntity);
                prop.SetValue(existingEntity, newValue);
            }

            return existingEntity;

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
