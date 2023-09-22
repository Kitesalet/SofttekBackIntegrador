using IntegradorSofttekImanol.Models.DTOs.Trabajo;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using WorkDtos and its logic.
    /// </summary>
    public interface IWorkService
    {
        /// <summary>
        /// Gets a collection of work data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the WorkDto entities.</returns>
        Task<IEnumerable<WorkGetDto>> GetAllWorksAsync(int page, int units);

        /// <summary>
        /// Gets work record data by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the work entities as a WorkDto.</returns>
        Task<WorkGetDto> GetWorkByIdAsync(int id, bool isUpdating = false);

        /// <summary>
        /// Creates a work record.
        /// </summary>
        /// <param name="workDto">An workDto.</param>
        /// <returns>A boolean value based on the creation of the work.
        /// </returns>
        Task<bool> CreateWorkAsync(WorkCreateDto workDto);

        /// <summary>
        /// Updates the work record data that hasnt been soft deleted.
        /// </summary>
        /// <param name="workDto">A workDto.</param>
        /// <returns>A boolean value based on the update of the work.</returns>
        Task<bool> UpdateWork(WorkUpdateDto workDto);

        /// <summary>
        /// Deletes a work record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the work, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteWorkAsync(int id);
    }
}
