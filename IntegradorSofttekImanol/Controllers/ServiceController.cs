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
    public class ServiceController : ControllerBase
    {

            private readonly IServiceService _service;
            private readonly ILogger<ServiceController> _logger;

            /// <summary>
            /// Initializes an instance of ServiceController using dependency injection with its parameters.
            /// </summary>
            /// <param name="service">An IServiceService.</param>
            /// <param name="logger">An ILogger.</param>
            public ServiceController(IServiceService service, ILogger<ServiceController> logger)
            {
                _service = service;
                _logger = logger;
            }

            /// <summary>
            /// Gets all services adding pagination.
            /// </summary>
            /// <returns>
            /// 200 OK response with the list of services if successful.
            /// |
            /// 500 BadRequest if unsuccesful.
            /// </returns>

            [HttpGet]
            [Authorize(Policy = "AdministradorOrConsultor")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [Route("services")]
            public async Task<IActionResult> GetAllServices([FromQuery] int page = 1, [FromQuery] int units = 10)
            {

                try
                {
                    if (page < 1 || units < 0)
                    {
                        _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                        return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
                    }

                    var services = await _service.GetAllServicesAsync(page, units);

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
            /// Gets all active services.
            /// </summary>
            /// <returns>
            /// 200 Ok with the list of services if successful.
            /// |
            /// 500 BadResponse if unsuccessful
            /// </returns>
            
            [HttpGet]
            [Authorize(Policy = "AdministradorOrConsultor")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Route("services/active")]
            public async Task<IActionResult> GetAllActiveServices()
            {
                try
                {
                    var activeServices = await _service.GetActiveServices();

                    _logger.LogInformation("All active services were retrieved!");
                    return Ok(activeServices);
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
            public async Task<IActionResult> GetService([FromRoute] int id)
            {

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid, id = {id}.");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                    }

                    var service = await _service.GetServiceByIdAsync(id);

                    if (service == null)
                    {
                        _logger.LogInformation($"service was not found, id = {id}.");
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
            public async Task<IActionResult> CreateService(ServiceCreateDto dto)
            {

                try
                {
                    var flag = await _service.CreateServiceAsync(dto);

                    if (!flag)
                    {
                        _logger.LogInformation($"service was not created, Descr = {dto.Descr}.");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The service was not created.");
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
            public async Task<IActionResult> UpdateService(int id, ServiceUpdateDto dto)
            {

                bool isUpdating = true;

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid, it was 0");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                    }

                    if (await _service.GetServiceByIdAsync(id, isUpdating) == null)
                    {
                        _logger.LogInformation($"service was not found in the database, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "service was not found!");
                    }

                    var result = await _service.UpdateService(dto);

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
            public async Task<IActionResult> DeleteService([FromRoute] int id)
            {

                try
                {
                    if (id < 0)
                    {
                        _logger.LogInformation($"Id field was invalid.");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                    }

                    var result = await _service.DeleteServiceAsync(id);

                    if (!result)
                    {
                        _logger.LogInformation($"service was not found, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The service was not found!");
                    }

                    _logger.LogInformation($"service was deleted ( soft deleted or hard deleted ), id = {id}.");
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
