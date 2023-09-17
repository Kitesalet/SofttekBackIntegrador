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

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        [HttpGet]
        [Route("usuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioGetDto>>> GetAllUsuarios()
        {
            var users = await _service.GetAllUsuariosAsync();

            return Ok(users);
        }

        /// <summary>
        /// Obtiene un usuario por su id.
        /// </summary>
        /// <param name="id">id del usuario a buscar.</param>
        [HttpGet]
        [Route("usuario/{id}")]
        public async Task<ActionResult<UsuarioLoginDto>> GetUsuario([FromRoute] int id)
        {
            var user = await _service.GetUsuarioByIdAsync(id);

            if (user == null)
            {
                return NotFound("No se ha encontrado el usuario.");
            }

            return Ok(await _service.GetUsuarioByIdAsync(id));
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">Datos del usuario a crear en un dto.</param>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> CreateUsuario(UsuarioCreateDto usuario)
        {
            var flag = await _service.CreateUsuarioAsync(usuario);

            if (!flag)
            {
                return BadRequest(flag);
            }

            return CreatedAtRoute("", flag);
        }

        /// <summary>
        /// Actualiza un usuario existente por su id.
        /// </summary>
        /// <param name="id">id del usuario a actualizar.</param>
        /// <param name="usuario">Datos actualizados del usuario en un dto</param>
        [HttpPut]
        [Route("usuario/{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, UsuarioUpdateDto usuario)
        {
            if (await _service.GetUsuarioByIdAsync(id) == null)
            {
                return NotFound("El usuario no ha sido encontrado.");
            }

            var result = await _service.UpdateUsuario(usuario);

            if (!result)
            {
                return BadRequest("Ha habido un error en la actualización del usuario.");
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un usuario por su id.
        /// </summary>
        /// <param name="id">id del usuario a eliminar.</param>
        [HttpDelete]
        [Route("usuario/{id}")]
        public async Task<ActionResult> DeleteUsuario([FromRoute] int id)
        {
            if (await _service.GetUsuarioByIdAsync(id) == null)
            {
                return NotFound("El usuario no ha sido encontrado.");
            }

            var result = await _service.DeleteUsuarioAsync(id);

            if (!result)
            {
                return BadRequest(result);
            }

            return NoContent();
        }
    }
}
