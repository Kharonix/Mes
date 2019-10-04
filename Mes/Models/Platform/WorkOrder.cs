using Mes.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class WorkOrder
    {
        public int Id { get; set; }
        [Display(Name = "Номер документа")]
        public int Number { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Дата закрытия")]
        public DateTime? EndDate { get; set; }
        public int? AssemblyId { get; set; }
        public Assembly Assembly { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }
        [Display(Name = "Заказано")]
        public decimal Count { get; set; }
        [Display(Name = "Изготовлено")]
        public decimal? DoneCount { get; set; }
        [Display(Name = "Статус заказа")]
        public WorkOrderStatus WorkOrderStatus { get; set; } 


    }
}