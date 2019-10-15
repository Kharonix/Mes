using Mes.Models;
using Mes.Models.Platform;
using Mes.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Mes.Service
{
    class CustomerRepository : IBaseDocument<Customer>
    {
        private WorkOrderContext db = new WorkOrderContext();

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public Customer Get(int? id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
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