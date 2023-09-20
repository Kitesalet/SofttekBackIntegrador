using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the proyect for defining and using ProyectDtos and its logic.
    /// </summary>
    public class ProyectoService : IProyectoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of ProyectoService using dependency injection with its parameters
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI</param>
        /// <param name="mapper">IMapper with DI</param>
        public ProyectoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<bool> CreateProyectoAsync(ProyectoCreateDto proyectoDto)
        {
            try
            {
                var proyecto = _mapper.Map<Proyecto>(proyectoDto);

                await _unitOfWork.ProyectoRepository.AddAsync(proyecto);

                proyecto.Estado = Estado.Pendiente;
                proyecto.FechaAlta = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
                return false;
            }


        }

        /// <inheritdoc />
        public async Task<bool> DeleteProyectoAsync(int id)
        {
            var flag = await _unitOfWork.ProyectoRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProyectoGetDto>> GetAllProyectosAsync(int page, int units)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAllAsync(page, units, e => e.Trabajos);

            foreach (var x in proyectos)
            {
                // Hacer un GetTrabajosByProyecto
            }

            var proyectosDto = _mapper.Map<List<ProyectoGetDto>>(proyectos);

            return proyectosDto;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProyectoGetDto>> GetProyectoByEstadoAsync(int state)
        {
            
            var proyectos = await _unitOfWork.ProyectoRepository.GetProyectoByEstado(state);

            var proyectosDto = _mapper.Map<List<ProyectoGetDto>>(proyectos);

            return proyectosDto;

        }

        /// <inheritdoc />
        public async Task<ProyectoGetDto> GetProyectoByIdAsync(int id)
        {
            var proyecto = await _unitOfWork.ProyectoRepository.GetByIdAsync(id);

            if (proyecto == null || proyecto.FechaBaja != null)
            {
                return null;
            }

            return _mapper.Map<ProyectoGetDto>(proyecto);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateProyecto(ProyectoUpdateDto proyectoDto)
        {
            var proyecto = await _unitOfWork.ProyectoRepository.GetByIdAsync(proyectoDto.CodProyecto);

            if (proyecto == null)
            {
                return false;
            }

            proyecto.Direccion = proyectoDto.Direccion;
            proyecto.Estado = proyectoDto.Estado;
            proyecto.Nombre = proyectoDto.Nombre;
            proyecto.FechaUpdate = DateTime.Now;
            //realizar getProyectosByTrabajo

            _unitOfWork.ProyectoRepository.Update(proyecto);

            await _unitOfWork.Complete();

            return true;
        }
    }
}
