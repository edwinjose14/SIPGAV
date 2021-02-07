using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Fincas = new HashSet<Finca>();
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public string Identificacion { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public int NumeroFincas { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Finca> Fincas { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
