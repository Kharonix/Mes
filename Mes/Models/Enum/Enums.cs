using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Enum
{
    public enum WorkOrderStatus : byte
    {
        [Display(Name = "Новый")]
        New = 0,
        [Display(Name = "В производстве")]
        Started = 1,
        [Display(Name = "Завершен")]
        Completed = 2
    }
    public enum InventoryStatus : byte {
        [Display(Name = "На складе")]
        InWarehouse = 0,
        [Display(Name = "Отдано заказчику")]
        InCustomer = 1
    }
}