using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.DAL.Repositories;
using IntegradorSofttekImanol.Models.Interfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implemmentation of a unit that manages repositories and databases.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UsuarioRepository UsuarioRepository { get; }

        /// <summary>
        /// Initializes an instance of UnitOfWork using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(context);
        }

        /// <inheritdoc/>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
