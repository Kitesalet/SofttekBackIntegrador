using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the service for defining and using ServiceDtos and its logic.
    /// </summary>
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of ServiceService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<bool> CreateServiceAsync(ServiceCreateDto serviceDto)
        {
            try
            {
                var service = _mapper.Map<Service>(serviceDto);

                await _unitOfWork.ServiceRepository.AddAsync(service);

                service.DeletedDate = DateTime.Now;

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
        public async Task<bool> DeleteServiceAsync(int id)
        {
            var flag = await _unitOfWork.ServiceRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ServiceGetDto>> GetActiveServices()
        {

            var services = await _unitOfWork.ServiceRepository.GetActiveServicesAsync();



            var servicesDto = _mapper.Map<List<ServiceGetDto>>(services);

            return servicesDto;

        }

        /// <inheritdoc />
        public async Task<IEnumerable<ServiceGetDto>> GetAllServicesAsync(int page, int units)
        {
            var services = await _unitOfWork.ServiceRepository.GetAllAsync(page, units, e => e.Works);

            var servicesDto = _mapper.Map<List<ServiceGetDto>>(services);

            return servicesDto;
        }

        /// <inheritdoc />
        public async Task<ServiceGetDto> GetServiceByIdAsync(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (service == null || service.DeletedDate != null)
            {
                return null;
            }

            var works = await _unitOfWork.WorkRepository.GetWorksByService(id);

            service.Works = works;

            return _mapper.Map<ServiceGetDto>(service);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateService(ServiceUpdateDto serviceDto)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(serviceDto.CodService);

            if (service == null)
            {
                return false;
            }

            service.Descr = serviceDto.Descr;
            service.State = serviceDto.State;
            service.HourValue = serviceDto.HourValue;
            service.UpdatedDate = DateTime.Now;

            _unitOfWork.ServiceRepository.Update(service);

            await _unitOfWork.Complete();

            return true;
        }
    }
}
