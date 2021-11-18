using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Data;
using WebAPI.Response;
using WebAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize]
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



        //[validarpermiso(idpermiso = "actualizar_socio_negocio")]

        [HttpPost]
        public IActionResult Post([FromBody] AgenteInsertar agenteActualizar)
        {
            try
            {
                BLL.Agente bllAgente = new BLL.Agente();
                Model.Agente modAgente = new Model.Agente
                {
                    IdAfiliado = agenteActualizar.IdAfiliado,
                    FechaContrato = agenteActualizar.FechaContrato
                };
                bllAgente.PromoverAfiliado(modAgente);


                //modagente.ipequipomodificacion = request.httpcontext.connection.remoteipaddress.tostring();



                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Afiliado insertado con exito",
                    Dato = modAgente
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

        [HttpGet]
        [Route("{idAgente:int}")]
        public IActionResult getbyid(Int32 idAgente)
        {
            try
            {
                BLL.Agente bllagente = new BLL.Agente();
                Model.Agente modagente = bllagente.FiltrarAgentexId(idAgente);

                var socionegocio = new
                {
                    modagente.IdAfiliado,
                    modagente.IdAgente,
                    modagente.NombreAgente,
                    modagente.ApellidoAgente,                   
                    modagente.FechaContrato,                
                    modagente.IdEstado,                  
                };

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Agente insertado con exito",
                    Dato = socionegocio
                });
            }
            catch (Exception e)
            {
                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Error,
                    Mensaje = $"{e.Message}",
                    Dato = e.StackTrace
                }); ;
            }
        }

        [HttpPut]
        //[validarpermiso(idpermiso = "actualizar_socio_negocio")]
        public IActionResult put([FromBody] AgenteActualizar agenteActualizar)
        {
            try
            {
                BLL.Agente bllAgente = new BLL.Agente();
                Model.Agente modagente = bllAgente.FiltrarAgentexId(agenteActualizar.IdAgente);

                modagente.IdAgente = agenteActualizar.IdAgente;
                modagente.NombreAgente = agenteActualizar.NombreAgente;
                modagente.ApellidoAgente = agenteActualizar.ApellidoAgente;
                modagente.IdReferente = agenteActualizar.IdReferente;
                modagente.IdEstado = agenteActualizar.IdEstado;
                modagente.FechaContrato = agenteActualizar.FechaContrato;

                if (modagente.IdEstado == 0)
                {
                   // bllAgente.ActualizarAgente(modagente);
                }
                else
                {
                    bllAgente.ActualizarAgente(modagente);
                }

                //modagente.ipequipomodificacion = request.httpcontext.connection.remoteipaddress.tostring();



                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Agente actualizado con exito",
                    Dato = modagente
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
