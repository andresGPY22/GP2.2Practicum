using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class Museo
    {
        public int museoId { get; set; }
        [Display(Name = "Nombre del museo")]
        public string nombre { get; set; }
        [Display(Name = "Días cerrado")]
        public string Dias { get; set; }
        [Display(Name = "Obras a destacar")]
        public string obrasDestacadas { get; set; }
        [Display(Name = "Precio (en € sin decimales)")]
        public int Precio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}