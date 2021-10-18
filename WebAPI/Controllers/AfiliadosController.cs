using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Data;
using WebAPI.Response;
using WebAPI.Models;

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
        [Route("{idAfiliado:int}")]       
        public IActionResult getbyid(Int32 idAfiliado)
        {
            try
            {
                BLL.Afiliado bllafiliado = new BLL.Afiliado();
                Model.Afiliado modafiliado = bllafiliado.FiltrarAfiliadoxId(idAfiliado);

                var socionegocio = new
                {
                    modafiliado.IdAfiliado,
                    modafiliado.NombreAfiliado,
                    modafiliado.ApellidoAfiliado,
                    modafiliado.IdReferente,
                    modafiliado.Celular,
                    modafiliado.TelefonoDomicilio,
                    modafiliado.CorreoElectronico,
                    modafiliado.Cedula,
                    modafiliado.Direccion1,
                    modafiliado.Direccion2,
                    modafiliado.FechaInscripcion,
                    modafiliado.NombreUsuario,
                    modafiliado.Contraseña,
                    modafiliado.IdEstado,
                    modafiliado.IdCargo
                };

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Afiliado insertado con exito",
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

        [HttpPut]
        //[validarpermiso(idpermiso = "actualizar_socio_negocio")]
        public IActionResult put([FromBody] AfiliadoActualizar afiliadoActualizar)
        {
            try
            {
                BLL.Afiliado bllAfiliado = new BLL.Afiliado();
                Model.Afiliado modafiliado = bllAfiliado.FiltrarAfiliadoxId(afiliadoActualizar.IdAfiliado);


                modafiliado.NombreAfiliado = afiliadoActualizar.NombreAfiliado;
                modafiliado.ApellidoAfiliado = afiliadoActualizar.ApellidoAfiliado;
                modafiliado.IdReferente = afiliadoActualizar.IdReferente;

                modafiliado.Celular = afiliadoActualizar.Celular;
                modafiliado.TelefonoDomicilio = afiliadoActualizar.TelefonoDomicilio;
                modafiliado.CorreoElectronico = afiliadoActualizar.CorreoElectronico;
                modafiliado.Cedula = afiliadoActualizar.Cedula;
                modafiliado.Direccion1 = afiliadoActualizar.Direccion1;
                modafiliado.Direccion2 = afiliadoActualizar.Direccion2;
                modafiliado.FechaInscripcion = afiliadoActualizar.FechaInscripcion;
                modafiliado.NombreUsuario = afiliadoActualizar.NombreUsuario;
                modafiliado.Contraseña = afiliadoActualizar.Contraseña;
                modafiliado.IdEstado = afiliadoActualizar.IdEstado;
                modafiliado.IdCargo = afiliadoActualizar.IdCargo;
                //modafiliado.ipequipomodificacion = request.httpcontext.connection.remoteipaddress.tostring();

                bllAfiliado.ActualizarAfiliado(modafiliado);

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Afiliado actualizado con exito",
                    Dato = modafiliado
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

        [HttpDelete]
        [Route("{idAfiliado:int}")]
        // [ValidarPermiso(IdPermiso = "ELIMINAR_SOCIO_NEGOCIO")]
        public IActionResult Delete(Int32 idAfiliado)
        {
            try
            {
                BLL.Afiliado bllAfiliado = new BLL.Afiliado();
                Model.Afiliado modAfiliado = bllAfiliado.FiltrarAfiliadoxId(idAfiliado);

                modAfiliado.IdEstado = 0;

                bllAfiliado.ActualizarAfiliado(modAfiliado);

                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "El afiliado ha sido dado de baja exitosamente",
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