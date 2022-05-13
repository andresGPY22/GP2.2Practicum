using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeleViajes.Models
{
    public class Experiencia
    {
        [Key]
        public int ExperienciaId { get; set; }
        public TipoExperiencia Tipo { get; set; }
        public string Lugar { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string ComunidadAutonoma { get; set; }
        public string Pais { get; set; }
        public string Agencia { get; set; }
        public decimal Precio { get; set; }
        public int DiasDisponible { get; set; }
        public string VideoFoto { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public enum TipoExperiencia
    {
        Otros = 0,
        Puenting = 1,
        Masaje = 2,
        Parapente = 3,
        MotoAcuatica = 4,
        Padel = 5,
        Surf = 6,
        Karting = 7
    }
}