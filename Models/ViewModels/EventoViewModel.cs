using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Models.ViewModels
{
    public class EventoViewModel
    {
        public string IdFinca { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}
