using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class RolUsuario
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string IdUsuario { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
