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
    public class AsignarController : ControllerBase
    {
        public AsignarController(
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
                BLL.AfiliadoSinAsignar bllAfiliado = new BLL.AfiliadoSinAsignar();

                List<Model.Afiliado> listaAfiliado = bllAfiliado.FiltrarAfiliadoSinAsignar();

                var listadoAfiliado = from x in listaAfiliado
                                      select new
                                      {
                                          x.IdAfiliado,
                                          x.NombreAfiliado,
                                          x.ApellidoAfiliado,
                                          x.Estado
                                      };
                if (!string.IsNullOrEmpty(filter))
                {
                    listadoAfiliado = listadoAfiliado.Where(m =>
                                               m.IdAfiliado.ToString().ToLower().Contains(filter.ToLower()) ||
                                               m.NombreAfiliado.ToLower().Contains(filter.ToLower()) ||
                                               m.ApellidoAfiliado.ToLower().Contains(filter.ToLower()) ||
                                               m.Estado.ToLower().Contains(filter.ToLower()));
                }

                if (!String.IsNullOrEmpty(sortActive))
                {
                    var dataTableFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

                    if (sortOrder == "asc")
                        listadoAfiliado = listadoAfiliado.OrderBy(
                            s =>
                            s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s)
                            );
                    else
                        listadoAfiliado = listadoAfiliado.OrderByDescending(s => s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s));
                }

                Int32 cantidadRegistro = listadoAfiliado.Count();

                listadoAfiliado = listadoAfiliado.Skip(pageNumber * pageSize).Take(pageSize);

                var respuesta = new
                {
                    lista = listadoAfiliado,
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

        [HttpGet]
        [Route("DataTableAsignar")]
        public IActionResult DataTableAsignar(
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
                                        x.ApellidoAgente
                                    };
                if (!string.IsNullOrEmpty(filter))
                {
                    listadoAgente = listadoAgente.Where(m =>
                                               m.IdAgente.ToString().ToLower().Contains(filter.ToLower()) ||
                                               m.NombreAgente.ToLower().Contains(filter.ToLower()) ||
                                               m.ApellidoAgente.ToLower().Contains(filter.ToLower())); 
                                               
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


        [HttpPost]
        public IActionResult Post([FromBody] AfiliadoInsertar modAfiliadoInsertar)
        {
            try
            {
                BLL.Afiliado bllAfiliado = new BLL.Afiliado();

                // Se crea el modelo del socioNegocio
                Model.Afiliado modAfiliado = new Model.Afiliado
                {
                    IdReferente = modAfiliadoInsertar.IdReferente,
                    NombreAfiliado = modAfiliadoInsertar.NombreAfiliado,
                    ApellidoAfiliado = modAfiliadoInsertar.ApellidoAfiliado,
                    Celular = modAfiliadoInsertar.Celular,
                    TelefonoDomicilio = modAfiliadoInsertar.TelefonoDomicilio,
                    CorreoElectronico = modAfiliadoInsertar.CorreoElectronico,
                    Cedula = modAfiliadoInsertar.Cedula,
                    Direccion1 = modAfiliadoInsertar.Direccion1,
                    Direccion2 = modAfiliadoInsertar.Direccion2,
                    FechaInscripcion = modAfiliadoInsertar.FechaInscripcion,
                    IdEstado = modAfiliadoInsertar.IdEstado,
                    IdCargo = modAfiliadoInsertar.IdCargo,
                    NombreUsuario = modAfiliadoInsertar.NombreUsuario,
                    Contraseña = modAfiliadoInsertar.Contraseña,
                };

                // Inserta en la base de datos
                modAfiliado = bllAfiliado.InsertarAfiliado(modAfiliado);

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Afiliado insertado con exito",
                    Dato = modAfiliado
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



