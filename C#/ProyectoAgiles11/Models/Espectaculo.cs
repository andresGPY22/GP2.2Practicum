using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace TeleViajes.Models
{
    public class Espectaculo
    {
        [Key]
        public int EspectaculoID { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Lugar { get; set; }
        public string CiudadPueblo { get; set; }
        public string Provincia { get; set; }
        public string ComunidadAutonoma { get; set; }
        public string Pais { get; set; }
        public int DuracionMinutos { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public decimal PrecioMinimo { get; set; }
        public decimal PrecioMaximo { get; set; }
        public string VideoFoto { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}