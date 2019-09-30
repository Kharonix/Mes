using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Enum
{
    public enum WorkOrderStatus : byte
    {
        [Display(Name = "New", Description ="Новый")]
        New = 0,
        [Display(Name = "Started", Description = "В производстве")]
        Started = 1,
        [Display(Name = "Completed", Description = "Завершен")]
        Completed = 2,
    }
}