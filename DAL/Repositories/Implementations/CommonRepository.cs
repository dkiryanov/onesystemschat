using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    /// <summary>
    /// Implementation of the Generic Repository pattern
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CommonRepository<TEntity> : ICommonRepository<TEntity> where TEntity : class
    {
        private readonly ChatEDMContainer _context;
        private readonly DbSet<TEntity> _dbSet;

        public CommonRepository(ChatEDMContainer context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return predicate != null ? _dbSet.Where(predicate) : null;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return entity != null ? _dbSet.Add(entity) : null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null) return null;

            TEntity updatedEntity = _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return updatedEntity;
        }

        public virtual TEntity Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);
            
            return this.Delete(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (entity == null) return null;

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            
           return _dbSet.Remove(entity);
        }
    }
}
