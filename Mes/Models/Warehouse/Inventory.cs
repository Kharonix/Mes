using Mes.Models.Enum;
using Mes.Models.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Warehouse
{
    public class Inventory
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public Assembly Assembly { get; set; }
        [Display(Name = "Количество")]
        public decimal Count { get; set; }
        [Display(Name = "Статус изделия")]
        public InventoryStatus InventoryStatus { get; set; }
    }
}