using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Models.ViewModels
{
    public class FincaViewModel
    {
        public string NumeroRegistro { get; set; }
        public string IdUsuario { get; set; }
        public string NombreFinca { get; set; }
        public string Descripcion { get; set; }
        public decimal Hectareas { get; set; }
        public string Ubicacion { get; set; }
        public string Foto { get; set; }

    }
}
