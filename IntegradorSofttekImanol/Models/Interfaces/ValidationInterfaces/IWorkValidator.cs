using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces
{
    public interface IWorkValidator
    {

        IActionResult GetAllWorks(int page = 1, int units = 10);

        IActionResult DeleteGetWorkValidator(int id);

        IActionResult DeleteError(int id, bool result);  
        IActionResult GetError(WorkGetDto dto);

        IActionResult CreateWorkValidator(WorkCreateDto dto);

        IActionResult CreateError(bool flag, WorkCreateDto dto);

        Task<IActionResult> UpdateWorkValidator(int id, WorkUpdateDto dto);

        IActionResult UpdateError(bool flag, WorkUpdateDto dto);



    }
}
