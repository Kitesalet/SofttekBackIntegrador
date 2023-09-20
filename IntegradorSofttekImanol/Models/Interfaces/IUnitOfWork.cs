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
        UsuarioRepository UserRepository { get; }

        /// <summary>
        /// Gets the repository for Proyecto data.
        /// </summary>
        ProyectoRepository ProjectRepository { get; }

        /// <summary>
        /// Gets the repository for Trabajo data.
        /// </summary>
        TrabajoRepository WorkRepository { get; }

        /// <summary>
        /// Gets the repository for Rol data.
        /// </summary>
        RolRepository RoleRepository { get; }

        /// <summary>
        /// Gets the repository for Servicio data.
        /// </summary>
        ServicioRepository ServiceRepository { get; }

        /// <summary>
        /// Completes and saves the context related to the database.
        /// </summary>
        /// <returns>The number of rows affected by saving the changed of the context.</returns>
        Task<int> Complete();
    }
}
