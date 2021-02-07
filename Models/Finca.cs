using System;
using System.Collections.Generic;

#nullable disable

namespace SIPGAV.Models
{
    public partial class Finca
    {
        public Finca()
        {
            Eventos = new HashSet<Evento>();
            Ganados = new HashSet<Ganado>();
            Maquinas = new HashSet<Maquina>();
            Trabajadors = new HashSet<Trabajador>();
        }

        public string NumeroRegistro { get; set; }
        public string IdUsuario { get; set; }
        public string NombreFinca { get; set; }
        public string Descripcion { get; set; }
        public decimal Hectareas { get; set; }
        public string Ubicacion { get; set; }
        public string Foto { get; set; }
        public DateTime FechaIngreso { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Ganado> Ganados { get; set; }
        public virtual ICollection<Maquina> Maquinas { get; set; }
        public virtual ICollection<Trabajador> Trabajadors { get; set; }
    }
}
