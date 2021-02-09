using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using SIPGAV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private IUsuarioServices usuarioServices;
        public LoginController(IUsuarioServices services)
        {
            usuarioServices = services;
        }

        [HttpPost]
        public IActionResult Autentificacion([FromBody] LoginViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            var userResponse = usuarioServices.Autentificacion(model);

            if (userResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o Contraseña Incorrecta";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }
        
    }
}
