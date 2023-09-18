using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines common operations for a repository handling entities of type T.
    /// </summary>

    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>An asynchronous operation that returns a collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets an entity of type T by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>All of the entities</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Adds an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>An entity by its ID</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Deletes an entity of type T by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>
        /// *True if it was deleted
        /// *False if it wasnt deleted
        /// </returns>
        bool Delete(int id);

        /// <summary>
        /// Updates an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Update(T entity);
    }
}
