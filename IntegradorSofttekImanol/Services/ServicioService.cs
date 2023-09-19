using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class ServicioService : IServicioService
    {
        /// <inheritdoc />
        public Task<bool> CreateServicioAsync(ServicioDTO trabajoDto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> DeleteServicioAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<ServicioDTO>> GetAllServiciosAsync(int page, int units)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<ServicioDTO> GetServicioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> UpdateServicio(ServicioDTO trabajoDto)
        {
            throw new NotImplementedException();
        }
    }
}
