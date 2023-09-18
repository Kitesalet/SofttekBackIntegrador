using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;


namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines common operations for a repository handling entities of type T.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        /// <summary>
        /// Initializes an instance of Repository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public Repository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        /// <inheritdoc/>
        public virtual async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _set.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            if(entity.FechaBaja == null) 
            {
            
                entity.FechaBaja = DateTime.Now;

            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            } 

            return true;

        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> GetAllAsync(int page, int units)
        {
            IQueryable<T> query = _set;

            return await query
                            .Where(t => t.FechaBaja == null)
                            .Skip((page - 1) * units)
                            .Take(units)
                            .ToListAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        /// <inheritdoc/>
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
