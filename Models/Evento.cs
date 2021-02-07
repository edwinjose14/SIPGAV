using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string IdFinca { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual Finca IdFincaNavigation { get; set; }
    }
}
