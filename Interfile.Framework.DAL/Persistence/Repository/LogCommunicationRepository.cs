using Interfile.Framework.DAL.Base;
using Interfile.Framework.Interfaces.Repository;
using Interfile.Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfile.Framework.DAL.Repository
{
    public class LogCommunicationRepository : BasicRepository<LogCommunication>, ILogCommunicationRepository
    {
        public LogCommunicationRepository(ServiceContext context) : base(context)
        {

        }

        public LogCommunicationRepository(ServiceContext context, bool autoCommit) : base(context, autoCommit)
        {

        }
    }
}
