using IntegradorSofttekImanol.Controllers;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.ControllerValidations
{
    public class WorkValidator : IWorkValidator
    {
        private readonly IWorkService _service;
        private readonly ILogger<WorkController> _logger;

        public WorkValidator(IWorkService work, ILogger<WorkController> logger)
        {
            _service = work;
            _logger = logger;
        }

        public IActionResult CreateError(bool flag, WorkCreateDto dto)
        {
            if (!flag)
            {
                _logger.LogInformation($"work was not created, Fecha = {dto.Date}, CodService = {dto.CodService}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The work was not created, check if the associated service state is active.");
            }

            return null;
        }

        public IActionResult CreateWorkValidator(WorkCreateDto dto)
        {
            if (dto.HourQty < 1)
            {
                _logger.LogInformation($"HourQty field was invalid, HourValue = {dto.HourQty}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "HourQty field was invalid!");
            }

            return null;
        }

        public IActionResult DeleteError(int id, bool result)
        {
            if(result == false)
            {
                _logger.LogInformation($"The work was not deleted, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The work was not deleted");
            }

            return null;
        }

        public IActionResult DeleteGetWorkValidator(int id)
        {
            if (id < 0)
            {
                _logger.LogInformation($"Id field was invalid, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            return null;
        }

        public IActionResult GetAllWorks(int page, int units)
        {
            if (page < 1 || units < 0)
            {
                _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
            }

            return null;
        }

        public IActionResult GetError(WorkGetDto dto)
        {
            if (dto == null)
            {
                _logger.LogInformation($"work was not found");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "work not found.");
            }

            return null;
        }

        public IActionResult UpdateError(bool flag, WorkUpdateDto dto)
        {
            if (flag == false)
            {
                _logger.LogInformation($"Error updating the work, Id = {dto.CodWork}, CodService = {dto.CodService}, CodProject = {dto.CodProject}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the work, check if the associated service state is Active!");
            }

            return null;
        }

        public async Task<IActionResult> UpdateWorkValidator(int id, WorkUpdateDto dto)
        {
            if (id < 0 || id != dto.CodWork)
            {
                _logger.LogInformation($"Id field was invalid.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            if (await _service.GetWorkByIdAsync(id) == null)
            {
                _logger.LogInformation($"work was not found in the database, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "work was not found!");
            }

            return null;
        }

    }
}
