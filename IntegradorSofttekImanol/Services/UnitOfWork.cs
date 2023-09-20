using AutoMapper;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implemmentation of a unit that manages repositories and databases.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UserRepository UserRepository { get; }
        public ProjectRepository ProjectRepository { get; }
        public WorkRepository WorkRepository { get; }
        public ServiceRepository ServiceRepository { get; }

        /// <summary>
        /// Initializes an instance of UnitOfWork using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        /// <param name="mapper"></param>
        public UnitOfWork(AppDbContext context, IMapper mapper)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            ProjectRepository = new ProjectRepository(context);
            WorkRepository = new WorkRepository(context);
            ServiceRepository = new ServiceRepository(context);
       
    }

        /// <inheritdoc/>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
