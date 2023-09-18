using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using UsuarioDtos and its logic.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Gets a collection of user data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the UsuarioGetDto entities</returns>
        Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync(int page, int units);

        /// <summary>
        /// Gets user data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the user entities as a UsuarioGetDto</returns>
        Task<UsuarioGetDto> GetUsuarioByIdAsync(int id);

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="usuarioDto">An UsuarioCreateDto</param>
        /// <returns>A boolean value based on the creation of the user
        /// </returns>
        Task<bool> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);

        /// <summary>
        /// Updates the user data that hasnt been soft deleted
        /// </summary>
        /// <param name="usuarioDto">A UsuarioUpdateDto</param>
        /// <returns>A boolean value based on the update of the user</returns>
        Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto);

        /// <summary>
        /// Deletes a user based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>A boolean value based on the Deletion of the user, true if it was soft or hard deleted</returns>
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
