using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using curso.api.Configurations;
using curso.api.Filters;
using curso.api.Infraestruture.Data;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace curso.api.Configurations
{
    public class JwtService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(UsuarioViewModeOutput usuarioViewModeOutput)
        {
            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("jwtconfigurations:secret").Value);
            var symmetricsecuritykey = new SymmetricSecurityKey(secret);
            var securitytokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModeOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModeOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModeOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricsecuritykey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtsecuritytokenhandler = new JwtSecurityTokenHandler();
            var tokengenerated = jwtsecuritytokenhandler.CreateToken(securitytokendescriptor);
            var token = jwtsecuritytokenhandler.WriteToken(tokengenerated);

            return token;
        }
    }
}
