using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Models.ViewModels
{
    public class TrabajadorViewModel
    {
        public string Identificacion { get; set; }
        public string IdFinca { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Eps { get; set; }
        //public int HorasTrabajadas { get; set; }
        //public decimal ValorxHora { get; set; }
        public string Foto { get; set; } 

        public int CalcularEdad()
        {
            int edad = 0;

            edad = (DateTime.Now.Year - FechaNacimiento.Year);
            if (DateTime.Today < FechaNacimiento.AddYears(edad)) edad--;

            return edad;
        }

        //public decimal CalcularSalario()
        //{
        //    decimal salario = 0;

        //    salario = HorasTrabajadas * ValorxHora;
            
        //    return salario;
        //}
    }
}
