using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Role entity.
    /// </summary>
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of RoleRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">A AppDbContext with DI.</param>
        /// <param name="mapper">A IMapper.</param>
        public RoleRepository(AppDbContext context, IMapper mapper) : base(context)
        {

            _context = context;
            _mapper =  mapper;
        }

        /// <inheritdoc />
        public RoleDto GetRoleDto(int id)
        {

            return _mapper.Map<RoleDto>(_context.Roles.FirstOrDefault(e => e.CodRole == id));

        }

    }


}
