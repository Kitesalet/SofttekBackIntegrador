using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.Entities;
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
        /// <returns>JWT Token serializado en una cadena de caracteres.</returns>
        public string GenerateToken(Usuario user)
        {
            //Se crea el array de claims, informacion que necesitamos en nuestro JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(ClaimTypes.NameIdentifier, user.Dni.ToString()),
                new Claim(ClaimTypes.Name, user.Nombre)
            };

            //Se hace un retrieve de la key en appsettings.json, logrando la generacion de las credenciales junto con
            //La key y el algoritmo
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Se crea el JwtSecurityToken, mediante la utilizacion de las claims ( data contenida ), tiempo de expiracion y las credentials
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            //Serializado del Token a string
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
