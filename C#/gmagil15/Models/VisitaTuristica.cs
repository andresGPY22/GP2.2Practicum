using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class VisitaTuristica
    {
        [Key]
        public int VisitaTuristicaId { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Recorrido (km)")]
        public float Recorrido { get; set; }

        [Display(Name = "Pago")]
        public bool Pago { get; set; }

        [Display(Name = "Agencia Tour Operadora")]
        public string Agencia { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha inicio")]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha fin")]
        public DateTime FechaFin { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public DateTime Hora { get; set; }

        [Display(Name = "Duración estimada (min)")]
        public int Duracion { get; set; }

        [Display(Name = "Precio")]
        public float Precio { get; set; }

        [Display(Name = "Dias de la semana que hay tour")]
        public string DiasSemana { get; set; }

        [Display(Name = "Excepciones")]
        public string Excepciones { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}