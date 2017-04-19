using Interfile.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfile.Framework.Interfaces.Repository;
using Interfile.Framework.DAL.Repository;
using System.Data.Entity;

namespace Interfile.Framework.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceContext _context;

        public UnitOfWork(ServiceContext context, bool autoCommit)
        {
            _context = context;
            Services = new ServiceRepository(_context, autoCommit);
            Methods = new MethodRepository(_context, autoCommit);
            LogsCommunication = new LogCommunicationRepository(_context, autoCommit);
        }

        public UnitOfWork(ServiceContext context)
        {
            _context = context;
            Services = new ServiceRepository(_context);
            Methods = new MethodRepository(_context);
            LogsCommunication = new LogCommunicationRepository(_context);
        }

        public ILogCommunicationRepository LogsCommunication { get; private set; }
        public IMethodRepository Methods { get; private set; }
        public IServiceRepository Services { get; private set; }

        public int SaveChanges()
        {
            bool changesMade = _context.ChangeTracker.Entries().Any(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            if (!changesMade)
                return 0;

            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
