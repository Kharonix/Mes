using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class Workplace
    {
        public Workplace() : base() {
            WorkOrders = new List<WorkOrder>();

        }
        public int Id { get; set; }
        [Display(Name = "Название цеха")]
        public string Name{ get; set; }
        public ICollection<WorkOrder> WorkOrders { get; set; }
    }
}