using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Proyecto entity
    /// </summary>
    public class RolRepository : Repository<Proyecto>, IRolRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of RolRepository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public RolRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

    }
