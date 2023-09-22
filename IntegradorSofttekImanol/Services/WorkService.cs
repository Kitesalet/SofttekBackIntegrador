using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Project;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Service;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{

    /// <summary>
    /// The implementation of the service for defining and using WorkDtos and its logic.
    /// </summary>
    public class WorkService : IWorkService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of WorkService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public WorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateWorkAsync(WorkCreateDto workDto)
        {
            try
            {

                var servicioActivo = await _unitOfWork.ServiceRepository.GetByIdAsync(workDto.CodService);

                //This returns a false value if the service state is false, if it returns a null value, or if its soft deleted
                if(servicioActivo.State == false || servicioActivo == null || servicioActivo.DeletedDate != null)
                {
                    return false;
                }

                var work = _mapper.Map<Work>(workDto);

                await _unitOfWork.WorkRepository.AddAsync(work);

                //Sets the work hour value to be the same as the service hour value at the date the work was created
                work.HourValue = servicioActivo.HourValue;

                work.HourQty = workDto.HourQty;
                work.CodService = workDto.CodService;
                work.CodProject = workDto.CodProject;
                work.Date = workDto.Date;
                work.CreatedDate = DateTime.Now;

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
        public async Task<bool> DeleteWorkAsync(int id)
        {
            var flag = await _unitOfWork.WorkRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WorkGetDto>> GetAllWorksAsync(int page, int units)
        {
            var works = await _unitOfWork.WorkRepository.GetAllAsync(page, units, e => e.Project, e => e.Service);

            var worksDto = _mapper.Map<List<WorkGetDto>>(works);

            return worksDto;
        }

        /// <inheritdoc/>
        public async Task<WorkGetDto> GetWorkByIdAsync(int id, bool isUpdating)
        {
            var work = await _unitOfWork.WorkRepository.GetByIdAsync(id);

            if (work == null || work.DeletedDate != null && isUpdating == false)
            {
                return null;
            }

            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(work.CodService);
            var serviceDto = _mapper.Map<ServiceGetMinDto>(service);
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(work.CodProject);
            var projectDto = _mapper.Map<ProjectGetMinDto>(project);

            var workDto = _mapper.Map<WorkGetDto>(work);

            workDto.Project = projectDto;
            workDto.Service = serviceDto;

            return workDto;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateWork(WorkUpdateDto workDto)
        {
            var work = await _unitOfWork.WorkRepository.GetByIdAsync(workDto.CodWork);

            try
            {
                work.CodProject = workDto.CodProject;
                work.CodService = workDto.CodService;
                work.HourQty = workDto.HourQty;
                work.UpdatedDate = DateTime.Now;
                work.DeletedDate = workDto.DeletedDate;

                _unitOfWork.WorkRepository.Update(work);

                await _unitOfWork.Complete();

                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
