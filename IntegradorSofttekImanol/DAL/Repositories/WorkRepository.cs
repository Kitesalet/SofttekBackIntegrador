using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Trabajo entity
    /// </summary>
    public class TrabajoRepository : Repository<Work>, IWorkRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of TrabajoRepository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public TrabajoRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }


    }
}
