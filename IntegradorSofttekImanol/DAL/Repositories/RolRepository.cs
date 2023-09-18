using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Rol entity
    /// </summary>
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        public RolRepository(AppDbContext context, IMapper mapper) : base(context)
        {

            _context = context;
            _mapper = mapper;
        }

        public RolDto? GetRolDto(int id)
        {

            return _mapper.Map<RolDto>(_context.Roles.FirstOrDefault(e => e.CodRol == id));

        }
    }


}
