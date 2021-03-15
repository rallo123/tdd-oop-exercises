﻿using System;
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
            _entities.Add((TEntity)entity.Clone());
            _logger?.Log($"{entity} was added");
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> copyOfEntities = new List<TEntity>();

            foreach(TEntity entity in _entities)
                copyOfEntities.Add((TEntity)entity.Clone());

            return copyOfEntities;
        } 

        public void Update(TEntity entity)
        {
            bool wasRemoved = _entities.Remove(entity);
            _entities.Add((TEntity)entity.Clone());

            if (wasRemoved)
                _logger?.Log($"{entity} was updated");
        }

        public void Delete(TEntity entity)
        {
            bool wasRemoved = _entities.Remove(entity);

            if (wasRemoved)
                _logger?.Log($"{entity} was deleted");
        }
    }
}
