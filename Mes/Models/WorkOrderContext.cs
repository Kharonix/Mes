using Mes.Models.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Mes.Models.Mapping;
using Mes.Models.Warehouse;

namespace Mes.Models
{
    public class WorkOrderContext : DbContext
    {
        public WorkOrderContext() : base("DefaultConnection") { }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Inventory> Inventories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WorkOrderMap());
            modelBuilder.Configurations.Add(new AssemblyMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new WorkplaceMap());
            base.OnModelCreating(modelBuilder);
        }
        
    }
}