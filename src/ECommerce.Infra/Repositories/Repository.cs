using ECommerce.Domain.Models;
using ECommerce.Infra.Context;
using ECommerce.Infra.Interfaces;

namespace ECommerce.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal readonly AppDbContext _context;
        private string _specificEntity = typeof(T).Name;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public T Add(T entityToAdd)
        {
            if (!EntityExist(entityToAdd))
            {
                _context.Set<T>().Add(entityToAdd);
                _context.SaveChangesAsync();
                return entityToAdd;
            }
            throw new Exception($"Entity {_specificEntity} with properties described already exist.");
        }

        public bool Delete(uint id)
        {
            var entityToDelete = Get(id);
            _context.Set<T>().Remove(entityToDelete);
            _context.SaveChangesAsync();
            return true;
        }

        public virtual T Get(uint id)
        {
            if (_context.Set<T>().FirstOrDefault(entity => entity.Id == id) is T entityToReturn)
            {
                entityToReturn.SetId(id);
                _context.SaveChangesAsync();
                return entityToReturn;
            }

            throw new Exception($"Entity {_specificEntity} with id {id} doesn't exist.");
        }


        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Update(T newEntity)
        {
            var existingEntity = Get(newEntity.Id);

            foreach (var prop in typeof(T).GetProperties().Where(prop => prop.Name != "Id"))
            {
                var newValue = prop.GetValue(newEntity);
                prop.SetValue(existingEntity, newValue);
            }
            _context.SaveChangesAsync();
            return existingEntity;

        }

        public bool EntityExist(T entityToAdd)
        {
            return _context.Set<T>().AsEnumerable().Any(existingEntity =>
                        existingEntity.GetType().GetProperties()
                            .Where(prop => prop.Name != "Id")
                            .All(prop => object.Equals(
                                prop.GetValue(existingEntity), prop.GetValue(entityToAdd)
                                )));
        }
    }
}
