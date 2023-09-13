using IntegradorSofttekImanol.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public AppDbContext _context { get; set; }
        public UsuarioController(AppDbContext context)
        {
            _context = context; 
        }

    }
}
