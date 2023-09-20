using AutoMapper;
using IntegradorSofttekImanol.Helpers;
using IntegradorSofttekImanol.Models.DTOs;
using IntegradorSofttekImanol.Models.DTOs.Usuario;
using IntegradorSofttekImanol.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the service for defining and using UsuarioDtos and its logic.
    /// </summary>
    public class UsuarioService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes an instance of UsuarioService using dependency injection with its parameters
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI</param>
        /// <param name="mapper">IMapper with DI</param>
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateUsuarioAsync(UserCreateDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<User>(usuarioDto);

                usuario.Contrasena = EncrypterHelper.Encrypter(usuario.Contrasena, $"RaNdOmCoDe");

                //Cargar su rol luego
                await _unitOfWork.UsuarioRepository.AddAsync(usuario);

                usuario.FechaAlta = DateTime.Now;

                usuario.Tipo = 1;

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUsuarioAsync(int id)
        {

            var flag = await _unitOfWork.UsuarioRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserGetDto>> GetAllUsuariosAsync(int page, int units)
        {

            var usuarios = await _unitOfWork.UsuarioRepository.GetAllAsync(page, units, e => e.Rol);      
            
            return _mapper.Map<List<UserGetDto>>(usuarios);
                   
        }

        /// <inheritdoc/>
        public async Task<UserGetDto> GetUsuarioByIdAsync(int id)
        {
            
            var usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(id);

            if(usuario == null || usuario.FechaBaja != null)
            {
                return null;
            }

            return _mapper.Map<UserGetDto>(usuario);
            
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateUsuario(UserUpdateDto usuarioDto)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(usuarioDto.CodUsuario);

            if (usuario == null)
            {
                return false;
            }

            usuario.Nombre = usuarioDto.Nombre;
            usuario.Tipo = usuarioDto.Tipo;
            usuario.Contrasena = usuarioDto.Contrasena;
            usuario.FechaUpdate = DateTime.Now;

            _unitOfWork.UsuarioRepository.Update(usuario);

            await _unitOfWork.Complete();

            return true;

        }
    }
}
