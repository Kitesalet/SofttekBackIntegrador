using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Proyecto entity.
    /// </summary>
    public interface IProyectoRepository : IRepository<Proyecto>
    {
        /// <summary>
        /// Gets and filters all proyects by state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns>All proyects filtered by state.</returns>
        public Task<IEnumerable<Proyecto>> GetProyectoByEstado(int state);

    }
}
