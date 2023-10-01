using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Service entity.
    /// </summary>
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of ServiceRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI</param>
        public ServiceRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Service>> GetActiveServicesAsync()
        {
            return await _context.Services.Include(e => e.Works)
                                            .Where(s => s.State == true && s.DeletedDate != null)
                                            .ToListAsync();
        }
    }
}
