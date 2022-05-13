using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class PortalComentarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Evento { get; set; }
        public string Comentario { get; set; }

    }
}