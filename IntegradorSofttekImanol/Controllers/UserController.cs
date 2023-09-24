using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
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
        private readonly IUserValidator _validator;

        /// <summary>
        /// Initializes an instance of UserController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IUserService.</param>
        /// <param name="logger">An ILogger.</param>
        public UserController(IUserService service,IUserValidator validator, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
            _validator = validator;
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

                #region Validations
                _validator.GetAllUsersValidator(page, units);
                #endregion

                var users = await _service.GetAllUsersAsync(page, units);

                _logger.LogInformation("All users were retrieved!");
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("user/{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {

                #region Validations
                _validator.GetUserValidator(id);
                #endregion

                var user = await _service.GetUserByIdAsync(id);

                _validator.GetUserError(user);

                _logger.LogInformation($"User was retrieved, id = {id}.");
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("users/register")]
        public async Task<IActionResult> CreateUser(UserCreateDto dto)
        {

                //It creates the user as a Consultor at first
                var flag = await _service.CreateUserAsync(dto);

                _validator.CreateUserValidator(dto, flag);

                _logger.LogInformation($"User was created, Dni = {dto.Dni}");
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("user/{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto dto)
        {

                #region Validations
                await _validator.UpdateUserValidator(id, dto);
                #endregion

                var result = await _service.UpdateUser(dto);

                #region Errors
                _validator.UpdateError(result, dto);
                #endregion

                _logger.LogInformation($"User was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "User was properly updated!");

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

                #region Validations
                _validator.DeleteGetUserValidator(id);
                #endregion

                var result = await _service.DeleteUserAsync(id);

                #region Errors
                _validator.DeleteGetUserValidator(id, result);
                #endregion

                _logger.LogInformation($"User was deleted, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The user was deleted!");

        }
    }
}
