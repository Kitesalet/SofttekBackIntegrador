using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.DAL.Repositories;
using IntegradorSofttekImanol.Models.Interfaces;

namespace IntegradorSofttekImanol.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public UsuarioRepository UsuarioRepository { get ; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(context);
        }

        public async Task<int> Complete()
        {

            return await _context.SaveChangesAsync();
           
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
