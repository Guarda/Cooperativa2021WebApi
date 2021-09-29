using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Data;
using WebAPI.Response;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfiliadoController : ControllerBase
    {

        public AfiliadoController(
            )
        {
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        BLL.Afiliado bllAfiliado = new BLL.Afiliado();

        //        List<Model.Afiliado> listaAfiliado = new List<Model.Afiliado>();

        //            listaAfiliado = bllAfiliado.FiltrarAfiliado();


        //        var listadoAfiliado = from x in listaAfiliado
        //                                  select new
        //                                  {
        //                                      x.IdAfiliado,
        //                                      x.Nombre,
        //                                      x.Abreviacion
        //                                  };



        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroObtenidoConExito,
        //            Dato = listadoAfiliado
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Error,
        //            Mensaje = $"{e.Message}",
        //            Dato = e.StackTrace
        //        });
        //    }
        //}

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
                BLL.Afiliado bllAfiliado = new BLL.Afiliado();

                List<Model.Afiliado> listaAfiliado = bllAfiliado.FiltrarAfiliado();

                var listadoAfiliado = from x in listaAfiliado
                                          select new
                                          {
                                              x.IdAfiliado,
                                              x.NombreAfiliado,
                                              x.ApellidoAfiliado
                                          };


                if (!string.IsNullOrEmpty(filter))
                {
                    listadoAfiliado = listadoAfiliado.Where(m =>
                                               m.IdAfiliado.ToString().ToLower().Contains(filter.ToLower()) ||
                                               m.NombreAfiliado.ToLower().Contains(filter.ToLower()) ||
                                               m.ApellidoAfiliado.ToLower().Contains(filter.ToLower()));
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

        //[HttpGet]
        //[Route("{idAfiliado:int}")]
        //[ValidarPermiso(IdPermiso = "FILTRAR_SOCIO_NEGOCIO")]
        //public IActionResult GetById(Int32 IdAfiliado)
        //{
        //    try
        //    {
        //        BLL.Afiliado bllAfiliado = new BLL.Afiliado();
        //        Model.Afiliado modAfiliado = bllAfiliado.FiltrarAfiliadoxId(IdAfiliado);

        //        var socioNegocio = new
        //        {
        //            modAfiliado.IdAfiliado,
        //            modAfiliado.Nombre,
        //            modAfiliado.CodigoCliente,
        //            modAfiliado.Abreviacion,
        //            modAfiliado.MostrarEtiqueta,
        //            modAfiliado.PermitirPeso,
        //            modAfiliado.AgruparRemisionDetalle,
        //        };

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroObtenidoConExito,
        //            Dato = socioNegocio
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Error,
        //            Mensaje = $"{e.Message}",
        //            Dato = e.StackTrace
        //        });
        //    }
        //}


        //[HttpPost]
        //[ValidarPermiso(IdPermiso = "INSERTAR_SOCIO_NEGOCIO")]
        //public IActionResult Post([FromBody] AfiliadoInsertar socioNegocioInsertar)
        //{
        //    try
        //    {
        //        BLL.Afiliado bllAfiliado = new BLL.Afiliado();

        //        // Se crea el modelo del socioNegocio
        //        Model.Afiliado modAfiliado = new Model.Afiliado
        //        {
        //            Nombre = socioNegocioInsertar.Nombre,
        //            Abreviacion = socioNegocioInsertar.Abreviacion,
        //            CodigoCliente = socioNegocioInsertar.CodigoCliente,

        //            MostrarEtiqueta = socioNegocioInsertar.MostrarEtiqueta,
        //            PermitirPeso = socioNegocioInsertar.PermitirPeso,
        //            AgruparRemisionDetalle = socioNegocioInsertar.AgruparRemisionDetalle,

        //            Activo = true,

        //            IdUsuarioCreacion = usuarioAPI.IdUsuario,
        //            FechaCreacion = DateTime.Now,
        //            IpEquipoCreacion = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

        //            IdUsuarioModificacion = usuarioAPI.IdUsuario,
        //            FechaModificacion = DateTime.Now,
        //            IpEquipoModificacion = Request.HttpContext.Connection.RemoteIpAddress.ToString()
        //        };

        //        // Inserta en la base de datos
        //        modAfiliado = bllAfiliado.InsertarAfiliado(modAfiliado);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroAgregadoConExito,
        //            Dato = modAfiliado
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Error,
        //            Mensaje = $"{e.Message}",
        //            Dato = e.StackTrace
        //        });
        //    }
        //}

        //[HttpPut]
        //[ValidarPermiso(IdPermiso = "ACTUALIZAR_SOCIO_NEGOCIO")]
        //public IActionResult Put([FromBody] AfiliadoActualizar socioNegocioActualizar)
        //{
        //    try
        //    {
        //        BLL.Afiliado bllAfiliado = new BLL.Afiliado();
        //        Model.Afiliado modAfiliado = bllAfiliado.FiltrarAfiliadoxId(socioNegocioActualizar.IdAfiliado);

        //        modAfiliado.Nombre = socioNegocioActualizar.Nombre;
        //        modAfiliado.CodigoCliente = socioNegocioActualizar.CodigoCliente;

        //        modAfiliado.Abreviacion = socioNegocioActualizar.Abreviacion;

        //        modAfiliado.MostrarEtiqueta = socioNegocioActualizar.MostrarEtiqueta;
        //        modAfiliado.PermitirPeso = socioNegocioActualizar.PermitirPeso;
        //        modAfiliado.AgruparRemisionDetalle = socioNegocioActualizar.AgruparRemisionDetalle;

        //        modAfiliado.Activo = true;

        //        modAfiliado.IdUsuarioModificacion = usuarioAPI.IdUsuario;
        //        modAfiliado.FechaModificacion = DateTime.Now;
        //        modAfiliado.IpEquipoModificacion = Request.HttpContext.Connection.RemoteIpAddress.ToString();

        //        bllAfiliado.ActualizarAfiliado(modAfiliado);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroActualizadoConExito,
        //            Dato = modAfiliado
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Error,
        //            Mensaje = $"{e.Message}",
        //            Dato = e.StackTrace
        //        });
        //    }
        //}

        //[HttpDelete]
        //[Route("{idAfiliado:int}")]
        //[ValidarPermiso(IdPermiso = "ELIMINAR_SOCIO_NEGOCIO")]
        //public IActionResult Delete(Int32 idAfiliado)
        //{
        //    try
        //    {
        //        BLL.Afiliado bllAfiliado = new BLL.Afiliado();
        //        Model.Afiliado modAfiliado = bllAfiliado.FiltrarAfiliadoxId(idAfiliado);

        //        modAfiliado.Activo = false;

        //        bllAfiliado.ActualizarAfiliado(modAfiliado);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroEliminadoConExito,
        //            Dato = modAfiliado
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Error,
        //            Mensaje = $"{e.Message}",
        //            Dato = e.StackTrace
        //        });
        //    }
        //}

    }
}