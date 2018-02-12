using PastebinMVC.DAL.Entities;
using System;

namespace PastebinMVC.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork<PastebinEntities>, IDisposable
    {
        private PastebinEntities _context;
        private PastebinRepository<Text> _textRepository;
        private PastebinRepository<User> _userRepository;

        public PastebinEntities Context => _context ?? new PastebinEntities();
        public PastebinRepository<Text> TextRepository => _textRepository ?? new PastebinRepository<Text>(Context);
        public PastebinRepository<User> UserRepository => _userRepository ?? new PastebinRepository<User>(Context);

        public void Commit()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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