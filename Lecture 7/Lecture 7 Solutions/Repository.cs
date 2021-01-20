using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7_Solutions
{
    public class Repository<TEntity> where TEntity : ICloneable
    {
        ILogger _logger;
        List<TEntity> _entities = new List<TEntity>();

        public Repository()
        {
        }

        public Repository(ILogger logger)
        {
            _logger = logger;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);

            if (_logger != null)
                _logger.Log($"{entity} was added");
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> copyOfEntities = new List<TEntity>();

            foreach(TEntity entity in _entities)
                copyOfEntities.Add((TEntity)entity.Clone());

            return copyOfEntities;
        } 

        public void Update(TEntity oldEntity, TEntity newEntity)
        {
            bool wasRemoved = _entities.Remove(oldEntity);
            _entities.Add(newEntity);

            if (wasRemoved && _logger != null)
                _logger.Log($"{oldEntity} was updated");
        }

        public void Delete(TEntity entity)
        {
            bool wasRemoved = _entities.Remove(entity);

            if (wasRemoved && _logger != null)
                _logger.Log($"{entity} was deleted");
        }
    }
}
