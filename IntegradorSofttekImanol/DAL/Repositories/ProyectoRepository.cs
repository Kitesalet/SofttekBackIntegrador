using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Proyecto entity
    /// </summary>
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of ProyectoRepository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public ProyectoRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }


    }
}
