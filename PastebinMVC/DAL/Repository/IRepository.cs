using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PastebinMVC.DAL.Repository
{
    interface IRepository<TEntity, in TKey>  : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity LoadEntityById(TKey id);
        IList<TEntity> LoadEntitiesById(Expression<Func<TEntity, bool>> where);
        IList<TEntity> LoadAllEntities();
        void Save();
    }
}
