using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegradorSofttekImanol.Models.Interfaces
{
    public interface IProjectValidator
    {
        IActionResult GetAllValidator(int page, int units);

        IActionResult CreateProjectValidator(bool flag);

        IActionResult GetAllProjectsByStateValidator(int state);


        Task<IActionResult> DeleteGetProjectValidator(int id);


        Task<IActionResult> UpdateProjectValidator(int id, ProjectUpdateDto dto);
        

    }
}
