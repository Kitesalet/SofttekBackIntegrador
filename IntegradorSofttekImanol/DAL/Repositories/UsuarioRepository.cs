using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Migrations;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the Usuario entity
    /// </summary>
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) : base(context)
        {

            _context = context;
           

        }


        /// <summary>
        /// Evaluates if a user exists and check its credentials
        /// </summary>
        /// <param name="dto">AuthenticateDTO</param>
        /// <returns> 
        /// * Un objeto usuario si la autenticacion es exitosa
        /// * Un valor nulo si la autenticacion falla
        /// </returns>
        public async Task<Usuario?> AuthenticateCredentials(UsuarioAuthenticateDTO dto)
        {
           

            return await _context.Usuarios.Include(e => e.Rol)
                                          .SingleOrDefaultAsync(e => e.Dni.ToString() == dto.Dni && e.Contrasena == EncrypterHelper.Encrypter(dto.contrasena,"d"));

        }

    }
}
