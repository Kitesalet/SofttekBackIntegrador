using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private TokenJwtHelper _tokenJWTHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            
            _unitOfWork = unitOfWork;
            _tokenJWTHelper = new TokenJwtHelper(configuration);

        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateDTO authenticate)
        {

            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(authenticate);

            if(userCredentials == null)
            {
                return Unauthorized("Las credenciales ingresadas son incorrectas!");
            }

            var token = _tokenJWTHelper.GenerateToken(userCredentials);

            return Ok(token);

        }

    }
}
