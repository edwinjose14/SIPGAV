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
    public class MaquinasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMaquinas()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Maquinas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Lista de Maquinas";
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
        public IActionResult GetMaquina(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (var db = new SIPGAVContext())
                {
                    var lst = db.Maquinas.ToList();
                    Maquina maquina = lst.Where(d => d.Id == Id).FirstOrDefault();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Maquina";
                    oRespuesta.Data = maquina;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public ActionResult AddMaquina(MaquinaViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Maquina maquina = new Maquina();
                    try
                    {
                        Map(model, maquina);
                        db.Maquinas.Add(maquina);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Maquina Registrado Con Exito!";
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
        public IActionResult UpdateMaquina(MaquinaViewModel model)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    Maquina maquina = new Maquina();
                    try
                    {
                        maquina = db.Maquinas.Find(model.Id);
                        Map(model, maquina);
                        db.Entry(maquina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Maquina Modificado Con Exito!";
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
        public IActionResult DeleteMaquina(int Id)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SIPGAVContext())
            {
                using (var transsacion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Maquina maquina = db.Maquinas.Find(Id);
                        db.Maquinas.Remove(maquina);
                        db.SaveChanges();
                        transsacion.Commit();
                        respuesta.Exito = 1;
                        respuesta.Mensaje = "Maquina Eliminado Con Exito!";
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

        private void Map(MaquinaViewModel model, Maquina maquina)
        {
            maquina.IdFinca = model.IdFinca;
            maquina.TipoMaquina = model.TipoMaquina;
            maquina.Cilindraje = model.Cilindraje;
            maquina.Tarea = model.Tarea;
            maquina.Combustible = model.Combustible;
            maquina.Cantidad = model.Cantidad;

        }
    }
}