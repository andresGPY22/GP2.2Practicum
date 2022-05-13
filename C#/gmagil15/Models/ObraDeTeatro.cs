using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class ObraDeTeatro
    {
        [Key]
        public int obraTeatroId { get; set; }
        [Display(Name = "Título de la obra")]
        public string Titulo { get; set; }
        [Display(Name = "Actore principales")]
        public string ActoresPrincipales { get; set; }
        public string Ciudad { get; set; }
        public string Lugar { get; set; }
        [Display(Name = "Días de la semana que hay concierto")]
        public string Dias { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de inicio de la obra")]
        public DateTime FechaIni { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de finalización de la obra")]
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
        public virtual ApplicationUser User { get; set;  }


    }
}