using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
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
    public class WorkController : ControllerBase
    {

        private readonly IWorkService _service;
        private readonly ILogger<WorkController> _logger;
        private readonly IWorkValidator _validator;

        /// <summary>
        /// Initializes an instance of WorkController using dependency injection with its parameters.
        /// </summary>
        /// <param name="work">An IWorkService.</param>
        /// <param name="logger">An ILogger.</param>
        public WorkController(IWorkService work,IWorkValidator validator, ILogger<WorkController> logger)
        {
            _service = work;
            _logger = logger;
            _validator = validator;
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
        public async Task<IActionResult> GetAllWorks([FromQuery] int page = 1, [FromQuery] int units = 10)
        {

                _validator.GetAllWorks(page, units);

                var works = await _service.GetAllWorksAsync(page, units);

                _logger.LogInformation("All works were retrieved!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, works);

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
        public async Task<IActionResult> GetWork([FromRoute] int id)
        {

            
                #region Validations
                _validator.DeleteGetWorkValidator(id);
                #endregion

                var work = await _service.GetWorkByIdAsync(id);

                #region Errors
                _validator.GetError(work);
                #endregion

                _logger.LogInformation($"work was retrieved, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, work);
            


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
        public async Task<IActionResult> CreateWork(WorkCreateDto dto)
        {

                #region Validations
                _validator.CreateWorkValidator(dto);
                #endregion

                var flag = await _service.CreateWorkAsync(dto);

                #region Errors
                _validator.CreateError(flag, dto);
                #endregion

                _logger.LogInformation($"work was created, Fecha = {dto.Date}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The work was created!");


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
        public async Task<IActionResult> UpdateWork(int id, WorkUpdateDto dto)
        {

                #region Validations
                _validator.UpdateWorkValidator(id, dto);
                #endregion

                var result = await _service.UpdateWork(dto);

                #region Errors
                _validator.UpdateError(result, dto);
                #endregion

                _logger.LogInformation($"work was properly updated, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "work was properly updated!");

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
        public async Task<IActionResult> DeleteWork([FromRoute] int id)
        {


                #region Validations
                _validator.DeleteGetWorkValidator(id);
                #endregion

                var result = await _service.DeleteWorkAsync(id);

                #region Errors
                _validator.DeleteError(id, result);
                #endregion

                _logger.LogInformation($"work was deleted, id = {id}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The work was deleted!");

        }

    }
}
