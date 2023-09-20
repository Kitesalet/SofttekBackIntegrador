using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Servicio entity
    /// </summary>
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of ServicioRepository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public ServicioRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Servicio>> GetActiveServiciosAsync()
        {
            return await _context.Servicios.Include(e => e.Trabajos)
                                            .Where(s => s.Estado == true)
                                            .ToListAsync();
        }
    }
}
