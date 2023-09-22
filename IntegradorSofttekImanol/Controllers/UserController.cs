using IntegradorSofttekImanol.Infrastructure;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes an instance of UserController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IUserService.</param>
        /// <param name="logger">An ILogger.</param>
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets all users adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of users if successful.
        /// </returns>
        
        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int page = 1, [FromQuery] int units = 10)
        {

            try
            {
                if(page < 1 || units < 0)
                {
                    _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest,"Pages or units input was invalid.");
                }

                var users = await _service.GetAllUsersAsync(page, units);

                _logger.LogInformation("All users were retrieved!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("user/{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                var user = await _service.GetUserByIdAsync(id);

                if (user == null)
                {
                    _logger.LogInformation($"User was not found, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "User not found.");
                }

                _logger.LogInformation($"User was retrieved, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("users/register")]
        public async Task<IActionResult> CreateUser(UserCreateDto dto)
        {

            try
            {
                var userExiste = await _service.GetUserByIdAsync(dto.Dni);

                if (userExiste != null)
                {
                    _logger.LogInformation($"User already existed, Dni = {dto.Dni}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.Conflict, "The user already exists!");

                }

                var flag = await _service.CreateUserAsync(dto);

                if (!flag)
                {
                    _logger.LogInformation($"User was not created, Dni = {dto.Dni}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user was not created.");
                }

                _logger.LogInformation($"User was created, Dni = {dto.Dni}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The user was created!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("user/{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto dto)
        {

            bool isUpdating = true;

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }


                if (await _service.GetUserByIdAsync(id, isUpdating) == null)
                {
                    _logger.LogInformation($"User was not found in the database, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "User was not found!");
                }

                var result = await _service.UpdateUser(dto);

                if (!result)
                {
                    _logger.LogInformation($"Error updating the user, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the user.");
                }

                _logger.LogInformation($"User was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "User was properly updated!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("user/{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                var result = await _service.DeleteUserAsync(id);

                if (!result)
                {
                    _logger.LogInformation($"User was not found, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The user was not found!");
                }

                _logger.LogInformation($"User was deleted ( soft deleted or hard deleted ), id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The user was deleted!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }
    }
}
