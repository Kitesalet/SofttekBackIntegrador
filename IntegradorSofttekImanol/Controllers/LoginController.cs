using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private TokenJwtHelper _tokenJWTHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IOption configuration, IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _tokenJWTHelper = new TokenJwtHelper(configuration);
            _mapper = mapper;

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioAuthenticateDTO authenticate)
        {

            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(authenticate);

            if (userCredentials == null)
            {
                return Unauthorized("Las credenciales ingresadas son incorrectas!");
            }

            var token = _tokenJWTHelper.GenerateToken(userCredentials);


            //var user = _mapper.Map<UsuarioLoginDto>(userCredentials);
            var user = new UsuarioLoginDto()
            {
                Token = token,
                Dni = userCredentials.Dni,
                Nombre = userCredentials.Nombre,
                Tipo = userCredentials.Tipo
            };

            //Nunca devolver Id ni password, si no que se puede devolver nombre, apellido y rol


            return Ok(user);

        }

    }
}
