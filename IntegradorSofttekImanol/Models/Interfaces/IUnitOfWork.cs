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
        UsuarioRepository UsuarioRepository { get; }

        /// <summary>
        /// Completes and saves the context related to the database.
        /// </summary>
        /// <returns>The number of rows affected by saving the changed of the context</returns>
        Task<int> Complete();
    }
}
