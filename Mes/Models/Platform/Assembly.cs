using Mes.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class Assembly
    {
        public Assembly() : base() {
            WorkOrders = new List<WorkOrder>();
            Inventories = new List<Inventory>();
        }
        public int Id { get; set; }
        [Display(Name = "Название изделия")]
        public string Name { get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}