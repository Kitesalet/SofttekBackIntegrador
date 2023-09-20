using IntegradorSofttekImanol.DAL.Repositories;

namespace IntegradorSofttekImanol.Models.Interfaces
{
    /// <summary>
    /// This interface defines a unit that manages repositories and databases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository for Usuario data.
        /// </summary>
        UserRepository UserRepository { get; }

        /// <summary>
        /// Gets the repository for Proyecto data.
        /// </summary>
        ProjectRepository ProjectRepository { get; }

        /// <summary>
        /// Gets the repository for Trabajo data.
        /// </summary>
        WorkRepository WorkRepository { get; }

        /// <summary>
        /// Gets the repository for Rol data.
        /// </summary>
        RoleRepository RoleRepository { get; }

        /// <summary>
        /// Gets the repository for Servicio data.
        /// </summary>
        ServiceRepository ServiceRepository { get; }

        /// <summary>
        /// Completes and saves the context related to the database.
        /// </summary>
        /// <returns>The number of rows affected by saving the changed of the context.</returns>
        Task<int> Complete();
    }
}
