using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleViajes.Models
{
    public class Degustacion
    {
        [Key]
        public int DegustacionId { get; set; }
        public TipoDegustacion Tipo { get; set; }
        public string Lugar { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string ComunidadAutonoma { get; set; }
        public string Pais { get; set; }
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public string VideoFoto { get; set; }
        public bool Obsequio { get; set; }
        
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public enum TipoDegustacion
    {
        Otros = 0,
        Vino = 1,
        Quesos = 2,
        Jamon = 3,
        Cervezas = 4,
        PlatosTipicos
    }
}

