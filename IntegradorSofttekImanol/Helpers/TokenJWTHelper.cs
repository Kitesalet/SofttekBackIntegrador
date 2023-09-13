using IntegradorSofttekImanol.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegradorSofttekImanol.Helpers
{
    public class TokenJwtHelper
    {

        private readonly IConfiguration _configuration;

        public TokenJwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un JWT Security Token como respuesta al login correcto de un usuario a la aplicacion
        /// </summary>
        /// <param name="user">UsuarioDto</param>
        /// <returns>JWT Token</returns>
        public string GenerateToken(UsuarioDTO user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(ClaimTypes.NameIdentifier, user.Dni.ToString()),
                new Claim(ClaimTypes.Name, user.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
