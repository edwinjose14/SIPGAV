using AutoMapper;
using SIPGAV.Models;
using SIPGAV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV
{
    public class MappingProfile : Profile
    {
        /*
        public MappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>().ForMember(
                d=>d.PrimerApellido, o=>o.MapFrom(o=>o.PrimerApellido) );
        }
        */
    }
}
