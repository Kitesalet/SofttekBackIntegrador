using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Migrations;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the User entity.
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI.</param>
        public UserRepository(AppDbContext context) : base(context)
        {

            _context = context;
           
        }

        /// <inheritdoc/>
        public async Task<User?> AuthenticateCredentials(UserAuthenticateDTO dto)
        {

            return await _context.Users
                                      .SingleOrDefaultAsync(e => e.DeletedDate == null 
                                                             && e.CodUser.ToString() == dto.CodUser 
                                                             && e.Password == EncrypterHelper.Encrypter(dto.Password, "RaNdOmCoDe"));;

        }
        
        /// <inheritdoc/>
        public async Task<bool> UserExists(UserAuthenticateDTO dto)
        {


            return await _context.Users.AnyAsync(e => e.CodUser.ToString() == dto.CodUser.ToString());

        }

    }
}
