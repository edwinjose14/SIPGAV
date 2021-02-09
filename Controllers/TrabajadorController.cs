using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIPGAV.Models;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using SIPGAV.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Exceptions.SqlServer;

namespace SIPGAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public TrabajadorController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetTrabajadores()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Trabajadors.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Trabajadores";
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
        public IActionResult GetTrabajador(string identificacion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Trabajadors.ToList();
                    Trabajador tr = lst.Where(d=>d.Identificacion==identificacion).FirstOrDefault();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Trabajador";
                    oRespuesta.Data = tr;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult AddTrabajador(TrabajadorViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Trabajador trabajador = new Trabajador();
                    try
                    {
                        trabajador = Map(model);
                        db.Trabajadors.Add(trabajador);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Trabajador Registrado Con Exito!";
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
        public IActionResult UpdateTrabajador(TrabajadorViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    //Trabajador trabajador = new Trabajador();
                    try
                    {
                        Trabajador trabajador = db.Trabajadors.Find(model.Identificacion);
                        MapUpdate(model, trabajador);

                        db.Entry(trabajador).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Trabajador Modificado Con Exito!";
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

        private void MapUpdate(TrabajadorViewModel model, Trabajador trabajador)
        {
            trabajador.IdFinca = model.IdFinca;
            trabajador.PrimerApellido = model.PrimerApellido;
            trabajador.SegundoApellido = model.SegundoApellido;
            trabajador.Nombres = model.Nombres;
            trabajador.Sexo = model.Sexo;
            trabajador.FechaNacimiento = model.FechaNacimiento;
            trabajador.Edad = model.CalcularEdad();
            trabajador.Telefono = model.Telefono;
            trabajador.Correo = model.Correo;
            trabajador.Password = Encriptar.GetSHA256(model.Password);
            trabajador.Eps = model.Eps;
            trabajador.FechaIngreso = DateTime.Now;
            trabajador.Estado = "Activo";
            trabajador.Salario = model.CalcularSalario();
            trabajador.Foto = UploadPhoto();
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
                        Trabajador trabajador = db.Trabajadors.Find(identificacion);
                        db.Trabajadors.Remove(trabajador);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Trabajador Eliminado Con Exito!";
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

        public Trabajador Map(TrabajadorViewModel model)
        {
            Trabajador trabajador = new Trabajador();

            trabajador.Identificacion = model.Identificacion;
            trabajador.IdFinca = model.IdFinca;
            trabajador.PrimerApellido = model.PrimerApellido;
            trabajador.SegundoApellido = model.SegundoApellido;
            trabajador.Nombres = model.Nombres;
            trabajador.Sexo = model.Sexo;
            trabajador.FechaNacimiento = model.FechaNacimiento;
            trabajador.Edad = model.CalcularEdad();
            trabajador.Telefono = model.Telefono;
            trabajador.Correo = model.Correo;
            trabajador.Password = Encriptar.GetSHA256(model.Password);
            trabajador.Eps = model.Eps;
            trabajador.FechaIngreso = DateTime.Now;
            trabajador.Estado = "Activo";
            trabajador.Salario = model.CalcularSalario();
            trabajador.Foto = UploadPhoto();

            return trabajador;
        }
    }
}
