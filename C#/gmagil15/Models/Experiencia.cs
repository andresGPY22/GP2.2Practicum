using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class Experiencia
    {
        [Key]
        public int experienciaId { get; set; }
        [Display(Name = "Tipo de experiencia")]
        public string Tipo { get; set; }

        [Display(Name = "Agencia patrocinadora")]
        public string agenciaPatrocinadora { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Display(Name = "Lugar")]
        public string Lugar { get; set; }
        [Display(Name = "Días de la semana")]
        public string Dias { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de inicio ")]
        public DateTime FechaIni { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de finalización ")]
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

        [Display(Name = "Excepciones")]
        public string Excepciones { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}