using Mes.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mes.Models.Platform
{
    public class AssemblyComponent
    {
        public AssemblyComponent() : base() {
        }
        public int Id { get; set; }
        [Display(Name = "Название компонент")]
        public string Name { get; set; }
        [Display(Name = "Необходимо для изделия")]
        public decimal Count { get; set; }
        public int AssembleId { get; set; }
        public Assembly Assembly { get; set; }
        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }
    }
}