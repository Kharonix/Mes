using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class WorkOrderContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
    }
}