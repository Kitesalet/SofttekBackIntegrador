using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;


namespace IntegradorSofttekImanol.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public virtual bool Delete(int id)
        {
            var entity = _set.Find(id);

            if (entity == null)
            {
                return false;
            }

            _context.Entry(entity).State = EntityState.Deleted;

            return true;

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
