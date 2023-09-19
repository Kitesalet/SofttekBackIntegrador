using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class TrabajoService : ITrabajoService
    {
        /// <inheritdoc />
        public Task<bool> CreateTrabajoAsync(TrabajoDto trabajoDto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DeleteTrabajoAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TrabajoDto>> GetAllTrabajosAsync(int page, int units)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<TrabajoDto> GetTrabajoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> UpdateTrabajo(TrabajoDto trabajoDto)
        {
            throw new NotImplementedException();
        }
    }
}
