using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Trabajo;
using IntegradorSofttekImanol.Models.DTOs.Usuario;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using ServicioDtos and its logic.
    /// </summary>
    public interface ITrabajoService
    {
        /// <summary>
        /// Gets a collection of work data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the TrabajoDto entities</returns>
        Task<IEnumerable<TrabajoGetDto>> GetAllTrabajosAsync(int page, int units);

        /// <summary>
        /// Gets work record data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the work entities as a TrabajoDto</returns>
        Task<TrabajoGetDto> GetTrabajoByIdAsync(int id);

        /// <summary>
        /// Creates a work record
        /// </summary>
        /// <param name="trabajoDto">An TrabajoDto</param>
        /// <returns>A boolean value based on the creation of the work
        /// </returns>
        Task<bool> CreateTrabajoAsync(TrabajoCreateDto trabajoDto);

        /// <summary>
        /// Updates the work record data that hasnt been soft deleted
        /// </summary>
        /// <param name="trabajoDto">A TrabajoDto</param>
        /// <returns>A boolean value based on the update of the work</returns>
        Task<bool> UpdateTrabajo(TrabajoUpdateDto trabajoDto);

        /// <summary>
        /// Deletes a work record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>A boolean value based on the Deletion of the work, true if it was soft or hard deleted</returns>
        Task<bool> DeleteTrabajoAsync(int id);
    }
}
