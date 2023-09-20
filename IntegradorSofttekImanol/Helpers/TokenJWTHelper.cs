using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.HelperClasses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegradorSofttekImanol.Helpers
{
    public class TokenJwtHelper
    {

        private readonly JwtSettings _jwtSettings;

        public TokenJwtHelper(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Generates a JWT Security Token as a response to the correct login of an user.
        /// </summary>
        /// <param name="user">A user.</param>
        /// <returns>a JWT Token serialized in a string.</returns>
        public string GenerateToken(User user)
        {
            //An array of claims is created, with the information we need in our JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                new Claim(ClaimTypes.NameIdentifier, user.CodUser.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, $"{user.Type}")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //An instance of JwtSecurityToken is created, using claims, expiration time, credentials, audience and issuer
            var securityToken = new JwtSecurityToken(
                claims: claims,
                audience:_jwtSettings.Audience,
                issuer: _jwtSettings.Issuer,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
                );

            //Serialize the token to a string
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
