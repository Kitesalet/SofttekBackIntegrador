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

            var flag = _unitOfWork.UsuarioRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

            /*
            if(usuario.FechaBaja != null || usuario != null)
            {
                usuario.FechaBaja = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            */

        }

        public async Task<IEnumerable<UsuarioGetDto>> GetAllUsuariosAsync()
        {

            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();      
            
            return _mapper.Map<List<UsuarioGetDto>>(usuarios.Where(e => e.FechaBaja == null));
                   
        }

        public async Task<UsuarioGetDto> GetUsuarioByIdAsync(int id)
        {
            
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            if(usuario == null)
            {
                return null;
            }

            return _mapper.Map<UsuarioGetDto>(usuario);
            
        }

        public async Task<bool> UpdateUsuario(UsuarioUpdateDto usuarioDto)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(usuarioDto.CodUsuario);

            if (usuario == null)
            {
                return false;
            }

            usuario.Nombre = usuarioDto.Nombre;
            usuario.Tipo = usuarioDto.Tipo;
            usuario.Contrasena = usuarioDto.Contrasena;

            _unitOfWork.UsuarioRepository.Update(usuario);

            await _unitOfWork.Complete();

            return true;

        }
    }
}
