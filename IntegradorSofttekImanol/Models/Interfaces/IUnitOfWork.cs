using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.DAL.Repositories;
using IntegradorSofttekImanol.DAL.Repositories.Interfaces;

namespace IntegradorSofttekImanol.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public UsuarioRepository UsuarioRepository { get; }
        Task<int> Complete();

    }
}
