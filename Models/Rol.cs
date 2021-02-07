using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolUsuarios = new HashSet<RolUsuario>();
        }

        public int Id { get; set; }
        public string Rol1 { get; set; }

        public virtual ICollection<RolUsuario> RolUsuarios { get; set; }
    }
}
