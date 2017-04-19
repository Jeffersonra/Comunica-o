using Interfile.Framework.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfile.Framework.DAL
{
    public class ServiceContext : DbContext
    {
        public ServiceContext()
            : base("name=ServiceContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Method> Methods { get; set; }
        public virtual DbSet<LogCommunication> LogsCommunication { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ServiceConfiguration());
        }
    }
}
