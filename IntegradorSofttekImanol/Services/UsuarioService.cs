using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> CreateUsuario(UsuarioCreateDto usuarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUsuarioAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioGetDto> GetUsuarioByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto)
        {
            throw new NotImplementedException();
        }
    }
}
