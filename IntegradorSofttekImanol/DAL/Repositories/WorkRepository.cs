using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Work entity.
    /// </summary>
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of WorkRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">AppDbContext with DI.</param>
        public WorkRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        /// <inheritdoc/>
        public async Task<List<Work>> GetWorksByProject(int idProject)
        {
            var works = await _context.Works.Where(w => w.CodProject == idProject)
                                       .ToListAsync();

            return works;
        }

        /// <inheritdoc/>
        public async Task<List<Work>> GetWorksByService(int idService)
        {
            var works = await _context.Works.Where(w => w.CodService == idService)
                                            .ToListAsync();

            return works;
        }
    }
}
