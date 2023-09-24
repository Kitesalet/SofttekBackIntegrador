using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
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
        private readonly IProjectValidator _validator;

        /// <summary>
        /// Initializes an instance of ProjectController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IProjectService.</param>
        /// <param name="logger">An ILogger.</param>
        public ProjectController(IProjectService service,IProjectValidator validator, ILogger<ProjectController> logger)
        {
            _service = service;
            _logger = logger;
            _validator = validator;
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

            #region Validations
            var validation = _validator.GetAllValidator(page, units);
            if(validation != null)
            {              
                return validation;
            }
            #endregion

            var projects = await _service.GetAllProjectsAsync(page, units);

            _logger.LogInformation("All Projects were retrieved!.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, projects);

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

            #region Validations
            var validation = _validator.GetAllProjectsByStateValidator(state);
            if()
            #endregion

            var projects = await _service.GetProjectByStateAsync(state);

            _logger.LogInformation("All filtered Projects were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, projects);
           
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

                #region Validations
                _validator.DeleteGetProjectValidator(id);
                #endregion

                var proyect = await _service.GetProjectByIdAsync(id);

                _logger.LogInformation($"proyect was retrieved, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, proyect);

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

                var flag = await _service.CreateProjectAsync(dto);

                #region Validations
                _validator.CreateProjectValidator(flag);
                #endregion

                _logger.LogInformation($"proyect was created, Descr = {dto.Name}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The project was created!");
            
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


                #region Validations
                await _validator.UpdateProjectValidator(id,dto);
                #endregion

                var result = await _service.UpdateProject(dto);

                #region Errors
                if (!result)
                {
                    _logger.LogInformation($"Error updating the proyect, id = {id}.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the project.");
                }
                #endregion

                _logger.LogInformation($"proyect was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "project was properly updated!");

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

                #region Validations
                _validator.DeleteGetProjectValidator(id);
                #endregion

                var result = await _service.DeleteProjectAsync(id);

                _logger.LogInformation($"Project was deleted ( soft deleted ), id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Project was deleted!.");

        }

    }
}
