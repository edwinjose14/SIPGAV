using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Maquina
    {
        public int Id { get; set; }
        public string IdFinca { get; set; }
        public string TipoMaquina { get; set; }
        public string Cilindraje { get; set; }
        public string Tarea { get; set; }
        public string Combustible { get; set; }
        public int Cantidad { get; set; }

        public virtual Finca IdFincaNavigation { get; set; }
    }
}
