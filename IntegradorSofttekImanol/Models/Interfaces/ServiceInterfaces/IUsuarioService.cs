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
        /// Gets a collection of user data.
        /// </summary>
        /// <returns>All of the UsuarioGetDto entities</returns>
        Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync();

        /// <summary>
        /// Gets user data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the Usuario entities as a UsuarioGetDto</returns>
        Task<UsuarioGetDto> GetUsuarioByIdAsync(int id);

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <param name="usuarioDto">An UsuarioCreateDto</param>
        /// <returns>A boolean value based on the creation of the Usuario
        /// </returns>
        Task<bool> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);

        /// <summary>
        /// Updates the user data
        /// </summary>
        /// <param name="usuarioDto">A UsuarioUpdateDto</param>
        /// <returns>A boolean value based on the update of the Usuario</returns>
        Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto);

        /// <summary>
        /// Deletes a user based on its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>A boolean value based on the Deletion of the Usuario</returns>
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
