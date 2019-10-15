using Mes.Models;
using Mes.Models.Platform;
using Mes.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Mes.Service
{
    public class AssemblyRepository : IBaseDocument<Assembly>
    {
        private WorkOrderContext db = new WorkOrderContext();

        public IEnumerable<Assembly> GetAll()
        {
            return db.Assemblies;
        }

        public Assembly Get(int? id)
        {
            return db.Assemblies.Find(id);
        }

        public void Create(Assembly assembly)
        {
            db.Assemblies.Add(assembly);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(Assembly assembly)
        {
            db.Entry(assembly).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Assembly assembly = db.Assemblies.Find(id);
            if (assembly != null)
                db.Assemblies.Remove(assembly);
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