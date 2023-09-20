using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

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


    }
}
