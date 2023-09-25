using IntegradorSofttekImanol.Models.DTOs.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Models.Interfaces.ValidationInterfaces
{
    public interface IServiceValidator
    {

        IActionResult GetAllServicesValidator(int page, int units);

        Task<IActionResult> DeleteGetServiceValidator(int id);

        IActionResult CreateServiceValidator(ServiceCreateDto dto);

        Task<IActionResult> UpdateServiceValidator(int id, ServiceUpdateDto dto);


    }
}
