using IntegradorSofttekImanol.DAL.Repositories.Interfaces;

namespace IntegradorSofttekImanol.Services.Interfaces
{
    public interface IUnitOfWork
    {

        public IUsuarioRepository UsuarioRepository { get; }
        Task<int> Complete();

    }
}
