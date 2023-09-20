using AutoMapper;
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
        public UserRepository UsuarioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
        public WorkRepository TrabajoRepository { get; }
        public RoleRepository RolRepository { get; }
        public ServiceRepository ServicioRepository { get; }

        /// <summary>
        /// Initializes an instance of UnitOfWork using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        /// <param name="mapper"></param>
        public UnitOfWork(AppDbContext context, IMapper mapper)
        {
            _context = context;
            UsuarioRepository = new UserRepository(context);
            ProyectoRepository = new ProyectoRepository(context);
            TrabajoRepository = new WorkRepository(context);
            RolRepository = new RoleRepository(context, mapper);
            ServicioRepository = new ServiceRepository(context);
       
    }

        /// <inheritdoc/>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
