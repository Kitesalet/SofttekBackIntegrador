

using IntegradorSofttekImanol.Models.DTOs.Servicio;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using ServiceDtos and its logic.
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Gets a collection of service data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the ServiceDto entities.</returns>
        Task<IEnumerable<ServiceGetDto>> GetAllServicesAsync(int page, int units);

        /// <summary>
        /// Gets service record data by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the service entities as a ServiceDto.</returns>
        Task<ServiceGetDto> GetServiceByIdAsync(int id);

        /// <summary>
        /// Creates a Service record.
        /// </summary>
        /// <param name="ServiceDto">A ServiceDTO.</param>
        /// <returns>A boolean value based on the creation of the service.
        /// </returns>
        Task<bool> CreateServiceAsync(ServiceCreateDto ServiceDto);

        /// <summary>
        /// Updates the service record data that hasnt been soft deleted.
        /// </summary>
        /// <param name="ServiceDto">A ServiceDto.</param>
        /// <returns>A boolean value based on the update of the Service.</returns>
        Task<bool> UpdateService(ServiceUpdateDto ServiceDto);

        /// <summary>
        /// Deletes a service record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the service, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteServiceAsync(int id);

        /// <summary>
        /// Gets all the active services Dtos.
        /// </summary>
        /// <returns>All the active services dtos.</returns>
        Task<IEnumerable<ServiceGetDto>> GetActiveServices();
    }
}
