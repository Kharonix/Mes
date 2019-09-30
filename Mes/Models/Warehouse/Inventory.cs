using Mes.Models.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Models.Warehouse
{
    public class Inventory
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public Assembly Assembly { get; set; }
        public decimal Count { get; set; }
    }
}