using Mes.Models.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Mes.Models.Mapping
{
    public class WorkOrderMap : EntityTypeConfiguration<WorkOrder>
    {
        public WorkOrderMap() 
        {
            //1-m Assembly
            this.HasOptional(wo => wo.Assembly)
                .WithMany(wo => wo.WorkOrders)
                .HasForeignKey(wo => wo.AssemblyId)
                .WillCascadeOnDelete(false);

            //1-m Customer
            this.HasOptional(wo => wo.Customer)
                .WithMany(wo => wo.WorkOrders)
                .HasForeignKey(wo => wo.CustomerId)
                .WillCascadeOnDelete(false);

            //1-m Workplace
            this.HasOptional(wo => wo.Workplace)
                .WithMany(wo => wo.WorkOrders)
                .HasForeignKey(wo => wo.WorkplaceId)
                .WillCascadeOnDelete(false);

        }
    }
}