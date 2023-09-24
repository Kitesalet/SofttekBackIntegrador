using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.ControllerValidations
{
    public class ProjectValidator : IProjectValidator
    {

        private readonly ILogger _logger;
        private readonly IProjectService _service;

        public ProjectValidator(ILogger logger, IProjectService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult GetAllValidator(int page, int units)
        {

            if (page < 1 || units < 0)
            {
                _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
            }

            return null;
        }

        public IActionResult GetAllProjectsByStateValidator(int state)
        {

            if (state < 1 || state > 3)
            {
                _logger.LogInformation($"State introduced was invalid, state = {state}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The state introduced was invalid!");
            }

            return null;
        }

        public async Task<IActionResult> DeleteGetProjectValidator(int id)
        {

            if (id < 0)
            {
                _logger.LogInformation($"Id field was invalid, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            if (await _service.GetProjectByIdAsync(id) == null)
            {
                _logger.LogInformation($"proyect was not found in the database, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "proyect was not found!");
            }

            return null;
        }

        public IActionResult CreateProjectValidator(bool flag)
        {

            if(flag == false)
            {
                _logger.LogInformation($"project was not created.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The project was not created");
            }

            return null;
        }

        public async Task<IActionResult> UpdateProjectValidator(int id, ProjectUpdateDto dto)
        {

            
                if (id < 0 || dto.CodProject != id)
                {
                    _logger.LogInformation($"Id field was invalid.");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
                }

                return null;         

        }


    }
}
