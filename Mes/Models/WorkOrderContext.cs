using Mes.Models.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Mes.Models
{
    public class WorkOrderContext : DbContext
    {
        public WorkOrderContext() : base("DefaultConnection") { }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Mes.Models.Warehouse.Inventory> Inventories { get; set; }
    }
}