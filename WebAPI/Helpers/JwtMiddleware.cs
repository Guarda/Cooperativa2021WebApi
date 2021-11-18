
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
      
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;            
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("TCmAu77GMjr8hD3m");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                List<Claim> listaClaim = new List<Claim>();

                Claim primarysid = jwtToken.Claims.Where(x => x.Type == "primarysid").Select(x => new Claim(ClaimTypes.PrimarySid, x.Value)).FirstOrDefault();
                Claim uniqueName = jwtToken.Claims.Where(x => x.Type == "unique_name").Select(x => new Claim(ClaimTypes.Name, x.Value)).FirstOrDefault();

                listaClaim.Add(primarysid);
                listaClaim.Add(uniqueName);
                listaClaim.AddRange(jwtToken.Claims.Select(x => new Claim(x.Type, x.Value)).Where(x => x.Type != "unique_name" && x.Type != "primarysid"));

                context.User = new ClaimsPrincipal(new ClaimsIdentity(listaClaim.ToArray()));
            }
            catch (Exception e)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}