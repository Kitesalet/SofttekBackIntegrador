using AutoMapper;
using IntegradorSofttekImanol.Models.Dictionaries;
using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using IntegradorSofttekImanol.Models.DTOs.Servicio;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.projectInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the proyect for defining and using ProjectDtos and its logic.
    /// </summary>
    public class ProjectService : IProjectService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of ProjectService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI</param>
        /// <param name="mapper">IMapper with DI</param>
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<bool> CreateProjectAsync(ProjectCreateDto projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);

                await _unitOfWork.ProjectRepository.AddAsync(project);

                project.State = ProjectState.Pendiente;
                project.CreatedDate = DateTime.Now;

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
        public async Task<bool> DeleteProjectAsync(int id)
        {
            var flag = await _unitOfWork.ProjectRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProjectGetDto>> GetAllProjectsAsync(int page, int units)
        {
            var projects = await _unitOfWork.ProjectRepository.GetAllAsync(page, units, e => e.Works);

            var projectsDto = _mapper.Map<List<ProjectGetDto>>(projects);

            return projectsDto;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProjectGetDto>> GetProjectByStateAsync(int state)
        {
            
            var projects = await _unitOfWork.ProjectRepository.GetProjectByState(state);

            var projectsDto = _mapper.Map<List<ProjectGetDto>>(projects);

            return projectsDto;

        }

        /// <inheritdoc />
        public async Task<ProjectGetDto> GetProjectByIdAsync(int id, bool isUpdating = false)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (project == null || project.DeletedDate != null && isUpdating == false)
            {
                return null;
            }

            project.Works = await _unitOfWork.WorkRepository.GetWorksByProject(id);

            return _mapper.Map<ProjectGetDto>(project);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateProject(ProjectUpdateDto projectDto)
        {

            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(projectDto.CodProject);

            try
            {

                project.Address = projectDto.Address;
                project.State = projectDto.State;
                project.Name = projectDto.Name;
                project.UpdatedDate = DateTime.Now;
                project.DeletedDate = projectDto.DeletedDate;

                _unitOfWork.ProjectRepository.Update(project);

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
