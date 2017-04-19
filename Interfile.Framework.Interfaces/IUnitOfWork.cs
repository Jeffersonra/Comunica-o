using Interfile.Framework.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfile.Framework.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILogCommunicationRepository LogsCommunication { get; }
        IMethodRepository Methods { get; }
        IServiceRepository Services { get; }

        int SaveChanges();
    }
}
