namespace IntegradorSofttekImanol.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        public void Update(T entity);
        public void Delete(int id);
        public void Add(T entity);

    }
}
