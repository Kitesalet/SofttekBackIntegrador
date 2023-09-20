using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Service entity
    /// </summary>
    public interface IServiceRepository : IRepository<Service>
    {
        /// <summary>
        /// Gets all the active services.
        /// </summary>
        /// <returns>All the active services.</returns>
        public Task<IEnumerable<Service>> GetActiveServicesAsync();

    }
}
