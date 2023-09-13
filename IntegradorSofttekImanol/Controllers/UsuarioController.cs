using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            return Ok(await _unitOfWork.UsuarioRepository.GetAll());
        }

    }
}
