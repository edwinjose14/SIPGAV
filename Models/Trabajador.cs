using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Trabajador
    {
        public string Identificacion { get; set; }
        public string IdFinca { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Eps { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public string Foto { get; set; }

        public virtual Finca IdFincaNavigation { get; set; }
    }
}
