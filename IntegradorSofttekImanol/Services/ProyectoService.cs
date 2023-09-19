using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class ProyectoService : IProyectoService
    {
        public Task<bool> CreateProyectoAsync(ProyectoDTO proyectoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProyectoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProyectoDTO>> GetAllProyectosAsync(int page, int units)
        {
            throw new NotImplementedException();
        }

        public Task<ProyectoDTO> GetProyectoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProyecto(ProyectoDTO proyectoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
