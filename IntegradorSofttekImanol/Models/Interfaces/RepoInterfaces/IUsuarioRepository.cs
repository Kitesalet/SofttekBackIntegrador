using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Usuario entity
    /// </summary>
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// Evaluates if a user exists and check its credentials
        /// </summary>
        /// <param name="dto">AuthenticateDTO</param>
        /// <returns> 
        ///  A Usuario instance if the authentication is successful
        ///  |
        ///  A null value if the authentication is not successful
        /// </returns>
        public Task<Usuario?> AuthenticateCredentials(UsuarioAuthenticateDTO dto);

    }
}