using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Models.ViewModels
{
    public class GanadoViewModel
    {
        public string IdFinca { get; set; }
        public string TipoAnimal { get; set; }
        public string Raza { get; set; }
        public string Vacunas { get; set; }
        public int Cantidad { get; set; }
    }
}
