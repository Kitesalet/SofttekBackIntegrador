using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Project entity.
    /// </summary>
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Gets and filters all projects by state.
        /// </summary>
        /// <param name="state">An int.</param>
        /// <returns>All projects filtered by state.</returns>
        public Task<IEnumerable<Project>> GetProjectByState(int state);

    }
}
