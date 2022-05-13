using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeleViajes.Models
{
    public class parqueTematico
    {
        [Key]
        public int id { get; set; }
        public String nombre { get; set; }
        public String ciudadPueblo { get; set; }
        public String provincia { get; set; }
        public String comunidadAutonoma { get; set; }
        public String pais { get; set; }
        public String tipo { get; set; }
        public float precioMin { get; set; }
        public float precioMax { get; set; }
        public String videoFoto { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}