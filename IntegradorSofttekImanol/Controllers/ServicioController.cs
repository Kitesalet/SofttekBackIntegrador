using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Controllers
{

    /// <summary>
    /// Generates a Controller responsible for managing service data.
    /// </summary>

    [Route("api")]
    [ApiController]
    [Authorize]
    public class ServicioController : ControllerBase
    {

            private readonly IServicioService _service;
            private readonly ILogger<ServicioController> _logger;

            public ServicioController(IServicioService service, ILogger<ServicioController> logger)
            {
                _service = service;
                _logger = logger;
            }

            /// <summary>
            /// Gets all services adding pagination.
            /// </summary>
            /// <returns>
            /// 200 OK response with the list of services if successful.
            /// </returns>

            [HttpGet]
            [Authorize(Policy = "AdministradorOrConsultor")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [Route("services")]
            public async Task<IActionResult> GetAllServicios([FromQuery] int page = 1, [FromQuery] int units = 10)
            {

                try
                {
                    if (page < 1 || units < 0)
                    {
                        _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}");
                        return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid");
                    }

                    var services = await _service.GetAllServiciosAsync(page, units);

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

                    _logger.LogInformation("All services were retrieved!");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, services);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
                }
            }

            /// <summary>
            /// Gets a service by their ID.
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
            [Route("service/{id:int}")]
            public async Task<IActionResult> GetServicio([FromRoute] int id)
            {

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                    }

                    var service = await _service.GetServicioByIdAsync(id);

                    if (service == null)
                    {
                        _logger.LogInformation($"service was not found, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "service not found.");
                    }

                    _logger.LogInformation($"service was retrieved, id = {id}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, service);
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
            [Route("service/register")]
            public async Task<IActionResult> CreateServicio(ServicioCreateDto dto)
            {

                try
                {
                    var flag = await _service.CreateServicioAsync(dto);

                    if (!flag)
                    {
                        _logger.LogInformation($"service was not created, Descr = {dto.Descr}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The service was not created");
                    }

                    _logger.LogInformation($"service was created, Descr = {dto.Descr}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The service was created!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
                }

            }

            /// <summary>
            /// Updates an existing service by their ID.
            /// </summary>
            /// <param name="id">ID of the service to update.</param>
            /// <param name="dto">Updated service data in a DTO.</param>
            /// <returns>
            /// 204 No Content response if service update is successful.
            /// |
            /// 400 Bad Request response if service update fails.
            /// </returns>

            [HttpPut]
            [Authorize(Policy = "Administrador")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status403Forbidden)]
            [Route("service/{id:int}")]
            public async Task<IActionResult> UpdateServicio(int id, ServicioUpdateDto dto)
            {

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid, it was 0");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                    }

                    if (await _service.GetServicioByIdAsync(id) == null)
                    {
                        _logger.LogInformation($"service was not found in the database, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "service was not found!");
                    }

                    var result = await _service.UpdateServicio(dto);

                    if (!result)
                    {
                        _logger.LogInformation($"Error updating the service, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the service.");
                    }

                    _logger.LogInformation($"service was properly updated, id = {id}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "service was properly updated!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
                }

            }

            /// <summary>
            /// Deletes a service by their ID.
            /// </summary>
            /// <param name="id">ID of the service to delete.</param>
            /// <returns>
            /// 204 No Content response if service deletion is successful.
            /// |
            /// 404 Not Found response if service deletion fails.
            /// </returns>

            [HttpDelete]
            [Authorize(Policy = "Administrador")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status403Forbidden)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [Route("service/{id:int}")]
            public async Task<IActionResult> DeleteServicio([FromRoute] int id)
            {

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid, it was 0");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                    }

                    var result = await _service.DeleteServicioAsync(id);

                    if (!result)
                    {
                        _logger.LogInformation($"service was not found, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The service was not found!");
                    }

                    _logger.LogInformation($"service was deleted ( soft deleted or hard deleted ), id = {id}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The service was deleted!");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
                }
            }

    }
}
