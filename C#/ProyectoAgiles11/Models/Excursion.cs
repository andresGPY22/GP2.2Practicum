using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleViajes.Models
{
    public class Excursion
    {
        [Key]
        public int ExcursionId { get; set; }
        public string CiudadPueblo { get; set; }
        public bool Pago { get; set; }
        public string Recorrido { get; set; }
        public string Pais { get; set; }
        public string Agencia { get; set; }
        public TipoExcursion Tipo { get; set; }
        public int Duracion { get; set; }
        public decimal Precio { get; set; }
        public int DiasDisponible { get; set; }
        public string VideoFoto { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
    public enum TipoExcursion
    {
        Pie=0,
        Patinete=1,
        Bici=2,
        Bus=3
    }
}