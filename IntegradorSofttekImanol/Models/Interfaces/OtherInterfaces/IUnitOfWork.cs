using IntegradorSofttekImanol.DAL.Repositories;

namespace IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces
{
    /// <summary>
    /// This interface defines a unit that manages repositories and databases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository for User data.
        /// </summary>
        UserRepository UserRepository { get; }

        /// <summary>
        /// Gets the repository for Project data.
        /// </summary>
        ProjectRepository ProjectRepository { get; }

        /// <summary>
        /// Gets the repository for Work data.
        /// </summary>
        WorkRepository WorkRepository { get; }

        /// <summary>
        /// Gets the repository for Service data.
        /// </summary>
        ServiceRepository ServiceRepository { get; }

        /// <summary>
        /// Completes and saves the context related to the database.
        /// </summary>
        /// <returns>The number of rows affected by saving the changed of the context.</returns>
        Task<int> Complete();
    }
}
