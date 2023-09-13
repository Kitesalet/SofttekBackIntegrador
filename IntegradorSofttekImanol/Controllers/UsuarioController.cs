using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        //[Authorize(Policy = "Admin")]
        [HttpGet]
        [Route("usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            return Ok(await _unitOfWork.UsuarioRepository.GetAll());
        }

        [HttpGet]
        [Route("usuarios/{id}")]
        public async Task<ActionResult<UsuarioGetDto>> GetUsuario(int id)
        {
            if (ModelState.IsValid)
            {

                

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> CreateUsuario(UsuarioGetDto usuario)
        {
            
        }


    }
}
