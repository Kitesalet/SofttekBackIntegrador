using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Controllers
{
    /// <summary>
    /// Generates a Controller responsible for managing service data.
    /// </summary>

    [Route("api")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService _service;
        private readonly ILogger<ProyectoController> _logger;

        public ProyectoController(IProyectoService service, ILogger<ProyectoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Gets all proyects adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of services if successful.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("proyectos")]
        public async Task<IActionResult> GetAllProyectos([FromQuery] int page = 1, [FromQuery] int units = 10)
        {

            try
            {
                if (page < 1 || units < 0)
                {
                    _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid");
                }

                var proyectos = await _service.GetAllProyectosAsync(page, units);

                #region pagination with the helper class
                /*
                var pageToShow = 1;

                if (Request.Query.ContainsKey("page"))
                {
                    int.TryParse(Request.Query["page"], out pageToShow);
                }

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

                var paginateservices = PaginateHelper.Paginate(services,pageToShow, url);
                */
                #endregion

                _logger.LogInformation("All proyectos were retrieved!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, proyectos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Gets a proyect by their ID.
        /// </summary>
        /// <param name="id">ID of the service to get.</param>
        /// <returns>
        /// 200 OK response with the service if found.
        /// |
        /// 404 Not Found response if no service is found.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("proyecto/{id:int}")]
        public async Task<IActionResult> GetProyecto([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                var proyect = await _service.GetProyectoByIdAsync(id);

                if (proyect == null)
                {
                    _logger.LogInformation($"proyect was not found, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "proyect not found.");
                }

                _logger.LogInformation($"proyect was retrieved, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, proyect);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Creates a new service.
        /// </summary>
        /// <param name="dto">service data in a DTO.</param>
        /// <returns>
        /// 201 Created response if service creation is successful.
        /// |
        /// 400 Bad Request response if service creation fails.
        /// |
        /// 409 Conflict if service was found in the database.
        /// </returns>
        
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("proyecto/register")]
        public async Task<IActionResult> CreateProyecto(ProyectoCreateDto dto)
        {

            try
            {
                var flag = await _service.CreateProyectoAsync(dto);

                if (!flag)
                {
                    _logger.LogInformation($"proyect was not created, Nombre = {dto.Nombre}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The proyect was not created");
                }

                _logger.LogInformation($"proyect was created, Descr = {dto.Nombre}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The proyect was created!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Updates an existing proyect by their ID.
        /// </summary>
        /// <param name="id">ID of the proyect to update.</param>
        /// <param name="dto">Updated proyect data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if proyect update is successful.
        /// |
        /// 400 Bad Request response if proyect update fails.
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("proyecto/{id:int}")]
        public async Task<IActionResult> UpdateProyecto(int id, ProyectoUpdateDto dto)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, it was 0");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                if (await _service.GetProyectoByIdAsync(id) == null)
                {
                    _logger.LogInformation($"proyect was not found in the database, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "proyect was not found!");
                }

                var result = await _service.UpdateProyecto(dto);

                if (!result)
                {
                    _logger.LogInformation($"Error updating the proyect, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the proyect.");
                }

                _logger.LogInformation($"proyect was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "proyect was properly updated!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Deletes a proyect by their ID.
        /// </summary>
        /// <param name="id">ID of the proyect to delete.</param>
        /// <returns>
        /// 204 No Content response if proyect deletion is successful.
        /// |
        /// 404 Not Found response if proyect deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("proyect/{id:int}")]
        public async Task<IActionResult> DeleteProyecto([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, it was 0");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                var result = await _service.DeleteProyectoAsync(id);

                if (!result)
                {
                    _logger.LogInformation($"proyecto was not found, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The service was not found!");
                }

                _logger.LogInformation($"proyecto was deleted ( soft deleted or hard deleted ), id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The proyecto was deleted!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

    }
}
