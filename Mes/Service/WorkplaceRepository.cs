using Mes.Models;
using Mes.Models.Platform;
using Mes.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Mes.Service
{
    class WorkplaceRepository : IBaseDocument<Workplace>
    {
        private WorkOrderContext db = new WorkOrderContext();

        public IEnumerable<Workplace> GetAll()
        {
            return db.Workplaces;
        }

        public Workplace Get(int? id)
        {
            return db.Workplaces.Find(id);
        }

        public void Create(Workplace workplace)
        {
            db.Workplaces.Add(workplace);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(Workplace workplace)
        {
            db.Entry(workplace).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Workplace workplace = db.Workplaces.Find(id);
            if (workplace != null)
                db.Workplaces.Remove(workplace);
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