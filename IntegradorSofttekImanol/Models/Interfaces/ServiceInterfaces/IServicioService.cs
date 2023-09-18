using IntegradorSofttekImanol.Models.DTOs;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using ServicioDtos and its logic.
    /// </summary>
    public interface IServicioService
    {
        /// <summary>
        /// Gets a collection of service data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the ServicioDto entities</returns>
        Task<IEnumerable<ServicioDTO>> GetAllServiciosAsync(int page, int units);

        /// <summary>
        /// Gets service record data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the service entities as a TrabajoDto</returns>
        Task<ServicioDTO> GetServicioByIdAsync(int id);

        /// <summary>
        /// Creates a servicio record
        /// </summary>
        /// <param name="servicioDto">A servicioDTO</param>
        /// <returns>A boolean value based on the creation of the service
        /// </returns>
        Task<bool> CreateServicioAsync(ServicioDTO trabajoDto);

        /// <summary>
        /// Updates the service record data that hasnt been soft deleted
        /// </summary>
        /// <param name="servicioDto">A ServicioDto</param>
        /// <returns>A boolean value based on the update of the work</returns>
        Task<bool> UpdateServicio(ServicioDTO trabajoDto);

        /// <summary>
        /// Deletes a service record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>A boolean value based on the Deletion of the service, true if it was soft or hard deleted</returns>
        Task<bool> DeleteServicioAsync(int id);
    }
}
