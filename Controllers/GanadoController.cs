using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIPGAV.Models;
using SIPGAV.Models.Response;
using SIPGAV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPGAV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGanado()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Ganados.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Ganado";
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Ganados.ToList();
                    Ganado ganado = lst.Where(d => d.Id == Id).FirstOrDefault();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Ganado";
                    oRespuesta.Data = ganado;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult AddGanado(GanadoViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Ganado ganado = new Ganado();
                    try
                    {
                        Map(model, ganado);
                        db.Ganados.Add(ganado);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Ganado Registrado Con Exito!";
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


        [HttpPut]
        public IActionResult UpdateGanado(GanadoViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Ganado ganado = new Ganado();
                    try
                    {
                        ganado = db.Ganados.Find(model.Id);
                        Map(model, ganado);
                        db.Entry(ganado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Ganado Modificado Con Exito!";
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

        [HttpDelete("{Id}")]
        public IActionResult DeleteGanado(int Id)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Ganado ganado = db.Ganados.Find(Id);
                        db.Ganados.Remove(ganado);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Ganado Eliminado Con Exito!";
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

        private void Map(GanadoViewModel model, Ganado ganado)
        {
            ganado.IdFinca = model.IdFinca;
            ganado.Raza = model.Raza;
            ganado.TipoAnimal = model.TipoAnimal;
            ganado.Cantidad = model.Cantidad;
            ganado.Vacunas = model.Vacunas;

        }
    }
}
