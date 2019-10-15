using Mes.Models;
using Mes.Models.Platform;
using Mes.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mes.Service
{
    public class WorkOrderRepository : IBaseDocument<WorkOrder>
    {
        private WorkOrderContext db = new WorkOrderContext();

        public IEnumerable<WorkOrder> GetAll()
        {
            var workOrders = db.WorkOrders.Include(w => w.Assembly).Include(w => w.Customer).Include(w => w.Workplace);
            return workOrders;
        }
        public IEnumerable<WorkOrder> GetOperation() {
            var workOrders = db.WorkOrders.Include(w => w.Assembly).Include(w => w.Customer).Include(w => w.Workplace).Where(workOrder=>workOrder.WorkOrderStatus==Models.Enum.WorkOrderStatus.Started);
            
            return workOrders;
        }

        public WorkOrder Get(int? id)
        {
            return db.WorkOrders.Find(id);
        }

        public void Create(WorkOrder workOrder)
        {
            db.WorkOrders.Add(workOrder);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(WorkOrder workOrder)
        {
            db.Entry(workOrder).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder != null)
                db.WorkOrders.Remove(workOrder);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}