using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Project entity.
    /// </summary>
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of ProjectRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">AppDbContext with DI.</param>
        public ProjectRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Project>> GetProjectByState(int state)
        {
            var Projects = await _context.Projects.Include(e => e.Works)
                                                    .Where(p => p.State == (ProjectState)state)
                                                    .ToListAsync();

            return Projects;
        }
    }
}
