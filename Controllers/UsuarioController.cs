using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SIPGAV.Models;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using SIPGAV.Services;
using SIPGAV.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public UsuarioController(IConfiguration configuration, IWebHostEnvironment env, IMapper mapper)
        {
            _configuration = configuration;
            _env = env;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Usuarios.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Usuarios";
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
            
        }

        [HttpGet("{identificacion}")]
        public IActionResult GetUsuario(string identificacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Usuarios.ToList();
                    Usuario us = lst.Where(d=>d.Identificacion==identificacion).FirstOrDefault();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Usuarios";
                    oRespuesta.Data = us;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult Add(UsuarioViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Usuario usuario = new Usuario();
                    try
                    {
                        usuario = Map(model);
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Usuario Registrado Con Exito!";
                    }
                    catch (Exception ex)
                    {
                        transsacion.Rollback();
                        respuesta.Mensaje = ex.Message;
                    }
                    return Ok(respuesta);
                }
            }
        }
        [Route("UploadPhoto")]
        [HttpPost]
        public string UploadPhoto()
        {
            string filename = "";
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                filename = Guid.NewGuid().ToString() + postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Files/Photos/" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            catch (Exception)
            {
                filename = "anonimo.png";
            }
            return filename;
        }

        [HttpPut]
        public IActionResult Update(UsuarioViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Usuario usuario = new Usuario();
                    try
                    {
                        usuario = db.Usuarios.Find(model.Identificacion);
                        usuario = Map(model);
                        db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Usuario Modificado Con Exito!";
                    }
                    catch (Exception ex)
                    {
                        transsacion.Rollback();
                        respuesta.Mensaje = ex.Message;
                    }
                    return Ok(respuesta);
                }
            }
        }

        [HttpDelete("{identificacion}")]
        public IActionResult Delete(string identificacion)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Usuario usuario = db.Usuarios.Find(identificacion);
                        db.Usuarios.Remove(usuario);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Usuario Eliminado Con Exito!";
                    }
                    catch (Exception ex)
                    {
                        transsacion.Rollback();
                        respuesta.Mensaje = ex.Message;
                    }
                }
            }
            return Ok(respuesta);
        }

        public Usuario Map(UsuarioViewModel model)
        {
            Usuario usuario = new Usuario();
            usuario.Identificacion = model.Identificacion;
            usuario.PrimerApellido = model.PrimerApellido;
            usuario.SegundoApellido = model.SegundoApellido;
            usuario.Nombres = model.Nombres;
            usuario.Correo = model.Correo;
            usuario.Password = Encriptar.GetSHA256(model.Identificacion);
            usuario.NumeroFincas = usuario.Fincas.Count;
            usuario.Foto = UploadPhoto();
            usuario.Telefono1 = model.Telefono1;
            usuario.Telefono2 = model.Telefono2;
            usuario.FechaIngreso = DateTime.Now;
            
            return usuario;
        }

    }
}
