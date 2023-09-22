using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Controllers
{
    /// <summary>
    /// Generates a Controller responsible for managing project data.
    /// </summary>

    [Route("api")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly ILogger<ProjectController> _logger;

        /// <summary>
        /// Initializes an instance of ProjectController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IProjectService.</param>
        /// <param name="logger">An ILogger.</param>
        public ProjectController(IProjectService service, ILogger<ProjectController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets all projects adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of services if successful.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("projects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] int page = 1, [FromQuery] int units = 10)
        {

            try
            {
                if (page < 1 || units < 0)
                {
                    _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
                }

                var projects = await _service.GetAllProjectsAsync(page, units);

                _logger.LogInformation("All Projects were retrieved!.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Gets all projects filtered by state.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of services if successful.
        /// |
        /// 400 Bad Request response if state is invalid
        /// |
        /// 500 Internal Server Error if theres an exception
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("projects/state/{state}")]
        public async Task<IActionResult> GetAllProjectsByState(int state)
        {

            try
            {
                if (state < 1 || state > 3)
                {
                    _logger.LogInformation($"State introduced was invalid, state = {state}.");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The state introduced was invalid!");
                }

                var projects = await _service.GetProjectByStateAsync(state);        

                _logger.LogInformation("All filtered Projects were retrieved!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Gets a project by their ID.
        /// </summary>
        /// <param name="id">ID of the project to get.</param>
        /// <returns>
        /// 200 OK response with the project if found.
        /// |
        /// 404 Not Found response if no project is found.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("project/{id:int}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                var proyect = await _service.GetProjectByIdAsync(id);

                if (proyect == null)
                {
                    _logger.LogInformation($"proyect was not found, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "proyect not found.");
                }

                _logger.LogInformation($"proyect was retrieved, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, proyect);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="dto">Project data in a DTO.</param>
        /// <returns>
        /// 201 Created response if service creation is successful
        /// |
        /// 400 Bad Request response if service creation fails
        /// |
        /// 409 Conflict if service was found in the database
        /// </returns>
        
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("project/register")]
        public async Task<IActionResult> CreateProject(ProjectCreateDto dto)
        {

            try
            {
                var flag = await _service.CreateProjectAsync(dto);

                if (!flag)
                {
                    _logger.LogInformation($"project was not created, Nombre = {dto.Name}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The project was not created");
                }

                _logger.LogInformation($"proyect was created, Descr = {dto.Name}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The project was created!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Updates an existing project by their ID.
        /// </summary>
        /// <param name="id">ID of the project to update.</param>
        /// <param name="dto">Updated project data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if proyect update is successful
        /// |
        /// 400 Bad Request response if proyect update fails
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("project/{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectUpdateDto dto)
        {

            bool isUpdating = true;

            try
            {
                if (id < 0 || dto.CodProject != id)
                {
                    _logger.LogInformation($"Id field was invalid.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                if (await _service.GetProjectByIdAsync(id, isUpdating) == null)
                {
                    _logger.LogInformation($"proyect was not found in the database, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "proyect was not found!");
                }

                var result = await _service.UpdateProject(dto);

                if (!result)
                {
                    _logger.LogInformation($"Error updating the proyect, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the project.");
                }

                _logger.LogInformation($"proyect was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "project was properly updated!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Deletes a project by their ID.
        /// </summary>
        /// <param name="id">ID of the project to delete.</param>
        /// <returns>
        /// 204 No Content response if project deletion is successful.
        /// |
        /// 404 Not Found response if project deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("project/{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, it was 0.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                var result = await _service.DeleteProjectAsync(id);

                if (!result)
                {
                    _logger.LogInformation($"Project was not found, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The project was not found!");
                }

                _logger.LogInformation($"Project was deleted ( soft deleted or hard deleted ), id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Project was deleted!.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

    }
}
