using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Data;
using WebAPI.Response;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenteController : ControllerBase
    {
        public AgenteController(
            )
        {
        }

        [HttpGet]
        [Route("DataTable")]
        public IActionResult DataTable(
           String filter,
           String sortActive,
           String sortOrder,
           Int32 pageNumber,
           Int32 pageSize
           )
        {
            try
            {
                BLL.Agente bllAgente = new BLL.Agente();

                List<Model.Agente> listaAgente = bllAgente.FiltrarAgente();

                var listadoAgente = from x in listaAgente
                                      select new
                                      {
                                          x.IdAgente,
                                          x.NombreAgente,
                                          x.ApellidoAgente,
                                          x.Estado
                                      };
                if (!string.IsNullOrEmpty(filter))
                {
                    listadoAgente = listadoAgente.Where(m =>
                                               m.IdAgente.ToString().ToLower().Contains(filter.ToLower()) ||
                                               m.NombreAgente.ToLower().Contains(filter.ToLower()) ||
                                               m.ApellidoAgente.ToLower().Contains(filter.ToLower()) ||
                                               m.Estado.ToLower().Contains(filter.ToLower()));
                }

                if (!String.IsNullOrEmpty(sortActive))
                {
                    var dataTableFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

                    if (sortOrder == "asc")
                        listadoAgente = listadoAgente.OrderBy(
                            s =>
                            s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s)
                            );
                    else
                        listadoAgente = listadoAgente.OrderByDescending(s => s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s));
                }

                Int32 cantidadRegistro = listadoAgente.Count();

                listadoAgente = listadoAgente.Skip(pageNumber * pageSize).Take(pageSize);

                var respuesta = new
                {
                    lista = listadoAgente,
                    cantidadRegistro
                };

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = MensajeServidor.RegistroObtenidoConExito,
                    Dato = respuesta
                });
            }
            catch (Exception e)
            {
                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Error,
                    Mensaje = $"{e.Message}",
                    Dato = e.StackTrace
                });
            }
        }
    }
}
