using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Models.ViewModels
{
    public class MaquinaViewModel
    {
        public int Id { get; set; }
        public string IdFinca { get; set; }
        public string TipoMaquina { get; set; }
        public string Cilindraje { get; set; }
        public string Tarea { get; set; }
        public string Combustible { get; set; }
        public int Cantidad { get; set; }
    }
}