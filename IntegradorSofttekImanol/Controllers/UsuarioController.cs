using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{


    /// <summary>
    /// Generates a Controller responsible for managing user data.
    /// </summary>
    
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
        /// Gets all users adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of users if successful.
        /// </returns>
        
        [HttpGet]
        [Route("usuarios")]
        public async Task<ActionResult<IEnumerable<TrabajoDto>>> GetAllUsers([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            var users = await _service.GetAllUsuariosAsync(page, units);

            return Ok(users);
        }

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to get.</param>
        /// <returns>
        /// 200 OK response with the user if found.
        /// 404 Not Found response if no user is found.
        /// </returns>
        
        [HttpGet]
        [Route("usuario/{id}")]
        public async Task<ActionResult<UsuarioLoginDto>> GetUsuario([FromRoute] int id)
        {
            var user = await _service.GetUsuarioByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(await _service.GetUsuarioByIdAsync(id));
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="dto">User data in a DTO.</param>
        /// <returns>
        /// 201 Created response if user creation is successful.
        /// 400 Bad Request response if user creation fails.
        /// </returns>
        
        [HttpPost]
        [Route("usuarios/register")]
        public async Task<ActionResult> CreateUsuario(UsuarioCreateDto dto)
        {
            var flag = await _service.CreateUsuarioAsync(dto);

            if (!flag)
            {
                return BadRequest(flag);
            }

            return CreatedAtRoute("", flag);
        }

        /// <summary>
        /// Updates an existing user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="dto">Updated user data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if user update is successful.
        /// 400 Bad Request response if user update fails.
        /// </returns>
        
        [HttpPut]
        [Route("usuario/{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, UsuarioUpdateDto dto)
        {
            if (await _service.GetUsuarioByIdAsync(id) == null)
            {
                return NotFound("User not found.");
            }

            var result = await _service.UpdateUsuario(dto);

            if (!result)
            {
                return BadRequest("Error updating the user.");
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to delete.</param>
        /// <returns>
        /// 204 No Content response if user deletion is successful.
        /// 404 Not Found response if user deletion fails.
        /// </returns>
        
        [HttpDelete]
        [Route("usuario/{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {

            var result = await _service.DeleteUsuarioAsync(id);

            if (!result)
            {
                return NotFound(result);
            }

            return NoContent();
        }
    }
}
