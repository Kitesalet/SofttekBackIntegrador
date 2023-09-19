using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the service for defining and using UsuarioDtos and its logic.
    /// </summary>
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of ServicioService using dependency injection with its parameters
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI</param>
        /// <param name="mapper">IMapper with DI</param>
        public ServicioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<bool> CreateServicioAsync(ServicioCreateDto servicioDto)
        {
            try
            {
                var servicio = _mapper.Map<Servicio>(servicioDto);

                await _unitOfWork.ServicioRepository.AddAsync(servicio);

                servicio.FechaAlta = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteServicioAsync(int id)
        {
            var flag = await _unitOfWork.ServicioRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ServicioGetDto>> GetAllServiciosAsync(int page, int units)
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAllAsync(page, units, e => e.Trabajo);

            foreach(var x in servicios)
            {
                // Hacer un GetTrabajosByServicio
            }

            var serviciosDto = _mapper.Map<List<ServicioGetDto>>(servicios);

            return serviciosDto;
        }

        /// <inheritdoc />
        public async Task<ServicioGetDto> GetServicioByIdAsync(int id)
        {
            var servicio = await _unitOfWork.ServicioRepository.GetByIdAsync(id);

            if (servicio == null || servicio.FechaBaja != null)
            {
                return null;
            }

            return _mapper.Map<ServicioGetDto>(servicio);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateServicio(ServicioUpdateDto servicioDto)
        {
            var servicio = await _unitOfWork.ServicioRepository.GetByIdAsync(servicioDto.CodServicio);

            if (servicio == null)
            {
                return false;
            }

            servicio.Descr = servicioDto.Descr;
            servicio.Estado = servicioDto.Estado;
            servicio.ValorHora = servicioDto.ValorHora;
            servicio.FechaUpdate = DateTime.Now;

            _unitOfWork.ServicioRepository.Update(servicio);

            await _unitOfWork.Complete();

            return true;
        }
    }
}
