using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class Musical
    {
        public int musicalId { get; set; }
        [Display(Name = "Título del musical")]
        public string Titulo { get; set; }
        [Display(Name = "Actores principales")]
        public string ActoresPrincipales { get; set; }
        public string Ciudad { get; set; }
        public string Lugar { get; set; }
        [Display(Name = "Días de la semana que hay función")]
        public string Dias { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de inicio del musical")]
        public DateTime FechaIni { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de finalización del musical")]
        public DateTime FechaFin { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Hora de inicio")]
        public DateTime Hora { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Duración (en minutos sin decimales)")]
        public int Duracion { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio mínimo (en € sin decimales)")]
        public int PrecioMin { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio medio (en € sin decimales)")]
        public int PrecioMed { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Precio máximo (en € sin decimales)")]
        public int PrecioMax { get; set; }
        [Display(Name = "Descripción de los precios")]
        public string DescripcionPrecios { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}