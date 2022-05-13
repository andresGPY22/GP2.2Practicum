using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class EncuentroDeportivo
    {
        [Key]
        public int IdEncuentroDeportivo { get; set; }
        [Display(Name = "Deporte")]
        public string Deporte { get; set; }
        [Display(Name = "Equipo Local")]
        public string EquipoLocal { get; set; }
        [Display(Name = "Equipo Visitante")]
        public string EquipoVisitante { get; set; }
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Display(Name = "Ubicación")]
        public string Lugar { get; set; }
        [Display(Name = "Día del encuentro deportivo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string Dia { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Hora de inicio")]
        public DateTime Hora { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio mínimo (en € sin decimales)")]
        public int PrecioMin { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio medio (en € sin decimales)")]
        public int PrecioMed { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio máximo (en € sin decimales)")]
        public int PrecioMax { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}