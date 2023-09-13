using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.DAL.Repositories.Interfaces;

namespace IntegradorSofttekImanol.Services.Interfaces
{
    public interface IUnitOfWork
    {
        AppDbContext _context { get; }
        public IUsuarioRepository UsuarioRepository { get; set; }
        Task<int> Complete();

    }
}
