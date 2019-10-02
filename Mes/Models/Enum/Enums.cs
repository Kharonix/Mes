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
        Completed = 2,
        [Display(Name = "Приостановлен")]
        Paused = 3
    }
    public enum InventoryStatus : byte {
        [Display(Name = "Повторная реализация")]
        SaleOfGoods = 0,
        [Display(Name = "Дефект")]
        Defect = 1
    }
    public enum ReturnOrderStatus : byte
    {
        [Display(Name = "На складе")]
        InWarehouse = 0,
        [Display(Name = "Отдано заказчику")]
        InCustomer = 1,
        [Display(Name = "Частично отдано заказчику")]
        PatialInCustomer = 1,
    }
}