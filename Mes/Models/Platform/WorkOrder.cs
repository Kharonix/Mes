using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AssemblyId { get; set; }
        public int CustomerId { get; set; }
        public int WorkplaceId { get; set; }

        public decimal Count { get; set; }
        public decimal? DoneCount { get; set; }
         


    }
}