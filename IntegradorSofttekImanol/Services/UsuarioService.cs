using AutoMapper;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
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

        public async Task<bool> CreateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                //Cargar su rol luego
                await _unitOfWork.UsuarioRepository.AddAsync(usuario);

                usuario.FechaAlta = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;

        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {

            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            if(usuario.FechaBaja != null || usuario != null)
            {
                usuario.FechaBaja = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }

            return false;

        }

        public async Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync(bool condition)
        {

            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            if (condition == true)
            {
                return _mapper.Map<List<UsuarioGetDto>>(usuarios);
            }
            
                return _mapper.Map<List<UsuarioGetDto>>(usuarios.Where(e => e.FechaBaja != null));
            
            
            


        }

        public async Task<UsuarioGetDto> GetUsuarioByIdAsync(int id)
        {
            
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            if(usuario.FechaBaja != null)
            {
                return _mapper.Map<UsuarioGetDto>(usuario);
            }

            return null;
            
        }

        public async Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto)
        {

            var usuario = await _unitOfWork.UsuarioRepository.GetById(usuarioDto.CodUsuario);

            if(usuario == null)
            {

                return false;

            }

            usuario.FechaUpdate = DateTime.Now;
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.Complete();

            return true;

        }
    }
}
