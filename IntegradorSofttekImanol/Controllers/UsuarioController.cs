using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service; 
        }


        [HttpGet]
        [Route("usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            return Ok(await _service.GetAllUsuariosAsync());
        }

        [HttpGet]
        [Route("usuario/{id}")]
        public async Task<ActionResult<UsuarioLoginDto>> GetUsuario(int id)
        {
            
           return Ok(await _service.GetUsuarioByIdAsync(id));
            
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> CreateUsuario(UsuarioCreateDto usuario)
        {

            var user = await _service.CreateUsuarioAsync(usuario);

            return CreatedAtRoute("",user);

        }

        [HttpPut]
        [Route("usuario/{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, UsuarioUpdateDto usuario)
        {   

            var result = await _service.UpdateUsuario(usuario);

            if(result != true)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("usuario/{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var result = await _service.DeleteUsuarioAsync(id);

            if(result != true)
            {
                return NotFound(result);
            }

            return NoContent();
        }

    }
}
