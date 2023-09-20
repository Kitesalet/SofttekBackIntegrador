using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Work entity.
    /// </summary>
    public interface IWorkRepository : IRepository<Work>
    {
        /// <summary>
        /// Gets a collection of Work objects filtered by the project
        /// </summary>
        /// <param name="idProject">An int</param>
        /// <returns>A collection of Work objects filtered by the project</returns>
        Task<List<Work>> GetWorksByProject(int idProject);

        /// <summary>
        /// Gets a collection of work objects filtered by the service
        /// </summary>
        /// <param name="idProject">An int</param>
        /// <returns>A collection of work objects filtered by the service</returns>
        Task<List<Work>> GetWorksByService(int idService);

    }
}
