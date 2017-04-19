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
    public class MethodRepository : BasicRepository<Method>, IMethodRepository
    {
        public MethodRepository(ServiceContext context) : base(context)
        {

        }

        public MethodRepository(ServiceContext context, bool autoCommit) : base(context, autoCommit)
        {

        }
    }
}
