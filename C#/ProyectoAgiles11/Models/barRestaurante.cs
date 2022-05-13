using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TeleViajes.Models
{
    public class barRestaurante
    {
        [Key]
        public int identificador { get; set; }
        public String nombre { get; set; }
        public String ciudad { get; set; }
        public String provincia { get; set; }
        public String comunidadAutonoma { get; set; }
        public String pais { get; set; }

        public String tipoComida { get; set; }
        public String estilo { get; set; }
        public float precioMin { get; set; }
        public float precioMax { get; set; }
        public float valoracionMedia { get; set; }
        public String videoFoto { get; set; }
        public  string UserId { get; set; }
        public  virtual ApplicationUser User { get; set; }
    }
}