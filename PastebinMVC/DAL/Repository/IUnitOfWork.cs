using System;
using System.Data.Entity;

namespace PastebinMVC.DAL.Repository
{
    public interface IUnitOfWork<C> : IDisposable where C : DbContext, new()
    {
        C Context { get; }
        void Commit();
    }
}
