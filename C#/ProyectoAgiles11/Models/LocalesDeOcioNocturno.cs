using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeleViajes.Models
{
    
    public class LocalesDeOcioNocturno
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string ciudadPueblo { get; set; }
        public string provincia { get; set; }
        public string comunidadAutonoma { get; set; }
        public string pais { get; set; }
        public string tipo { get; set; }
        public float precioEntrada { get; set; }
        public float valoracionMedia { get; set; }
        public string videoFoto { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}