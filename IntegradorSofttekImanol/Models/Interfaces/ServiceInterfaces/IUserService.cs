

using IntegradorSofttekImanol.Models.DTOs.Usuario;

namespace IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces
{
    /// <summary>
    /// This interface defines the service for defining and using UserDtos and its logic.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a collection of user data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the UserGetDto entities.</returns>
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync(int page, int units);

        /// <summary>
        /// Gets user data by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the user entities as a UserGetDto.</returns>
        Task<UserGetDto> GetUserByIdAsync(int id, bool isUpdating = false);

        /// <summary>
        /// Creates an user.
        /// </summary>
        /// <param name="userDto">An userCreateDto.</param>
        /// <returns>A boolean value based on the creation of the user.
        /// </returns>
        Task<bool> CreateUserAsync(UserCreateDto userDto);

        /// <summary>
        /// Updates the user data that hasnt been soft deleted.
        /// </summary>
        /// <param name="userDto">A userUpdateDto.</param>
        /// <returns>A boolean value based on the update of the user.</returns>
        Task<bool> UpdateUser(UserUpdateDto userDto);

        /// <summary>
        /// Deletes a user based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the user, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteUserAsync(int id);
    }
}
