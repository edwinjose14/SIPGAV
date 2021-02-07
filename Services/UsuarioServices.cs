using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SIPGAV.Models;
using SIPGAV.Models.Common;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using SIPGAV.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SIPGAV.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        
        private readonly AppSetting _app;

        public UsuarioServices(IOptions<AppSetting> app)
        {
            _app = app.Value;
    
        }

        public UsuarioRespuesta Autentificacion(LoginViewModel model)
        {
            UsuarioRespuesta respuesta = new UsuarioRespuesta();

            using (var db = new SIPGAVContext())
            {
               
                    string pass = Encriptar.GetSHA256(model.Password);

                    var usuario = db.Usuarios.Where(d => d.Correo == model.Correo &&
                                                    d.Password == pass).FirstOrDefault();
                   
                    if (usuario == null) return null;
                    
                    respuesta.Correo = usuario.Correo;
                    respuesta.Token = GetToken(usuario);
                
            }

            return respuesta;
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHdl = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_app.Secreto);
            var tokendescrip = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Identificacion),
                        new Claim(ClaimTypes.Email, usuario.Correo)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHdl.CreateToken(tokendescrip);
            return tokenHdl.WriteToken(token);
        }

    }
}
