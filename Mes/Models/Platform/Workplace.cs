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
            Assemblies = new List<Assembly>();
        }
        public int Id { get; set; }
        [Display(Name = "Название цеха")]
        public string Name{ get; set; }
        public ICollection<Assembly> Assemblies { get; set; }
    }
}