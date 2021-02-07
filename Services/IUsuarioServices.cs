using Microsoft.AspNetCore.Mvc;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Services
{
    public interface IUsuarioServices
    {
        UsuarioRespuesta Autentificacion(LoginViewModel model);
    }
}
