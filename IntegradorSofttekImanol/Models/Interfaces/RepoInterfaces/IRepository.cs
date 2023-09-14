using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        public Task AddAsync(T entity);
        public bool Delete(int id);
        public Task<bool> Update(T entity);
    }
}
