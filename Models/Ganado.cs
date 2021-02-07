using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Ganado
    {
        public int Id { get; set; }
        public string IdFinca { get; set; }
        public string TipoAnimal { get; set; }
        public string Raza { get; set; }
        public string Vacunas { get; set; }
        public int Cantidad { get; set; }

        public virtual Finca IdFincaNavigation { get; set; }
    }
}
