using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{

    /// <summary>
    /// The implementation of the service for defining and using UsuarioDtos and its logic.
    /// </summary>
    public class TrabajoService : ITrabajoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of TrabajoService using dependency injection with its parameters
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI</param>
        /// <param name="mapper">IMapper with DI</param>
        public TrabajoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateTrabajoAsync(TrabajoCreateDto trabajoDto)
        {
            try
            {
                var trabajo = _mapper.Map<Trabajo>(trabajoDto);

                await _unitOfWork.TrabajoRepository.AddAsync(trabajo);

                trabajo.valorHora = trabajoDto.valorHora;
                trabajo.CantHoras = trabajoDto.CantHoras;
                trabajo.CodServicio = trabajoDto.CodServicio;
                trabajo.CodProyecto = trabajoDto.CodProyecto;
                trabajo.Fecha = trabajoDto.Fecha;
                trabajo.FechaAlta = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteTrabajoAsync(int id)
        {
            var flag = await _unitOfWork.TrabajoRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TrabajoGetDto>> GetAllTrabajosAsync(int page, int units)
        {
            var trabajos = await _unitOfWork.TrabajoRepository.GetAllAsync(page, units, e => e.Proyecto, e => e.Servicio);

            var trabajosDto = _mapper.Map<List<TrabajoGetDto>>(trabajos);

            return trabajosDto;
        }

        /// <inheritdoc/>
        public async Task<TrabajoGetDto> GetTrabajoByIdAsync(int id)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetByIdAsync(id);

            if (trabajo == null || trabajo.FechaBaja != null)
            {
                return null;
            }

            return _mapper.Map<TrabajoGetDto>(trabajo);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTrabajo(TrabajoUpdateDto trabajoDto)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetByIdAsync(trabajoDto.codTrabajo);

            if (trabajo == null)
            {
                return false;
            }

            trabajo.CodProyecto = trabajoDto.CodProyecto;
            trabajo.CodServicio = trabajoDto.CodServicio;
            trabajo.CantHoras = trabajoDto.CantHoras;
            trabajo.valorHora = trabajoDto.valorHora;
            trabajo.FechaUpdate = DateTime.Now;

            _unitOfWork.TrabajoRepository.Update(trabajo);

            await _unitOfWork.Complete();

            return true;
        }
    }
}
