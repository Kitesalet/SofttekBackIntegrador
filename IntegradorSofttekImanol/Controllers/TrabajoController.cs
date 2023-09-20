using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Controllers
{
    /// <summary>
    /// Generates a Controller responsible for managing work data.
    /// </summary>

    [Route("api")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {

        private readonly ITrabajoService _service;
        private readonly ILogger<TrabajoController> _logger;

        public TrabajoController(ITrabajoService work, ILogger<TrabajoController> logger)
        {
            _service = work;
            _logger = logger;
        }

        /// <summary>
        /// Gets all works adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of works if successful.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("works")]
        public async Task<IActionResult> GetAllTrabajos([FromQuery] int page = 1, [FromQuery] int units = 10)
        {

            try
            {
                if (page < 1 || units < 0)
                {
                    _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}");
                    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid");
                }

                var works = await _service.GetAllTrabajosAsync(page, units);

                #region pagination with the helper class
                /*
                var pageToShow = 1;

                if (Request.Query.ContainsKey("page"))
                {
                    int.TryParse(Request.Query["page"], out pageToShow);
                }

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

                var paginateworks = PaginateHelper.Paginate(works,pageToShow, url);
                */
                #endregion

                _logger.LogInformation("All works were retrieved!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, works);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Gets a work by their ID.
        /// </summary>
        /// <param name="id">ID of the work to get.</param>
        /// <returns>
        /// 200 OK response with the work if found.
        /// |
        /// 404 Not Found response if no work is found.
        /// </returns>

        [HttpGet]
        [Authorize(Policy = "AdministradorOrConsultor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("work/{id:int}")]
        public async Task<IActionResult> GetTrabajo([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                var work = await _service.GetTrabajoByIdAsync(id);

                if (work == null)
                {
                    _logger.LogInformation($"work was not found, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "work not found.");
                }

                _logger.LogInformation($"work was retrieved, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, work);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Creates a new work.
        /// </summary>
        /// <param name="dto">work data in a DTO.</param>
        /// <returns>
        /// 201 Created response if work creation is successful.
        /// |
        /// 400 Bad Request response if work creation fails.
        /// |
        /// 409 Conflict if work was found in the database.
        /// </returns>

        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("work/register")]
        public async Task<IActionResult> CreateTabajo(TrabajoCreateDto dto)
        {

            try
            {
                var flag = await _service.CreateTrabajoAsync(dto);

                if (!flag)
                {
                    _logger.LogInformation($"work was not created, Fecha = {dto.Fecha}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The work was not created");
                }

                _logger.LogInformation($"work was created, Fecha = {dto.Fecha}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The work was created!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Updates an existing work by their ID.
        /// </summary>
        /// <param name="id">ID of the work to update.</param>
        /// <param name="dto">Updated work data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if work update is successful.
        /// |
        /// 400 Bad Request response if work update fails.
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("work/{id:int}")]
        public async Task<IActionResult> UpdateTrabajo(int id, TrabajoUpdateDto dto)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, it was 0");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                if (await _service.GetTrabajoByIdAsync(id) == null)
                {
                    _logger.LogInformation($"work was not found in the database, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "work was not found!");
                }

                var result = await _service.UpdateTrabajo(dto);

                if (!result)
                {
                    _logger.LogInformation($"Error updating the work, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the work.");
                }

                _logger.LogInformation($"work was properly updated, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "work was properly updated!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Deletes a work by their ID.
        /// </summary>
        /// <param name="id">ID of the work to delete.</param>
        /// <returns>
        /// 204 No Content response if work deletion is successful.
        /// |
        /// 404 Not Found response if work deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize(Policy = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("work/{id:int}")]
        public async Task<IActionResult> DeleteTrabajo([FromRoute] int id)
        {

            try
            {
                if (id < 0)
                {
                    _logger.LogInformation($"Id field was invalid, it was 0");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
                }

                var result = await _service.DeleteTrabajoAsync(id);

                if (!result)
                {
                    _logger.LogInformation($"work was not found, id = {id}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The work was not found!");
                }

                _logger.LogInformation($"work was deleted ( soft deleted or hard deleted ), id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The work was deleted!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

    }
}
