using IntegradorSofttekImanol.DAL.Repositories.Interfaces;
using IntegradorSofttekImanol.Services.Interfaces;

namespace IntegradorSofttekImanol.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUsuarioRepository UsuarioRepository => throw new NotImplementedException();

        public UnitOfWork(IUnitOfWork unitOfWork)
        {
            
        }

        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }
    }
}
