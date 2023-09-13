using IntegradorSofttekImanol.DAL.Repositories;

namespace IntegradorSofttekImanol.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public UsuarioRepository UsuarioRepository { get; }
        Task<int> Complete();

    }
}
