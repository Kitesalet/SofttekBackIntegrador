using IntegradorSofttekImanol.Models.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces
{
    public interface IUserValidator
    {
        IActionResult UpdateError(bool flag, UserUpdateDto user);
        IActionResult GetUserValidator(int id);
        IActionResult GetAllUsersValidator(int page, int units);
        
        IActionResult DeleteGetUserValidator(int id, bool result = true);
        
        IActionResult CreateUserValidator(UserCreateDto dto, bool flag);
        
        Task<IActionResult> UpdateUserValidator(int id, UserUpdateDto dto);

        IActionResult GetUserError(UserGetDto? user);
       
        
    }
}
