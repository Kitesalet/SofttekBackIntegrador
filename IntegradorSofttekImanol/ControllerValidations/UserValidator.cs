using IntegradorSofttekImanol.Controllers;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.ControllerValidations
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserValidator(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult GetUserValidator(int id) 
        {
            if (id < 0)
            {
                _logger.LogInformation($"Id field was invalid, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            return null;

        }
        public IActionResult CreateUserValidator(UserCreateDto dto, bool flag)
        {
            if (dto.Dni < 0)
            {
                _logger.LogInformation($"User was not created, invalid Dni, Dni = {dto.Dni}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user was not created, Dni was invalid.");
            }
            if (flag == false)
            {
                _logger.LogInformation($"User was not created, Dni = {dto.Dni}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user was not created.");
            }

            return null;
        }

        public IActionResult DeleteGetUserValidator(int id , bool result = true)
        {

            if (id < 0)
            {
                _logger.LogInformation($"Id field was invalid.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            if (!result)
            {
                _logger.LogInformation($"User was not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The user was not found!");
            }

            return null;
        }

        public IActionResult GetAllUsersValidator(int page, int units)
        {

            if (page < 1 || units < 0)
            {
                _logger.LogInformation($"Pages or unit input was invalid, pages = {page}, units = {units}.");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Pages or units input was invalid.");
            }

            return null;
        }

        public async Task<IActionResult> UpdateUserValidator(int id, UserUpdateDto dto)
        {
            if (id < 0 || id != dto.CodUser)
            {
                _logger.LogInformation($"Id field was invalid, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Id field is invalid.");
            }

            if (dto.Type > 2 || dto.Type < 1)
            {
                _logger.LogInformation($"Type field was invalid, type = {dto.Type}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The type field was invalid");
            }

            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"User was not found in the database, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "User was not found!");
            }

            return null;
        }

        public IActionResult UpdateError(bool flag, UserUpdateDto user)
        {
            if (flag == false)
            {
                _logger.LogInformation($"Error updating the user, id = {user.CodUser}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Error updating the user.");
            }

            return null;
        }

        public IActionResult GetUserError(UserGetDto? user, int id)
        {
            if (user == null)
            {
                _logger.LogInformation($"User was not found, id = {id}.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "User not found.");
            }

            return null;
        }
    }
}
