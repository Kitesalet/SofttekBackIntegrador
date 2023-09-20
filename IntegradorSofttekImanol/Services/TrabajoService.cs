using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class TrabajoService : ITrabajoService
    {
        public Task<bool> CreateTrabajoAsync(TrabajoCreateDto trabajoDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTrabajoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrabajoGetDto>> GetAllTrabajosAsync(int page, int units)
        {
            throw new NotImplementedException();
        }

        public Task<TrabajoGetDto> GetTrabajoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrabajo(TrabajoUpdateDto trabajoDto)
        {
            throw new NotImplementedException();
        }
    }
}
