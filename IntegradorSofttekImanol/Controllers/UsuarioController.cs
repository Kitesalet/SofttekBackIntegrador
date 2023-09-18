using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [Authorize(Policy = "AdministradorOrConsultor")]
        [Route("usuarios")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            var users = await _service.GetAllUsuariosAsync(page, units);

            #region pagination with the helper class
            /*
            var pageToShow = 1;

            if (Request.Query.ContainsKey("page"))
            {
                int.TryParse(Request.Query["page"], out pageToShow);
            }

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

            var paginateUsers = PaginateHelper.Paginate(users,pageToShow, url);
            */
            #endregion

            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, users);
        }

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to get.</param>
        /// <returns>
        /// 200 OK response with the user if found.
        /// |
        /// 404 Not Found response if no user is found.
        /// </returns>
        
        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [Route("usuario/{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            var user = await _service.GetUsuarioByIdAsync(id);

            if (user == null)
            {
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound,"User not found.");
            }

            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="dto">User data in a DTO.</param>
        /// <returns>
        /// 201 Created response if user creation is successful.
        /// |
        /// 400 Bad Request response if user creation fails.
        /// |
        /// 409 Conflict if user was found in the database.
        /// </returns>
        
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [Route("usuarios/register")]
        public async Task<IActionResult> CreateUsuario(UsuarioCreateDto dto)
        {
            var usuarioExiste = await _service.GetUsuarioByIdAsync(dto.Dni);

            if(usuarioExiste == true)
            {

               return ResponseFactory.CreateErrorResponse(HttpStatusCode.Conflict, "The user already exists!");

            }

            var flag = await _service.CreateUsuarioAsync(dto);

            if (!flag)
            {
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user wans't created");
            }

            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The user was created!");
        }

        /// <summary>
        /// Updates an existing user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="dto">Updated user data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if user update is successful.
        /// |
        /// 400 Bad Request response if user update fails.
        /// </returns>
        
        [HttpPut]
        [Authorize(Policy = "Administrador")]
        [Route("usuario/{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, UsuarioUpdateDto dto)
        {
            if (await _service.GetUsuarioByIdAsync(id) == null)
            {
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "User was not found!");
            }

            var result = await _service.UpdateUsuario(dto);

            if (!result)
            {
                return BadRequest("Error updating the user.");
            }

            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.NoContent, "User was properly Updated!");
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to delete.</param>
        /// <returns>
        /// 204 No Content response if user deletion is successful.
        /// |
        /// 404 Not Found response if user deletion fails.
        /// </returns>
        
        [HttpDelete]
        [Authorize(Policy = "Administrador")]
        [Route("usuario/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {

            var result = await _service.DeleteUsuarioAsync(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound,"The user was not found!");
            }

            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.NoContent, "The user was deleted!");
        }
    }
}
