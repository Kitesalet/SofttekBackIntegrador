using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Rol entity
    /// </summary>
    public interface IRolRepository : IRepository<Rol>
    {
        /// <summary>
        /// Gets a role by its id and maps it into its Dto
        /// </summary>
        /// <param name="dto">An int</param>
        /// <returns> 
        ///  A Rol instance if the query is successful
        ///  |
        ///  A null value if the query is not successful
        /// </returns>
        public RolDto GetRolDto(int id);

    }
}
