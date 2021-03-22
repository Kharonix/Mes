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

    public enum HttpCode
    {
        //500 Internal server error — всё сломалось, но мы скоро починим
        InternalServerError = 500,
        //400 Bad request — а теперь у вас всё сломалось
        BadRequest = 400,
        //403 Forbidden — вам сюда нельзя
        Forbidden = 403,
        //404 Not found — по этому адресу никто не живёт
        NotFound = 404,
        //405 Method not allowed — нельзя такое делать
        MethodNotAllowed = 405,
        //422 Unprocessable entity — исправьте и пришлите снова
        UnprocessableEntity = 422
    }
}