using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using System.Linq.Expressions;

namespace IntegradorSofttekImanol.Models.Interfaces.projectInterfaces
{
    /// <summary>
    /// This interface defines the project for defining and using ProyectoDtos and its logic.
    /// </summary>
    public interface IProyectoService
    {
        /// <summary>
        /// Gets a collection of project data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the ProyectoDTO entities</returns>
        Task<IEnumerable<ProyectoGetDto>> GetAllProyectosAsync(int page, int units);

        /// <summary>
        /// Gets project record data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the project entities as a proyectoDTO</returns>
        Task<ProyectoGetDto> GetProyectoByIdAsync(int id);

        /// <summary>
        /// Creates a servicio record
        /// </summary>
        /// <param name="proyectoDto">A ProyectoCreateDto</param>
        /// <returns>A boolean value based on the creation of the project
        /// </returns>
        Task<bool> CreateProyectoAsync(ProyectoCreateDto proyectoDto);

        /// <summary>
        /// Updates the project record data that hasnt been soft deleted
        /// </summary>
        /// <param name="proyectoDto">A ProyectoUpdateDto</param>
        /// <returns>A boolean value based on the update of the project</returns>
        Task<bool> UpdateProyecto(ProyectoUpdateDto proyectoDto);

        /// <summary>
        /// Deletes a project record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>A boolean value based on the Deletion of the project, true if it was soft or hard deleted</returns>
        Task<bool> DeleteProyectoAsync(int id);
    }
}
