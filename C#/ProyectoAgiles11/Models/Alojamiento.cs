using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeleViajes.Models
{
    public enum TipoAlojamiento
    {
        Hotel,
        HotelRural,
        Apartamento,
        CasaRural
    }
    public class Alojamiento
    {
        [Key]
        public int AlojamientoId { get; set; }
        public string Nombre { get; set; }
        public string CiudadPueblo { get; set; }
        public string Provincia { get; set; }
        public string ComunidadAutonoma { get; set; }
        public string Pais { get; set; }
        public TipoAlojamiento Tipo { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public bool HayParking { get; set; }
        public bool HayPiscina { get; set; }
        public bool HayInstalacionesDeportivas { get; set; }
        public bool HayInstalacionesInfantiles { get; set; }
        public string VideoFoto { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}