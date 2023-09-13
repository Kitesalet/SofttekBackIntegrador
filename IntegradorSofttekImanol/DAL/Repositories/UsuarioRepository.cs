using IntegradorSofttekImanol.DAL.Repositories.Interfaces;
using IntegradorSofttekImanol.Entities;
using IntegradorSofttekImanol.Migrations;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
