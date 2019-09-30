using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class Customer
    {
        public Customer() : base() {
            WorkOrders = new List<WorkOrder>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }
    }
}