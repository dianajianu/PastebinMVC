using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PastebinMVC.DAL.Entities;


namespace PastebinMVC.DAL.Repository
{
    public class PastebinRepository<TEntity> : IRepository<TEntity, long> where TEntity : class
    {
        PastebinEntities _context;
        DbSet<TEntity> _set;

        public PastebinRepository(PastebinEntities context = null)
        {
            _context = context ?? new PastebinEntities();
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _set.Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var entityToBeDeleted = _set.Find(id);
            _set.Remove(entityToBeDeleted);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToBeDeleted = _set.Where(predicate);
            _set.RemoveRange(entitiesToBeDeleted);
        }

        public TEntity LoadEntityById(long id)
        {
            return _set.Find(id);
        }

        public IList<TEntity> LoadEntitiesById(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public IList<TEntity> LoadAllEntities()
        {
            return _set.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}