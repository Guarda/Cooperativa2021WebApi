using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


namespace Services
{
    public interface ISessionService
    {
        Model.UsuarioSesion Authenticate(Model.Afiliado modAfiliado);
    }

    public class SessionService : ISessionService
    {
       

        public SessionService()
        {
           
        }

        public Model.UsuarioSesion Authenticate(Model.Afiliado modAfiliado)
        {
            var agenteApi = new Model.UsuarioSesion
            {
                NombreUsuario = modAfiliado.NombreUsuario,
                IdAfiliado = modAfiliado.IdAfiliado,
                FechaExpiracion = DateTime.UtcNow.AddDays(7),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TCmAu77GMjr8hD3m");

            var claims = new Dictionary<string, object>
            {
                {ClaimTypes.Name, modAfiliado.NombreUsuario},
                {ClaimTypes.PrimarySid, modAfiliado.IdAfiliado.ToString()}
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = claims,
                Expires = agenteApi.FechaExpiracion,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            agenteApi.Token = tokenHandler.WriteToken(token);

            return agenteApi;
        }
    }
}