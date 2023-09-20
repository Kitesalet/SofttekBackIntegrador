using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.HelperClasses;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace IntegradorSofttekImanol.Controllers
{

    /// <summary>
    /// Generates a Controller responsible for user authentication and login.
    /// </summary>
    
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private TokenJwtHelper _tokenJWTHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// Initializes an instance of LoginController using dependency injection with its parameters
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="configuration">IOptions with JwtSettings</param>
        /// <param name="mapper">IMapper</param>
        public LoginController(IUnitOfWork unitOfWork, IOptions<JwtSettings> configuration, IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _tokenJWTHelper = new TokenJwtHelper(configuration);
            _mapper = mapper;

        }


        /// <summary>
        /// Authenticates a user and generates a JWT token for successful login.
        /// </summary>
        /// <param name="authenticate">UsuarioAuthenticateDTO</param>
        /// <returns>
        /// If authentication is successful, returns an OK response with the JWT token.
        /// |
        /// If authentication fails, returns an Unauthorized response with an error message.
        /// </returns>

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticateDTO authenticate)
        {

            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(authenticate);

            if (userCredentials == null)
            {
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.Unauthorized,"The entered credentials are invalid");
            }

            var token = _tokenJWTHelper.GenerateToken(userCredentials);

            var user = new UserLoginDTO()
            {
                Token = token,
                CodUser = userCredentials.CodUser,
                Name = userCredentials.Name,
                Type = userCredentials.Type,
                Role = _mapper.Map<RoleDto>(userCredentials.Role)
            };

            //Never return a password

            return Ok(user);

        }

    }
}
