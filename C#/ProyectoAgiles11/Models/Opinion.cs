using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleViajes.Models
{
    public class Opinion
    {
        [Key]
        public int OpinionId { get; set; }
        public TipoRecurso Recurso { get; set; }
        public string NombreRecurso { get; set; }
        public string Descripcion { get; set; }
        public TipoValoracion Voto { get; set; }
           

    }
    public enum TipoRecurso
    {
        Alojamiento,
        ExcursionYVisitaGuiada,
        Experiencia,
        DegustacionGastronomica,
        BarRestaurante,
        LocalDeOcioNocturno,
        ParqueTematico,
        Espectaculo
    }

    public enum TipoValoracion
    { 
       Asombroso=5,
       Genial=4,
       Normal=3,
       Mal=2,
       Decepcionante=1
    }
}