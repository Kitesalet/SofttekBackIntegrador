using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.ControllerValidations
{
    public class ServiceValidator : IServiceValidator
    {
        private readonly ILogger _logger;
        private readonly IServiceService _service;

        public ServiceValidator(ILogger logger, IServiceService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult CreateServiceValidator(ServiceCreateDto dto)
        {

            if (dto.HourValue < 0)
            {
                _logger.LogInformation($"service was not created, HourValue field was invalid, HourValue = {dto.HourValue}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "HourValue field was invalid!");
            }

            return null;

        }

        public async Task<IActionResult> DeleteGetServiceValidator(int id)
        {
            var service = await _service.GetServiceByIdAsync(id);

            if (id < 0)
            {
                _logger.LogInformation($"Id field was invalid, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            if (service == null)
            {
                _logger.LogInformation($"service was not found, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "service not found.");
            }

            return null;
        }

        public IActionResult GetAllServicesValidator(int page, int units)
        {
            if (page < 1 || units < 0)
            {
                _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
            }

            return null;
        }

        public async Task<IActionResult> UpdateServiceValidator(int id, ServiceUpdateDto dto)
        {

            if (id < 0 || id != dto.CodService)
            {
                _logger.LogInformation($"Id field was invalid");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid");
            }

            if (await _service.GetServiceByIdAsync(id) == null)
            {
                _logger.LogInformation($"service was not found in the database, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "service was not found!");
            }

            if (dto.HourValue < 0)
            {
                _logger.LogInformation($"service was not created, HourValue field was invalid, HourValue = {dto.HourValue}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "HourValue field was invalid!");
            }

            return null;

        }
    }
}
