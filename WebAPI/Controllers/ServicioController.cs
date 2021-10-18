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
    public class ServicioController : ControllerBase
    {

        public ServicioController(
            )
        {
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        BLL.Servicios bllServicios = new BLL.Servicios();

        //        List<Model.Servicios> listaServicios = new List<Model.Servicios>();

        //            listaServicios = bllServicios.FiltrarServicios();


        //        var listadoServicios = from x in listaServicios
        //                                  select new
        //                                  {
        //                                      x.IdServicios,
        //                                      x.Nombre,
        //                                      x.Abreviacion
        //                                  };



        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroObtenidoConExito,
        //            Dato = listadoServicios
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
                BLL.Servicios bllServicios = new BLL.Servicios();

                List<Model.Servicios> listaServicios = bllServicios.FiltrarServicios();

                var listadoServicios = from x in listaServicios
                                      select new
                                      {
                                          x.IdServicio,
                                          x.NombreServicio,
                                          x.DescripcionServicio, 
                                          x.Precio,
                                          x.Plazo,
                                          x.Estado
                                      };


                if (!string.IsNullOrEmpty(filter))
                {
                    listadoServicios = listadoServicios.Where(m =>
                                               m.IdServicio.ToString().ToLower().Contains(filter.ToLower()) ||
                                               m.NombreServicio.ToLower().Contains(filter.ToLower()) ||
                                               m.DescripcionServicio.ToLower().Contains(filter.ToLower()) ||
                                               m.Precio.ToString().Contains(filter.ToString()) ||
                                               m.Plazo.ToLower().Contains(filter.ToLower()) ||
                                               m.Estado.ToLower().Contains(filter.ToLower()));
                }

                if (!String.IsNullOrEmpty(sortActive))
                {
                    var dataTableFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

                    if (sortOrder == "asc")
                        listadoServicios = listadoServicios.OrderBy(
                            s =>
                            s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s)
                            );
                    else
                        listadoServicios = listadoServicios.OrderByDescending(s => s.GetType().GetProperty(sortActive, dataTableFlags).GetValue(s));
                }

                Int32 cantidadRegistro = listadoServicios.Count();

                listadoServicios = listadoServicios.Skip(pageNumber * pageSize).Take(pageSize);

                var respuesta = new
                {
                    lista = listadoServicios,
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
        //[Route("{idServicios:int}")]
        //[ValidarPermiso(IdPermiso = "FILTRAR_SOCIO_NEGOCIO")]
        //public IActionResult GetById(Int32 IdServicios)
        //{
        //    try
        //    {
        //        BLL.Servicios bllServicios = new BLL.Servicios();
        //        Model.Servicios modServicios = bllServicios.FiltrarServiciosxId(IdServicios);

        //        var socioNegocio = new
        //        {
        //            modServicios.IdServicios,
        //            modServicios.Nombre,
        //            modServicios.CodigoCliente,
        //            modServicios.Abreviacion,
        //            modServicios.MostrarEtiqueta,
        //            modServicios.PermitirPeso,
        //            modServicios.AgruparRemisionDetalle,
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
        //public IActionResult Post([FromBody] ServiciosInsertar socioNegocioInsertar)
        //{
        //    try
        //    {
        //        BLL.Servicios bllServicios = new BLL.Servicios();

        //        // Se crea el modelo del socioNegocio
        //        Model.Servicios modServicios = new Model.Servicios
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
        //        modServicios = bllServicios.InsertarServicios(modServicios);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroAgregadoConExito,
        //            Dato = modServicios
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
        //public IActionResult Put([FromBody] ServiciosActualizar socioNegocioActualizar)
        //{
        //    try
        //    {
        //        BLL.Servicios bllServicios = new BLL.Servicios();
        //        Model.Servicios modServicios = bllServicios.FiltrarServiciosxId(socioNegocioActualizar.IdServicios);

        //        modServicios.Nombre = socioNegocioActualizar.Nombre;
        //        modServicios.CodigoCliente = socioNegocioActualizar.CodigoCliente;

        //        modServicios.Abreviacion = socioNegocioActualizar.Abreviacion;

        //        modServicios.MostrarEtiqueta = socioNegocioActualizar.MostrarEtiqueta;
        //        modServicios.PermitirPeso = socioNegocioActualizar.PermitirPeso;
        //        modServicios.AgruparRemisionDetalle = socioNegocioActualizar.AgruparRemisionDetalle;

        //        modServicios.Activo = true;

        //        modServicios.IdUsuarioModificacion = usuarioAPI.IdUsuario;
        //        modServicios.FechaModificacion = DateTime.Now;
        //        modServicios.IpEquipoModificacion = Request.HttpContext.Connection.RemoteIpAddress.ToString();

        //        bllServicios.ActualizarServicios(modServicios);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroActualizadoConExito,
        //            Dato = modServicios
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
        //[Route("{idServicios:int}")]
        //[ValidarPermiso(IdPermiso = "ELIMINAR_SOCIO_NEGOCIO")]
        //public IActionResult Delete(Int32 idServicios)
        //{
        //    try
        //    {
        //        BLL.Servicios bllServicios = new BLL.Servicios();
        //        Model.Servicios modServicios = bllServicios.FiltrarServiciosxId(idServicios);

        //        modServicios.Activo = false;

        //        bllServicios.ActualizarServicios(modServicios);

        //        return Ok(new Respuesta
        //        {
        //            Exito = CodigoRespuesta.Exito,
        //            Mensaje = _appSettings.MensajeServidor.RegistroEliminadoConExito,
        //            Dato = modServicios
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