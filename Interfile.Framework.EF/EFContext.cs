using Interfile.Framework.Model;
using System;
using System.Data.Entity;

namespace Interfile.Framework.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection")
        {

        }
        public DbSet<LogCommunication> LogsCommunication { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Method> Methods { get; set; }
    }
}
