using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Usuario entity.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Evaluates if a user exists and check its credentials.
        /// </summary>
        /// <param name="dto">AuthenticateDTO.</param>
        /// <returns> 
        ///  A Usuario instance if the authentication is successful
        ///  |
        ///  A null value if the authentication is not successful
        /// </returns>
        public Task<User?> AuthenticateCredentials(UserAuthenticateDTO dto);

        /// <summary>
        /// Evaluates the existence of a user.
        /// </summary>
        /// <param name="dto">AuthenticateDTO.</param>
        /// <returns> 
        /// A true value if the query is a success
        /// |
        /// A false value if it fails
        /// </returns>
        Task<bool> UserExists(UserAuthenticateDTO dto);


    }
}