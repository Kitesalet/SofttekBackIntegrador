using IntegradorSofttekImanol.DAL;
using IntegradorSofttekImanol.Services.Interfaces;
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

        public async Task<IEnumerable<IActionResult>> GetAllUsuarios()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

    }
}
