using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
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
            private readonly IServiceValidator _validator;

            /// <summary>
            /// Initializes an instance of ServiceController using dependency injection with its parameters.
            /// </summary>
            /// <param name="service">An IServiceService.</param>
            /// <param name="logger">An ILogger.</param>
            public ServiceController(IServiceService service, IServiceValidator validator , ILogger<ServiceController> logger)
            {
                    _service = service;
                    _logger = logger;
                    _validator = validator;
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

                    #region Validations
                    _validator.GetAllServicesValidator(page, units);
                    #endregion

                    var services = await _service.GetAllServicesAsync(page, units);

                    _logger.LogInformation("All services were retrieved!");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, services);

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

                 var activeServices = await _service.GetActiveServices();

                 _logger.LogInformation("All active services were retrieved!");
                 return Ok(activeServices);

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

                await _validator.DeleteGetServiceValidator(id);

                var service = _service.GetServiceByIdAsync(id);

                _logger.LogInformation($"service was retrieved, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, service);
               
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

                    #region Validations
                    _validator.CreateServiceValidator(dto);
                    #endregion

                    var flag = await _service.CreateServiceAsync(dto);

                    #region Errors
 
                    if (!flag)
                    {
                        _logger.LogInformation($"service was not created, Descr = {dto.Descr}.");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The service was not created.");
                    }
                    #endregion

                    _logger.LogInformation($"service was created, Descr = {dto.Descr}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The service was created!");


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

                    #region Validations
                    await _validator.UpdateServiceValidator(id, dto);
                    #endregion

                    var result = await _service.UpdateService(dto);

                    #region Errors
                    if (!result)
                    {
                        _logger.LogInformation($"Error updating the service, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the service.");
                    }
                    #endregion

                    _logger.LogInformation($"service was properly updated, id = {id}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "service was properly updated!");


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

                     #region Validations
                     await _validator.DeleteGetServiceValidator(id);
                     #endregion

                    var result = await _service.DeleteServiceAsync(id);

                    #region Errors
                    if (!result)
                    {
                        _logger.LogInformation($"service was not found, id = {id}");
                        return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The service was not found!");
                    }
                    #endregion

                    _logger.LogInformation($"service was deleted ( soft deleted or hard deleted ), id = {id}.");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The service was deleted!");

            }

    }
}
