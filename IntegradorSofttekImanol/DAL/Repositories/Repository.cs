using IntegradorSofttekImanol.DAL.Repositories.Interfaces;
using IntegradorSofttekImanol.Migrations;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    public class Repository<T> : IRepository<T>
    {

        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
