using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Options;
using Services;
using Helpers;
using Model;
using WebAPI.Response;
using WebApi.Models;

namespace Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("Api/[Controller]")]
    public class AutenticacionController : ControllerBase
    {
        private ISessionService _sessionService;
      

        public AutenticacionController(
            ISessionService sessionService
            
            )
        {
            _sessionService = sessionService;
          
        }

        [HttpPost]
        public IActionResult Autenticacion(
            AuthenticationInput autenticacionInput
            )
        {
            try
            {

                BLL.Afiliado bllAfiliado = new BLL.Afiliado();

                // Filtra el agente que concuerde con el NombreUsuario ingresado
                Model.Afiliado modAfiliado = bllAfiliado.FiltrarAfiliadoxNombreUsuario(autenticacionInput.NombreUsuario);


                if (string.IsNullOrEmpty(modAfiliado.NombreUsuario))
                {
                    return Ok(new Respuesta
                    {
                        Exito = CodigoRespuesta.Advertencia,
                        Mensaje = "El nombre de usuario o la contraseña son incorrectos"
                    });
                }
                // Crea un SaltedHash con la contraseña y el SaltedHash generado cuando se creo la contraseña
                // para verificar si el usuario es el mismo
                //byte[] contrasena = SaltedHash.GenerateSaltedHash(autenticacionInput.Contrasena, modAfiliado.SaltedHash);

                // Compara las contraseñas encriptadas
                //bool contrasenaCorrecta = SaltedHash.CompareByteArrays(modAfiliado.Contraseña, contrasena);
                bool contraseñaCorrecta = modAfiliado.Contraseña.Equals(modAfiliado.Contraseña);

                //if (modAfiliado.IdEstadoAfiliado == EstadoAfiliadoEnumerable.PendienteVerificacion)
                //    return Ok(new Respuesta
                //    {
                //        Exito = CodigoRespuesta.Advertencia,
                //        Mensaje = "El agemte no ha confirmado el correo electrónico."
                //    });

                //if (modAfiliado.IdEstadoAfiliado == EstadoUsuarioEnumerable.Suspendido)
                //    return Ok(new Respuesta
                //    {
                //        Exito = CodigoRespuesta.Advertencia,
                //        Mensaje = "El agente ha sido suspendido, por favor contactar con el administrador."
                //    });

                // Si la contraseña es incorrecta no devolvemos el token al usuario
                if (!contraseñaCorrecta)
                {
                    return Ok(new Respuesta
                    {
                        Exito = CodigoRespuesta.Advertencia,
                        Mensaje = "El nombre de usuario o la contraseña son incorrectos"
                    });
                }

                // Si la contraseña es correcta, creamos la sesión al usuario
                Model.UsuarioSesion sessionAPI = _sessionService.Authenticate(modAfiliado);

                //BLL.HistorialInicioSesion bllHistorialInicioSesion = new BLL.HistorialInicioSesion();

                // Se retorna el token
                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = "Usuario autenticado",
                    Dato = new
                    {
                        sessionAPI
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new Respuesta
                {
                    Exito = CodigoRespuesta.Exito,
                    Mensaje = e.Message
                }) ;
            }
        }


    }
}