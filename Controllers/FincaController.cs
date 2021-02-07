using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SIPGAV.Models;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincaController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public FincaController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetFincas()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Fincas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Finca";
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpGet("{numeroRegistro}")]
        public IActionResult GetFinca(string numeroRegistro)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Fincas.ToList();
                    Finca finca = lst.Where(d => d.NumeroRegistro == numeroRegistro).FirstOrDefault();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Finca";
                    oRespuesta.Data = finca;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult AddFinca(FincaViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Finca finca = new Finca();
                    try
                    {
                        finca = Map(model);
                        db.Fincas.Add(finca);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Finca Registrado Con Exito!";
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
        public IActionResult UpdateFinca(FincaViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Finca finca = new Finca();
                    try
                    {
                        finca = db.Fincas.Find(model.NumeroRegistro);
                        finca = Map(model);
                        db.Entry(finca).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Finca Modificado Con Exito!";
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

        [HttpDelete("{numeroRegistro}")]
        public IActionResult DeleteFinca(string numeroRegistro)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Finca finca = db.Fincas.Find(numeroRegistro);
                        db.Fincas.Remove(finca);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Finca Eliminado Con Exito!";
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

        public Finca Map(FincaViewModel model)
        {
            Finca finca = new Finca();
            finca.NumeroRegistro = model.NumeroRegistro;
            finca.IdUsuario = model.IdUsuario;
            finca.NombreFinca = model.NombreFinca;
            finca.Descripcion = model.Descripcion;
            finca.Hectareas = model.Hectareas;
            finca.Ubicacion = model.Ubicacion;
            finca.Foto = UploadPhoto();
            finca.FechaIngreso = DateTime.Now;

            return finca;
        }
    }
}
